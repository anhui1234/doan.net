using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LicenseContext = OfficeOpenXml.LicenseContext;

namespace DoAn6
{
    public partial class QuanLy : Form
    {
        ServiceReference2.WebService1SoapClient hi = new ServiceReference2.WebService1SoapClient();

        static bool hienthi = true;
        static bool andi = false;
        String connection = "Data Source=DESKTOP-DM4TB0K\\HIEUQUANG;Initial Catalog=QuanLyNhanvien24;Integrated Security=True";
        public QuanLy()
        {
            InitializeComponent();
        }

        
        private void QuanLy_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.CHUCVU' table. You can move, or remove it, as needed.
            this.cHUCVUTableAdapter.Fill(this.dataSet1.CHUCVU);
            // TODO: This line of code loads data into the 'dataSet1.PHONGBAN' table. You can move, or remove it, as needed.
            this.pHONGBANTableAdapter1.Fill(this.dataSet1.PHONGBAN);
            // TODO: This line of code loads data into the 'dataSet1.HOPDONG' table. You can move, or remove it, as needed.
            this.hOPDONGTableAdapter.Fill(this.dataSet1.HOPDONG);
            // TODO: This line of code loads data into the 'dsphongban.PHONGBAN' table. You can move, or remove it, as needed.
            //  this.pHONGBANTableAdapter.Fill(this.dsphongban.PHONGBAN);
            fillTinhTrang();
        }
      
        private void button2_Click(object sender, EventArgs e)
        {
            int i = 0;
            ThongTinNhanVien.Visible = hienthi;
            diemdanh.Visible = andi;
            phongban.Visible = andi;
            phucap.Visible = andi;
            DataSet ds = new DataSet();
            ds = hi.getdata();
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            foreach(DataRow rows in dt.Rows)
            {
                listView1.Items.Add(rows["MANV"].ToString());
                listView1.Items[i].SubItems.Add(rows["TENNV"].ToString());
                listView1.Items[i].SubItems.Add(rows["GIOITINH"].ToString());
                listView1.Items[i].SubItems.Add(rows["TRINHDO"].ToString());
                listView1.Items[i].SubItems.Add(rows["NGAYSINH"].ToString());
                listView1.Items[i].SubItems.Add(rows["HONNHAN"].ToString());
                listView1.Items[i].SubItems.Add(rows["SOCMND"].ToString());
                listView1.Items[i].SubItems.Add(rows["QUEQUAN"].ToString());
                listView1.Items[i].SubItems.Add(rows["PHONE"].ToString());
                listView1.Items[i].SubItems.Add(rows["EMAIL"].ToString());
                listView1.Items[i].SubItems.Add(rows["TEN"].ToString());
                listView1.Items[i].SubItems.Add(rows["TEN"].ToString());
                i++;

            }
        }

        

        

        private void btnPhongBan_Click(object sender, EventArgs e)
        {
            ThongTinNhanVien.Visible = andi;
            diemdanh.Visible = andi;
            phongban.Visible = hienthi;
            phucap.Visible = andi;


        }

       
       
       


       

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            DataSet ds = new DataSet();
            ds = hi.getInformationDepartment(comboBox1.Text);
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            foreach(DataRow rows in dt.Rows)
            {
                tenpb.Text = rows["TEN"].ToString();
                truongphong.Text = rows["TENNV"].ToString();
                diachi.Text = rows["DIACHI"].ToString();
                chitieu.Text = rows["CHITIEU"].ToString();
            }
            
