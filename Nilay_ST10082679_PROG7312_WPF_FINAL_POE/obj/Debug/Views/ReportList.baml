   M S B A M L   `   `   `  ����b  ^Nilay_ST10082679_PROG7312_WPF_FINAL_POE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulla5clr-namespace:Nilay_ST10082679_PROG7312_WPF_FINAL_POE'Nilay_ST10082679_PROG7312_WPF_FINAL_POE  5   	   8    2Nilay_ST10082679_PROG7312_WPF_FINAL_POE.ReportList   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Glocal5clr-namespace:Nilay_ST10082679_PROG7312_WPF_FINAL_POE     5   	     � Title$  
ReportList��5   	   $	��450��6   $	��800��6)   .��5	      ]� ��. ��5
   
   �� 5       �� ImageSource$ /Assets/BImage.jpg��6   .+�5   
   �� -   5         ��Name$ BtnBackToReportIssues��5      $��Back To Report Issues��60   $��Bottom=�6P   $��
0,10,10,10q�6h   $
��10,5q�6|   
����  ����	#FF87D2DC$��23��5   _   $	��174��6k   ��5      �� 5       �� 
TargetType" ��6"   .R�5      ��  �� CornerRadius$ 10��6   #��z��6/   $��1q�5      #��z��61   ._�5      �� $��Center=�6+   $��Center=�6H   5      5      5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ DashboardDataGrid��5      
�������   AutoGenerateColumns .  $	��207��5   /      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Location��6%   	   
IsReadOnly	 . 1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 67   �� *
Location+6T     5      $ Category��6%   	 . 
 67   �� *CategorySelection+6]     5      $ Description��6%   	 . 
 6:   �� *Description+6Z     5       $  Number of Documents/Images��6%   	 . 
 6I   �� *ImagesOrDocs.Count+6p   5"      5#      5$      