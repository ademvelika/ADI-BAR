   M S B A M L   `   `   `  ����@  <MYBAR, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:MYBAR.View.InventarMYBAR.View.Inventar  5      ;"clr-namespace:MYBAR.CustomControlsMYBAR.CustomControls  5      $    MYBAR.View.Inventar.FleteHyrje   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:MYBAR.View.Inventar     5      6control"clr-namespace:MYBAR.CustomControls     5      $��Stretch=�5	      $��Stretch=�6-     � 	Resources  5       �� 
TargetType �� Property �� Value �� 
TargetType ��Name �� Triggers P� Property P� Value	 �� 
TargetName 
  linear
 �� 
StartPoint �� EndPoint � SpreadMethod � ColorInterpolationMode � Color � Offset  ScrollBarTrackThumb �Name ��Name �� CornerRadius � RowDefinitions ]�Name ]� Thumb n�Name ]� IncreaseRepeatButton ��Name J� Opacity ]� DecreaseRepeatButton P� 
SourceName  ButtonSelectBrush  	DarkBrush �� Angle��%�  '��       &	  �    &	     '�� �    �� 5   
   " ��6   .�5      ��  � �� 5      �� 5      " ��6&   .R�5      � $��Panel��6   .+�5      �� $ ContentSite��6/   $��Center=�5   )   $��Center=�5   )   $��Header��5   )   $
��10,2q�5   )   5       5      P� 5       �@��
IsSelected . . �5   "   �� $	 Panel��6)    � ��
 ��·�6R   5      P� 5       �@��
IsSelected .  . �5   "   �� $	 Panel��6)    � ��
 �����6R   5      5      5!      5"      �� 5#   
   $	
 0,0&�5&      $	 0,1&�6   $	 Pad=�5'      $ SRgbLinearInterpolation=�6   .��5(      � $ 	#FFFFFFFF��6   $ 0Q�6-   � 5)      $ 	#FFC3C1C1��6   $ 1Q�6-   � 5*      $ 	#FFDFDFDF��6   $	 0.5Q�6-   5+      �� 5,   
   " n�5-   	   .�5.      ��  � �� 5/      �� 50      " n�6&   .R�51      � $
 Grid��6   .+�52      �� $��Stretch=�6(   $��Stretch=�53   !   $
��Auto��54   !   $
��Auto��55   !   
������ 56   !   �� 57      $ CornerScrollBarRectangle��6%   $ 5��58      $��Stretch=�59      $��Stretch=�5:      $
��Auto��5;      $
��Auto��5<      $��0,1,0,1q�5=      #��z��5>      5?       5@      P� 5A       �@�Tag$ 
Horizontal��5B   !   . �5C   "   �� $	 CornerScrollBarRectangle��6)    � ��$
 Auto��5E   !   �� 5F   "   $	 CornerScrollBarRectangle��6)    � ��$ 6��5H   !   5I      5K      5M      5N      �� 5O   
   " ��6   .�5P      ��  �@��IsFlicksEnabled .  5Q      �� 5R       � �� �#ADABAB5S      �� 5T       � ��
 ���� 5U      �� 5V       � ��$ 7��5W      �� 5X       � �� 5Y      �� 5Z      " ��6&   .R�5[      � $ GridRoot��6   $��7��5\      #��z��5]       5^      �� 5_   "   $��0.00001* �60   .+�5a      ]� $ 
PART_Track��6$   $��0��5b      ��. |�.   5e   "   n� 5f   &   $ Thumb��6,   #��z��5g   %   #���  5h   %    5j   "   �� 5k   &   $ PageUp��63   $��ScrollBar.PageDownCommand��5l   -   $ 0Q�5m   -   |�.  5n   -    5p   "   �� 5q   &   $ PageDown��63   $��ScrollBar.PageUpCommand��5r   -   $ 0Q�5s   -   |�.  5t   -   5v      5w       5x      P� 5y      $ Thumb��6&    �@J�IsMouseOver . . �5|   "   �� # �  6)   $	 Thumb��5}   !    � ��5~   !   5      P� 5�      $ Thumb��6&    �@n�
IsDragging . . �5�   "   �� # �  6)   $	 Thumb��5�   !    � ��5�   !   5�      P� 5�       � {� .  . �5�   "   �� $	 Thumb��6)    � y�$ 	Collapsed=�5�   !   5�      P� 5�       �@��Orientation$ 
Horizontal=�5�   !   . �5�   "   �� $	 GridRoot��6)    �@�LayoutTransform 5�   &   �� 5�   *   $	 -90Q�6:   5�   #   �� 5�   "   $	 
PART_Track��6)    �@�LayoutTransform 5�   &   �� 5�   *   $	 -90Q�6:   5�   #   �� 5�   "    � ��$
 Auto��5�   !   �� 5�   "    � ��$ 8��5�   !   �� 5�   "   $	 Thumb��6)    �@�Tag$ 
Horizontal��5�   !   �� 5�   "   $	 PageDown��6)    � ��$ ScrollBar.PageLeftCommand��5�   !   �� 5�   "   $	 PageUp��6)    � ��$  ScrollBar.PageRightCommand��5�   !   5�      5�      5�      5�      5�      .��5�      �  5�   
   �� 5�      $��2* �6   �� 5�      $��* �6    � ColumnDefinitions 5�   
   �� 5�      $��* �6   �� 5�      $��2* �6   .+�5�   
   � -   5        $��	LeftPanel��5�   8   ���#f4f4f7$��0��6'   $��2��6J    5�      �� 5�      $
��auto �6    �� 5�      .+�5�      � -   5        $��
SearchGrid��5�   9   $��1,5,1,5q�6   ���#f4f4f7 5�      �� 5�      $
��auto �6'   �� 5�      �� 5�      $
��auto �6'   .+�5�      �� $��Center=�6   
�������$��	ExtraBold"�6M   $��20(�6d   .��6r   Kerko Artikull6�   �� 5�      -   5        $��KerkoArtikullTextBox��5�   �   $��20(�6   $��1��6(   $��Center=�68   $��0q�6Z    � ToolTip$# Enter per te filluar kerkimin��6�   6�   �� 5�      -   5        $��SearchArtikullBtn��5�   ,   
�������$��0q�6E   $��2��6{   .��5�      �� $��/Images/search.png��6   5�      5�      � 5�      -   5        $��GridaCP��5�       $��1��6    5�      �� 5�      $
��auto �6'   66   �� 5�      $��2* �6'   .+�5�      �� .��5�      �� -   5        $��Grupet��5�   !   5�      5�      �� 5�      $��1��6   .��5�      �� -   5        $��	Produktet��5�   !   5�      5�      5�      5�      &   System.Windows.Controls.DataGrid  5�   
   -   5        $��FH��5�   D     HeaderStyle   ColumnHeaderStyle# [ 6       CanUserAddRows  .  !   HeadersVisibility$! Column=�6f   "   AutoGenerateColumns" .  #   ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$# * 6�   $��1��6�   $   Columns$ 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,  &System.Windows.Controls.DataGridColumn%   
IsReadOnly% . &   
FontWeight$
& Bold"�67   '   Header$' Asortimenti��6J   1  +System.Windows.Controls.DataGridBoundColumn(   Binding( 6_   �� *Asortimenti+4  .System.Windows.Controls.DataGridTemplateColumn  5�      $
' Sasi��6)   )   CellTemplate) 5�      �� 5�      .R�5�      �� $��0q�6&   $
��Bold"�6:   ��6M   �� *SASI+* �� Mode$* TwoWay=�+ �� NotifyOnSourceUpdated+ . , �� NotifyOnTargetUpdated, . - �� UpdateSourceTrigger$- PropertyChanged=�5�      5�        5�      % . $
& Bold"�67   $' Njesi��6J   ( 6Y   �� *Njesi+  5�      $
' Cmim��6)   ) 5�      �� 5�      .R�5�      �� $��0q�6&   $
��Bold"�6:   ��6M   �� *CMIM+$* TwoWay=�+ . , . $- PropertyChanged=�. �� StringFormat$. N2��5�      5�      /   	CellStyle/ 5      �� 5     *  $System.Windows.Controls.DataGridCell"  6   .�5     ��  � ��$ 40��6/   �� 5      � �� �#f2f4f463   �� 5      � ��$ 18(�61   �� 5      � ��$ Aileron Thin)�63   6K   0 �� Triggers0 5     P� 5	      �@ 
IsSelected . . �5
     ��  � �� �#f2f4f46;   �� 5      � ��
 �   �6;   5     5       5     =  7System.Windows.Controls.Primitives.DataGridColumnHeader��%�   '        �� 5     "  6   .�5     ��  � ��$ 22(�61   6>   �� 5      � ��$ Regular"�63   6E   �� 5      � ��$ Arial)�63   5     5     5     � 5  
   #��[  6   $��1��64   $��1��6E    5      �� 5!     $��* �6#   �� 5"     $
��auto �6#   �� 5#     �� 5$     �� 5%     $��* �6#    5'     �� 5(     $
��auto �6    60   �� 5)     $
��auto �6    60   �� 5*     $��* �6    6.   �� 5+     6"   .+�5.     �� $��0��6   
�������$��20(�67   $��2��6E   .��6Y   Data6_   �� 5/     -	   5        $��	DataLabel��5/  F   $��2��6   
�������$��20(�68   6Y   �� 50     $��3��6   
�������$��20(�67   $��2��6E   $��0,0,159.5,0q�6Y   .��6o   Numer Fature6}   �� 51     -
   5        $��NrFatureLabel��51  4   $��4��6   $��20(�6&   $��0.5,0,-0.5,0q�6I   6a   �� 53     $��35(�6   $��1��6"   $��2��6/   .��6D   Total6K   �� 54     -   5        $��Total��54  �   $��1��6   $��35(�6%   $
��Bold"�63   
���  ��$��2��6V   $��Center=�6f   $	��0,5q�6�   0.006�   �� 55     $��3��6   $��2��6)   $��1��6>   .+�56     � $��
0,0,-0.5,0q�6   .+�57     �� $��/Images/info.png��6   $��50��62   6A   �� 58     $��Center=�6   $��16(�67   
���  ��$
��Wrap=�6V   1 �� TextAlignment$1 Center=�6k   =;Per te fshire nje rresht klikoni dy here mbi asortimentin !6�   5;     5=     � 5>     $��2��6   .+�5?     �� -   5        $��DirectPrint��5?  F   $��0,0,10,0q�6   $��80��6+   $��80��6:   
�������.��5@     �� $��/Images/Print.png��6   5A     �� 5B     -   5        $��PrintInScreen��5B  i   $��80��6   $��80��6(   
�������$��20(�6   .��5C     �� $��/Images/fullscreen.png��6   5D     5E     �� 5L     -   5        $	��New��5L  �   $��50��6   $��Center=�6#   $��Bottom=�6F   $��50��6a   ���#57bc90$��3��6�   $��20(�6�   
�������$��0,0,10,7q�6�   $��2��6�   .��6�   E Re6�   �� 5M     -   5        $
��Save��5M  �   $��50��6   $��Bottom=�6#   $��50��6>   ���#57bc90$��2��6_   $��3��6o   $��20(�6|   
�������$��0,0,10,7q�6�   $
��Ruaj��6�   6�   �� 5N     -   5        $��	DeleteBtn��5N  �   $��Bottom=�6   $��3��60   $��3��6A   $��	0,0,9.5,0q�6N   $��20(�6a   $��50��6o   
�������
���  ��.��6�   Fshij6�   �� 5O     -   5        $��Kerko��5O  �   $	��100��6   $��Bottom=�6$   $��4��6?   ���#57bc90$��3��6d   $��20(�6q   $��50��6   
�������$��	0.5,0,0,7q�6�   .��6�   Kerko Fature6�   5R     5S     5T     