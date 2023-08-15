using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace project1
{
    public partial class UStore : UserControl
    {
        public UStore()
        {
            InitializeComponent();
        }
        DB db=new DB();
        Customer c = new Customer();
        string barcode;
        public List<Mobile> cartmobiles = new List<Mobile>();

        public string Numbering()
        {
          double C = (((MainForm)Application.OpenForms["MainForm"]).factors.Count());
           return (C + 100000).ToString();
        }
        private void UStore_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource =db.customers.ToList();
            comboBox1.ValueMember = "Name";
            comboBox1.DisplayMember = "Name";
            comboBox1.Text = "";
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = ((MainForm)Application.OpenForms["MainForm"]).mobiles;
            dataGridView1.DataSource = ((MainForm)Application.OpenForms["MainForm"]).tools;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            barcode = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["BarCode"].Value.ToString();
            Mobile m = new Mobile();
            m = m.Reads(barcode);
            cartmobiles.Add(m);
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = cartmobiles;
            double Sum = 0;
            foreach (var item in cartmobiles)
            {
                Sum = item.Price + Sum;
            }
            label6.Text = Sum.ToString();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            c = (Customer)comboBox1.SelectedItem;
            label9.Text = c.PhoneNumber;
            if (comboBox1.Text != "")
            {
                groupBox1.Enabled = true;
            }
            
           
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Cart cart = new Cart();
            cart.Date = DateTime.Now;
            cart.SumPrice = Convert.ToDouble(label6.Text);
            cart.customer = c;
            cart.products = cartmobiles;
            Factor f = new Factor();
            f.FacNumber = Numbering();
            cart.factor = f;
            ((MainForm)Application.OpenForms["MainForm"]).carts.Add(cart);
            try
            {
                db.carts.Add(cart);
                db.SaveChanges();
                MessageBox.Show("کالا های مورد نظر در سبد خرید شما ثبت شد");
        }
            catch (Exception)
            {
                MessageBox.Show("مقدار ها رو وارد کنید  ");
            }

}
        
     

        private void button1_Click(object sender, EventArgs e)
        {
            comboBox1.Text = "";
            label2.Text = "0";
            dataGridView2.DataSource = null;
            cartmobiles.Clear();
            groupBox1.Enabled = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Mobile m = new Mobile();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = m.Read(textBox1.Text);

        }

      
    }
}
