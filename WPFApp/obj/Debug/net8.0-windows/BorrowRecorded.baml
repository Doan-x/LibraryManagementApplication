   M S B A M L   `   `   `  ����A  =WPFApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:WPFAppWPFApp  5   	       WPFApp.BorrowRecorded   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:WPFApp     5   	     � Title$  BorrowRecord��5   	   $	��450��6   $	��800��6+   .��5	      � $��10,0,7,0q�6    � RowDefinitions 5
   
   �� 5      $
��Auto �6   $��70��6*   �� 5      $
��Auto �6   $��50��6*   �� 5      �� 5      $
��Auto �6   $��50��6*   .+�5   
   �� $
��Bold"�6   $��24(�6"   $��0,10,0,0q�60   ���	#FFCE1616$��Borrow Record��6Y   �� 5   
    �� Orientation$ 
Horizontal=�6   $��1��6.   .+�5      �� $ 
Horizontal=�6   $	��651��62   $��40��6>   .+�5      �� -   5        $��	txtSearch��5      $	��300��6+   $��0,0,20,0q�6:   6O   �� 5      -   5        $��	btnSearch��5      $��Search��6*   $��80��6;   6I   5      �� 5      -   5        $��btnAdd��5      $	��Add��6#   $��0,0,10,0q�61   $��31��6C   $	��119��6O   $��Right=�6p   5      �� 5   
   $��2��6   $��
0,10,0,310q�6"   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dgBorrowedBook��5   &      
IsReadOnly$
 True��6      AutoGenerateColumns$ False��6>   $��2��6Z   $��0,10,0,0q�6g      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto 6T   	   
Visibility$	 	Collapsed=�6a   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 61   �� *borrow.BookId+6a     5      $ Fullname��6%   $ * 6`   
 67   �� *borrow.User.FullName+6`     5      $ PhoneNumber��6%   $ * 6f   
 6:   �� *borrow.User.PhoneNumber+6f     5      $
 Cccd��6%   $ * 6X   
 63   �� *borrow.User.Cccd+6X     5      $
 Book��6%   $ * 6Y   
 63   �� *borrow.Book.Title+6Y     5       $ Author��6%   $ * 6\   
 65   �� *borrow.Book.Author+6\     5!      $ 
Start Date��6%   $ * 6^   
 69   �� *borrow.StartDate+6^     5"      $ End Date��6%   $ * 6Z   
 67   �� *borrow.EndDate+6Z     5#      $
 Debt��6%   $ * 6L   
 63   �� *debt+6L   4  .System.Windows.Controls.DataGridTemplateColumn  5$      $ Actions��6)   $ * 6:      CellTemplate 5%      �� 5&      .R�5'      ��  ��Name$ 	btnReturn��6%   -   5        $��Return��5'   8   $��	10,0,10,0q�6a   6w   5(      5*      5-      5/      50      