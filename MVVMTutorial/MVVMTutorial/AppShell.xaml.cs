using System;
using System.Collections.Generic;
using MVVMTutorial.ViewModels;
using MVVMTutorial.Views;
using Xamarin.Forms;

namespace MVVMTutorial
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(HslPage), typeof(HslPage));
            Routing.RegisterRoute(nameof(TrainingCourseListPage), typeof(TrainingCourseListPage));
            Routing.RegisterRoute(nameof(NewTrainingCoursePage), typeof(NewTrainingCoursePage));
            Routing.RegisterRoute(nameof(TrainingCoursePage), typeof(TrainingCoursePage));


        }

    }
}
