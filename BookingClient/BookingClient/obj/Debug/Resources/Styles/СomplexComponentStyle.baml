   M S B A M L   `   `   `  ����R  NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   bool2VisibilityConverter  �� 
TargetType �� 
ResourceId �� TypeInTargetAssembly&    System.Windows.Controls.DataGrid �� Property �� Value �� 
TargetType'  !System.Windows.VisualStateManager   VisualStateGroups%  System.Windows.VisualStateGroup   States   System.Windows.VisualState   
Storyboard	 �� 
TargetName
 �� TargetProperty8  2System.Windows.Media.Animation.EasingColorKeyFrame �� KeyTime �� Value R� KeyTime  System.Windows.Visibility   	Collapsed R� Value ��Name J� SnapsToDevicePixels �Name J� Opacity � Points �� Stretch  
GlyphColor �� Color ��Name �� CornerRadius �� Padding ��Name � ColumnDefinitions � RowDefinitions    SelectAllCommand7  1System.Windows.Controls.DataGridHeadersVisibility
   All �� ConverterParameter!     HeadersVisibilityConverter! �� 	Converter" �� RelativeSource# �� AncestorTypeG  ASystem.Windows.Controls.Primitives.DataGridColumnHeadersPresenter$  Name%   Column& ��Name' �� CanContentScroll( ��Name) �� Orientation* �� ViewportHeight+ �� ViewportSize, �� ScrollableHeight- � Maximum*. �� #ComputedVerticalScrollBarVisibility/ � Value0 �� Mode1 �� ViewportWidth2 �� ScrollableWidth,3 �� %ComputedHorizontalScrollBarVisibility4 �� Triggers5 P� Property6 P� Value*  $System.Windows.Controls.DataGridCell)	  #System.Windows.Controls.DataGridRow?
  9System.Windows.Controls.Primitives.SelectiveScrollingGrid?  9System.Windows.Controls.Primitives.DataGridCellsPresenter7 	  
ItemsPanelA  ;System.Windows.Controls.Primitives.DataGridDetailsPresenter8 	  DetailsVisibility$9 
  SelectiveScrollingOrientation;  5System.Windows.Controls.SelectiveScrollingOrientation:   Vertical#;    RowDetailsScrollingConverter:  4System.Windows.Controls.Primitives.DataGridRowHeader
<   Row  RowHeaderGripperStyle= �� Orientation> n�Name  ColumnHeaderGripperStyle=  7System.Windows.Controls.Primitives.DataGridColumnHeader?  Name@ J� IsHitTestVisible�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     :x,http://schemas.microsoft.com/winfx/2006/xaml      5      %�*  &	        (��      5   )   $" DataGridSelectAllButtonStyle��"   )'   m    '  S    '	  3    &	 �    '  �    7   7  7  &	 �%    '  �&    7  7  '  9)    �� 5      6#   �� 5      "  ��6   .�5	   
   ��  � �� 5
      �� 5      " ��6"   .R�5      �  5        5      CommonStates��. 5   "     
Normal��6.     5   "   	MouseOver��. 5   &   �� .��5   *   �� $	 Border��5   -   $*
 $(Shape.Fill).(SolidColorBrush.Color)�5   -   .g�5   .     $ 0��6B   $ #66C04F��6N   5   +   5   '   5   #     5   "   Pressed��. 5   &   �� .��5   *   �� $	 Border��5   -   $*
 $(Shape.Fill).(SolidColorBrush.Color)�5   -   .g�5   .     $ 0��6B   $ #66C04F��6N   5   +   5    '   5!   #     5"   "   Disabled��. 5#   &   �� .��5$   *   T� $
 (UIElement.Visibility)�6H   $	 Arrow��6{   ..�5%   .   i� $ 0��6E   # Z 6Q   5&   +   5'   '   5(   #   5)      .+�5,      �� $ Border��6$    . 
������ 5-      � 5/      $ Arrow��50      $��Right=�51      $��8,8,3,3q�52      $
 0.15Q�53       �   ��� ��� ��� ��� $ Uniform=�55      $��Bottom=�56      ��57      �� 58   "   # �  62   5:      5;      5<      5>      5?      �� 5B      "    6   .�5C   
   ��  � ��
 �   �6'   �� 5D   
     �@  RowDetailsVisibilityMode$ VisibleWhenSelected=�65   �� 5E   
    � �� . 6:   �� 5F   
    �@��PanningMode$
 Both=�65   �� 5G   
    �@��IsFlicksEnabled .  63   �� 5H   
     �@  AlternatingRowBackground
 �  ��65   �� 5I   
    � ��$ 0q�6,   �� 5J   
    �@  ColumnHeaderHeight$ 22Q�6/   �� 5K   
    �@  MinRowHeight$ 20Q�6)   �� 5L   
    �@  	RowHeight$ 20Q�6&   �� 5M   
     �@  HorizontalGridLinesBrush
 ���� 65   �� 5N   
    �@  VerticalGridLinesBrush �#DDDDDD63   �� 5P   
    � �� 5Q      �� 5R      "   6"   .R�5S      �� $ border��5V      ���#DDDDDD$ 20��5U       . #��z��5X      #��z��5Y      # z��5Z       5[        5\      CommonStates��. 5]   "     Disabled��. 5^   &   �� .��5_   *   �� $	 border��5`   -   $0
 *(Panel.Background).(SolidColorBrush.Color)�5a   -   .g�5b   .     $ 0��6B   $ Black��6N   5c   +   5d   '   5e   #     5f   "   
