   M S B A M L   `   `   `  ����b  ^Nilay_ST10082679_PROG7312_WPF_FINAL_POE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulla5clr-namespace:Nilay_ST10082679_PROG7312_WPF_FINAL_POE'Nilay_ST10082679_PROG7312_WPF_FINAL_POE  5   	   9    3Nilay_ST10082679_PROG7312_WPF_FINAL_POE.LocalEvents   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Glocal5clr-namespace:Nilay_ST10082679_PROG7312_WPF_FINAL_POE     5   	   -   5          � Title$  LocalEvents��5	   	   $	��800��6   $
��1200��6*   $	��600��67   .��5      �� $
��Auto=�6   $��Disabled=�66   .��5   
   � ��5      �� 5       �� ImageSource$ /Assets/BImage.jpg��6    � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6     � ColumnDefinitions 5      �� 5      -   5         ��Name$ FirstColumn��5   -   $��* �6#   6-   �� 5      -   5        $ SecondColumn��5   -   $��* �6#   6-   .+�5      �� -   5         ��Name$ 
lblHeading��5   (   $��2��6   $$��Local Events and Announcements��6<   
�������$
��Left=�5       $��Center=�6/   $��20(�6J   $
��Bold"�6X   $��	364,0,0,0q�6j   $��36��6}   $	��324��6�   �� 5"      $��1��6   $��0��6&    �� Orientation$ Vertical=�66   $��	10,0,2,10q�6M   .+�5#      �� -   5        $ lblSearchByCategory��5#      $��Search by Category:��65   $
��Bold"�6S   $��14(�6e   $��0,0,0,10q�6s   $	��154��6�   
�������6�   �� 5$      -   5         ��Name$ txtSearchByCategory��5$      $	��200��67   $��25��6C   ���	#FFC4CCDE$��0,0,0,10q�6f   $��Center=�6x   �� 5%      -   5        $ lblSearchByDate��5%      $��Search by Date:��61   $
��Bold"�6K   $��14(�6]   $��	0,10,0,10q�6k   $	��131��6~   
�������6�   (  "System.Windows.Controls.DatePicker  5&      -   5          Name$  dateTimePickerSearchByDate��5&      $	��200��6A   $��25��6M   ���	#FFC4CCDE$��0,0,0,10q�6p   $��Center=�6�   �� 5'      -	   5        $��	btnSearch��5'   *   $��Search��6   $��80��6;   $��30��6F   $��0,10,0,0q�6R   
����  ����	#FF5BA4A2$
��Bold"�5(   [   $��14(�6m   $��Center=�6{   ��5)      �� 5*      	 �� 
TargetType"	 ��6*   .R�5+      �� 
 �� CornerRadius$
 15��6%   #��z��67   #��z��6a   #��z��6�   ._�5,   "   �� $��Center=�63   $��Center=�6P   5-      5.      50      51      �� 53      -
   5        $ 	lblEvents��53   !   $��1��6   $��Events:��64   $
��Bold"�6F   $��18(�6X   $
��Left=�6f   $��10,207,0,10q�6�   $��70��6�   $��2��6�   
�������6�   �� 54      $��2��6   $
��Auto=�6(   $��Disabled=�6K   $��10,48,10,25q�6t   
�������$	��200��6�   .��55      �� -   5         ��Name$ stackPanelEvents��55      $ Vertical=�67   $��Center=�6N   56      �� 58      -   5        $ lblRecommendedEvents��58   1   $��3��6   $��0��6!   $��Recommended Events:��6O   $
��Bold"�6m   $��18(�6   $
��Left=�6�   $��10,10,0,175q�6�   $	��206��6�   
�������6�   &   System.Windows.Controls.DataGrid  59      -   5          Name$ dataGridRecommendedEvents��59   $   $��3��6      AutoGenerateColumns .     CanUserAddRows .  
�������$��10,44,10,38q�6�      Columns 5:      0  *System.Windows.Controls.DataGridTextColumn  5;      ,  &System.Windows.Controls.DataGridColumn   Header$
 Name��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$	 110 6P   1  +System.Windows.Controls.DataGridBoundColumn   Binding 67   �� *Name+6P     5<      $ Description��6)   $	 350 6^    6>   �� *Description+6^     5=      $
 Date��6)   $	 100 6i    67   �� *Date+ �� StringFormat$ 
yyyy-MM-dd��6i     5>      $ Duration��6)   $ 80 6X    6;   �� *
Duration+6X     5?      $ Category��6)   $	 100 6X    6;   �� *
Category+6X   5A      �� 5C      -   5        $ stackPanelRight��5C      $��1��62   $��1��6?   $��3��6O   $ Vertical=�6`   $��
48,0,0,100q�6w   $
��Left=�6�   .+�5D      �� -   5        $ lblUniqueCategories��5D      $��Unique Categories:��65   $
��Bold"�6R   $��18(�6d   $
��Left=�6r   $��0,10,0,5q�6�   
�������6�   �� 5E      -   5         ��Name$ listBoxUniqueCategories��5E      $	��241��6;   $��98��6G   
�������6i   �� 5F      -   5        $ lblTopSearches��5F      $��Top 5 Searches:��60   $
��Bold"�6J   $��18(�6\   $
��Left=�6j   $��0,20,0,5q�6�   
�������6�   �� 5G      -   5        $ listBoxTopSearches��5G      $	��250��66   $��81��6B   
�������6O   5H      �� 5J      -   5         ��Name$ btnBackToMainMenu��5J   2   $��0��6   $��0��6"   $��Back To Main Menu��6M   $
��Left=�6i   $��	10,10,0,0q�6�   $	��Top=�5K      $��34��6-   $	��132��69   
����  ����	#FF87D2DC$
��Bold"�6�   ��5L      �� 5M      "	 ��6&   .R�5N      �� $
 15��6!   #��z��63   #��z��6]   #��z��6�   ._�5O      �� $��Center=�6/   $��Center=�6L   5P      5Q      5S      5T      5U      5V      