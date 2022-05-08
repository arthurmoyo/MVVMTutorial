using System;
using MVVMTutorial.Models;
using MVVMTutorial.Services;
using MVVMTutorial.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MVVMTutorial
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            DependencyService.Register<IDataStore<TrainingCourse>,MockTrainingCourseDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