Normal��6.   5g      ._�5i      �� $ DG_ScrollViewer��5j      |�.  
���   ���5m      �� 5n   "   " ��62   .R�5o   &   �  5p   *   �� 5q   .   $
��Auto �6?   �� 5r   .   $��* �6?   �� 5s   .   $
��Auto �6?    5u   *   �� 5v   .   $
��Auto �6<   �� 5w   .   $��* �6<   �� 5x   .   $
��Auto �6<   .+�5{   *   �� |�.  #��Z 5}   -   ��5~   -   C� *�� $" DataGridSelectAllButtonStyle��"   +y�5   -   �� *HeadersVisibility+# Z #! Z  " �� "#   ��5�   -   �� *CellsPanelHorizontalOffset+" �� "#     5�   *   $!$ PART_ColumnHeadersPresenter��5�   -   $��1��5�   -   y�5�   -   �� *HeadersVisibility+# Z% #! Z  " �� "#   �� 5�   *   $!& PART_ScrollContentPresenter��5�   -   $��2��5�   -   $��1��5�   -   #' z��5�   -   �� 5�   *   $( PART_VerticalScrollBar��5�   -   $��2��5�   -   $��1��5�   -   $) Vertical=�5�   -   #+ z* 5�   -   #- z, 5�   -   #y�z. 5�   -   / 5�   -   �� *VerticalOffset+$0 OneWay=�" �� *TemplatedParent+� 5�   *   $��1��5�   -   $��2��5�   -    5�   .   �� 5�   2   ��5�   5   �� **(NonFrozenColumnsViewportHorizontalOffset+" �� "#   �� 5�   2   $��* �6C   .+�5�   .   �� $( PART_HorizontalScrollBar��5�   1   $��1��5�   1   $) 
Horizontal=�5�   1   #+ z1 5�   1   #- z2 5�   1   #y�z3 5�   1   / 5�   1   �� *HorizontalOffset+$0 OneWay=�" �� *TemplatedParent+5�   +   5�   '   5�   #   .��5�      �� # z 6-   5�      5�      5�      5�      4 5�   
   P� 5�      5 �@��
IsGrouping6 . . �5�      ��  � �� .  6B   5�      5�      �� 5�      "   6   .�5�   
   ��  � �� 5�      �� 5�      "  6"   .R�5�      �� $ border��5�      
������ 
������  .  5�        5�      FocusStates��. 5�   "     	Unfocused��6.     5�   "   Focused��6.   5�        5�      CurrentStates��. 5�   "     Regular��6.     5�   "   Current��6.   5�      ._�5�      �� # z 6+   $��Center=�6g   $��Center=�6�   5�      5�      5�      5�      �� 5�      "  	 6   .�5�   
   ��  � �� �#4DA3386'   �� 5�   
    �@J�SnapsToDevicePixels . 60   �� 5�   
    �@=�ErrorTemplate 65   Z� �� 5�   
    �@	 ValidationErrorTemplate 5�      �� 5�      .R�5�      �� 
���  ��$��2,0,0,0q�5�      $��!��5�      $��Center=�5�      5�      5�      �� 5�   
    � �� 5�      �� 5�      " 	 6"   .R�5�      �� $ 
DGR_Border��5�      #��z��5�      #��z��5�       . ���#D1D0D0 5�        5�      CommonStates��. 5�   "     
Normal��6.     5�   "   Normal_AlternatingRow��. 5�   &   �� .��5   *   �� $	 
DGR_Border��5  -   $0
 *(Panel.Background).(SolidColorBrush.Color)�5  -   .g�5  .     $ 0��6B   $ #9F9F9F��6N   5  +   5  '   5  #     5  "   Normal_Selected��. 5  &   �� .��5  *   �� $	 
DGR_Border��5  -   $0
 *(Panel.Background).(SolidColorBrush.Color)�5  -   .g�5  .     $ 0��6B   $ #4DA338��6N   5  +   5  '   5  #     5  "   Unfocused_Selected��. 5  &   �� .��5  *   �� $	 
DGR_Border��5  -   $0
 *(Panel.Background).(SolidColorBrush.Color)�5  -   .g�5  .     $ 0��6B   $ #4DA338��6N   5  +   5  '   5   #     5"  "   Normal_Editing��. 5#  &   �� .��5$  *   �� $	 
DGR_Border��5%  -   $0
 *(Panel.Background).(SolidColorBrush.Color)�5&  -   .g�5'  .     $ 0��6B   $ #4DA338��6N   5(  +   5)  '   5*  #     5,  "   MouseOver_Editing��. 5-  &   �� .��5.  *   �� $	 
DGR_Border��5/  -   $0
 *(Panel.Background).(SolidColorBrush.Color)�50  -   .g�51  .     $ 0��6B   $ #4DA338��6N   52  +   53  '   54  #     56  "   MouseOver_Unfocused_Editing��. 57  &   �� .��58  *   �� $	 
DGR_Border��59  -   $0
 *(Panel.Background).(SolidColorBrush.Color)�5:  -   .g�5;  .     $ 0��6B   $ #4DA338��6N   5<  +   5=  '   5>  #     5@  "   Unfocused_Editing��. 5A  &   �� .��5B  *   �� $	 
DGR_Border��5C  -   $0
 *(Panel.Background).(SolidColorBrush.Color)�5D  -   .g�5E  .     $ 0��6B   $ #4DA338��6N   5F  +   5G  '   5H  #     5J  "   	MouseOver��. 5K  &   �� .��5L  *   �� $	 
DGR_Border��5M  -   $0
 *(Panel.Background).(SolidColorBrush.Color)�5N  -   .g�5O  .     $ 0��6B   $ #4DA338��6N   5P  +   5Q  '   5R  #     5X  "   MouseOver_Selected��. 5Y  &   �� .��5Z  *   �� $	 
DGR_Border��5[  -   $0
 *(Panel.Background).(SolidColorBrush.Color)�5\  -   .g�5]  .     $ 0��6B   $ #66C04F��6N   5^  +   5_  '   5`  #     5b  "    MouseOver_Unfocused_Selected��. 5c  &   �� .��5d  *   �� $	 
DGR_Border��5e  -   $0
 *(Panel.Background).(SolidColorBrush.Color)�5f  -   .g�5g  .     $ 0��6B   $ #66C04F��6N   5h  +   5i  '   5j  #   5k     ._�5n     
   5o     �� 5p  "   $
��Auto �63   �� 5q  "   $��* �63    5s     �� 5t  "   $��* �60   �� 5u  "   $
��Auto �60   .+�5w       $��1��5x  !   #��z7 5y  !   # z 5z  !     5{     $��1��5|  !   $��1��5}  !   #y�z8 5~  !   9 5  !   �� *AreRowDetailsFrozen+# Z: #! Z; " �� "#     5�     $��2��5�  !   $9 Vertical=�5�      y�5�      �� *HeadersVisibility+# Z< #! Z  " �� "#   5�     5�     5�     5�     5�     �� 5�     "  n�6*   .�5�  
   ��  � ��$ 22��6#   �� 5�  
    � ��
 ���� 6'   �� 5�  
    �@�Cursor$ SizeNS��6#   �� 5�  
    � �� 5�     �� 5�     " n�6"   .R�5�     �� #��z��5�     # z��5�     5�     5�     5�     �� 5�     "   6   .�5�  
   ��  � �� 5�     �� 5�     "  6"   .R�5�     �  5�       5�     CommonStates��. 5�  "     
Normal��6.     5�  "   Normal_CurrentRow��6.     5�  "   Unfocused_EditingRow��6.     5�  "   Normal_EditingRow��6.     5�  "   	MouseOver��. 5�  &   �� .��5�  *   �� $	 rowHeaderBorder��5�  -   $0
 *(Panel.Background).(SolidColorBrush.Color)�5�  -   .g�5�  .     $ 0��6B   $ #4DA338��6N   5�  +   5�  '   5�  #     5�  "   MouseOver_CurrentRow��6.     5�  "   "MouseOver_Unfocused_EditingRow��6.     5�  "   MouseOver_EditingRow��6.     5�  "    MouseOver_Unfocused_Selected��6.     5�  "   MouseOver_Selected��6.     5�  "   +'MouseOver_Unfocused_CurrentRow_Selected��6.     5�  "   !MouseOver_CurrentRow_Selected��6.     5�  "   Unfocused_Selected��6.     5�  "   !Unfocused_CurrentRow_Selected��6.     5�  "   Normal_CurrentRow_Selected��6.     5�  "   Normal_Selected��6.   5�     .+�5�     �� $ rowHeaderBorder��5�     $��10��5�     
������ ._�5�     �� $= 
Horizontal=�6)   .+�5�  "   �� # z 5�  %   �� 5�  "    .  ��5�  %   �� *ValidationErrorTemplate+" �� "# 	 y�5�  %   �� *(Validation.HasError)+8!   " �� "# 	 5�     5�     n� 5�     $> PART_TopHeaderGripper��5�     8�� $	��Top=�5�     n� 5�     $> PART_BottomHeaderGripper��6    8�� $��Bottom=�5�     5�     5�     5�     5�     �� 5�     "  n�6-   .�5�  
   ��  � ��$ 8��6"   �� 5�  
    � ��
 ���� 6'   �� 5�  
    �@�Cursor$ SizeWE��6#   �� 5�  
    � �� 5�     �� 5�     " n�6"   .R�5�     �� #��z��6   # z��6G   5�     5�     5�     �� 5�     "   6   .�5�  
   ��  � ��$ Center=�65   �� 5�  
    � �� 5�     �� 5�     "  6"   .R�5�     � .+�5�     �� $ columnHeaderBorder��5�     $��0 0 1 0q�5�     ���#D1D0D0
������ ._�5     �� $��Center=�5  !   # z 5  !   $��Center=�5  !   5     n� 5     $> PART_LeftHeaderGripper��5     $
��Left=�5	     8��  5
     n� 5     $> PART_RightHeaderGripper��5     $��Right=�5     8�� 5     5     5     5     �� 5  
    � ��
 �  ��5     5     �� 5     "   6   .�5  
   ��  � �� 5     �� 5     "  6"   .R�5     � .+�5       $? PART_FillerColumnHeader��5     @ .  5      �� 5!     5"     5#     5%     5&     5)     