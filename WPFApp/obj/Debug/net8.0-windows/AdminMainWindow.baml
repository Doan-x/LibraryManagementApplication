   M S B A M L   `   `   `  ����A  =WPFApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:WPFAppWPFApp  5   	       WPFApp.AdminMainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:WPFApp     5   	     � Title$  AdminMainWindow��5   	   $	��450��6!   $	��800��6.   .��5	      � $��	170,0,0,0q�6   $
��Left=�6   $��Center=�69   $	��504��6T   $	��191��6`    � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� -   5        $��ManageUsers��5   @   $��Manage Users��6   $	��200��6(   $��50��64   6S   �� 5   
   -   5        $��ManageBooks��5   @   $��Manage Books��6   $	��200��6(   $��50��64   $��1��6n   �� 5   
   -   5        $��BorrowRecords��5   O   $��Borrow Records��6   $��1��6*   $	��200��67   $��50��6C   $��	0 16 16 0q�6d   6w   �� 5   
   -   5        $��Reservations��5   d   $��Browse reservations��6   $��1��6/   $��1��6<   $	��200��6L   $��50��6X   $��	16 16 0 0q�6x   6�   5      5      