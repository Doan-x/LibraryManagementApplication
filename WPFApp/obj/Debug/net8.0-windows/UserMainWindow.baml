   M S B A M L   `   `   `  ����A  =WPFApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:WPFAppWPFApp  5   	       WPFApp.UserMainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:WPFApp     5   	     � Title$  UserMainWindow��5   	   $	��450��6    $
��1000��6-   .��5	      � $	��Top=�6   $��10q�6$    � RowDefinitions 5
   
   �� 5      $
��auto �6   $��30��6*   �� 5      $
��auto �6   $��30��6*   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $
��auto �6   $	��120��6,   �� 5      $
��auto �6   $	��300��6,   �� 5      $
��300* �6   .+�5   
   �� $��2��6   $��0,0,10,0q�6"   .+�5      �� -   5        $��btnUserInformation��5   <   $��User Information��6   $��50��60   6V   �� 5      -   5        $��btnReservation��5   I   $��Reservation��6   $��53��6+   $��0,10,0,0q�67   6_   �� 5      -   5        $��	btnLogout��5   E   $��Log out��6   $��53��6'   $��0,10,0,0q�63   6V   5      �� 5   
   $��User Information��6   $��30(�6+   $
��Bold"�69   ���	#FFE22A2A$��1��6c   $��0,0,0,10q�6s   �� 5   
    �� Orientation$ Vertical=�6   $��1��6,   $��2��69   .+�5      �� $ 
Horizontal=�6   $
��Left=�62   $��0,0,0,10q�6M   $��25��6_   .+�5      �� -   5        $��	txtSearch��5      $	��300��6+   �� 5      -   5        $��	btnSearch��5   *   $��Search��6   $	��119��6;   $��10,0,0,0q�6G   6Y   5      5       &   System.Windows.Controls.DataGrid  5!   
   -   5        $��dgBorrow��5!   /      AutoGenerateColumns$ False��6   $��3��6?   $��2��6L      
IsReadOnly$
 True��6�      Columns 5"      0  *System.Windows.Controls.DataGridTextColumn  5#      ,  &System.Windows.Controls.DataGridColumn   Header$ BookId��6%      
Visibility$ 	Collapsed=�6X   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 65   �� *borrow.BookId+6X     5$      $ 	BookTitle��6%   
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 * 6^   	 68   �� *borrow.Book.Title+6^     5%      $ Author��6%   $
 * 6\   	 65   �� *borrow.Book.Author+6\     5&      $ Borrowed Start Date��6%   $
 * 6g   	 6B   �� *borrow.StartDate+6g     5'      $ Borrowed End Date��6%   $
 * 6d   	 6@   �� *borrow.EndDate+6d     5(      $ Returned Date��6%   $
 * 6c   	 6<   �� *borrow.ReturnDate+6c     5)      $ Status��6%   $
 * 6P   	 65   �� *status+6P   5+      � 5-   
   $��3��6   $��1��6   $��0,0,10,0q�6,    5.      �� 5/      $
��auto �6#   $��80��60   �� 50      $��* �6#    52      �� 53      $
��auto �6    $��20��6.   �� 54      $
��auto �6    $��20��6.   �� 55      $
��auto �6    $��20��6.   �� 56      $
��auto �6    $��20��6.   �� 57      $
��auto �6    $��20��6.   �� 58      $
��auto �6    $��20��6.   �� 59      $
��auto �6    $��20��6.   �� 5:      $
��auto �6    $��20��6.   �� 5;      $
��auto �6    $��20��6.   �� 5<      $
��auto �6    $��20��6.   �� 5=      $
��auto �6    $��30��6.   .+�5?      �� $��UserId��6   $��0��6%   �� 5@      $��FullName��6   $��1��6'   �� 5A      $
��CCCD��6   $��2��6#   �� 5B      $��PhoneNumber��6   $��3��6*   �� 5C      $��EmailAddress��6   $��4��6+   �� 5D      $��Password��6   $��5��6'   �� 5E      $��Enrrol Time��6   $��6��6*   �� 5F      -   5        $��txtName��5F   3   $��2��6   $��1��6#   63   �� 5G      -   5        $��txtCCCD��5G   3   $��1��6   $��1��6#   63   �� 5I      -	   5        $��txtPhoneNumber��5I   3   $��3��6   $��1��6#   63   �� 5J      -
   5        $��txtEmailAddress��5J   3   $��4��6   $��1��6#   63   �� 5L      -   5        $��txtPass��5L   3   $��5��6   $��1��6#   63   (  "System.Windows.Controls.DatePicker  5M      -   5        $��dpEnrrolTime��5M   6   $��6��6   $��1��6&   ${�False��6J   �� 5O      -   5        $��btnSave��5O   W   $
��Save��6   $��8��6$   $��2��61   $��87,0,0,0q�6E   6f   �� 5P      -   5        $��	txtUserId��5P   3   $��0��6   $��1��6#   ${�False��6D   5Q      5S      5T      