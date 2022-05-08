using MVVMTutorial.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MVVMTutorial.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TrainingCoursePage : ContentPage
    {
        public TrainingCoursePage()
        {
            InitializeComponent();
            BindingContext = new TrainingCourseViewModel();
        }
    }
}