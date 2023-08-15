using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project1
{
    public class Mobile : Product
    {
        public int id { get; set; }
        public string Brand { get; set; }
        public int RAM { get; set; }
        public string Cpu { get; set; }
        public string Size { get; set; }
        public enum cpulist
        {
            Sanppdragon,
            Exynos,
            Apple
        }
        DB db=new DB();

        public string Create(Mobile m)
        {
            if (m.Barcode.Length >= 10)
            {
                if (Read(m))
                {
                    ((MainForm)Application.OpenForms["MainForm"]).mobiles.Add(m);
                    return "ثبت با موفقیت انجام شد";
                }
                return "کالا تکراری میباشد ";
            }
            else
            {
                return "قالب بارکد معتبر نیست ";
            }

        }
        bool Read(Mobile m)
        {
            foreach (var item in db.mobiles.ToList())
            {
                if (m.Barcode == item.Barcode)
                {
                    return false;
                }
            }
            return true;
        }
        public List<Mobile> Read()
        {
            return db.mobiles.ToList();
          
        }
        public List<Product> Read(string barcode)
        {
            List<Product> ReadResult = new List<Product>();
            foreach (var item in db.mobiles.ToList())
            {
                if (item.Barcode.Contains(barcode))
                {
                    ReadResult.Add(item);
                }
            }
            return ReadResult;
        }
        public Mobile Reads(string barcode)
        {
            foreach (var item in db.mobiles)
            {
                if (item.Barcode == barcode)
                {
                    return item;
                }
            }
            return null;
        }
        public string Update(string barcode, Mobile m)
        {
            foreach (var item in db.mobiles)
            {
                if (item.Barcode == barcode)
                {
                    item.Name = m.Name;
                    item.Price = m.Price;
                    item.Number = m.Number;
                    item.Category = m.Category;
                    item.Brand = m.Brand;
                    item.RAM = m.RAM;
                    item.Size = m.Size;
                    item.Cpu = m.Cpu;
                    return "ویرایش با موفقیت انجام شد ";
                }

            }
            return "کالایی در لیست ثبت نشده است";
        }
        public string Delete(string barcode)
        {
            foreach (var item in ((MainForm)Application.OpenForms["MainForm"]).mobiles)
            {
                if (item.Barcode == barcode)
                {
                    ((MainForm)Application.OpenForms["MainForm"]).mobiles.Remove(item);
                    return "کالای مورد نظر حذف شد";
                }
            }
            return "کالای مورد نظر یافت نشد";

        }



    }



}
