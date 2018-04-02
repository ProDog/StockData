using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSpider.Stock
{
    class Program
    {
        static void Main(string[] args)
        {
            //GetStockInfo.SaveStockInfoToSqlite();
            GetHistoryTradeData.SaveStockHisDate();
        }
    }
}
