using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capgemini.WebApi.ViewModels
{
    public class TransaccionClientViewModel
    {
        public string ProductNumber { get; set; }
        public DateTime TranDate { get; set; }
        public decimal Ammount { get; set; }
        public string Status { get; set; }


    }
}