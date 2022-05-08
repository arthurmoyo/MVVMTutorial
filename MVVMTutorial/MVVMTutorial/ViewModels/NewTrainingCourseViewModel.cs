using System;
using System.ComponentModel;
using MVVMTutorial.Models;
using MVVMTutorial.Services;
using Xamarin.Forms;

namespace MVVMTutorial.ViewModels
{
    public class NewTrainingCourseViewModel : INotifyPropertyChanged
    {
        public NewTrainingCourseViewModel()
        {
            Title = "Create new training course";
            SaveNewTrainingCourseCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveNewTrainingCourseCommand.ChangeCanExecute();
            MinDate = DateTime.Now;
            MaxDate = DateTime.Now.AddDays(30);
        }

        public bool ValidateSave()
        {
            return !string.IsNullOrWhiteSpace(name) && !string.IsNullOrWhiteSpace(presentedBy) && date >= DateTime.Now;
        }
        public IDataStore<TrainingCourse> DataStore => DependencyService.Get<IDataStore<TrainingCourse>>();

        private string name;
        private string presentedBy;
        private DateTime date;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Name
        {
            get => name; set
            {
                name = value; OnPropertyChanged(nameof(Name));
            }
        }

        public string PresentedBy
        {
            get => presentedBy; set
            {
                presentedBy = value;
                OnPropertyChanged(nameof(PresentedBy));
            }
        }

        public DateTime Date
        {
            get => date;
            set
            {
                date = value;
                OnPropertyChanged(nameof(Date));

            }
        }

        public string Title { get; }
        public Command SaveNewTrainingCourseCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
        private async void OnSave()
        {
            TrainingCourse newItem = new TrainingCourse()
            {
                Id = Guid.NewGuid().ToString(),
                Name = Name,
                PresentedBy = PresentedBy,
                Date = Date,
            };

            await DataStore.AddAsync(newItem);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        public DateTime MinDate { get; set; }

        public DateTime MaxDate { get; set; }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
