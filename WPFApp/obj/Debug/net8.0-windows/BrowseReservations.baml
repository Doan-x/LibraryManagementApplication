   M S B A M L   `   `   `  ����A  =WPFApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:WPFAppWPFApp  5   	       WPFApp.BrowseReservations   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:WPFApp     5   	     � Title$  BrowseReservations��5   	   $	��450��6$   $
��1000��61   .��5	      � .+�5
   
   � $	��Top=�6   $��10q�6(    � RowDefinitions 5      �� 5      $
��auto �6    $��30��6.   �� 5      $
��auto �6    $��30��6.   �� 5      $��* �6     � ColumnDefinitions 5      �� 5      $
��auto �6#   $	��150��60   �� 5      $
��300* �6#   .+�5      �� $��
Resevation��6   $��30(�6)   $
��Bold"�67   ���	#FFE22A2A$��10,0,0,0q�6`   �� 5       �� Orientation$ Vertical=�6   $��1��60   $��1��6=   $��10,0,0,0q�6M   .+�5      �� $ 
Horizontal=�6   $
��Left=�66   $��0,0,0,10q�6Q   $��25��6c   .+�5      �� -   5        $��	txtSearch��5      $	��300��6/   �� 5      -   5        $��	btnSearch��5   .   $��Search��6   $	��119��6?   $��10,0,0,0q�6K   6]   5      5      &   System.Windows.Controls.DataGrid  5      -   5        $��dgReservations��5   3      AutoGenerateColumns$ False��6   $��3��6I   $��1��6V   $��10,0,0,0q�6f      
IsReadOnly$
 True��6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ BookID��6)      
Visibility$ 	Collapsed=�6`   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 69   �� *Borrow.Book.BookId+6`     5      $ BookID��6)   $ 	Collapsed=�6[   	 69   �� *ReservationId+6[     5      $ UserId��6)   
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 * 6[   $ 	Collapsed=�6e   	 69   �� *User.UserId+6e     5       $ FullName��6)   $
 * 6]   	 6;   �� *User.FullName+6]     5!      $ PhoneNumber��6)   $
 * 6c   	 6>   �� *User.PhoneNumber+6c     5"      $ Email��6)   $
 * 6W   	 68   �� *
User.Email+6W     5#      $
 CCCD��6)   $
 * 6U   	 67   �� *	User.Cccd+6U     5$      $ 
Book Title��6)   $
 * 6c   	 6=   �� *Borrow.Book.Title+6c     5%      $ Book Author��6)   $
 * 6e   	 6>   �� *Borrow.Book.Author+6e     5&      $ ReservationDate��6)   $
 * 6g   	 6B   �� *ReservationDate+6g   4  .System.Windows.Controls.DataGridTemplateColumn  5'      $ Actions��6-   $
 * 6>      CellTemplate 5(      �� 5)      .R�5*   "   ��  ��Name$ 	btnDelete��6)   -   5        $��Delete��5*   <   $��	10,0,10,0q�6e   6{   5+      5-      5/      � 51      $��3��6    53      �� 54      $
��auto �6$   $��20��62   �� 55      $
��auto �6$   $��20��62   �� 56      $
��auto �6$   $��20��62   �� 57      $
��auto �6$   $��20��62   �� 58      $
��auto �6$   $��20��62   �� 59      $
��auto �6$   $��20��62   �� 5:      $
��auto �6$   $��20��62   �� 5;      $
��auto �6$   $��20��62   .+�5@      �� $��
Start Date��6   $��0��6-   $
��Bold"�6:   $��16(�6L   �� 5A      $��End Date��6   $��2��6+   $��16(�68   $
��Bold"�6F   (  "System.Windows.Controls.DatePicker  5C      -   5        $��dpStartDate��5C   9   $
��Left=�6   $��0,31,0,0q�6L   $��2��6^   $	��163��6o   $��18(�6{     5D      -   5        $��	dpEndDate��5D   F   $
��Left=�6   $��2��69   $��16(�6W   $��	0,31,0,20q�6e   $��3��6x   $	��163��6�   �� 5E      -   5        $��
btnConfirm��5E   ^   $��Confirm��6   $��5��6+   $��2��68   $��87,0,0,0q�6L   $��18(�6q   $
��Bold"�6   6�   �� 5F      -   5        $��	txtUserId��5F      $y�	Collapsed=�6+   $��6��6B   �� 5G      -	   5        $��	txtBookId��5G      $y�	Collapsed=�6+   $��6��6B   �� 5H      -
   5        $��txtBorrowId��5H      $y�	Collapsed=�6-   5J      5L      5M      5N      