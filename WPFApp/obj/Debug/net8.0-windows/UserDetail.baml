   M S B A M L   `   `   `  ����A  =WPFApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:WPFAppWPFApp  5   	       WPFApp.UserDetail   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:WPFApp     5   	     � Title$  UsersDetail��5   	   $	��450��6   $
��1000��6*   .��5	      � $	��Top=�6   $��10q�6$    � RowDefinitions 5
   
   �� 5      $
��auto �6   $��30��6*   �� 5      $
��auto �6   $��30��6*   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $
��auto �6   $	��300��6,   �� 5      $
��300* �6   .+�5   
   �� $��User Detail��6   $��30(�6&   $
��Bold"�64   ���	#FFE22A2A6F   �� 5   
    �� Orientation$ Vertical=�6   $��1��6,   $��1��69   $��10,0,0,0q�6I   .+�5      �� $ 
Horizontal=�6   $
��Left=�62   $��0,0,0,10q�6M   $��25��6_   .+�5      �� -   5        $��	txtSearch��5      $	��300��6+   �� 5      -   5        $��	btnSearch��5   *   $��Search��6   $	��119��6;   $��10,0,0,0q�6G   6Y   5      5      &   System.Windows.Controls.DataGrid  5   
   -   5        $��dgBorrow��5   /      AutoGenerateColumns$ False��6   $��3��6?   $��1��6L   $��10,0,0,0q�6\      
IsReadOnly$
 True��6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ BookId��6%      
Visibility$ 	Collapsed=�6Q   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 65   �� *BookId+6Q     5      $ 	BookTitle��6%   
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 * 6W   	 68   �� *
Book.Title+6W     5      $ Author��6%   $
 * 6T   	 65   �� *
user.Email+6T     5      $ Borrowed Start Date��6%   $
 * 6`   	 6B   �� *	StartDate+6`     5       $ Borrowed End Date��6%   $
 * 6]   	 6@   �� *	EndDate+6]     5!      $ Returned Date��6%   $
 * 6\   	 6<   �� *
ReturnDate+6\   5#      � 5%   
   $��3��6    5&      �� 5'      $
��auto �6#   $��80��60   �� 5(      $��* �6#    5*      �� 5+      $
��auto �6    $��20��6.   �� 5,      $
��auto �6    $��20��6.   �� 5-      $
��auto �6    $��20��6.   �� 5.      $
��auto �6    $��20��6.   �� 5/      $
��auto �6    $��20��6.   �� 50      $
��auto �6    $��20��6.   �� 51      $
��auto �6    $��20��6.   �� 52      $
��auto �6    $��20��6.   �� 53      $
��auto �6    $��20��6.   �� 54      $
��auto �6    $��20��6.   �� 55      $
��auto �6    $��30��6.   .+�57      �� $��UserId��6   $��0��6%   �� 58      $��FullName��6   $��1��6'   �� 59      $
��CCCD��6   $��2��6#   �� 5:      $��PhoneNumber��6   $��3��6*   �� 5;      $��EmailAddress��6   $��4��6+   �� 5<      $��Password��6   $��5��6'   �� 5>      -   5        $��txtCCCD��5>   3   $��1��6   $��1��6#   63   �� 5?      -   5        $��txtName��5?   3   $��2��6   $��1��6#   63   �� 5@      -   5        $��txtPhoneNumber��5@   3   $��3��6   $��1��6#   63   �� 5A      -   5        $��txtEmailAddress��5A   3   $��4��6   $��1��6#   63   �� 5C      -   5        $��txtPass��5C   3   $��5��6   $��1��6#   ${�False��6B   �� 5E      -	   5        $��btnSave��5E   W   $
��Save��6   $��7��6$   $��2��61   $��87,0,0,0q�6E   6f   �� 5F      -
   5        $��	txtUserId��5F   3   $��0��6   $��1��6#   ${�False��6D   5G      5I      5K      