using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using QLDA.Models;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Data;

namespace QLDA
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        //Tạo đối tượng con trỏ tới Model
        QuanLNSContext db = new QuanLNSContext();

        //hàm load dữ liệu lên data grid 
        private void HienThiDuLieu()
        {
            var query = from da in db.DuAns
                        select da;
            dgvQLDuAn.ItemsSource = query.ToList();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            HienThiDuLieu();
        }
        //thêm hàm check DL
        private bool CheckDL()
        {
            string tb = "";
            if (txtMaDa.Text == "" || txtTenDa.Text == "" || txtSoNv.Text == "" || txtMoTa.Text == "")
            {
                tb += "\n Bạn cần phải nhập đầy đủ dữ liệu!";
            }

            if (!Regex.IsMatch(txtSoNv.Text, @"\d+"))
            {
                tb += "\n Số lượng nhập vào phải là số!";
            }
            else
            {
                int sl = int.Parse(txtSoNv.Text);
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
        public int SoNvDaText { get; set; }

        private void LoadData()
        {
            // Lấy dữ liệu từ database và gán cho datagrid
            dgvQLDuAn.ItemsSource = db.DuAns;

            // Gán giá trị của thuộc tính SoNvDa cho SoNvDaText
            DuAn da = (DuAn)dgvQLDuAn.SelectedItem;
            if (da != null)
            {
                SoNvDaText = (int)da.SoNvDa;
            }
        }
        private void dtnqlduan_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgvQLDuAn.SelectedItem != null)
            {
                DuAn da = (DuAn)dgvQLDuAn.SelectedItem;
                if (da != null)
                {
                    txtMaDa.Text = da.MaDa;
                    txtTenDa.Text = da.TenDa;

                    SoNvDaText = (int)da.SoNvDa;
                    txtSoNv.Text = SoNvDaText.ToString();
                    txtMoTa.Text = da.MoTaDa;
                }
            }
        }
            private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            //Kiểm tra không cho nhập trùng mã 
            var query = db.DuAns.SingleOrDefault(t => t.MaDa.Equals(txtMaDa.Text));
            if (query != null)
            {
                MessageBox.Show("Mã dự án này đã tồn tại!", "Thông Báo");
                HienThiDuLieu();
            }
            else
            {
                try
                {
                    if (CheckDL())
                    {
                        DuAn daMoi = new DuAn();
                        daMoi.MaDa = txtMaDa.Text;
                        daMoi.TenDa = txtTenDa.Text;
                        daMoi.SoNvDa = int.Parse(txtSoNv.Text);
                        daMoi.MoTaDa = txtMoTa.Text;
                        db.DuAns.Add(daMoi);
                        db.SaveChanges();
                        MessageBox.Show("Thêm thành công!", "Thông Báo");
                        HienThiDuLieu();
                    }
                }
                catch (Exception e1)
                {
                    MessageBox.Show("Có lỗi khi thêm: " + e1.Message, "Thông Báo");
                }
            }
            txtMaDa.Text = "";
            txtTenDa.Text = "";
            txtSoNv.Text = "";
            txtMoTa.Text = "";
        }



        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //xác định 1 dự án cần sửa theo Mã
                var daSua = db.DuAns.SingleOrDefault(t => t.MaDa.Equals(txtMaDa.Text));
                if (daSua != null)
                {
                    if (CheckDL())
                    {
                        daSua.TenDa = txtTenDa.Text;
                        daSua.SoNvDa = int.Parse(txtSoNv.Text);
                        daSua.MoTaDa = txtMoTa.Text;
                        db.SaveChanges();
                        MessageBox.Show("Sửa thành công!", "Thông Báo");
                        HienThiDuLieu();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy sản phẩm cần sửa!");
                    }
                }
                txtMaDa.Text = "";
                txtTenDa.Text = "";
                txtSoNv.Text = "";
                txtMoTa.Text = "";
            }
            catch (Exception e1)
            {
                MessageBox.Show("Có lỗi khi sửa: " + e1.Message, "Thông Báo");
            }
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            //xác định 1 dự án cần xóa theo Mã
            var daXoa = db.DuAns.SingleOrDefault(t => t.MaDa.Equals(txtMaDa.Text));
            if (daXoa != null)
            {
                MessageBoxResult rs = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Thông Báo", MessageBoxButton.YesNo);
                if (rs == MessageBoxResult.Yes)
                {
                    db.DuAns.Remove(daXoa);
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

        private void btnTLai_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}