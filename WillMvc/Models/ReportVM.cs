using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WillMvc.Models
{
    public class ReportVM
    {
        public int Id { get; set; }
        public string 客戶名稱 { get; set; }
        public int NumOfContact { get; set; }
        public int NumOfBankInfo { get; set; }
    }
}