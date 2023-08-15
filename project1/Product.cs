using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace project1
{
    public class Product
    {

        public string Barcode { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
        public List<Product> Products = new List<Product>();
        public bool Check(Product p)
        {
            foreach (var item in Products)
            {
                if (item.Barcode == p.Barcode)
                {
                    return false;
                }
            }
            return true;
        }
        public void Create(Product p)
        {
            if (p.Barcode.Length >= 10)
            {
                if (Check(p))
                {
                    Products.Add(p);
                }
            }
        }
    }
}
