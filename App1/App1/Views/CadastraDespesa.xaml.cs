using App1.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CadastraDespesa : ContentPage { 

        
        private CadastraDespesaViewModel viewModel;
        public Models.DespesaModel dadosDespesa;


    public CadastraDespesa(Models.DespesaModel despesa = null)    {
        
        dadosDespesa = despesa;


        InitializeComponent();
        viewModel = new CadastraDespesaViewModel(this);
        this.BindingContext = viewModel;

            // mostra dados da agenda corrente
            if (despesa != null)
            {

                viewModel.Descricao = despesa.Descricao;
                viewModel.Valor = despesa.Valor;
                viewModel.Pago = despesa.Pago;
                viewModel.DataVencimento = despesa.DataVencimento;

                viewModel.InformaAlteracao("Descricao");
                viewModel.InformaAlteracao("Valor");
                viewModel.InformaAlteracao("Pago");
                viewModel.InformaAlteracao("DataVencimento");
            }
        }

        public bool DadosOk()
        {
            if (string.IsNullOrEmpty(viewModel.Descricao))
            {
                DisplayAlert("Erro", "Descrição não foi informado", "OK");
                //txtNome.Focus();
                return false;
            }

            var valor = viewModel.Valor;

            if   (valor.Equals(null))
            {
                DisplayAlert("Erro", "Valor não foi selecionado", "OK");
                //txtFone.Focus();
                return false;
            }

            return true;
        }
    }
}