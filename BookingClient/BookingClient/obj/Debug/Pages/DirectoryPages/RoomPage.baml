   M S B A M L   `   `   `  ����H  DBookingClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:BookingClient.PagesBookingClient.Pages  5      "    BookingClient.Pages.RoomPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:BookingClient.Pages     5      -   5          N� Title$  RoomPage��5	       N� 
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
IsReadOnly . $��1��5R         AutoGenerateColumns .     CanUserAddRows .    Columns 5V      0  *System.Windows.Controls.DataGridTextColumn  5W      ,  &System.Windows.Controls.DataGridColumn   Header$ Тур��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$	 10* 6Z   1  +System.Windows.Controls.DataGridBoundColumn   Binding 66   �� *tours.tour_name+6Z     5X      $2 ,Краткое описание номера��6)   $	 10* 6h    6J   �� *	room_name+6h     5Y      $ Кровати��6)   $ 80 6Y    6:   �� *
beds_count+6Y     5Z      $ Цена��6)   $ 80 6Q    67   �� *price+6Q   5\      5]      � 5_   
   -   5         �Name$ DlgPanel��5_   W   $��2��6   ���#DDDDDD$	��270��64   $y�	Collapsed=�6@    5`      �� 5a      $��80 �6    �� 5b      �� 5c      $
��auto �6    .+�5f      �� -   5         ��Name$ RecordChangeTitle��5h      $��24(�5g      $
��None��5i      $��Center=�5j      $��Center=�5k      �� 5n      $��1��6   .��5o      �� $��	10,0,10,0q�5p       �� Orientation$ Vertical=�5q      .+�5t      �� $��Название тура��6   �� 5u      -   5        $ TourNameComboBox��5v       �� DisplayMemberPath$ 	tour_name��5w       �� 
IsEditable . 5x      �� 5z      $#��Описание номера��6   �� 5{      -   5        $ RoomNameTextBox��5{      �� 5}      $+��%Количество кроватей��6   �� 5~      -   5        $ BedsCountTextBox��5~      �� 5�      $��Цена за номер��6   �� 5�      -   5        $ PriceTextBox��5�      5�      5�      �� 5�      $��79��5�      $	 20��5�      ���#D1D0D0$��3��5�      $��3q�5�      ._�5�      �� $ 
Horizontal=�6   $
��16 0q�66   .+�5�      �� -   5        $
 CommitChangeRecordsButton��5�        LightStandartButton#��[ 5�      $��Принять��5�      $��0 0 12 0q�5�      �� 5�      -   5        $!
 RollbackChangeRecordsButton��5�      #��[ 5�      $��Отменить��5�      5�      5�      5�      5�      5�      5�      