using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using MVVMTutorial.Models;
using MVVMTutorial.Services;
using Xamarin.Forms;

namespace MVVMTutorial.ViewModels
{
    [QueryProperty(nameof(TrainingCourseId), nameof(TrainingCourseId))]

    public class TrainingCourseViewModel : INotifyPropertyChanged
    {
        private string trainingCourseId;
        private string name;
        private string presentedBy;
        private DateTime date;

        public IDataStore<TrainingCourse> DataStore => DependencyService.Get<IDataStore<TrainingCourse>>();
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

        public string TrainingCourseId
        {
            get
            {
                return trainingCourseId;
            }
            set
            {
                trainingCourseId = value;
                LoadTrainingCourseById(value);
            }
        }

        public async void LoadTrainingCourseById(string itemId)
        {
            try
            {
                var item = await DataStore.GetByIdAsync(itemId);
                if (item == null)
                {
                    await Shell.Current.GoToAsync("..");
                }
                Name = item.Name;
                PresentedBy = item.PresentedBy;
                Date = item.Date;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Training Course");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
