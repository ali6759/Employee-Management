   M S B A M L   `   `   `  ����P  LWpfEmployeeManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:WpfEmployeeManagementWpfEmployeeManagement  5   	   &     WpfEmployeeManagement.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:WpfEmployeeManagement     5   	   -   5          � Title$  Employees Management��5   	   $	��700��6&   $
��1200��63   .��5	      � $��0,0,10,0q�6    � ColumnDefinitions 5
   
   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��2q�6!   
�������$	��250��6D   $��Center=�6P   $��2q�6m   
�������._�5      �� .+�5      �� -   5        $��btnEmployes��5   j   $��20,65q�6   ���#3E454C$��50��6=   
�������$��28(�6\   .��6�   	Employees6�   �� 5      -   5        $��	btnSearch��5   j   $��20,70q�6   ���#3E454C$��50��6=   
�������$��28(�6\   .��6�   Search6�   �� 5      $
��10,0q�6   $	��251��6&   $	��150��63   $��Resources/logo.jpg��6?    J� RenderTransformOrigin$ 	0.5,0.068&�6[   5      5      �� 5   
   -   5        $��	HomePanel��5   Y   $��1��6   $��2q�6!   $y�Visible=�6,   
�������$��Stretch=�6j   $��2q�6�   
�������._�5      �� $��Stretch=�6   .+�5      �� $��42(�6   $��0,50,0,0q�6&   $��Heavy"�68   $��Center=�6K   $��Times New Roman)�6h   .��6�   &$Welcom to Employee Management System6�   �� 5      $��Resources/search.jpg��6   $	��551��66   �� 5      -   5         ��Name$
 test��5      $��Label��6&   5      5      �� 5   
   -   5        $��EmployeesPanel��5   [   $��1��6   $��2q�6!   $y�	Collapsed=�6,   
�������$��Stretch=�6q   $��2q�6�   
�������._�5      �� $��Stretch=�6   ���#EFA82D$��15q�6L   .+�5       &   System.Windows.Controls.DataGrid  -   5        $��EmployeesGrid��5    &   $��5q�6      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6;      CanUserAddRows .     MinColumnWidth$	 100Q�6b      CanUserResizeColumns . 5"      � 5#      $��5q�6    � RowDefinitions 5$      �� 5%      $	��150 �6(   �� 5&      $��* �6(   .+�5(      � $��5q�6    $��0��6+   .+�5)      �� $��2q�6    $
��Bold"�6+   .��6=   Detailed Info:6N   �� 5*      -   5        $��EmployeeLable��5*   9   $��2q�6    $	��---��6+   6P   5,      ]� 5-      $��Center=�6    $��20q�6=   $��1��6I   .+�5.      �� -	   5        $��btnAddEmployee��5.   ]   $��10q�6!   $��50��6-   $	��150��69   
�������.��6�   Add Employee6�   �� 5/      -
   5        $��btneleteEmployee��5/   ]   $��10q�6!   $��50��6-   $	��150��69   
�������.��6�   Delete6�   �� 50      -   5        $��btnEditEmployee��50   ]   $��10q�6!   $��50��6-   $	��150��69   
�������.��6�   Edit6�   51      53      55      57      58      59      