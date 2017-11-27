using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App1.Views;
using System.Windows.Input;
using Xamarin.Forms;
using App1.ViewModels;
namespace App1.ViewModels
{
    public class CadastraDespesaViewModel : INotifyPropertyChanged
    {

        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public bool Pago { get; set; }
        public DateTime DataVencimento { get; set; }

        public ICommand OkBotao { protected set; get; }
        public ICommand DeleteCommand { protected set; get; }

        public CadastraDespesa ParentPage { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;


        public void InformaAlteracao(string propriedade)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propriedade));
        }

        public CadastraDespesaViewModel(CadastraDespesa pai)
        {
            ParentPage = pai;

            this.OkBotao = new Command(async () =>
            {
                // verifica se todos os campos foram informados
                if (ParentPage.DadosOk())
                {
                    // atualizar lista de eventos da aplicação, avisando janela pai que dados foram informados
                    Models.DespesaModel novo = new Models.DespesaModel(0, Descricao, Valor, Pago, DataVencimento);
                    if (ParentPage.dadosDespesa != null)
                        novo.Id = ParentPage.dadosDespesa.Id;
                    MessagingCenter.Send<Application, Models.DespesaModel>(App.Current,
                                                                          "CadastraDespesa", novo);

                    // encerrar tela
                    var telaInicial = Application.Current.MainPage as Views.MasterDetailPrincipal;
                    await telaInicial.PopAsync();
                }
            });

            this.DeleteCommand = new Command(async () =>
            {
                if (ParentPage.dadosDespesa == null)
                    await ParentPage.DisplayAlert("Erro", "Dados não podem ser eliminados", "OK");
                else
                {
                    var resposta = await ParentPage.DisplayAlert("Elimina Registro",
                                                "Confirma eliminação do registro?", "Sim", "Não");
                    if (resposta)
                    {
                        MessagingCenter.Send<Application, Models.DespesaModel>(App.Current,
                                                        "DeleteDados", ParentPage.dadosDespesa);

                       
                        var telaInicial = Application.Current.MainPage as Views.MasterDetailPrincipal;
                        await telaInicial.PopAsync();
                    }
                }
            });

        }
    }
}