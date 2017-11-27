using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App1.Interfaces;

namespace App1.Views
{
    public class MasterDetailPrincipal : MasterDetailPage
    {

        public NavigationPage navegacao = null;
        
        public MasterDetailPrincipal()
        {
            navegacao = new NavigationPage(new Views.PaginaInicial());
            Detail = navegacao;
            Master = new Views.PaginaInicial();

        }

        public async Task PushAsync(Page pagina)
        {
            IsPresented = false;
            await navegacao.PushAsync(pagina);
        }

        public async Task PopAsync()
        {
            await navegacao.PopAsync();
        }

        protected override bool OnBackButtonPressed()
        {
            // IMPORTANTE: Ao pressionar o botão físico BACK do dispositivo, o aplicativo é encerrado se essa for a única tela na pilha de
            // navegação de tela, mas ocorre um crash. A rotina abaixo corrige esse problema.
            var md = Xamarin.Forms.Application.Current.MainPage as MasterDetailPage;
            if (md != null && !md.IsPresented && (!(md.Detail is NavigationPage) || ((NavigationPage)md.Detail).Navigation.NavigationStack.Count == 1))
            {
                // encerra a aplicação
                var closer = DependencyService.Get<IDeviceSpecific>();
                if (closer != null)
                    closer.CloseApplication();
            }
            else
            {
                base.OnBackButtonPressed();
            }

            return true;
        }

    }
}
