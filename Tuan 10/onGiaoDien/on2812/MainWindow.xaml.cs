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
using on2812.Models;
using System.Reflection;
using System.Text.RegularExpressions;
namespace on2812
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
        truonghocdb4Context db = new truonghocdb4Context();
        private void HienThiDuLieu()
        {
            var query = from sv in db.Sinhviens
                        orderby sv.Diem
                        select new
                        {
                            sv.Masv,
                            sv.Hoten,
                            sv.Diachi,
                            sv.Diem,
                            sv.Malop
                        };
            dgDanhSach.ItemsSource = query.ToList();
        }
        private void HienThiCB()
        {
            var query = from lophoc in db.Lophocs
                        select lophoc;
            cbolophoc.ItemsSource = query.ToList();
            cbolophoc.DisplayMemberPath = "Tenlop";
            cbolophoc.SelectedValuePath = "Malop";
            cbolophoc.SelectedIndex = 0;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            HienThiCB();
            HienThiDuLieu();
        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            var query = db.Sinhviens.SingleOrDefault(sv => sv.Masv == int.Parse(txtmsv.Text));
            if(query != null)
            {
                MessageBox.Show("Ma sinh vien da ton tai", "Thong bao");
                HienThiDuLieu();
            }
            else
            {
                try
                {
                    if (CheckDL())
                    {
                        Sinhvien svMoi = new Sinhvien();
                        svMoi.Masv = int.Parse(txtmsv.Text);
                        svMoi.Hoten = txtdiem.Text;
                        svMoi.Diachi = cbodiachi.Text;
                        svMoi.Diem = byte.Parse(txtdiem.Text);
                        Lophoc lh = (Lophoc)cbolophoc.SelectedItem;
                        svMoi.Malop = lh.Malop;

                        db.Sinhviens.Add(svMoi);
                        db.SaveChanges();
                        MessageBox.Show("Them thanh cong!", "Thong bao");
                        HienThiDuLieu();
                    }
                }
                catch(Exception x)
                {
                    MessageBox.Show("Co loi khi them: " + x.Message, "Thong bao");
                }
            }
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            var svXoa = db.Sinhviens.SingleOrDefault(sv => sv.Masv == int.Parse(txtmsv.Text));
            if(svXoa != null)
            {
                try
                {
                    if (CheckDL())
                    {
                        MessageBoxResult rs = MessageBox.Show("Ban co chac chan muon xoa?", "Thong bao", MessageBoxButton.YesNo);
                        if (rs == MessageBoxResult.Yes)
                        {
                            db.Sinhviens.Remove(svXoa);
                            db.SaveChanges();
                            HienThiDuLieu();
                        }
                    }
                }
                catch(Exception x)
                {
                    MessageBox.Show("Co loi khi xoa: " + x.Message, "Thong bao");
                }
            }
            else
            {
                MessageBox.Show("Khong co sinh vien can xoa", "Thong bao");
            }
        }

        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            var svSua = db.Sinhviens.SingleOrDefault(sv => sv.Masv == int.Parse(txtmsv.Text));
            if(svSua != null)
            {
                try
                {
                    if (CheckDL())
                    {

                        svSua.Hoten = txthoten.Text;
                        svSua.Diachi = cbodiachi.Text;
                        svSua.Diem = byte.Parse(txtdiem.Text);
                        Lophoc lh = (Lophoc)cbolophoc.SelectedItem;
                        svSua.Malop = lh.Malop;
                        db.SaveChanges();
                        MessageBox.Show("Ban da sua thanh cong", "Thong Bao");
                        HienThiDuLieu();
                    }
                }
                catch(Exception x)
                {
                    MessageBox.Show("Co loi khi sua:" + x.Message, "Thong bao");
                }
            }
            else
            {
                MessageBox.Show("Khong co sinh vien nay de sua", "Thong bao");
            }
           
        }

        private void btnTim_Click(object sender, RoutedEventArgs e)
        {
            var svTim = db.Sinhviens.SingleOrDefault(sv => sv.Masv == int.Parse(txtmsv.Text));
            if(svTim != null)
            {


                var query = from sv in db.Sinhviens
                            where sv.Masv == int.Parse(txtmsv.Text)
                                    orderby sv.Diem
                                    
                                    select new
                                    {
                                        sv.Masv,
                                        sv.Hoten,
                                        sv.Diachi,
                                        sv.Diem,
                                        sv.Malop
                                    };
                        dgDanhSach.ItemsSource = query.ToList();
                    
                
                
            }
            else
            {
                MessageBox.Show("Khong co ma sinh vien nay");
            }
        }
        private bool CheckDL()
        {
            string tb = " ";
            if (txtmsv.Text == "" | txthoten.Text == "" |txtdiem.Text == "")
            {
                tb += ("Du lieu khong duoc de trong");
            }
            if (!Regex.IsMatch(txtdiem.Text,@"\d+"))
            {
                tb += ("Diem phai la so");
            }
            else
            {
                byte d = byte.Parse(txtdiem.Text);
                if (d < 0)
                {
                    tb += ("Diem phai lon hon 0");
                }
            }
            if(tb!=" ")
            {
                MessageBox.Show(tb, "Thong bao", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }

        private void dgDanhSach_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if(dgDanhSach.SelectedItem != null)
            {
                Type t = dgDanhSach.SelectedItem.GetType();
                PropertyInfo[] p = t.GetProperties();
                txtmsv.Text = p[0].GetValue(dgDanhSach.SelectedValue).ToString();
                txthoten.Text = p[1].GetValue(dgDanhSach.SelectedValue).ToString();
                txtdiem.Text = p[3].GetValue(dgDanhSach.SelectedValue).ToString();
                cbodiachi.Text = p[2].GetValue(dgDanhSach.SelectedValue).ToString();
                cbolophoc.SelectedValue= p[4].GetValue(dgDanhSach.SelectedValue).ToString();
            }
            else
            {
                MessageBox.Show("Co loi khi chon dong", "Thong bao");
            }
        }
    }
}
