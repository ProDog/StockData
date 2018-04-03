using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Web.Script.Serialization;

namespace DataSpider.Stock
{
    public class GetHistoryTradeData
    {
        public static void SaveStockHisDate()
        {
            DbHelper db = new DbHelper();
            var dic = GetStockInfo.ReadAllStockInfo();
            int index = 1;
            int num = 1;
            DateTime start = new DateTime(2000, 1, 1);
            DateTime end = new DateTime(2018, 3, 10);

            foreach (var item in dic)
            {
                Console.WriteLine("Get {0}/{1} stock info data", index, dic.Count);
                List<StockDataForDay> listStockDate = GetStockHisTradeData(item.Key, start, end);
                if (listStockDate.Count > 0)
                {
                    foreach (var dayData in listStockDate)
                    {
                        try
                        {
                            string id = item.Key + dayData.StartDate;
                            string sql = string.Format(
                                "insert into StockHisTradeData (ID,Code,StartDate,StartPrice,EndPrice,ChangePrice,ChangeRatio,LowPrice,HighPrice,TotalHand,TotalAmount,ChangeHandRate,UpdateDate) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}')", id, item.Key, dayData.StartDate, dayData.StartPrice, dayData.EndPrice, dayData.ChangePrice, dayData.ChangeRatio, dayData.LowPrice, dayData.HighPrice, dayData.TotalHand, dayData.TotalAmount, dayData.ChangeHandRate, dayData.UpdateDate);
                            db.ExecInsertSql(sql);
                            Console.WriteLine("Save {0}:{1} history trade data successfully. {2}", item.Key, dayData.StartDate,num);
                            num++;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Save {0}:{1} history trade data fail.wrong message:{2}", item.Key, dayData.StartDate,ex.ToString());
                            Console.ReadKey();
                        }
                    }
                }
                index++;
            }
            db.CloseConn();
        }

        public static List<StockDataForDay> GetStockHisTradeData(string stockCode, DateTime starTime, DateTime endTime, string type = "cn")
        {
            string url = string.Format(@"http://q.stock.sohu.com/hisHq?code={3}_{0}&start={1}&end={2}", stockCode, starTime.ToString("yyyyMMdd"), endTime.ToString("yyyyMMdd"), type);
            List<StockDataForDay> listStockDate=new List<StockDataForDay>();
            //访问https需加上 ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(CheckValidationResult); 
            WebClient wc = new WebClient();
            wc.Credentials = CredentialCache.DefaultCredentials;
            wc.Encoding = Encoding.UTF8;
            string result = wc.DownloadString(url);
           
            JavaScriptSerializer jss = new JavaScriptSerializer();
            dynamic modelDy = jss.Deserialize<dynamic>(result);
            int status = modelDy[0]["status"];
           
            if (status == 0)
            {
                foreach (var item in modelDy[0]["hq"])
                {
                    StockDataForDay stockData = new StockDataForDay()
                    {
                        Code = modelDy[0]["code"].ToString().Replace("cn_", ""),
                        StartDate = item[0],
                        StartPrice = Convert.ToDouble(item[1]),
                        EndPrice = Convert.ToDouble(item[2]),
                        ChangePrice = Convert.ToDouble(item[3]),
                        ChangeRatio = Convert.ToDouble(item[4].ToString().Replace("%", "")),
                        LowPrice = Convert.ToDouble(item[5]),
                        HighPrice = Convert.ToDouble(item[6]),
                        TotalHand = Convert.ToInt32(item[7]),
                        TotalAmount = Convert.ToDouble(item[8]),
                        ChangeHandRate = Convert.ToDouble(item[9].ToString().Replace("%", "")),
                        UpdateDate = DateTime.Now.ToString("yyyy-MM-dd")
                    };
                    listStockDate.Add(stockData);
                }
            }
            return listStockDate;
        }
    }
}
