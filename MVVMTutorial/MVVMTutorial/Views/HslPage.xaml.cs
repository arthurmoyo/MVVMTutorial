using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMTutorial.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MVVMTutorial.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HslPage : ContentPage
    {
        public HslPage()
        {
            InitializeComponent();
            BindingContext = new HslViewModel();
            Title = "HSL Colour Picker";
        }
    }
}