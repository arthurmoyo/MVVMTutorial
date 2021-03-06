using MVVMTutorial.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MVVMTutorial.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TrainingCourseListPage : ContentPage
    {
        TrainingCourseListViewModel _viewModel;

        public TrainingCourseListPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new TrainingCourseListViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}