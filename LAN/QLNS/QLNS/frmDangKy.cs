using Microsoft.Office.Interop.Excel;
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
    public partial class frmDangKy : Form
    {
        public frmDangKy()
        {
            InitializeComponent();
        }
        string con = @"Data Source=LANGVAN;Initial Catalog=QuanLNS;Integrated Security=True";
        private void btnDangKy_Click(object sender, EventArgs e)
        {
            string tenDangNhap = txtTenDangNhap.Text;
            string matKhau = txtMatKhau.Text;
            string maNV = txtMaNV.Text;
            string query = "SELECT COUNT(*) FROM DangNhap WHERE TenDN = @TenDangNhap";
            using (SqlConnection connection = new SqlConnection(con))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);
                connection.Open();
                int count = (int)command.ExecuteScalar();
                if (count > 0)
                {
                    MessageBox.Show("Tên đăng nhập đã tồn tại");
                }
                else
                {
                    query = "SELECT COUNT(*) FROM NhanVien WHERE MaNV = @MaNV";
                    command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaNV", maNV);
                    count = (int)command.ExecuteScalar();
                    if (count == 0)
                    {
                        MessageBox.Show("Không tồn tại nhân viên với mã nhân viên này");
                    }
                    else
                    {
                        query = "SELECT COUNT(*) FROM DangNhap WHERE MaNV = @MaNV";
                        command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@MaNV", maNV);
                        count = (int)command.ExecuteScalar();
                        if (count > 0)
                        {
                            MessageBox.Show("Mã nhân viên đã được đăng ký, vui lòng sử dụng mã nhân viên khác");
                        }
                        else
                        {
                            query = "INSERT INTO DangNhap (TenDN, MatKhau, MaNV) VALUES (@TenDangNhap, @MatKhau, @MaNV)";
                            command = new SqlCommand(query, connection);
                            command.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);
                            command.Parameters.AddWithValue("@MatKhau", matKhau);
                            command.Parameters.AddWithValue("@MaNV", maNV);
                            int rowsAffected = command.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Đăng ký thành công");
                                frmDangNhap fr = new frmDangNhap();
                                fr.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Đăng ký thất bại");
                            }
                        }
                    }
                }
            }
        }
    }
}
