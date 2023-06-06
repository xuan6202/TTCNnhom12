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
using System.Text.RegularExpressions;
using System.Reflection;
using cuoiki.Models;
namespace cuoiki
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
                        orderby sv.Masv
                        select new
                        {
                            sv.Masv,
                            sv.Hoten,
                            sv.Malop
                        };
            dgvSinhvien.ItemsSource = query.ToList();
        }
        private void HienThiCB()
        {
            var query = from lh in db.Lophocs
                        select lh;
            cbolop.ItemsSource = query.ToList();
            cbolop.DisplayMemberPath = "HocLop";
            cbolop.SelectedValuePath = "MaLop";
            cbolop.SelectedIndex = 0;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            HienThiCB();
            HienThiDuLieu();
       
        }
    }
}
