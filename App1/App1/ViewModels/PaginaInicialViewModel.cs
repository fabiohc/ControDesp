using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App1.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using App1.Views;

namespace App1.ViewModels
{
    public class PaginaInicialViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public void InformaAlteracao(string propriedade)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propriedade));
        }


        public ObservableCollection<DespesaModel> Despesas { get; set; }

        public ICommand IncluirCommand { protected set; get; }

        public ICommand SearchCommand { protected set; get; }
        
        public PaginaInicialViewModel()
        {
            //this.SearchCommand = new Command(async () =>
            //{

            //    MessagingCenter.Send<Application, Models.DespesaModel>(App.Current,
            //                                     "PesquisePorNome", ParentPage.dadosAgenda);


            //});


            this.IncluirCommand = new Command(async () =>
            {
                // incluir nova entrada na agenda
                var telaInicial = Application.Current.MainPage as Views.MasterDetailPrincipal;
                await telaInicial.PushAsync(new CadastraDespesa());
            });


           
        }

    }
}
