using System;
namespace ExpensesAPI.Models
{
    public class Outlay
    {
        public int OutlayID { get; set; }
        public int MaterialID { get; set; }
        public int OutlayTypeID { get; set; }
        public int UserID { get; set; }
        public double Price { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
    }
}

