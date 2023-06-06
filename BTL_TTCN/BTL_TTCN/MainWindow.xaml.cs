using System;
using System.Collections.Generic;
using System.Data;
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

namespace BTL_TTCN
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public object ConnectDataBase { get; private set; }

        public MainWindow()
        {
            InitializeComponent();

         
        }


        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (AllowLogin())
                return;


        DataTable dtData = ConnectDataBase.Connect.DataTransport("SELECT * FROM DangNhap");
            for (int i=0; i<dtData.Rows.Count; i++)
            {
                if(txtUsername.Text.ToLower().Trim()== Convert.ToString(dtData.Rows[i]["Username"]).ToLower().Trim())
                {
                    if(txtPassword.Password == Convert.ToString(dtData.Rows[i]["Password"]))
                    {
                        MessageBox.Show("Đăng nhập thành công", "Chúc mừng", MessageBoxButton.OK, MessageBoxImage.Information);
                            return;
                    }
                    else
                    {
                        MessageBox.Show("Mật khẩu bạn nhập không chính xác", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Tài khoản bạn nhập không chính xác", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    txtUsername.Focus();
                    return;
                }
            }
        }
        private bool AllowLogin()
        {
            if (txtUsername.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập tài khoản", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtUsername.Focus();
                return false;
            }
            if(txtPassword.Password.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập mật khẩu", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtPassword.Focus();
                return false;
            }
                return true;
        }
    }
}
