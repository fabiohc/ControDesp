using App1.BDLocal;
using App1.Views;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace App1
{
    public partial class App : Application
    {
        private static BancoLocal localDatabase;
        public static BancoLocal BDLocal
        {
            get { return localDatabase; }

        }



        public App()
        {
            InitializeComponent();

            localDatabase = new BancoLocal();

            Application.Current.MainPage = new Views.MasterDetailPrincipal();
                
        }
       






        /*

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }*/
    }
}
