using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn6
{
    public partial class Form1 : Form
    {
        ServiceReference2.WebService1SoapClient web = new ServiceReference2.WebService1SoapClient();

        private string current = "";
        public Form1(string current)
        {
            this.current = current;
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox2.Focus();
            textBox1.Text = current;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string userName = textBox1.Text;
            string password = textBox2.Text;
            MessageBox.Show(userName);
            try
            {
                int rs = web.Login(userName, password);
                string maNV = web.GetMaNV(userName, password);
                if (rs == 0)
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu không đúng!!!");
                    textBox1.Text = "";
                    textBox2.Text = "";
                }
                else if (rs == 1)
                {
                    QuanLy quanLy = new QuanLy();
                    quanLy.Show();
                    this.Visible = false;
                }
                else if (rs == 2)
                {
                    Nhanven nhanven = new Nhanven(maNV);
                    nhanven.Show();
                    this.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Thoát ứng dụng", "Thông báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
