using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project1
{
   public class Cart
    {
        public int id { get; set; }
        public DateTime Date { get; set; }
        public double SumPrice { get; set; }

        public Factor factor { get; set; }
        public Customer customer { get; set; }
        public List<Mobile> products { get; set; }
    }
}
