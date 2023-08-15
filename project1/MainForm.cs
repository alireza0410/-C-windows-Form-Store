using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace project1
{
    public partial class MainForm : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
       (
       int nLeftRect, // x-coordinate of upper-left corner
       int nTopRect, // y-coordinate of upper-left corner
       int nRightRect, // x-coordinate of lower-right corner
       int nBottomRect, // y-coordinate of lower-right corner
       int nWidthEllipse, // width of ellipse
       int nHeightEllipse // height of ellipse
       );
        public MainForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 15, 15));
        }

        public List<Product> products = new List<Product>();
       public List<Cart> carts =new List<Cart>();
        public List<Customer> customers=new List<Customer>();
        public List<Factor>factors=new List<Factor>();
        public List<Mobile> mobiles = new List<Mobile>();
        public List<Tools>tools=new List<Tools>();
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }
        private void button2_Click(object sender, EventArgs e)
        {
             Uproduct uproduct = new Uproduct();    
            if (panel2.Controls.Count > 0)
            {
                panel2.Controls[0].Dispose();
            }
            panel2.Controls.Add(uproduct);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UCustomer Customer = new UCustomer();
            if (panel2.Controls.Count > 0)
            {
                panel2.Controls[0].Dispose();
            }
            panel2.Controls.Add(Customer);

        }

        private void button3_Click(object sender, EventArgs e)
        {
             UStore store=new UStore();
            if (panel2.Controls.Count > 0)
            {
                panel2.Controls[0].Dispose();
            }
            panel2.Controls.Add(store);
           

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}   
