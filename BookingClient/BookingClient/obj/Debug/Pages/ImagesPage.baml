   M S B A M L   `   `   `  ????H  DBookingClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:BookingClient.PagesBookingClient.Pages  5      $    BookingClient.Pages.ImagesPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:BookingClient.Pages     5        N? Title$  
ImagesPage??5	       N? 
Background
 ????? ? 	Resources 5         listTemplate ?? BitmapScalingMode ?? Path??%|   &	        ?? 5   
   .R?5      ?? $	??280??5      $ HighQuality=?5      ??5      ?? $	 img?5      5      .??5      ?  ? ColumnDefinitions 5   
   ?? 5      $??* ?6   ?? 5      $
??auto ?6   ?? 5      $??* ?6   .+?5   
   ? $??0??6    ? RowDefinitions 5      ?? 5      $??36 ?6    ?? 5       ?? 5!      $
??Auto ?6    ?? 5"      $	??140 ?6    $	??140??6-   .+?5%      ?? -   5        $??image??5'      $??1??5&      $ HighQuality=?5(      ?? 5*       ?? Orientation$ 
Horizontal=?6   .+?5+      ?? -   5         ??Name$ AddRecordButton??5,        	AddButton#??[ 5-      	 ? ToolTip$	 Добавить??5.      5/      ?? 51      -   5        $ EditRecordButton??52        
EditButton#??[ 53      $ 	 Редактировать??54      55      ?? 57      -   5        $ DeleteRecordButton??58        DeleteButton#??[ 59      $	 Удалить??5:      5;      5=      ?? 5@      -   5        
 ??Name$
 GridSplitter??5A      $??2??5B      $??Center=?5C      $??Stretch=?5D      $??3??5E      
???????5F      ? 5I      $??3??6   .+?5K      ?? -   5         ??Name$ imgList??5L      #??[  5N      $??Visible=?5O      $??Disabled=?5P      $	??140??5R      ??5M      ??  ?? ElementName$ RecordsDataGrid??$ SelectedItem.tours???5S      ?? 5T      .R?5U      ? 5V      5X      5Y      5Z      ?? 5\   
   -   5        $
 DialogGridSplitter??5]      $??1??5^      $??Stretch=?5_      $??3??5`      
???????5a      ? 5d   
   $??2??6    5e      ?? 5f      $??36 ?6    ?? 5g      .+?5j      ]? .+?5k      ?? -   5         ??Name$ FilterComboBox??5l      $	??180??5m       ?? 
IsEditable . 5o      ?? 5q      -	   5         ??Name$ FilterTextBox??5r        BaseTextBox#??[ 5s      
 ? Tag$ 
Поиск??5t      5u      5w      &   System.Windows.Controls.DataGrid  5y      -
   5          Name$ RecordsDataGrid??5z      $??1??5{         AutoGenerateColumns .     CanUserAddRows .     Columns 5?      0  *System.Windows.Controls.DataGridTextColumn  5?      ,  &System.Windows.Controls.DataGridColumn   Header$ Тур??6)      Width5  /System.Windows.Controls.DataGridLengthConverter$	 12* 6T   1  +System.Windows.Controls.DataGridBoundColumn   Binding 66   ?? *	tour_name+6T     5?      $# Начальный город??6)   $ 5* 6g    6B   ?? *cities.city_name+6g     5?      $! Конечный город??6)   $ 5* 6f    6A   ?? *cities.city_name+6f     5?      $ Цена??6)   $ 3* 6Q    67   ?? *price+6Q     5?      $ Дни??6)   $ 2* 6T    66   ?? *	day_count+6T     5?      $ Размер группы??6)   $ 3* 6c    6@   ?? *max_group_size+6c   5?      5?      5?      5?      