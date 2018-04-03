using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;

namespace DataSpider.Stock
{
    public class DbHelper
    {
        public const string DbPath = @"Data/GripStock.sqlite";
        SQLiteConnection conn = new SQLiteConnection();
        public  DbHelper()
        {
            if (!File.Exists(DbPath))
            {
                SQLiteConnection.CreateFile(DbPath);
                conn = new SQLiteConnection("Data Source=" + DbPath);
                conn.Open();
                CreateTable(SqlAssemble.sqlCreateTable_StockInfo);
                CreateTable(SqlAssemble.sqlCreateTable_StockHisTradeData);
            }
            else
            {
                conn=new SQLiteConnection("Data Source=" + DbPath);
                conn.Open();
            }
            
        }

        private void CreateTable(string sql)
        {
            SQLiteCommand comm=new SQLiteCommand(sql,conn);
            comm.ExecuteNonQuery();
        }

        public void ExecInsertSql(string sql)
        {
            SQLiteCommand comm=new SQLiteCommand(sql,conn);
            comm.ExecuteNonQuery();
        }

        public void CloseConn()
        {
            conn.Close();
        }
    }
}
