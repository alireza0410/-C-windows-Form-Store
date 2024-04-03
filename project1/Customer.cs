using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using static System.Windows.Forms.AxHost;
using System.Net.Configuration;

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
                        item.name =name;
                        item.PhoneNumber = PhoneNumber;

                }
                return "ویرایش با موفقیت انجام شد ";

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
       
    }
}