   M S B A M L   `   `   `  ����A  =WPFApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:WPFAppWPFApp  5   	   !    WPFApp.UserManagementWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:WPFApp     5   	     � Title$  UserManagementWindow��5   	   $	��450��6&   $
��1200��63   .��5	      � $��10,0,7,0q�6    � RowDefinitions 5
   
   �� 5      $
��Auto �6   $��70��6*   �� 5      $
��Auto �6   $��3��6*   �� 5      $
��Auto �6   $��38.923��6*   �� 5      .+�5   
   �� $
��Bold"�6   $��24(�6"   $��0,10,0,0q�60   ���	#FFCE1616$��Manage User��6Y   �� 5   
    �� Orientation$ 
Horizontal=�6   $��2��6.   $��	0,0,0,321q�6;   $��2��6N   .+�5      �� $ 
Horizontal=�6   $	��651��62   .+�5      �� -   5        $��	txtSearch��5      $	��300��6+   $��0,0,20,0q�6:   $��Center=�6L   �� 5      -   5        $��	btnSearch��5      $��Search��6*   $��80��6;   $��Center=�6a   5      5      �� 5   
   $��1��6   $��	0,0,0,321q�6"   $��3��65   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dgUsers��5   &      
IsReadOnly$
 True��6      AutoGenerateColumns$ False��67   $��3��6S   $��0,10,0,0q�6`      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ UserId��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6U   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 65   �� *user.UserId+6U     5      $ Fullname��6%   $ * 6Y   	 67   �� *user.FullName+6Y     5      $ PhoneNumber��6%   $ * 6_   	 6:   �� *user.PhoneNumber+6_     5      $
 Cccd��6%   $ * 6Q   	 63   �� *	user.Cccd+6Q     5       $ Email��6%   $ * 6S   	 64   �� *
user.Email+6S     5!      $ BookBorrowing��6%   $ * 6Z   	 6<   �� *	borrowing+6Z     5"      $ Returnedbookslate��6%   $ * 6a   	 6@   �� *returnedLate+6a     5#      $ BookBorrowed��6%   $ * 6X   	 6;   �� *
borrowed+6X     5$      $ 	ErrolTime��6%   $ * 6\   	 68   �� *user.DateJoined+6\   4  .System.Windows.Controls.DataGridTemplateColumn  5%      $ Action��6)   $ * 69   
   CellTemplate
 5&      �� 5'      .R�5(      ��  ��Name$ 	btnDelete��6%   -   5        $�� Delete ��5(   8   $��Center=�6c   $��50��6�   6�   5)      5,      5/      51      52      