            DataSet ds2 = new DataSet();
            ds2 = hi.getInformationEmplayee(comboBox1.Text);
            DataTable dt2 = new DataTable();
            dt2 = ds2.Tables[0];
            int i = 0;
            employeeDeparment.Items.Clear();
            employeeDeparment.Refresh();
            foreach (DataRow rows in dt2.Rows)
            {
                employeeDeparment.Items.Add(rows["MANV"].ToString());
                employeeDeparment.Items[i].SubItems.Add(rows["TENNV"].ToString());
                employeeDeparment.Items[i].SubItems.Add(rows["GIOITINH"].ToString());
                employeeDeparment.Items[i].SubItems.Add(rows["TRINHDO"].ToString());
                employeeDeparment.Items[i].SubItems.Add(rows["NGAYSINH"].ToString());
                employeeDeparment.Items[i].SubItems.Add(rows["HONNHAN"].ToString());
                employeeDeparment.Items[i].SubItems.Add(rows["SOCMND"].ToString());
                employeeDeparment.Items[i].SubItems.Add(rows["QUEQUAN"].ToString());
                employeeDeparment.Items[i].SubItems.Add(rows["PHONE"].ToString());
                employeeDeparment.Items[i].SubItems.Add(rows["EMAIL"].ToString());
                employeeDeparment.Items[i].SubItems.Add(rows["TEN"].ToString());
                employeeDeparment.Items[i].SubItems.Add(rows["TEN"].ToString());
                i++;
            }
          
        }
        public void delete()
        {

            if (employeeDeparment.Items.Count >= 0)
            {
                for (int i = 0; i < employeeDeparment.Items.Count; i++)
                {

                    employeeDeparment.Items[i].Remove();
                    i--;

                }
            }
    }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)

        {
            
            string gioitinh = "";
            if (nam.Checked = true)
            {
                gioitinh = "NAM";
            }
            else
            {
                gioitinh = "NU";
            }
              //  if (hi.insert(manv.Text,tennv.Text,gioitinh,trinhdo.Text,))
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ThongTinNhanVien.Visible = andi;
            diemdanh.Visible = hienthi;
            phongban.Visible = andi;
            phucap.Visible = andi;
        }

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView1.SelectedItems)
            {
                manv.Text = item.SubItems[0].Text;
                tennv.Text = item.SubItems[1].Text;

                if (item.SubItems[2].Text.Equals("NAM"))
                {
                    nam.Checked = true;
                }
                else
                {
                    nu.Checked = true;
                }
                trinhdo.Text = item.SubItems[3].Text;
                // dateTimePicker1.Value = item.SubItems[4].Text;
                honnhan.Text = item.SubItems[5].Text;
                socmnd.Text = item.SubItems[6].Text;
                que.Text = item.SubItems[7].Text;
                sodt.Text = item.SubItems[8].Text;
                email.Text = item.SubItems[9].Text;
                comboBox2.Text = item.SubItems[10].Text;
                comboBox3.Text = item.SubItems[11].Text;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

       

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label56_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label57_Click(object sender, EventArgs e)
        {

        }

        private void label50_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void label56_Click_1(object sender, EventArgs e)
        {

        }


        private void btnDoiMatKhau_Click_1(object sender, EventArgs e)
        {
            pnDmk.Visible = hienthi;
            pnTt.Visible = andi;
            pnTTK.Visible = andi;
        }

        private void btnThongTin_Click_1(object sender, EventArgs e)
        {
            pnDmk.Visible = andi;
            pnTt.Visible = hienthi;
            pnTTK.Visible = andi;
        }

        private void btnTTK_Click_1(object sender, EventArgs e)
        {
            pnDmk.Visible = andi;
            pnTt.Visible = andi;
            pnTTK.Visible = hienthi;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn đăng xuất?", "Chú Ý", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                Application.Restart();
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
           
            if (MessageBox.Show("Bạn muốn thoát?", "Chú Ý", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                Application.Exit();
        }
        // them tinh trang vao combobox
        public void fillTinhTrang()
        {
            using (SqlConnection sqlcon = new SqlConnection(connection))
            {

               
                sqlcon.Open();
                SqlDataAdapter sqlda = new SqlDataAdapter("select * from TINHTRANG;", sqlcon);
                DataTable dtbl = new DataTable();
                sqlda.Fill(dtbl);
                TinhTrang.ValueMember = "TINHTRANG";
                TinhTrang.DisplayMember = "TinhTrang";
                TinhTrang.DataSource = dtbl;
            }

        }

        private void ThongTinNhanVien_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void button21_Click(object sender, EventArgs e)
        {
            if (hi.DeleteTest())
            {
                MessageBox.Show("Delete thanh cong");
            }
            else
            {
                MessageBox.Show("Delete khong thanh cong");
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new System.Windows.Forms.OpenFileDialog();
            openFile.Title = "Chọn file exel nhân viên cần import";
            openFile.Filter = "Exel file (*.xls)(*.xlsx)(*.xlsm)|*.xls;*.xlsx;*.xlsm";
            openFile.InitialDirectory = @"C:\";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                string path = openFile.FileName;
                var package = new ExcelPackage(new FileInfo(path));

                ExcelWorksheet workSheet = package.Workbook.Worksheets.First();
                StringBuilder sbSQL = new StringBuilder();
                sbSQL.Append("set dateformat dmy;");
                sbSQL.Append("Insert into nhanvien values");
                for (int i = workSheet.Dimension.Start.Row + 1; i <= workSheet.Dimension.End.Row; i++)
                {
                    sbSQL.Append("(");
                    for (int j = workSheet.Dimension.Start.Column; j <= workSheet.Dimension.End.Column; j++)
                    {
                        try
                        {
                            string value;
                            if (j == workSheet.Dimension.End.Column)
                            {
                                value = "'" + workSheet.Cells[i, j].Value.ToString() + "'";
                            }
                            else
                            {
                                value = "'" + workSheet.Cells[i, j].Value.ToString() + "', ";
                            }
                            sbSQL.Append(value);
                        }
                        catch (Exception exe)
                        {

                        }
                    }
                    if (i == workSheet.Dimension.End.Row)
                    {
                        sbSQL.Append(")");

                    }
                    else
                    {
                        sbSQL.Append("), ");
                    }
                }
                string sql = sbSQL.ToString();
               // txtSQL.Text = sql;
                DialogResult rs = MessageBox.Show(sql, "Import?!", MessageBoxButtons.OKCancel);
                if (rs == DialogResult.OK)
                {
                    if (hi.ImportEmployees(sql))
                    {
                        MessageBox.Show("Import thanh cong");
                    }
                    else
                    {
                        MessageBox.Show("Import khong thanh cong");
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ThongTinNhanVien.Visible = andi;
            diemdanh.Visible = andi;
            phongban.Visible = andi;
            phucap.Visible = hienthi;
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }
    }
   
}
