   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1  5   	       WpfApp1.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp1     5   	   -   5          � Title$&   Cập nhập bảng sản phẩm��5   	   $	��550��6(   $	��800��65   $��Times New Roman)�5	   	   $��20(�6&   .��5      � .+�5   
   �� $��Mã sản phẩm: ��6   $
��Left=�6(   $��	50,50,0,0q�6C   $	��Top=�6V   $	��150��6n   $��30��6z   �� 5   
   $��Tên sản phẩm: ��6   $
��Left=�6)   $��
50,100,0,0q�6D   $	��Top=�6X   $	��150��6p   $	��30 ��6|   �� 5   
   $��Loại sản phẩm: ��6   $
��Left=�6*   $��
50,150,0,0q�6E   $	��Top=�6Y   $	��150��6q   $��30��6}   �� 5   
   $��Đơn giá: ��6   $
��Left=�6$   $��
50,200,0,0q�6?   $	��Top=�6S   $	��150��6k   $��30��6w   �� 5   
   $��Số lượng: ��6   $
��Left=�6%   $��
50,250,0,0q�6@   $	��Top=�6T   $	��150��6l   $��30��6x   �� 5   
   -   5        $��txtmasp��5      $
��Left=�6!   $��
280,50,0,0q�6<   $�� ��6P    �� TextWrapping$
 Wrap=�6X   $	��Top=�6l   $	��200��6�   $��30��6�   �� 5   
   -   5        $��txttensp��5      $
��Left=�6"   $��280,100,0,0q�6=   $�� ��6R   $
 Wrap=�6Z   $	��Top=�6n   $	��200��6�   $��30��6�   �� 5   
   -   5        $��	txtdongia��5      $
��Left=�6#   $��280,200,0,0q�6>   $�� ��6S   $
 Wrap=�6[   $	��Top=�6o   $	��200��6�   $��30��6�   �� 5   
   -   5        $��
txtsoluong��5      $
��Left=�6$   $��280,250,0,0q�6?   $�� ��6T   $
 Wrap=�6\   $	��Top=�6p   $	��200��6�   $��30��6�   �� 5   
   -   5        $��	cboloaisp��5      $
��Left=�6$   $��280,150,0,0q�6?    �� SelectedIndex$ 0��6T   $	��Top=�6f   $	��200��6~   $��30��6�   .@�5      �� .��6   
Gia dụng6%   �� 5      .��6   Điện lạnh6&   �� 5      .��6   Điện tử6$   �� 5      .��6   Laptop6#   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ 
dgvSanPham��5      $��
0 300 0 60q�6'      AutoGenerateColumns$ False��5         AlternatingRowBackground
 �����   CanUserAddRows$ False��5          Columns 5!      0  *System.Windows.Controls.DataGridTextColumn  5"      ,  &System.Windows.Controls.DataGridColumn   Header$ Mã SP��6!   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 60   �� *MaSp+  5#      $ Tên SP��6!   	 61   �� *TenSp+  5$      $ Mã loại SP��6!   	 65   �� *MaLoai+  5%      $ Số lượng��6!   	 63   �� *	SoLuong+  5&      $ 
Đơn giá��6!   	 62   �� *DonGia+  5'      $ Thành tiền��6!   
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 * 6S   	 65   �� *	ThanhTien+6S   5)      �� 5+   
   -   5        $��btnthem��5+      $��Thêm��6    $
��Left=�6/   $��
50,496,0,0q�6J   $	��Top=�6^   $��80��6v   $��30��6�   �� 5,   
   -	   5        $��btnsua��5,      $��Sửa��6   $
��Left=�6-   $��170,496,0,0q�6H   $	��Top=�6]   $��80��6u   $��30��6�   �� 5-   
   -
   5        $��btnxoa��5-      $
��Xóa��6   $
��Left=�6-   $��290,496,0,0q�6H   $	��Top=�6]   $��80��6u   $��30��6�   �� 5.   
   -   5        $��btntim��5.      $
��Tìm��6   $
��Left=�6-   $��410,496,0,0q�6H   $	��Top=�6]   $��80��6u   $��30��6�   �� 5/   
   -   5        $��
btnthongke��5/      $��Thống kê��6#   $
��Left=�66   $��530,496,0,0q�6Q   $	��Top=�6f   $	��100��6~   $��30��6�   51      53      