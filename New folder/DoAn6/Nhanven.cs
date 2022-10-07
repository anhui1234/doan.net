using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DoAn6
{
    public partial class Nhanven : Form
    {
        ServiceReference2.WebService1SoapClient hi = new ServiceReference2.WebService1SoapClient();
        DataSet ds;
        private string maNV { get; set; }

        static bool hienthi = true;
        static bool andi = false;
        String connection = "Data Source=DESKTOP-DM4TB0K\\HIEUQUANG;Initial Catalog=QuanLyNhanvien24;Integrated Security=True";
        public Nhanven(string maNV)
        {
            this.maNV = maNV;
            InitializeComponent();
            DataSet ds = hi.GetInformationNhanVien(maNV);
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            foreach (DataRow rows in dt.Rows)
            {
                IDNV.Text = rows["TENNV"].ToString();
                MaNV.Text = rows["MANV"].ToString();
                TenNV.Text = rows["TENNV"].ToString();
                GT.Text = rows["GIOITINH"].ToString();
                TrinhDo.Text = rows["TRINHDO"].ToString();
                NgaySinh.Text = rows["NGAYSINH"].ToString();
                HonNhan.Text = rows["HONNHAN"].ToString();
                SoCMND.Text = rows["SOCMND"].ToString();
                QueQuan.Text = rows["QUEQUAN"].ToString();
                phone.Text = rows["PHONE"].ToString();
                Email.Text = rows["EMAIL"].ToString();
                cv.Text = rows["CHUCVU"].ToString();
                HL.Text = rows["HESOLUONG"].ToString();


            }
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            
            DialogResult dr;
            dr = MessageBox.Show("Bạn có muốn thoát khỏi tài khoản không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Application.Restart();
               
            }
            else
            {

            }
        }

        private void Nhanven_Load(object sender, EventArgs e)
        {
            

        }

           
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            MaNV.Enabled = false;
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            cv.Enabled = false;
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {
            HL.Enabled = false;
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {
            IDNV.Enabled = false;
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            TrinhDo.Enabled = false;
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
