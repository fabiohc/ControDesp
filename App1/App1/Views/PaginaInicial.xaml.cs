using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App1.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App1.BDLocal;
using App1.Models;
using App1.Models;

using System.Collections.ObjectModel;



namespace App1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaginaInicial : ContentPage
    {
        private PaginaInicialViewModel viewModel;

        public PaginaInicial()
        {
            InitializeComponent();
            viewModel = new PaginaInicialViewModel();
            this.BindingContext = viewModel;

            MostraDados();

            // usuário terminou de editar ou inserir um registro
            MessagingCenter.Subscribe<Application, Models.DespesaModel>(this, "CadastraDespesa",
                                            (sender, arg) =>
                                            {
                                                // atualiza dados no banco de dados local
                                                DespesaTable.InsertUpdateDados(arg.Id, arg.Descricao, arg.Valor, arg.Pago, arg.DataVencimento);

                                                
                                                MostraDados();
                                            });

            MessagingCenter.Subscribe<Application, Models.DespesaModel>(this, "DeleteDados",
                                          (sender, arg) =>
                                          {
                                                // apaga evento no banco de dados local
                                                DespesaTable.RemoveRegistro(arg.Id);

                                                // atualiza lista
                                                MostraDados();
                                          });

        }

        async void Despesa_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            // obtem item selecionado
            DespesaModel item = (DespesaModel)e.Item;
            if (item == null)
                return;

            // abrir view para edição do item selecionado
            var telaInicial = Application.Current.MainPage as Views.MasterDetailPrincipal;
            await telaInicial.PushAsync(new CadastraDespesa(item));
        }

        public void MostraDados()
        {
            List<DespesaModel> lista = DespesaTable.GetDespesas();
            if (lista == null)
                viewModel.Despesas = new ObservableCollection<DespesaModel>();
            else
                viewModel.Despesas = new ObservableCollection<DespesaModel>(lista);

            
            
            viewModel.InformaAlteracao("Despesas");
            viewModel.InformaAlteracao("Descricao");
            viewModel.InformaAlteracao("Valor");
            viewModel.InformaAlteracao("Pago");
            viewModel.InformaAlteracao("DataVencimento");
            
        }
    }
}