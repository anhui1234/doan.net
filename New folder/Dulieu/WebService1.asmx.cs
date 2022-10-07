using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Data.Common;
namespace Dulieu
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
    public  static   SqlConnection conn = new SqlConnection("Data Source=DESKTOP-DM4TB0K\\HIEUQUANG;Initial Catalog=QuanLyNhanvien24;Integrated Security=True");
        [WebMethod]
        public int  HelloWorld()
        {
            return 7+8 ;
        }
        [WebMethod]
        public DataSet getdata()
        {
            conn.Open();
            string query= "select N.MANV,TENNV,GIOITINH,TRINHDO,NGAYSINH,HONNHAN,SOCMND,QUEQUAN,PHONE,EMAIL,C.TEN,P.TEN from NHANVIEN n JOIN PHONGBAN P ON N.PHONGBAN = P.MAPB JOIN CHUCVU C ON N.CHUCVU = C.MACV; ";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataSet ds = new DataSet();
            conn.Close();
            da.Fill(ds);
            return ds;
        }
        [WebMethod]
        public DataSet getAccount()
        {
            conn.Open();
            string query = "select * from USERS ;";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataSet ds = new DataSet();
            conn.Close();
            da.Fill(ds);
            return ds;
        }
       [WebMethod]
       public DataSet getInformationDepartment(string ten)
        {
            conn.Open();
            string query= "select B.TEN,DIACHI,CHITIEU,DIACHI,N.TENNV from PHONGBAN B JOIN NHANVIEN N ON N.PHONGBAN = B.MAPB WHERE B.TEN = N'"+ten+@"' AND N.CHUCVU = 'TP'; ";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataSet ds = new DataSet();
            conn.Close();
            da.Fill(ds);
            return ds;
        }
        [WebMethod]
        public DataSet getInformationEmplayee(string ten)
        {
            conn.Open();
            string query = "select N.MANV, TENNV, GIOITINH, TRINHDO, NGAYSINH, HONNHAN, SOCMND, QUEQUAN, PHONE, EMAIL, B.TEN, C.TEN from PHONGBAN B JOIN NHANVIEN N ON N.PHONGBAN = B.MAPB JOIN CHUCVU C ON N.CHUCVU = C.MACV WHERE B.TEN = N'"+ten+@"' AND NOT N.CHUCVU = 'TP'; ";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataSet ds = new DataSet();
            conn.Close();
            da.Fill(ds);
            return ds;
        }
        [WebMethod]
        public string getMaphongban(string tenPB)
        {
            string name = "";
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            string query = "select MAPB  from PHONGBAN WHERE TEN=N'" + tenPB + @"';";
            cmd.Connection = conn;
            cmd.CommandText = query;
            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int index = reader.GetOrdinal("MAPB");
                        name = reader.GetString(index);
                    }
                }
            }

                return name ;
        }
        [WebMethod]
        public string getMaChucVu(string tenCV)
        {
            string name = "";
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            string query = "select MACV  from CHUCVU WHERE TEN=N'" + tenCV + @"';";
            cmd.Connection = conn;
            cmd.CommandText = query;
            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int index = reader.GetOrdinal("MACV");
                        name = reader.GetString(index);
                    }
                }
            }

            return name;
        }
        // thêm nhân viên vào cơ sở dữ liệu
        [WebMethod]
        public bool insert(string manv,string tennv, string gioitinh,string trinhdo,DateTime ngaysinh,string honnhn,string socmnn,string que,string phone,string email,string phongban,string cv)
        {
            string mapb = getMaphongban(phongban);
            string macv = getMaChucVu(cv);
            try
            {
                conn.Open();
                string query = "insert into NHANVIEN VALUES (N'" + manv + @"', N'" + tennv + @"', N'" + gioitinh + @"', N'" + trinhdo + @"', N'" + ngaysinh + @"',N'" + honnhn + @"',N'" + socmnn + @"',N'" + que + @"',N'" + phone + @"',N'" + email + @"',N'" + mapb + @"',N'" + macv + @"');";
                SqlCommand com = new SqlCommand(query,conn);
                com.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        // lay danh sach tinh trang 
        [WebMethod]
        public DataTable getTinhTrang()
        {
            
            conn.Open();
            string query = "select * from TINHTRANG;";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataTable dtbl = new DataTable();
            da.Fill(dtbl);

            return dtbl;
        }

        //0 - khong dang nhap thanh cong
        //1 - dang nhap voi vai tro quan ly
        //2 - dang nhap voi vai tro nhan vien
        [WebMethod]
        public int Login(string userName, string password)
        {
            conn.Open();
            string query = "select n.chucvu from USERS u join NHANVIEN n on u.manv=n.manv where u.users = '" + userName + "' and passwords = '" + password + "'";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataSet ds = new DataSet();
            conn.Close();
            da.Fill(ds);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                string chucVu = row["CHUCVU"].ToString();
                if ((String.Compare(chucVu, "TP", true)) == 0)
                {
                    return 1;
                }
                else
                {
                    return 2;
                }
            }
            return 0;
        }

        [WebMethod]
        public string GetMaNV(string userName, string password)
        {
            string rs = null;
            conn.Open();
            string query = "select manv from USERS where users = '" + userName + "' and passwords = '" + password + "'";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataSet ds = new DataSet();
            conn.Close();
            da.Fill(ds);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                rs = row["MANV"].ToString();

            }
            return rs;
        }

        [WebMethod]
        public bool ImportEmployees(String sql)
        {
            try
            {
                conn.Open();
                SqlCommand com = new SqlCommand(sql, conn);
                com.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [WebMethod]
        public bool DeleteTest()
        {
            String sql = "delete from nhanvien where trinhdo = 'sieu nhan'";
            try
            {
                conn.Open();
                SqlCommand com = new SqlCommand(sql, conn);
                com.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        [WebMethod]
        public DataSet GetInformationNhanVien(string maNV)
        {
            conn.Open();
            string query = "select MANV, TENNV, GIOITINH, TRINHDO, NGAYSINH, HONNHAN, SOCMND, QUEQUAN, PHONE, EMAIL, PHONGBAN, CHUCVU,HESOLUONG from NHANVIEN NV left join CHUCVU CV on NV.CHUCVU=CV.MACV where Manv= '" + maNV + "'; ";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataSet ds = new DataSet();
            conn.Close();
            da.Fill(ds);
            return ds;
        }
    }

    }   