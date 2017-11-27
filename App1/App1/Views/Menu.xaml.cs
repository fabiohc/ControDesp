
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App1.ViewModels;

namespace App1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Menu : ContentPage
    {
        public Menu()
        {
            InitializeComponent();
            BindingContext = new MenuViewModel();
        }
    }
}