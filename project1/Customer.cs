using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using static System.Windows.Forms.AxHost;

namespace project1
{
    public class Customer
    {
        public int id { set; get; }
        public string name { set; get; }
        public string PhoneNumber { set; get; }
        public DateTime Date { set; get; }
        public List<Cart> carts { set; get; }
        DB db=new DB();
        public string Creat(Customer c)
        {

            if (Read(c))
            {
                ((MainForm)Application.OpenForms["MainForm"]).customers.Add(c);
                return "اطلاعات مشتری جدید ثبت شد";
            }
            else
            {
                return "شماره تماس تکراری است";
            }

        }
        public bool Read(Customer c)
        {
            foreach (var item in ((MainForm)Application.OpenForms["MainForm"]).customers)
            {
                if (item.PhoneNumber == c.PhoneNumber)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            return true;


        }
      
        public List<Customer> Read()
        {
            return ((MainForm)Application.OpenForms["MainForm"]).customers.ToList();
        }
        public List<Customer> Read(string name)
        {
            List<Customer> ReadResult = new List<Customer>();
            foreach (var item in db.customers.ToList())
            {
                if (item.name.Contains(name))
                {
                    ReadResult.Add(item);
                }
            }
            return ReadResult;
        }
        public Customer Reads(string name)
        {
            if (name != String.Empty)
            {
                foreach (var item in ((MainForm)Application.OpenForms["MainForm"]).customers)
                {
                    if (item.name == name)
                    {
                        return item;
                    }
                }
            }
            return null;
        }
        public string Update(string Phonenumber, Customer c)
        {
            foreach (var item in ((MainForm)Application.OpenForms["MainForm"]).customers)
            {
                if (item.PhoneNumber == Phonenumber)
                {
                    item.name = c.name;
                    item.PhoneNumber = c.PhoneNumber;
                    return "ویرایش با موفقیت انجام شد ";
                }
            }
            return "مشتری در لیست ثبت نشد";
        }
        public string Delete(string phonenumber)
        {
            foreach (var item in ((MainForm)Application.OpenForms["MainForm"]).customers)
            {

                if (item.PhoneNumber == phonenumber)
                {
                    ((MainForm)Application.OpenForms["MainForm"]).customers.Remove(item);
                    return "مشتری با موفقیت حذف شد ";
                }

            }
            return "مشتری در لیست ثبت نشده است ";
        }
        //public string Create2(Customer cu)
        //{
        //    db1.Customers.Add(cu);
        //    db1.SaveChanges();
        //    return "اطلاعات مشتری جدید ثبت شد";
        //}

        //public bool Exist(Customer cu)
        //{
        //    return db1.Customers.Any(i => i.id == cu.id);
        //}
        //public long CountTable()
        //{
        //    //تعداد ردیف های جدول 
        //    return db1.Customers.LongCount();

        //}
        //public Customer Read(int id)
        //{
        //    return db1.Customers.Find(id);
        //    //return db1.Store.Where(i => i.id == id).SingleOrDefault();
        //}
        //public List<Customer> Read(string SearchText)
        //{
        //    return db1.Customers.Where(i => i.name.Contains(SearchText) || i.name.Contains(SearchText)).ToList();
        //}
        //public List<Customer> Read()
        //{
        //    return db1.Customers.ToList();
        //}
        //public void Update(int id, Customer cu)
        //{
        //    var Update = db1.Customers.Where(i => i.id == id).SingleOrDefault();
        //    if (Update != null)
        //    {
        //        Update.name = cu.name;
        //        Update.PhoneNumber = cu.PhoneNumber;
        //        db1.SaveChanges();
        //    }

        //}
        //public void Delete(int id)
        //{
        //    var Delete = db1.Customers.Where(i => i.id == id).Select(i => i).FirstOrDefault();
        //    db1.Customers.Remove(Delete);
        //    db1.SaveChanges();
        //}
        //public void DeleteAll()
        //{
        //    foreach (var item in db1.Customers.ToList())
        //    {
        //        var Delete = db1.Customers.Where(i => i.id == item.id).Select(i => i).FirstOrDefault();
        //        db1.Customers.Remove(Delete);
        //    }
        //    db1.SaveChanges();
        //}
    }
}