   M S B A M L   `   `   `  ����H  DBookingClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:BookingClient.PagesBookingClient.Pages  5      (    "BookingClient.Pages.InclusionsPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:BookingClient.Pages     5      -   5          N� Title$  InclusionsPage��5	       N� 
Background �#CACACA � 	Resources 5         DarkStandartButton �� 
TargetType �� BasedOn  	AddButton  
CopyButton  
EditButton  DeleteButton��%�   &	        7   &	 "     7  &	 D     7  &	 f     7  &	 �     7  �� 5   
   " ��6+   8   6?   �� 5   
   " ��6"   8   66   �� 5   
   " ��6#   8   67   �� 5   
   " ��6#   8   67   �� 5   
   " ��6%   8   69   5      .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $
��Auto �6   �� 5      -   5         ��Name$ RecordChangeBlock��5   ,   $
��auto �6   6,   .+�5   
   �  � RowDefinitions 5      �� 5      $
��auto �6    �� 5      .+�5"      �� -   5         ��Name$ ChangePanel��5"   f   $��79��6   $��0��6!   $��3 3 3 0q�6.   	 �� CornerRadius$	 20��6?   ���#DDDDDD._�5#      ]� $
��16 0q�6   .+�5$      �� -   5        
 ��Name$
 AddRecordButton��5&      #��[  5%      $��Добавить��5'      $��0 0 12 0q�5)      �� 5+      -   5        $
 CopyRecordButton��5-      #��[  5,      $��Копировать��5.      $��0 0 12 0q�50      �� 52      -   5        $
 EditRecordButton��54      #��[  53      $��Изменить��55      $��0 0 12 0q�57      �� 59      -   5        $
 DeleteRecordButton��5;      #��[  5:      $��Удалить��5<      $��0 0 12 0q�5>      �� 5@      -   5         ��Name$ FilterComboBox��5A      $	��180��5B      $��0 0 12 0q�5D      �� 5F      -	   5         ��Name$ FilterTextBox��5H        SearchTextBox#��[ 5G      5I      5K      5L      &   System.Windows.Controls.DataGrid  5N      -
   5          Name$ RecordsDataGrid��5Q      $��14q�5O         
IsReadOnly . $��1��5R         AutoGenerateColumns .     CanUserAddRows .    Columns 5V      0  *System.Windows.Controls.DataGridTextColumn  5W      ,  &System.Windows.Controls.DataGridColumn   Header$ Включение��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6_   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6<   �� *inclusion_name+6_   5Y      5Z      �� 5\   
   -   5         ��Name$ DialogGridSplitter��5]      $��1��5^      $��Stretch=�5_      � 5a   
   -   5         �Name$ DlgPanel��5a   W   $��2��6   ���#DDDDDD$	��270��64   $y�	Collapsed=�6@    5b      �� 5c      $��80 �6    �� 5d      �� 5e      $
��auto �6    .+�5h      �� -   5         ��Name$ RecordChangeTitle��5j      $��24(�5i      $
��None��5k      $��Center=�5l      $��Center=�5m      �� 5o      $��1��6   .��5p      �� $��	10,0,10,0q�5q       �� Orientation$ Vertical=�5r      .+�5t      �� $)��#Название включения��6   �� 5u      -   5        $ InclusionNameTextBox��5u      5w      5x      � 5z      $��2��5{      $��30��5|      $��	10,0,10,0q�5}       5      �� 5�      �� 5�      .+�5�      �� -   5        $
 CommitChangeRecordsButton��5�        AcceptButton#��[ 5�      $��0��5�      $��Принять��5�      $��0,0,5,0q�5�      5�      �� 5�      -   5        $!
 RollbackChangeRecordsButton��5�        CancelButton#��[ 5�      $��1��5�      $��Отменить��5�      $��5,0,0,0q�5�      5�      5�      5�      5�      5�      