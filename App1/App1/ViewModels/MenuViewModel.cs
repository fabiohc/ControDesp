using App1.Interfaces;
using System.Windows.Input;
using Xamarin.Forms;
using App1.Views;

namespace App1.ViewModels
{
    public class MenuViewModel
    {

        public ICommand MenuTapped { protected set; get; }

        public MenuViewModel()
        {
            this.MenuTapped = new Command<string>(async (id) =>
            {
                switch (id)
                {
                    case "novo":
                        var telaInicial =
                            Application.Current.MainPage as Views.MasterDetailPrincipal;
                        await telaInicial.PushAsync(new CadastraDespesa());
                        break;
                    case "sair":
                        DependencyService.Get<IDeviceSpecific>().CloseApplication();
                        break;
                }
            });
        }
    }
}
