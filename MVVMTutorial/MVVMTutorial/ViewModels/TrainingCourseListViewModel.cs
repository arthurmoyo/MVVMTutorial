using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;
using MVVMTutorial.Models;
using MVVMTutorial.Services;
using MVVMTutorial.Views;
using Xamarin.Forms;

namespace MVVMTutorial.ViewModels
{
    public class TrainingCourseListViewModel : INotifyPropertyChanged
    {
        public IDataStore<TrainingCourse> DataStore => DependencyService.Get<IDataStore<TrainingCourse>>();

        private TrainingCourse _selectedItem;
        private bool _isBusy;

        public ObservableCollection<TrainingCourse> TrainingCourses { get; }
        public string Title { get; private set; }
        public Command LoadItemsCommand { get; }
        public Command AddNewTrainingCourseCommand { get; }
        public Command<TrainingCourse> TrainingCourseTapped { get; }

        public bool IsBusy
        {
            get => _isBusy; 
            set
            {
                _isBusy = value;
                OnPropertyChanged(nameof(IsBusy));
            }
        }

        public TrainingCourseListViewModel()
        {
            Title = "Training Courses";
            TrainingCourses = new ObservableCollection<TrainingCourse>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            AddNewTrainingCourseCommand = new Command(async () => await AddNewTrainingCourse());
            TrainingCourseTapped = new Command<TrainingCourse>(OnTrainingCourseSelected);
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                TrainingCourses.Clear();
                var courses = await DataStore.GetAllAsync(true);
                foreach (var course in courses)
                {
                    TrainingCourses.Add(course);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }

        public TrainingCourse SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                //OnItemSelected(value);
                OnPropertyChanged(nameof(SelectedItem));
            }
        }

        async void OnTrainingCourseSelected(TrainingCourse trainingCourse)
        {
            if (trainingCourse == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(TrainingCoursePage)}?{nameof(TrainingCourseViewModel.TrainingCourseId)}={trainingCourse.Id}");
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private async Task AddNewTrainingCourse()
        {
            await Shell.Current.GoToAsync(nameof(NewTrainingCoursePage));

        }

    }
}
