using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_Lib.Models
{
    public class item
    {
        public int id {  get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public decimal price { get; set; }
    }
}
