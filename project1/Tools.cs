using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project1
{
    public class Tools:Product
    {
        public int id { get; set; }
        public string Tcategory { get; set; }
        DB db=new DB();
        public string Create(Tools m)
        {
            if (m.Barcode.Length >= 10)
            {
                if (Read(m))
                {
                   db.tools.Add(m);
                    return "ثبت با موفقیت انجام شد";
                }
                return "کاال تکراری میباشد ";
            }
            else
            {
                ; return "قالب بارکد معتبر نیست ";
            }
        }
        bool Read(Tools m)
        {
            foreach (var item in db.tools.ToList())
            {
                if (m.Barcode == item.Barcode)
                {
                    return false;
                }

            }
            return true;
        }
        public List<Tools> Read()

        {
            return db.tools.ToList();
        }
        public List<Product> Read(string barcode)
        {
            List<Product> ReadResult = new List<Product>();
            foreach (var item in db.tools.ToList())
            {
                if (item.Barcode.Contains(barcode))
                {
                    ReadResult.Add(item);
                }
            }
            return ReadResult;
           
        }
        public Tools Reads(string barcode)
        {
            foreach (var item in db.tools)
            {
                if (item.Barcode == barcode)
                {
                    return item;
                }
            }
            return null;
        }
        public string Update(string barcode, Tools m)
        {
           
            foreach (var item in db.tools)
            {
                if (item.Barcode == barcode)
                {
                    item.Name = m.Name;
                    item.Price = m.Price;
                    item.Number = m.Number;
                    item.Category = m.Category;
                    item.Tcategory=m.Tcategory;
                  
                    return "ویرایش با موفقیت انجام شد ";
                }

            }
            return "کالایی در لیست ثبت نشده است";
        }
        public string Delete(string barcode)
        {
            foreach (var item in ((MainForm)Application.OpenForms["MainForm"]).tools)
            {
                if (item.Barcode == barcode)
                {
                    ((MainForm)Application.OpenForms["MainForm"]).tools.Remove(item);
                    return "کالای مورد نظر حذف شد";
                }
            }
            return "کالای مورد نظر یافت نشد";
        }

    }
    public enum TCategory
    {
        Internal,
        External
    }
}

