   M S B A M L   `   `   `  ���� @  <MYBAR, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:MYBAR.View.InventarMYBAR.View.Inventar  ;"clr-namespace:MYBAR.CustomControlsMYBAR.CustomControls  $    MYBAR.View.Inventar.FleteHyrje   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     3local!clr-namespace:MYBAR.View.Inventar     6control"clr-namespace:MYBAR.CustomControls     $��Stretch=�$��Stretch=�  � 	Resources   �� 
TargetType �� Property �� Value �� 
TargetType ��Name �� Triggers P� Property P� Value	 �� 
TargetName 
  linear
 �� 
StartPoint �� EndPoint � SpreadMethod � ColorInterpolationMode � Color � Offset  ScrollBarTrackThumb �Name ��Name �� CornerRadius � RowDefinitions ]�Name ]� Thumb n�Name ]� IncreaseRepeatButton ��Name J� Opacity ]� DecreaseRepeatButton P� 
SourceName  ButtonSelectBrush  	DarkBrush �� Angle��%s  '��       &	      &	 �    '�� <    �� " ��.���  � �� �� " ��.R�� $��Panel��.+��� $ ContentSite��$��Center=�$��Center=�$��Header��$
��10,2q� P�  �@��
IsSelected . . ��� $	 Panel�� � ��
 ��·�P�  �@��
IsSelected .  . ��� $	 Panel�� � ��
 ������� $	
 0,0&�$	 0,1&�$	 Pad=�$ SRgbLinearInterpolation=�.��� $ 	#FFFFFFFF��$ 0Q�� $ 	#FFC3C1C1��$ 1Q�� $ 	#FFDFDFDF��$	 0.5Q��� " n�.���  � �� �� " n�.R�� $
 Grid��.+��� $��Stretch=�$��Stretch=�$
��Auto��$
��Auto��
������ �� $ CornerScrollBarRectangle��$ 5��$��Stretch=�$��Stretch=�$
��Auto��$
��Auto��$��0,1,0,1q�#��z�� P�  �@�Tag$ 
Horizontal��. ��� $	 CornerScrollBarRectangle�� � ��$
 Auto���� $	 CornerScrollBarRectangle�� � ��$ 6���� " ��.���  �@��IsFlicksEnabled .  ��  � �� �#ADABAB��  � ��
 ���� ��  � ��$ 7����  � �� �� " ��.R�� $ GridRoot��$��7��#��z�� �� $��0.00001* �.+�]� $ 
PART_Track��$��0����. |�.   n� $ Thumb��#��z��#���   �� $ PageUp��$��ScrollBar.PageDownCommand��$ 0Q�|�.   �� $ PageDown��$��ScrollBar.PageUpCommand��$ 0Q�|�.   P� $ Thumb�� �@J�IsMouseOver . . ��� # �  $	 Thumb�� � ��P� $ Thumb�� �@n�
IsDragging . . ��� # �  $	 Thumb�� � ��P�  � {� .  . ��� $	 Thumb�� � y�$ 	Collapsed=�P�  �@��Orientation$ 
Horizontal=�. ��� $	 GridRoot�� �@�LayoutTransform �� $	 -90Q��� $	 
PART_Track�� �@�LayoutTransform �� $	 -90Q���  � ��$
 Auto����  � ��$ 8���� $	 Thumb�� �@�Tag$ 
Horizontal���� $	 PageDown�� � ��$ ScrollBar.PageLeftCommand���� $	 PageUp�� � ��$  ScrollBar.PageRightCommand��.���  �� $��2* ��� $��* � � ColumnDefinitions �� $��* ��� $��2* �.+�� -   $��	LeftPanel�����#f4f4f7$��0��$��2�� �� $
��auto ��� .+�� -   $��
SearchGrid��$��1,5,1,5q����#f4f4f7 �� $
��auto ��� �� $
��auto �.+��� $��Center=�
�������$��	ExtraBold"�$��20(�.��Kerko Artikull�� -   $��KerkoArtikullTextBox��$��20(�$��1��$��Center=�$��0q� � ToolTip$# Enter per te filluar kerkimin���� -   $��SearchArtikullBtn��
�������$��0q�$��2��.���� $��/Images/search.png��� -   $��GridaCP��$��1�� �� $
��auto ��� $��2* �.+��� .���� -   $��Grupet���� $��1��.���� -   $��	Produktet��&   System.Windows.Controls.DataGrid  -   $��FH��  HeaderStyle   ColumnHeaderStyle# [     CanUserAddRows  .  !   HeadersVisibility$! Column=�"   AutoGenerateColumns" .  #   ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$# * $��1��$   Columns$ 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn%   
IsReadOnly% . &   
FontWeight$
& Bold"�'   Header$' Asortimenti��1  +System.Windows.Controls.DataGridBoundColumn(   Binding( �� *Asortimenti+4  .System.Windows.Controls.DataGridTemplateColumn  $
' Sasi��)   CellTemplate) �� .R��� $��0q�$
��Bold"����� *SASI+* �� Mode$* TwoWay=�+ �� NotifyOnSourceUpdated+ . , �� NotifyOnTargetUpdated, . - �� UpdateSourceTrigger$- PropertyChanged=�  % . $
& Bold"�$' Njesi��( �� *Njesi+  $
' Cmim��) �� .R��� $��0q�$
��Bold"����� *CMIM+$* TwoWay=�+ . , . $- PropertyChanged=�. �� StringFormat$. N2��/   	CellStyle/ �� *  $System.Windows.Controls.DataGridCell"  .���  � ��$ 40����  � �� �#f2f4f4��  � ��$ 18(���  � ��$ Aileron Thin)�0 �� Triggers0 P�  �@ 
IsSelected . . ���  � �� �#f2f4f4��  � ��
 �   �  =  7System.Windows.Controls.Primitives.DataGridColumnHeader��%a   '        �� "  .���  � ��$ 22(���  � ��$ Regular"���  � ��$ Arial)�� #��[  $��1��$��1�� �� $��* ��� $
��auto ��� �� �� $��* � �� $
��auto ��� $
��auto ��� $��* ��� .+��� $��0��
�������$��20(�$��2��.��Data�� -	   $��	DataLabel��$��2��
�������$��20(��� $��3��
�������$��20(�$��2��$��0,0,159.5,0q�.��Numer Fature�� -
   $��NrFatureLabel��$��4��$��20(�$��0.5,0,-0.5,0q��� $��35(�$��1��$��2��.��Total�� -   $��Total��$��1��$��35(�$
��Bold"�
���  ��$��2��$��Center=�$	��0,5q�0.00�� $��3��$��2��$��1��.+�� $��
0,0,-0.5,0q�.+��� $��/Images/info.png��$��50���� $��Center=�$��16(�
���  ��$
��Wrap=�1 �� TextAlignment$1 Center=�=;Per te fshire nje rresht klikoni dy here mbi asortimentin !� $��2��.+��� -   $��DirectPrint��$��0,0,10,0q�$��80��$��80��
�������.���� $��/Images/Print.png���� -   $��PrintInScreen��$��80��$��80��
�������$��20(�.���� $��/Images/fullscreen.png���� -   $	��New��$��50��$��Center=�$��Bottom=�$��50�����#57bc90$��3��$��20(�
�������$��0,0,10,7q�$��2��.��E Re�� -   $
��Save��$��50��$��Bottom=�$��50�����#57bc90$��2��$��3��$��20(�
�������$��0,0,10,7q�$
��Ruaj���� -   $��	DeleteBtn��$��Bottom=�$��3��$��3��$��	0,0,9.5,0q�$��20(�$��50��
�������
���  ��.��Fshij�� -   $��Kerko��$	��100��$��Bottom=�$��4�����#57bc90$��3��$��20(�$��50��
�������$��	0.5,0,0,7q�.��Kerko Fature