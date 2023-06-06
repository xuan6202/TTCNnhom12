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

namespace QLNS
{
    public partial class frmDangNhap : Form
    {
        string con = @"Data Source=LANGVAN;Initial Catalog=QuanLNS;Integrated Security=True";

        public frmDangNhap()
        {
            InitializeComponent();
        }
        public void DangNhap_Load(object sender, EventArgs e)
        {
            
            
        }

        public void btnDangNhap_Click(object sender, EventArgs e)
        {
            string TenDangNhap = txtTenDangNhap.Text;
            string MatKhau = txtMatKhau.Text;
            string MaNV = txtMaNV.Text;
            string query = "SELECT * FROM DangNhap WHERE TenDN = @TenDangNhap";
            using (SqlConnection connection = new SqlConnection(con))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TenDangNhap", TenDangNhap);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Close();
                    query = "SELECT * FROM DangNhap WHERE TenDN = @TenDangNhap AND MatKhau = @MatKhau";
                    command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@TenDangNhap", TenDangNhap);
                    command.Parameters.AddWithValue("@MatKhau", MatKhau);
                    reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Close();
                        query = "SELECT * FROM DangNhap WHERE TenDN = @TenDangNhap AND MatKhau = @MatKhau AND MaNV = @MaNV";
                        command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@TenDangNhap", TenDangNhap);
                        command.Parameters.AddWithValue("@MatKhau", MatKhau);
                        command.Parameters.AddWithValue("@MaNV", MaNV);
                        reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            MessageBox.Show("Đăng nhập thành công");
                        }
                        else
                        {
                            reader.Close();
                            MessageBox.Show("Mã nhân viên không đúng");
                        }
                    }
                    else
                    {
                        reader.Close();
                        MessageBox.Show("Mật khẩu không đúng");
                    }
                }
                else
                {
                    reader.Close();
                    MessageBox.Show("Tên đăng nhập không đúng");
                }
            }

        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            frmDangKy fr = new frmDangKy();
            fr.Show();
            this.Hide();
        }
    }
}
