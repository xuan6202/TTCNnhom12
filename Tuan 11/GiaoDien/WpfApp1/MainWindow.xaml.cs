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
using WpfApp1.Models;
using System.Text.RegularExpressions;
using System.Reflection;

namespace WpfApp1
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
        qlbanhangContext db = new qlbanhangContext();
        private void HienThiDuLieu()
        {
            //truy vấn dữ liệu sử dụng LINQ
            var query = from sp in db.SanPhams
                        orderby sp.DonGia
                        select new
                        {
                            sp.MaSp,
                            sp.TenSp,
                            sp.MaLoai,
                            sp.SoLuong,
                            sp.DonGia,
                            ThanhTien = sp.SoLuong * sp.DonGia
                        };

            //hiển thị dữ liệu lên data grid 
            dgvSanPham.ItemsSource = query.ToList();
        }
        

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            HienThiDuLieu();
        
        }
    }
}
