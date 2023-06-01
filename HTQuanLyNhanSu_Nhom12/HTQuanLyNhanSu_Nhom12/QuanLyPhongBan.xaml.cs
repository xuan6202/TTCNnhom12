using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using HTQuanLyNhanSu_Nhom12.Models;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Linq;

namespace HTQuanLyNhanSu_Nhom12
{
    /// <summary>
    /// Interaction logic for QuanLyPhongBan.xaml
    /// </summary>
    public partial class QuanLyPhongBan : Window
    {
        public QuanLyPhongBan()
        {
            InitializeComponent();
        }
        //Tạo thể hiện của lớp Context
        QuanLNSContext db = new QuanLNSContext();

        private void HienThiDuLieu()
        {

            //Truy vấn dữ liệu sử dụng LINQ
            var query = from pb in db.PhongBans
                        select pb;
            //Hiển thị dl lên data grid 
            dgvQLPhongBan.ItemsSource = query.ToList();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            HienThiDuLieu();
        }
        //thêm hàm check DL
        private bool CheckDL()
        {
            string tb = "";
            if (txtMa.Text == "" || txtTen.Text == "" || txtSoNV.Text == "" || txtMota.Text == "")
            {
                tb += "\n Bạn cần phải nhập đầy đủ dữ liệu!";
            }

            if (!Regex.IsMatch(txtSoNV.Text, @"\d+"))
            {
                tb += "\n Số lượng nhập vào phải là số!";
            }
            else
            {
                int sl = int.Parse(txtSoNV.Text);
                if (sl < 0)
                {
                    tb += "\n Số lượng nhập vào phải là số dương!";
                }
            }
            if (tb != "")
            {
                MessageBox.Show(tb, "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            //Kiểm tra không cho nhập trùng mã phòng ban
            var query = db.PhongBans.SingleOrDefault(t => t.MaPb.Equals(txtMa.Text));
            if (query != null)
            {
                MessageBox.Show("Mã phòng ban này đã tồn tại!", "Thông Báo");
                HienThiDuLieu();
            }
            else
            {
                try
                {
                    if (CheckDL())// nếu DL nhập vào hợp lệ 
                    {
                        PhongBan pbMoi = new PhongBan();
                        pbMoi.MaPb = txtMa.Text;
                        pbMoi.TenPb = txtTen.Text;
                        pbMoi.SoNvPb = int.Parse(txtSoNV.Text);
                        pbMoi.MoTaPb = txtMota.Text;
                        db.PhongBans.Add(pbMoi);
                        db.SaveChanges();//luu thay doi vao csdl
                        MessageBox.Show("Thêm thành công!", "Thông Báo");
                        HienThiDuLieu();
                    }
                }
                catch (Exception e1)
                {
                    MessageBox.Show("Có lỗi khi thêm: " + e1.Message, "Thông Báo");
                }
            }
            }

        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //xác định 1 phòng ban cần sửa theo Mã
                var pbSua = db.PhongBans.SingleOrDefault(t => t.MaPb.Equals(txtMa.Text));
                if (pbSua != null)
                {
                    if (CheckDL())
                    {
                        pbSua.TenPb = txtTen.Text;
                        pbSua.SoNvPb = int.Parse(txtSoNV.Text);
                        pbSua.MoTaPb = txtMota.Text;
                        db.SaveChanges();
                        MessageBox.Show("Sửa thành công!", "Thông Báo");
                        HienThiDuLieu();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy sản phẩm cần sửa!");
                    }
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show("Có lỗi khi sửa: " + e1.Message, "Thông Báo");
            }
        }

    private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            //xác định 1 phòng ban cần xóa theo Mã
            var pbXoa = db.PhongBans.SingleOrDefault(t => t.MaPb.Equals(txtMa.Text));
            if (pbXoa != null)
            {
                MessageBoxResult rs = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Thông Báo", MessageBoxButton.YesNo);
                if (rs == MessageBoxResult.Yes)
                {
                    db.PhongBans.Remove(pbXoa);
                    db.SaveChanges();
                    HienThiDuLieu();
                }
            }
            else
            {
                MessageBox.Show("Không có sản phẩm này để xóa!", "Thông Báo");
            }
        }

        private void btnThoat_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Xác nhận", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }
        //chọn dòng trong data grid 
        private void dgvQLPhongBan_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if (dgvQLPhongBan.SelectedItem != null)
            {
                try
                {
                    Type t = dgvQLPhongBan.SelectedItem.GetType();
                    PropertyInfo[] p = t.GetProperties();
                    txtMa.Text = p[0].GetValue(dgvQLPhongBan.SelectedValue).ToString();
                    txtTen.Text = p[1].GetValue(dgvQLPhongBan.SelectedValue).ToString();
                    txtSoNV.Text = p[2].GetValue(dgvQLPhongBan.SelectedValue).ToString();
                    txtMota.Text = p[3].GetValue(dgvQLPhongBan.SelectedValue).ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi khi chọn hàng" + ex.Message, "Thông Báo");
                }
            }
        }

        private void btnTLai_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
        
    }
}
