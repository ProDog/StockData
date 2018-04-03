using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSpider.Stock
{
    public class StockDataForDay
    {
        public string Code;
        public string StartDate { get; set; }
        public double StartPrice { get; set; }
        public double EndPrice { get; set; }
        public double ChangePrice { get; set; }
        public double ChangeRatio { get; set; }
        public double LowPrice { get; set; }
        public double HighPrice { get; set; }
        public int TotalHand { get; set; }
        public double TotalAmount { get; set; }
        public double ChangeHandRate { get; set; }
        public string UpdateDate { get; set; }
    }
}
