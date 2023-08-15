using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace project1
{
    public partial class Uproduct : UserControl
    {

        public Uproduct()
        {
            InitializeComponent();
        }
        string Barcode;
        DB db=new DB();
        Mobile m = new Mobile();
        Tools t = new Tools();
        void ClearForm()
        {
            foreach (var item in groupBox1.Controls)
            {
                if (item is TextBox)
                {
                    (item as TextBox).Text = "";
                }
                else if (item is ComboBox)
                {
                    (item as ComboBox).SelectedItem = null;
                }
            }
            foreach (var item in groupBox2.Controls)
            {
                if (item is TextBox)
                {
                    (item as TextBox).Text = "";
                }
                else if (item is ComboBox)
                {
                    (item as ComboBox).SelectedItem = null;
                }
            }

            comboBox4.SelectedItem = null;
            numericUpDown1.Value = 1;
            numericUpDown2.Value = 0;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "تلفن همراه")
            {
                groupBox4.Enabled = false;
                groupBox2.Enabled = true;
            }
            else if (comboBox1.Text == "لوازم جانبی")
            {
                groupBox2.Enabled = false;
                groupBox4.Enabled = true;
            }
            else
            {
                groupBox2.Enabled = false;
                groupBox4.Enabled = false;
            }
        }
      
        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "افزودن کالا")
            {
                if (comboBox1.SelectedItem.ToString() == "تلفن همراه")
                {
                    //Mobile m = new Mobile();
                    m.Name = textBox2.Text;
                    m.Barcode = textBox1.Text;
                    m.Price = Convert.ToDouble(textBox3.Text);
                    m.Number = Convert.ToInt32(numericUpDown2.Value);
                    m.Brand = comboBox3.Text;
                    m.Cpu = comboBox2.Text;
                    m.Size = Convert.ToString(textBox4.Text);
                    m.RAM = Convert.ToInt32(numericUpDown1.Value);
                    m.Category = comboBox1.Text;
                    MessageBox.Show(m.Create(m));
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = m.Read();
                    radioButton2.Checked = true;

                }
             
                else if (comboBox1.Text =="لوازم جانبی")
                {
                    //Tools t = new Tools();
                    t.Name = textBox2.Text;
                    t.Barcode = textBox1.Text;
                    t.Price = Convert.ToDouble(textBox3.Text);
                    t.Number = Convert.ToInt32(numericUpDown2.Value);
                    t.Tcategory = comboBox4.Text;
                    t.Category = comboBox1.Text;
                    MessageBox.Show(t.Create(t));
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = t.Read();
                    radioButton1.Checked = true;

                }
                db.tools.Add(t);
                db.mobiles.Add(m);
                db.SaveChanges();
            }
            else if (button1.Text == "ویرایش کالا")
            {
                if (comboBox1.SelectedItem.ToString() == "تلفن همراه")
                {
                    Mobile m = new Mobile();
                    m.Name = textBox2.Text;
                    m.Barcode = textBox1.Text;
                    m.Price = Convert.ToDouble(textBox3.Text);
                    m.Number = Convert.ToInt32(numericUpDown2.Value);
                    m.Brand = comboBox3.Text;
                    m.Cpu = comboBox2.Text;
                    m.Size = Convert.ToString(textBox4.Text);
                    m.RAM = Convert.ToInt32(numericUpDown1.Value);
                    m.Category = comboBox1.Text;
                    MessageBox.Show(m.Update(Barcode, m));
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = m.Read();
                    radioButton2.Checked = true;

                }
                else if (comboBox1.Text == "لوازم جانبی")
                {
                    Tools t = new Tools();
                    t.Name = textBox2.Text;
                    t.Barcode = textBox1.Text;
                    t.Price = Convert.ToDouble(textBox3.Text);
                    t.Number = Convert.ToInt32(numericUpDown2.Value);
                    t.Tcategory = comboBox4.Text;
                    t.Category = comboBox1.Text;
                    MessageBox.Show(t.Update(Barcode, t));
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = t.Read();
                    radioButton1.Checked = true;
                }
            }
           

            button1.Text = "افزودن کالا";
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                Tools t = new Tools();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = t.Read();
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                Mobile m = new Mobile();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = m.Read();
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                Mobile m = new Mobile();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = m.Read(textBox5.Text);
            }
            else
            {
                Tools t = new Tools();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = t.Read(textBox5.Text);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            contextMenuStrip1.Show(Cursor.Position.X, Cursor.Position.Y);
            Barcode = dataGridView1.Rows[dataGridView1.CurrentRow.Index]
            .Cells["Barcode"].Value.ToString();
        }

        private void ویرایشToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button1.Text = "ویرایش کالا";
            if (radioButton2.Checked)
            {
                Mobile m = new Mobile();
                m = m.Reads(Barcode);
                textBox2.Text = m.Name;
                textBox1.Text = m.Barcode;
                textBox3.Text = m.Price.ToString();
                numericUpDown2.Value = m.Number;
                comboBox3.Text = m.Brand;
                comboBox2.Text = m.Cpu;
                textBox4.Text = m.Size.ToString();
                numericUpDown1.Value = m.RAM;
                groupBox2.Enabled = true;
                groupBox4.Enabled = false;
            }
            else if (radioButton1.Checked)
            {
                Tools t = new Tools();
                t = t.Reads(Barcode);
                textBox2.Text = t.Name;
                textBox1.Text = t.Barcode;
                textBox3.Text = t.Price.ToString();
                numericUpDown2.Value = t.Number;
                comboBox4.Text = t.Tcategory;
                groupBox2.Enabled = false;
                groupBox4.Enabled = true;

            }


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void حذفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                Mobile m = new Mobile();
                MessageBox.Show(m.Delete(Barcode ));
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = m.Read();
            }
            else
            {
                Tools t = new Tools();
                MessageBox.Show(t.Delete(Barcode));
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = t.Read();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }  
}


