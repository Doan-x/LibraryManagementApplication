   M S B A M L   `   `   `  ����A  =WPFApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:WPFAppWPFApp  5   	       WPFApp.BookManagement   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:WPFApp     5   	     � Title$  BookManagement��5   	   $	��450��6    $
��1000��6-   .��5	      � .+�5   
   � $��10,0,7,0q�6   $��1��6!    � RowDefinitions 5      �� 5      $
��Auto �6    $��30��6.   �� 5      $
��Auto �6    $��30��6.   �� 5      $
��100* �6    �� 5      $
��Auto �6    $��30��6.   .+�5      �� $
��Bold"�6   $��24(�6&   $��0,10,0,0q�64   ���	#FFCE1616.��6]   Manage Book6j   �� 5       �� Orientation$ Vertical=�6   $��1��60   .+�5      �  � ColumnDefinitions 5      �� 5      $
��92.6 �6+   �� 5      $��336.4 �6+   �� 5      $
��auto �6+   $	��100��68   �� 5      $��* �6+   .+�5      �� $ 
Horizontal=�6!   $��Center=�6:   $��2��6W   .+�5      �� -   5        $��	txtSearch��5   "   $	��300��63   �� 5      -   5        $��	btnSearch��5   2   $��Search��6!   $	��119��6C   $��10,0,0,0q�6O   6a   5      �� 5!      -   5        $��btnAdd��5!      $��New Book��6+   $��31��6?   $	��100��6K   $��3��6W   $
��Left=�6|   $��	154,0,0,0q�6�   5"      5#      &   System.Windows.Controls.DataGrid  5%      -   5          Name$ dgBooks��5%   *      
IsReadOnly$
 True��6      AutoGenerateColumns$ False��6;   $��2��6W   $��0,10,0,0q�6d      Columns 5&      0  *System.Windows.Controls.DataGridTextColumn  5'      ,  &System.Windows.Controls.DataGridColumn   Header$ Book Id��6)   	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 * 6Z   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6:   �� *book.BookId+6Z     5(      $ Title��6)      MinWidth$	 100Q�6W   
 68   �� *
book.Title+6W     5)      $ Author��6)   $	 * 6Y   
 69   �� *book.Author+6Y     5*      $ Price��6)   $	 * 6W   
 68   �� *
book.Price+6W     5+      $ Category��6)   $	 * 6j   
 6;   �� *book.Category.CategoryName+6j     5,      $ Quantity��6)   $	 * 6]   
 6;   �� *book.Quantity+6]     5-      $ 
Date Added��6)   $	 * 6`   
 6=   �� *book.DateAdded+6`     5.      $ 	Borrowing��6)   $	 * 6Z   
 6<   �� *	Borrowing+6Z   4  .System.Windows.Controls.DataGridTemplateColumn  50      $
 Edit��6-   $	 * 6;      CellTemplate 51      �� 52      .R�53   "   ��  ��Name$ btnEdit��6)   -   5        $�� Edit ��53   :   $��Center=�6a   $��50��6~   6�   54      57        58      $ Delete��6-   $	 * 6=    59      �� 5:      .R�5;   "   �� $ 	btnDelete��6)   -   5        $�� Delete ��5;   <   $��Center=�6g   $��50��6�   6�   5<      5>      5@      5B      5C      5D      