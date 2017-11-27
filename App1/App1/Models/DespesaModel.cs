using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.Models
{
    public class DespesaModel: IComparable<DespesaModel>
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public bool Pago { get; set; }
        public DateTime DataVencimento { get; set; }

        public DespesaModel(int id, string descricao, decimal valor, bool pago, DateTime dataVencimento)
        {
            Descricao = descricao;
            Valor = valor;
            Pago = pago;
            DataVencimento = dataVencimento.Date;
        }

        public int CompareTo(DespesaModel other)
        {

            return this.Descricao.CompareTo(other.Descricao);
            return this.Valor.CompareTo(other.Valor);
            return this.Pago.CompareTo(other.Pago);
            return this.DataVencimento.CompareTo(other.DataVencimento);
    
        }

    }
}
