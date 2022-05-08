using System.ComponentModel;
using MVVMTutorial.ViewModels;
using Xamarin.Forms;

namespace MVVMTutorial.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}