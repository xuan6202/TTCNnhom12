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
using on3.Models;
namespace on3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }
        truonghocdb4Context db = new truonghocdb4Context();
        private void HienThiDataGrid()
        {
            var query = from sv in db.Sinhviens
                        orderby sv.Diem
                        select sv;
             dgDanhsach.ItemsSource = query.ToList();
        }
        private void HienThiCB()
        {
            var query = from lh in db.Lophocs
                        select lh;
            cbolophoc.ItemsSource = query.ToList();
            cbolophoc.DisplayMemberPath = "Tenlop";
            cbolophoc.SelectedValuePath = "Malop";
            cbolophoc.SelectedIndex = 0;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            HienThiCB();
            HienThiDataGrid();
        }

       
        private void butThem_Click(object sender, RoutedEventArgs e)
        {
            
            var query = db.Sinhviens.SingleOrDefault(t => t.Masv.Equals(txtmsv.Text));
            if(query != null)
            {
                MessageBox.Show("Mã sinh viên này đã tồn tại!", "Thông báo");
                HienThiDataGrid();
            }
            else
            {
                Sinhvien s = new Sinhvien();
                s.Masv = int.Parse(txtmsv.Text);
                s.Hoten = txthoten.Text;
                s.Diachi = cbodiachi.Text;
                s.Diem = byte.Parse(txtdiem.Text);
                s.Malop = int.Parse(cbolophoc.SelectedValue.ToString());

                db.Sinhviens.Add(s);
                db.SaveChanges();
                MessageBox.Show("Thêm thành công!", "Thông báo");
                HienThiDataGrid();
            }
        }


        private void butSua_Click(object sender, RoutedEventArgs e)
        {
            
                var svSua = db.Sinhviens.SingleOrDefault(sv => sv.Masv.Equals(txtmsv.Text));
                if (svSua != null)
                {
                    svSua.Hoten = txthoten.Text;
                    svSua.Diachi = cbodiachi.Text;
                    svSua.Diem = byte.Parse(txtdiem.Text);
                    svSua.Malop = int.Parse(cbolophoc.SelectedValue.ToString());


                    db.SaveChanges();
                MessageBox.Show("Bạn đã sửa thành công", "thông báo");
                    HienThiDataGrid();
                }

            
        }

        private void butXoa_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var svXoa = db.Sinhviens.SingleOrDefault(sv => sv.Masv == int.Parse(txtmsv.Text));
                MessageBoxResult rs = MessageBox.Show("bạn có chắc chắc muốn xóa?", "Thông báo", MessageBoxButton.YesNo);
                if(rs == MessageBoxResult.Yes)
                {
                    db.Sinhviens.Remove(svXoa);
                    db.SaveChanges();
                    HienThiDataGrid();
                }
               
            }
            catch(Exception x)
            {
                MessageBox.Show("Có lỗi khi xóa: " + x.Message);
               
            }
        }
    }
}
