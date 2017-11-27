using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App1.Interfaces;

namespace App1.BDLocal
{
    public class BancoLocal
    {
        private SQLiteConnection dbConnection;
        public SQLiteConnection DBConnection
        {
            get { return dbConnection; }
        }

        public BancoLocal()
        {
            // conecta ao banco de dados local (ou cria, caso ele ainda não exista)

            try
            {
                dbConnection = DependencyService.Get<ISQLiteConnection>().DBConnection();
            }
            catch (Exception e)
            {

                throw;
            }
          

            // cria ou altera as tabelas, se for necessário
            dbConnection.CreateTable<DespesaTable>();
        }
    }
}
