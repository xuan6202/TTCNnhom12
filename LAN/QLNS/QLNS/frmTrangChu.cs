using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using DataTable = System.Data.DataTable;
using app = Microsoft.Office.Interop.Excel.Application;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace QLNS
{

    public partial class frmTrangChu : Form
    {
        public string con = @"Data Source=LANGVAN;Initial Catalog=QuanLNS;Integrated Security=True";
        public frmTrangChu()
        {
            InitializeComponent();
        }

        private void TrangChu_Load(object sender, EventArgs e)
        {
            Connectionss cons = new Connectionss(con);
            cons.OpenConnection();
            ProcessData qr1 = new ProcessData(cons);
            string query = "SELECT * FROM NhanVien";
            DataTable dt = qr1.ExecuteQuery(query);
            dGrNhanVien.DataSource = dt;
            cons.CloseConnection();
            string queryNgaySinh = "SELECT NgaySinh FROM NhanVien";
            using (SqlConnection connection = new SqlConnection(con))
            {
                SqlCommand command = new SqlCommand(queryNgaySinh, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string ngaySinhString = reader.GetString(0);
                        if (!cbNgaySinh.Items.Contains(ngaySinhString))
                        {
                            cbNgaySinh.Items.Add(ngaySinhString);
                        }
                }
                reader.Close();
            }

            // Lấy dữ liệu mã phòng ban từ bảng PhongBan và truyền vào combobox cbMaPB
            string queryMaPB = "SELECT MaPB FROM PhongBan";
            using (SqlConnection connection = new SqlConnection(con))
            {
                SqlCommand command = new SqlCommand(queryMaPB, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string maPB = reader.GetString(0);
                    if (!cbMaPB.Items.Contains(maPB))
                    {
                        cbMaPB.Items.Add(maPB);
                    }
                }
                reader.Close();
            }

            // Lấy dữ liệu mã dự án từ bảng DuAn và truyền vào combobox cbMaDA
            string queryMaDA = "SELECT MaDA FROM DuAn";
            using (SqlConnection connection = new SqlConnection(con))
            {
                SqlCommand command = new SqlCommand(queryMaDA, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string maDA = reader.GetString(0);
                    if (!cbMaDA.Items.Contains(maDA))
                    {
                        cbMaDA.Items.Add(maDA);
                    }
                }
                reader.Close();
            }
        }

        private void btnTroLai_Click(object sender, EventArgs e)
        {
            frmDangNhap frmDangNhap = new frmDangNhap();
            frmDangNhap.Show();
            this.Hide();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string MaNV = txtMaNV.Text;
            string TenNV = txtHoTen.Text;
            string DiaChi = txtDiaChi.Text;
            string MaPB = cbMaPB.SelectedItem?.ToString();
            string MaDA = cbMaDA.SelectedItem?.ToString();
            string NgaySinh = cbNgaySinh.SelectedItem?.ToString();
            string qr = "SELECT * FROM NhanVien WHERE 1=1";
            string Luong = txtLuong.Text;
            float LUONG = 0;
            if (!string.IsNullOrEmpty(MaNV))
            {
                qr += " AND MaNV = @MaNV ";
            }
            if (!string.IsNullOrEmpty(TenNV))
            {
                qr += " AND TenNV = @TenNV ";
            }
            if (!string.IsNullOrEmpty(DiaChi))
            {
                qr += " AND DiaChi = @DiaChi ";
            }
            if (!string.IsNullOrEmpty((MaPB)))
            {
                qr += " AND MaPB = @MaPB ";
            }
            if (!string.IsNullOrEmpty((MaDA)))
            {
                qr += " AND MaDA = @MaDA ";
            }
            if (!string.IsNullOrEmpty((NgaySinh)))
            {
                qr += "and NgaySinh = @NgaySinh ";
            }
            if (!string.IsNullOrEmpty(Luong))
            {
                float luong = float.Parse(txtLuong.Text);
                qr += " AND Luong = @Luong ";
                LUONG = luong;
            }
            SqlConnection connection = new SqlConnection(con);

            SqlCommand command = new SqlCommand(qr, connection);
            if (!string.IsNullOrEmpty(MaNV))
            {
                command.Parameters.AddWithValue("@MaNV", MaNV);
            }
            if (!string.IsNullOrEmpty(TenNV))
            {
                command.Parameters.AddWithValue("@TenNV", TenNV);
            }
            if (!string.IsNullOrEmpty(DiaChi))
            {
                command.Parameters.AddWithValue("@DiaChi", DiaChi);
            }
            if (!string.IsNullOrEmpty(Luong))
            {
                command.Parameters.AddWithValue("@Luong", LUONG);
            }
            if (!string.IsNullOrEmpty(MaDA))
            {
                command.Parameters.AddWithValue("@MaDA", MaDA);
            }
            if (!string.IsNullOrEmpty(MaPB))
            {
                command.Parameters.AddWithValue("@MaPB", MaPB);
            }
            if (!string.IsNullOrEmpty(NgaySinh))
            {
                command.Parameters.AddWithValue("@NgaySinh", NgaySinh);
            }
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            if (dataTable.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy kết quả nào!");
            }
            else
            {
                dGrNhanVien.DataSource = dataTable;
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaNV.Text = "";
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            txtLuong.Text = "";
            cbMaDA.SelectedIndex = -1;
            cbMaPB.SelectedIndex = -1;
            cbNgaySinh.SelectedIndex = -1;
        }

        private void dGrNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow selectedRow = dGrNhanVien.Rows[e.RowIndex];
            selectedRow.Selected = true;
            txtMaNV.Text = selectedRow.Cells["MaNV"].Value.ToString();
            txtHoTen.Text = selectedRow.Cells["TenNV"].Value.ToString();
            txtDiaChi.Text = selectedRow.Cells["DiaChi"].Value.ToString();
            txtLuong.Text = selectedRow.Cells["Luong"].Value.ToString();
            cbNgaySinh.SelectedItem = selectedRow.Cells["NgaySinh"].Value.ToString();
            cbMaPB.SelectedItem = selectedRow.Cells["MaPB"].Value.ToString();
            cbMaDA.SelectedItem = selectedRow.Cells["MaDA"].Value.ToString();
        }

        private void dGrNhanVien_SelectionChanged(object sender, EventArgs e)
        {
            if (dGrNhanVien.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dGrNhanVien.SelectedRows[0];
                txtMaNV.Text = selectedRow.Cells["MaNV"].Value.ToString();
                txtHoTen.Text = selectedRow.Cells["TenNV"].Value.ToString();
                txtDiaChi.Text = selectedRow.Cells["DiaChi"].Value.ToString();
                txtLuong.Text = selectedRow.Cells["Luong"].Value.ToString();
                cbNgaySinh.SelectedItem = selectedRow.Cells["NgaySinh"].Value.ToString();
                cbMaPB.SelectedItem = selectedRow.Cells["MaPB"].Value.ToString();
                cbMaDA.SelectedItem = selectedRow.Cells["MaDA"].Value.ToString();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dGrNhanVien.SelectedRows.Count > 0)
            {
                string maNV = dGrNhanVien.SelectedRows[0].Cells["MaNV"].Value.ToString();
                string query = "DELETE FROM NhanVien WHERE MaNV = @MaNV";
                using (SqlConnection connection = new SqlConnection(con))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaNV", maNV);
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    MessageBox.Show(rowsAffected + " hàng đã được xóa");
                }
                dGrNhanVien.Rows.Remove(dGrNhanVien.SelectedRows[0]);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một hàng để xóa");
            }
        }
        public void LoadData()
        {
            string qr = "SELECT * FROM NhanVien";
            SqlConnection cnn = new SqlConnection(con);
            SqlCommand cmd = new SqlCommand(qr, cnn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dGrNhanVien.DataSource = dt;
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dGrNhanVien.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dGrNhanVien.SelectedRows[0];
                string maNV = selectedRow.Cells["MaNV"].Value.ToString();
                string tenNV = txtHoTen.Text;
                string diaChi = txtDiaChi.Text;
                float luong = float.Parse(txtLuong.Text);
                string ngaySinh = cbNgaySinh.Text;
                string maPB = cbMaPB.Text;
                string maDA = cbMaDA.Text;
                string query = "SELECT COUNT(*) FROM PhongBan WHERE MaPB = @MaPB";
                using (SqlConnection connection = new SqlConnection(con))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaPB", maPB);
                    connection.Open();
                    bool exists = (int)command.ExecuteScalar() > 0;
                    if (!exists)
                    {
                        MessageBox.Show("MaPB không tồn tại trong bảng PhongBan");
                        return;
                    }
                }
                query = "SELECT COUNT(*) FROM DuAn WHERE MaDA = @MaDA";
                using (SqlConnection connection = new SqlConnection(con))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaDA", maDA);
                    connection.Open();
                    bool exists = (int)command.ExecuteScalar() > 0;
                    if (!exists)
                    {
                        MessageBox.Show("MaDA không tồn tại trong bảng DuAn");
                        return;
                    }
                }
                query = "UPDATE NhanVien SET TenNV = @TenNV, DiaChi = @DiaChi, Luong = @Luong, NgaySinh = @NgaySinh, MaPB = @MaPB, MaDA = @MaDA WHERE MaNV = @MaNV";
                using (SqlConnection connection = new SqlConnection(con))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaNV", maNV);
                    command.Parameters.AddWithValue("@TenNV", tenNV);
                    command.Parameters.AddWithValue("@DiaChi", diaChi);
                    command.Parameters.AddWithValue("@Luong", luong);
                    command.Parameters.AddWithValue("@NgaySinh", ngaySinh);
                    command.Parameters.AddWithValue("@MaPB", maPB);
                    command.Parameters.AddWithValue("@MaDA", maDA);
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    MessageBox.Show(rowsAffected + " hàng đã được cập nhật");
                }
                LoadData();
            }
        }
        
        private void btnXuat_Click(object sender, EventArgs e)
        {
            string filePath = @"F:\LAN\nd.xlsx";
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var worksheet = package.Workbook.Worksheets.Add("NhanVien");
                using (var connection = new SqlConnection(con))
                {
                    connection.Open();
                    string query = "SELECT MaNV, TenNV, DiaChi, Luong, NgaySinh, MaPB, MaDA FROM NhanVien";
                    using (var command = new SqlCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            worksheet.Cells.LoadFromDataReader(reader, true);
                            worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();
                        }
                    }
                }
                package.Save();
            }
            MessageBox.Show("Xuất tập tin thành công");
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string maNV = txtMaNV.Text;
            string tenNV = txtHoTen.Text;
            string diaChi = txtDiaChi.Text;
            string ngaySinh = cbNgaySinh.Text;
            string luong = txtLuong.Text;
            string maPB = cbMaPB.Text;
            string maDA = cbMaDA.Text;
            if (string.IsNullOrEmpty(maNV) || string.IsNullOrEmpty(tenNV) || string.IsNullOrEmpty(diaChi) || string.IsNullOrEmpty(ngaySinh) || string.IsNullOrEmpty(luong) || string.IsNullOrEmpty(maPB) || string.IsNullOrEmpty(maDA))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }
            using (SqlConnection connection = new SqlConnection(con))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM NhanVien WHERE MaNV=@MaNV";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaNV", maNV);
                    int result = (int)command.ExecuteScalar();
                    if (result > 0)
                    {
                        MessageBox.Show("Mã nhân viên đã tồn tại!");
                        return;
                    }
                }
            }
            using (SqlConnection connection = new SqlConnection(con))
            {
                connection.Open();
                string query = "INSERT INTO NhanVien(MaNV, TenNV, DiaChi, NgaySinh, Luong, MaPB, MaDA) VALUES (@MaNV, @TenNV, @DiaChi, @NgaySinh, @Luong, @MaPB, @MaDA)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaNV", maNV);
                    command.Parameters.AddWithValue("@TenNV", tenNV);
                    command.Parameters.AddWithValue("@DiaChi", diaChi);
                    command.Parameters.AddWithValue("@NgaySinh", ngaySinh);
                    command.Parameters.AddWithValue("@Luong", luong);
                    command.Parameters.AddWithValue("@MaPB", maPB);
                    command.Parameters.AddWithValue("@MaDA", maDA);
                    int result = command.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Thêm mới nhân viên thành công!");
                        txtMaNV.Text = "";
                        txtHoTen.Text = "";
                        txtDiaChi.Text = "";
                        cbNgaySinh.Text = "";
                        txtLuong.Text = "";
                        cbMaPB.Text = "";
                        cbMaDA.Text = "";
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Thêm mới nhân viên thất bại!");
                    }
                }
            }
        }
    }
}
