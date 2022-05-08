using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMTutorial.Models;
using MVVMTutorial.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MVVMTutorial.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewTrainingCoursePage : ContentPage
    {
        public TrainingCourse TrainingCourse { get; set; }
        public NewTrainingCoursePage()
        {
            InitializeComponent();
            BindingContext = new NewTrainingCourseViewModel();
        }
    }
}