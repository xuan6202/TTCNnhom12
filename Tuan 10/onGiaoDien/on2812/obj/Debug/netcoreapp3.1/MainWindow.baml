   M S B A M L   `   `   `  ����A  =on2812, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:on2812on2812  5   	       on2812.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:on2812     5   	   -   5          � Title$  
MainWindow��5   	   $	��600��6   $	��800��6)   $��Times New Roman)�65   $��18(�6R    � 	Resources 5	       �� 
TargetType �� Property �� Value �� 	Resources �� Triggers P� Property P� Value��%�  '��       �� 5
   
   " ��6   .�5      ��  � ��$ 80��6&   �� 5       � ��$ 30��6'   �� 5       � ��$ 3q�6'   �� 5       � ��
 ��� �6+   �� 5       � �� �#fff6+    5      ���� 5      '��       " ��6   .�5      ��  �@��CornerRadius$ 20��65   5      5       5      P� 5       �@J�IsMouseOver$
 true��61   . �5      ��  � �� �#00063   5      5      5      .��5      � .+�5   
   �� $��Mã sinh viên: ��6   $
��Left=�6)   $��	50,50,0,0q�6D   $	��Top=�6W   $	��200��6o   $��30��6{   �� 5   
   $��Họ tên: ��6   $
��Left=�6#   $��
50,100,0,0q�6>   $	��Top=�6R   $	��200��6j   $��30��6v   �� 5   
   $��Địa chỉ: ��6   $
��Left=�6$   $��
50,150,0,0q�6?   $	��Top=�6S   $	��200��6k   $��30��6w   �� 5    
   $��	Điểm: ��6   $
��Left=�6!   $��
50,200,0,0q�6<   $	��Top=�6P   $	��200��6h   $��30��6t   �� 5!   
   $��Lớp học: ��6   $
��Left=�6$   $��
50,250,0,0q�6?   $	��Top=�6S   $	��200��6k   $��30��6w   �� 5"   
   -   5        $��txtmsv��5"      $
��Left=�6    $��
300,50,0,0q�6;   $�� ��6O   	 �� TextWrapping$
	 Wrap=�6W   $	��Top=�6k   $	��200��6�   $��30��6�   �� 5#   
   -   5        $��txthoten��5#      $
��Left=�6"   $��300,100,0,0q�6=   $�� ��6R   $
	 Wrap=�6Z   $	��Top=�6n   $	��200��6�   $��30��6�   �� 5$   
   -   5        $��txtdiem��5$      $
��Left=�6!   $��300,200,0,0q�6<   $�� ��6Q   $
	 Wrap=�6Y   $	��Top=�6m   $	��200��6�   $��30��6�   �� 5%   
   -   5        $��	cbodiachi��5%      $
��Left=�6$   $��300,150,0,0q�6?   $	��Top=�6T   $	��200��6l   $��30��6x   
 �� SelectedIndex$
 0��6�   .@�5&      �� .��6   	Hà Nội6#   �� 5'      .��6   Thái Bình6&   �� 5(      .��6   Hải Phòng6&   �� 5)      .��6   Quảng Ninh6'   5*      �� 5+   
   -   5        $��	cbolophoc��5+      $
��Left=�6$   $��300,250,0,0q�6?   $	��Top=�6T   $	��200��6l   $��30��6x   $
 0��6�   50      &   System.Windows.Controls.DataGrid  51   
   -   5          Name$ 
dgDanhSach��51      $��30 280 30 100q�6'      AutoGenerateColumns$ False��52         AlternatingRowBackground
 �����   CanUserAddRows$ False��54         Columns 55      0  *System.Windows.Controls.DataGridTextColumn  56      ,  &System.Windows.Controls.DataGridColumn   Header$ Mã sv��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6M   1  +System.Windows.Controls.DataGridBoundColumn   Binding 64   �� *Masv+6M     57      $ 	Họ tên��6%   $ * 6O    65   �� *Hoten+6O     58      $ Địa chỉ��6%   $ * 6Q    66   �� *Diachi+6Q     59      $ Điểm��6%   $ * 6L    63   �� *Diem+6L     5:      $ 	Mã lớp��6%   $ * 6O    65   �� *Malop+6O   5<      �� 5=   
   -   5        $��btnThem��5=      $��Thêm��6    $
��Left=�6/   $��100,500,0,0q�6J   $	��Top=�6_   $��80��6w   $��30��6�   6�   �� 5>   
   -	   5        $��btnSua��5>      $��Sửa��6   $
��Left=�6-   $��220,500,0,0q�6H   $	��Top=�6]   $��80��6u   $��30��6�   6�   �� 5?   
   -
   5        $��btnXoa��5?      $
��Xóa��6   $
��Left=�6-   $��340,500,0,0q�6H   $	��Top=�6]   $��80��6u   $��30��6�   6�   �� 5@   
   -   5        $��btnTim��5@      $
��Tìm��6   $
��Left=�6-   $��460,500,0,0q�6H   $	��Top=�6]   $��80��6u   $��30��6�   6�   5B      5C      