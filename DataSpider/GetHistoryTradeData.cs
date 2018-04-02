using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Net;
using Newtonsoft.Json;

namespace DataSpider.Stock
{
    public class GetHistoryTradeData
    {
        public static void SaveStockHisDate()
        {
            DbHelper db = new DbHelper();
            var dic = GetStockInfo.ReadAllStockInfo();
            DateTime start = new DateTime(2000, 1, 1);
            DateTime end = new DateTime(2018, 3, 10);
            StockDataForDay stockDayData;
            foreach (var item in dic)
            {
                GetStockHisTradeData(item.Key, start, end, "cn");
                //string id = item.Key + stockDayData.StartDate;
                string sql =
                   string.Format(
                       "insert into StockHisTradeData (ID,Code,StartDate,StartPrice,EndPrice,ChangePrice,ChangeRatio,LowPrice,HighPrice,TotalHand,TotalAmount,ChangeHandRate,UpdateDate) values ('{0}','{1}','{2}','{3}','{4}','{5}')", item.Key, item.Value.Name, item.Value.Type, item.Value.Exchange, item.Value.StartDate, item.Value.CreateDate);
                db.ExecInsertSql(sql);
            }
            db.CloseConn();
        }
        public static string GetStockHisTradeData(string stockCode,DateTime starTime,DateTime endTime,string type="cn")
        {
            string url = string.Format(@"http://q.stock.sohu.com/hisHq?code={3}_{0}&start={1}&end={2}", stockCode,
                starTime.ToString("yyyyMMdd"), endTime.ToString("yyyyMMdd"), type);
            string content = string.Empty;
            //访问https需加上这句话 
            // ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(CheckValidationResult);
            //访问http（不需要加上面那句话） 
            WebClient wc = new WebClient();
            wc.Credentials = CredentialCache.DefaultCredentials;
            wc.Encoding = Encoding.UTF8;
            string result = wc.DownloadString(url);
            
            

            StockDataForDay sd = (StockDataForDay)JsonConvert.DeserializeObject(result);
            

            if (result.Contains("errcode"))
            {
                //可能发生错误 
            }
            //Response.Write(returnText); 
            return result;
        }
    }
}
