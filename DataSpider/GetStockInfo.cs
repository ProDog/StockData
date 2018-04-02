using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace DataSpider.Stock
{
    public static class GetStockInfo
    {
        public const string StockListUrl = @"http://quote.eastmoney.com/stocklist.html";
        

        public static void SaveStockInfoToSqlite()
        {
            DbHelper db = new DbHelper();
            var dic = ReadAllStockInfo();
            foreach (var item in dic)
            {
                string sql =
                    string.Format(
                        "insert into StockInfo (Stock_Code,Stock_Name,Stock_Type,Stock_Exchange,Stock_StartDate,Stock_CreateDate) values ('{0}','{1}','{2}','{3}','{4}','{5}')",item.Key,item.Value.Name,item.Value.Type,item.Value.Exchange,item.Value.StartDate,item.Value.CreateDate);
                db.ExecInsertSql(sql);
            }
            db.CloseConn();
        }

        public static Dictionary<string,StockInfo> ReadAllStockInfo()
        {
            HtmlWeb htmlWeb = new HtmlWeb();
            htmlWeb.OverrideEncoding = Encoding.GetEncoding(936);
            HtmlDocument doc = htmlWeb.Load(StockListUrl);

            Dictionary<string, string> dicExchange = new Dictionary<string, string>()
            {
                {"上海", @"/html[1]/body[1]/div[9]/div[2]/div[1]/ul[1]"},
                {"深圳", @"/html[1]/body[1]/div[9]/div[2]/div[1]/ul[2]"}
            };

            Dictionary<string, StockInfo> dicStock = new Dictionary<string, StockInfo>();
            foreach (var item in dicExchange)
            {
                //获取所有子节点
                var res = doc.DocumentNode.SelectSingleNode(item.Value).SelectNodes(@"li");
                if (res.Count > 0)
                {
                    foreach (var node in res)
                    {
                        //获取名称和代码
                        var name = node.InnerText.Trim();
                        if (string.IsNullOrEmpty(name)) continue;
                        var str = name.Split('(', ')');
                        if (str.Length < 2) continue;

                        StockInfo stock = new StockInfo()
                        {
                            Code = str[1],
                            Name = str[0],
                            Exchange = item.Key,
                            StartDate = new DateTime(2000, 1, 1),
                            CreateDate = DateTime.Now
                        };
                        if (!dicStock.ContainsKey(stock.Code))
                        {
                            dicStock.Add(stock.Code, stock);
                        }
                    }
                }
            }
            return dicStock;
        }

    }
}
