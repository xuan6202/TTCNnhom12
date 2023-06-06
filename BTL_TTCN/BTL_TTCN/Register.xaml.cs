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
using BTL_TTCN.General;
using static BTL_TTCN.General.Method;

namespace BTL_TTCN
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        private BTL_TTCN.General.Method.TrangThaiForm _trangThaiForm;
        public BTL_TTCN.General.Method.TrangThaiForm TrangThaiForm
        {
            get { return _trangThaiForm; }
            set { _trangThaiForm = value; }
        }
        public Register()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Cursor = Cursors.Wait;
            txtMaNV.Background = Brushes.LightGoldenrodYellow;
            txtUsername.Background = Brushes.LightGoldenrodYellow;
            txtPassword.Background = Brushes.LightGoldenrodYellow;
            txtRePassword.Background = Brushes.LightGoldenrodYellow;

            this.Cursor = Cursors.Arrow;
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckInputControl())
                return;
            String sSQL = "";
            switch (_trangThaiForm)
            {
                case Method.TrangThaiForm.DangKy:
                    sSQL = "INSERT INTO TAIKHOAN VALUE(" + ConvertStringSQL(txtMaNV.Text) + "," + ConvertStringSQL(txtUsername.Text) + "," + ConvertStringSQL(txtPassword.Password) + ")";
                    break;
            }
        }
 /*      if (ConnectDatabase.Connect.DataExecution (sSQL) ==1){
            MessageBox.Show ("Đăng ký thành công" , "Thông báo", MesageBoxButton.OK, MesageBoxImage.Information);
            return;*/
        private string ConvertStringSQL(String sValue)
        {
            String sSQL = "'" + sValue + "'";
            return sSQL;
        }
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private bool CheckInputControl()
        {
            if(txtMaNV.Text.Trim()== "")
            {
                MessageBox.Show("Bạn chưa nhập mã nhân viên", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtMaNV.Focus();
                return false;
            }
            if(txtUsername.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập tài khoản", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtUsername.Focus();
                return false;
            }
            if(txtPassword.Password.Trim()== "")
            {
                MessageBox.Show("Bạn chưa nhập mật khẩu", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtPassword.Focus();
                return false;
            }
            if(txtRePassword.Password.Trim()== "")
            {
                MessageBox.Show("Bạn chưa xác nhận lại mật khẩu", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtRePassword.Focus();
                return false;
            }
            String sPass = Convert.ToString(txtPassword.Password);
            String sRePass = Convert.ToString(txtRePassword.Password);
            if(String.Compare(sPass, sRePass) != 0)
            {
                MessageBox.Show("Mật khẩu chưa trùng khớp", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtRePassword.Focus();
                return false;
            }
            return true;
        }
    }
}
