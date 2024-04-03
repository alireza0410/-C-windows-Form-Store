using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace project1
{
    public partial class UCustomer : UserControl
    {
        public UCustomer()
        {
            InitializeComponent();
        }
       
        string phonnumber;
        
        private void button1_Click(object sender, EventArgs e)
        {
             DB db = new DB();
            Customer c = new Customer();

            c.name = textBox1.Text;
            c.PhoneNumber = textBox2.Text;
            c.Date =DateTime.Now;
            if (button1.Text=="افزودن مشتری") 
            {

                MessageBox.Show(c.Creat(c)); 
            }
          
            else if (button1.Text=="ویرایش مشتری")
            {
                MessageBox.Show(c.Update(phonnumber, c));
 
            }
          
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = c.Read();
            db.customers.Add(c);
            db.SaveChanges();

            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void حذفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Customer c= new Customer();
            MessageBox.Show(c.Delete(phonnumber));
            //dataGridView1.DataSource = null;
            dataGridView1.DataSource = c.Read();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            Customer c = new Customer();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = c.Read(textBox3.Text);

        }

       

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            contextMenuStrip1.Show(Cursor.Position.X, Cursor.Position.Y);
           phonnumber = dataGridView1.Rows[dataGridView1.CurrentRow.Index]
           .Cells["PhoneNumber"].Value.ToString();
        }

      

        private void UCustomer_Load(object sender, EventArgs e)
        {
            Customer c = new Customer();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = c.Read();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void zToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index]
            .Cells["Name"].Value.ToString();
            textBox2.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index]
           .Cells["PhoneNumber"].Value.ToString();
            button1.Text = "ویرایش مشتری";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
