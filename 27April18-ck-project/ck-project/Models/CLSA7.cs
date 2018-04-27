using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ck_project.Models
{
    public class CLSA7
    {
        public string Designer { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.00}")]
        public int Total_Open { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.00}")]
        public int Total_Sold { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.00}")]
        public int Total_Deferred { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.00}")]
        public int Total_Lost_Price { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.00}")]
        public int Total_Lost_Comp { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.00}")]
        public int Total_Lost_Other { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.00}")]
        public int Total_Closed { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.00}")]
        public int Total { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.00}")]
        public decimal Closed_Percentage { get; set; }
    }
}