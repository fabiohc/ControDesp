using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App1.Models;
using SQLite;



namespace App1.BDLocal
{
    [Table("despesas")]
    public class DespesaTable
    {
        // identificação do registro
        [PrimaryKey, Column("id"), AutoIncrement]
        public int Id { get; set; }

        [MaxLength(80), Column("descricao")]
        public string Descricao { get; set; }

        [MaxLength(8), Column("valor")]
        public decimal Valor { get; set; }

        [MaxLength(1), Column("pago")]
        public bool Pago { get; set; }

        [MaxLength(8), Column("dataPagamento")]
        public DateTime DataPagamento { get; set; }

        //static public List<DespesaTable>() {}



        static public List<DespesaModel> GetDespesas()
        {
            try
            {
                string strQuery = "SELECT * FROM [despesas]";
                List<DespesaTable> listaDespesa = App.BDLocal.DBConnection.Query<DespesaTable>(strQuery);

                if (listaDespesa.Count == 0)
                    return null;

                DespesaModel novo;
                List<DespesaModel> lstModel = new List<DespesaModel>();
                foreach (DespesaTable despesa in listaDespesa)
                {
                    novo = new DespesaModel(despesa.Id, despesa.Descricao, despesa.Valor, despesa.Pago, despesa.DataPagamento);
                    lstModel.Add(novo);
                }

                // ordena a lista em ordem alfabética
                lstModel.Sort();

                return lstModel;
            }
            catch (Exception)
            {
                return null;
            }
        }




        static public List<DespesaModel> PesquisarPorDescricaoDespesa(string descricaoDespesa)
        {

            try
            {
                string strQuery = "SELECT Descricao FROM [despesas]";

                List<DespesaTable> nomeRetornado = App.BDLocal.DBConnection.Query<DespesaTable>(strQuery);

                if (nomeRetornado.Count == 0)
                    return null;

                DespesaModel despesas;
                List<DespesaModel> lstDespesas = new List<DespesaModel>();

                foreach (DespesaTable item in nomeRetornado)
                {

                    despesas = new DespesaModel(item.Id, item.Descricao,item.Valor, item.Pago, item.DataPagamento);
                    lstDespesas.Add(despesas);

                }

                lstDespesas.Sort();

                return lstDespesas;


            }
            catch (Exception)
            {

                throw;
            }


        }

        

        static public bool InsertUpdateDados(int id, string descricao, decimal valor, bool pago, DateTime dataPagamento)
    {
        try
        {
            DespesaTable desp = new DespesaTable();

                desp.Id = id;
                desp.Descricao = descricao;
                desp.Valor = valor;
                desp.Pago = pago;
                desp.DataPagamento = dataPagamento;

                            
            if (id == 0)
                App.BDLocal.DBConnection.Insert(desp);
            else
                App.BDLocal.DBConnection.Update(desp);

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

        

        static public bool RemoveRegistro(int id)
        {
            try
            {
                string strQuery = "DELETE FROM [despesas] where id = " + id.ToString();
                App.BDLocal.DBConnection.Execute(strQuery);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


    }
}
