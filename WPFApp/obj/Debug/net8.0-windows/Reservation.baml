   M S B A M L   `   `   `  ����A  =WPFApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:WPFAppWPFApp  5   	       WPFApp.Reservation   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:WPFApp     5   	     � Title$  Reservation��5   	   $	��450��6   $	��800��6*   .��5
      � $	��Top=�6   $��10q�6$    � RowDefinitions 5   
   �� 5      $
��auto �6   $��30��6*   �� 5      $
��auto �6   $��30��6*   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $
��auto �6   $	��300��6,   �� 5      $
��300* �6   .+�5   
   �� $��
Resevation��6   $��30(�6%   $
��Bold"�63   ���	#FFE22A2A$��10,0,0,0q�6\   �� 5   
    �� Orientation$ Vertical=�6   $��1��6,   $��1��69   $��10,0,0,0q�6I   .+�5      �� $ 
Horizontal=�6   $
��Left=�62   $��0,0,0,10q�6M   $��25��6_   .+�5      �� -   5        $��	txtSearch��5      $	��300��6+   �� 5      -   5        $��	btnSearch��5   *   $��Search��6   $	��119��6;   $��10,0,0,0q�6G   6Y   5      5      &   System.Windows.Controls.DataGrid  5   
   -   5        $��dgBook��5   /      AutoGenerateColumns$ False��6   $��3��6=   $��1��6J   $��10,0,0,0q�6Z      
IsReadOnly$
 True��6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ BookID��6%      
Visibility$ 	Collapsed=�6V   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 65   �� *book.BookId+6V     5      $ Title��6%   
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 * 6S   	 64   �� *
book.Title+6S     5      $ Author��6%   $
 * 6U   	 65   �� *book.Author+6U     5       $ Category��6%   $
 * 6f   	 67   �� *book.Category.CategoryName+6f     5!      $ 	Remaining��6%   $
 * 6W   	 68   �� *	remaining+6W   5$      � 5&   
   $��3��6    5'      �� 5(      $
��auto �6#   $��80��60   �� 5)      $��* �6#    5+      �� 5,      $
��auto �6    $��20��6.   �� 5-      $
��auto �6    $��20��6.   �� 5.      $
��auto �6    $��20��6.   �� 5/      $
��auto �6    $��30��6.   �� 50      $
��auto �6    $��30��6.   .+�53      �� $��
Start Date��6   $��0��6)   $��16(�66   $
��Bold"�6D   �� 54      $��End Date��6   $��1��6'   $
��Left=�64   $
��Bold"�6O   $��16(�6a   (  "System.Windows.Controls.DatePicker  56      -   5        $��dpStartDate��56   C   $��Center=�6   $��0��66   $��0,0,0,31q�6V   $	��214��6h   $��18(�6t   $��2��6�   $��1��6�     57      -   5        $��	dpEndDate��57   6   $��Center=�6   $��18(�6G   $��	0,31,0,20q�6U   $��3��6h   $	��214��6y   $��1��6�   �� 58      -   5        $��btnRegister��58   [   $��Register��6   $��3��6(   $��2��65   $��86,0,0,0q�6I   $
��Bold"�6�   $��18(�6�   �� 59      -   5        $��btnClose��59   Y   $��Close��6   $��4��6%   $��2��62   $��	86,10,0,0q�6F   $
��Bold"�6�   $��18(�6�   5:      5<      5=      