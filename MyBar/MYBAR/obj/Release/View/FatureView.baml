   M S B A M L   `   `   `  ���� @  <MYBAR, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:MYBAR.View
MYBAR.View      MYBAR.View.FatureView   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     *localclr-namespace:MYBAR.View     -   $��Stretch=�$��Stretch=�
�������  � 	Resources     ScrollThumbs �� 
TargetType �� Property �� Value �� 
TargetType �Name ��Name �� CornerRadius �� Triggers	 P� Property
 P� Value �� 
TargetName � RowDefinitions ]�Name ]� Thumb n�Name ]� IncreaseRepeatButton ��Name J� Opacity ]� DecreaseRepeatButton P� 
SourceName  ButtonSelectBrush  	DarkBrush �� Angle  BaseButtonStyle J� SnapsToDevicePixels ��Name  ProductStyle �� Triggers  HeaderProdukt �� BasedOn  BottomButons �� 
StartPoint �� EndPoint � SpreadMethod � ColorInterpolationMode � Color � Offset��%�
  &	        '�� P    &	 ^    &	 �    &	 k	    '�� �	    7  &	 �	    �� " n�.���  � �� �� " n�.R�� $
 Grid��.+��� $��Stretch=�$��Stretch=�$
��Auto��$
��Auto��
������ �� $ 
Rectangle1��$ 10��$��Stretch=�$��Stretch=�$
��Auto��$
��Auto��#��z�� P� 	 �@�Tag$
 
Horizontal��. ��� $ 
Rectangle1�� � ��$
 Auto���� $ 
Rectangle1�� � ��$ 7���� " ��.���  �@��IsFlicksEnabled .  ��  � ��
 �������  � ��
 �������  � ��$ 10����  � �� �� " ��.R�� $ GridRoot��$��19��#��z�� �� $��0.00001* �.+�]� $ 
PART_Track��$��0����. |�.   n� $ Thumb��#��z��#���    �� $ PageUp��$��ScrollBar.PageDownCommand��$ 0Q�|�.   �� $ PageDown��$��ScrollBar.PageUpCommand��$ 0Q�|�.   P� $ Thumb��	 �@J�IsMouseOver
 . . ��� # �  $ Thumb�� � ��P� $ Thumb��	 �@n�
IsDragging
 . . ��� # �  $ Thumb�� � ��P� 	 � {�
 .  . ��� $ Thumb�� � y�$ 	Collapsed=�P� 	 �@��Orientation$
 
Horizontal=�. ��� $ GridRoot�� �@�LayoutTransform �� $	 -90Q��� $ 
PART_Track�� �@�LayoutTransform �� $	 -90Q���  � ��$
 Auto����  � ��$ 12���� $ Thumb�� �@�Tag$ 
Horizontal���� $ PageDown�� � ��$ ScrollBar.PageLeftCommand���� $ PageUp�� � ��$  ScrollBar.PageRightCommand���� " ��.���  �@�FocusVisualStyle Z� ��  � �� �#57bc90��  � �� �#cccccc��  � ��$ 0q���  � ��$ Black"���  � �� �#333333��  � ��$
 Left=���  � ��$ Center=���  � ��$ 7,0,10,0q���  � ��$ 0,0,0,2q���  � ��
 �������  � ��$ 20(���  � ��$ 65����  � �� �� " ��.R��� $ Chrome��#��z��#��z��#��z�� . ._��� $ 	Presenter��#��z��#��z��#��z����. # z  P� 	 � {�
 .  . ���  � �� �#333333P� 	 �@J�IsMouseOver
 . . ���  � �� �#67b8e0��  � �� �#cccccc��  � ��
 �����P� 	 � ��
 . . ���  � �� �#1ba1e2��  � �� �#1ba1e2��  � �� �#ffffffP� 	 �@J�	IsFocused
 . . ��� $ Chrome�� � �� �#1ba1e2�� " �.���  �@�FocusVisualStyle Z� ��  � �� �#57bc90��  � ��$ 0,0,0,4q���  � ��$ 65�� P� 	 �@J�IsMouseOver
 . . ���  � �� �#67b8e0�� " �.���  �@�FocusVisualStyle Z� ��  � �� �#f4f4f7�� " ��8   �� $	 0,0&�$	 0,1&�$	 Pad=�$ SRgbLinearInterpolation=�.��� $ 	#FF58839A��$
 0.86Q�� $ 	#FF59849B��$	 0.5Q�� $ 	#FF538099��$
 0.14Q�.���  �� $��4* ��� $��2* ��� $��* �  � ColumnDefinitions  �� $��2* ��� $��3* ��� $��4* �.+��� -   $��0��$
��Auto=�! �� PanningMode$
! Both=�$��2��.���� -   $��KategoriteContainer��$��5,0,0,0q����#f4f4f7.+�� -   $��GrupetHeader��  shiritibackgroud#��[ #��[   �� $��* �.+��� $��Center=�$��22(�$��Black"�$��0��.��
Kategori�� -   $��Grupet���� -   $��
FastSearch��$��22(�|�. $��Bottom=�$��2��$��40���� -   $��ProductsScroll��$��1��$
! Both=�$��3��$
��Auto=�.���� -   $��ProduktePanel�����#f4f4f7$��	10,0,10,0q�.+�� -	   $��ProdukteHeader��#��[ #��[   �� $
��Auto ��� $��* ��� $
��Auto �.+��� $��22(�$��Black"�$��0��.��Asortimenti�� $��22(�$��Black"�$��2��.��Cmimi�� -
   $��	Produktet���� $��2��$��0��$
��Auto=�.���� 
������ $��0,0,5,0q�.+�&   System.Windows.Controls.DataGrid  -   $��
FatureBody��"   
IsReadOnly" .   RowStyleWithAlternation#   RowStyle## [  	 HeaderStyle$   ColumnHeaderStyle#$ [	 %   HeadersVisibility$% Column=�&   AutoGenerateColumns& .  '   CanUserAddRows' .  (   ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$( * )   Columns) 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn*   
IsReadOnly* . +   Header$+ Asortimenti��1  +System.Windows.Controls.DataGridBoundColumn,   Binding, �� *Asortimenti+  * . $
+ Sasi��, �� *Sasi+  * . $+ Cmimi��, �� *Cmimi+  ��%      -   $��FatureBody2��$	��0.5q�$
% None=�& .  " . ' .  $( * )   * . $+ Asortimenti��, �� *Asortimenti+  * . $
+ Sasi��, �� *Sasi+  * . $+ Cmimi��, �� *Cmimi+-   	CellStyle- �� *  $System.Windows.Controls.DataGridCell"  .���  � �� �#e2faff��  � ��$ 20(���  � ��$ Aileron Thin)���  � ��$ 40�� P� 	 �@ 
IsSelected
 . . ���  � �� �#7DA7D9��  � ��
 �   �  ��%    � ���#f4f4f7$��2��$��2��$��1��  �� $	��27* ��� $
��293* � �� $
��auto ��� $
��auto ��� $��* �.+�� $��2�� �� �� .+�� $
��0,10q�.+��� $��35(�	Tavolina:�� -   $��	FreeTable��
������ $��35(�$��50��� $��Right=�$��Right=�.+��� $
��Left=�$��35(�$
��Bold"�$��15,0,5,0q�.��Totali�� -   $��Total��$
��Left=�$��Center=�$��30(�$��	UltraBold"�$��Arial)�
���  ��� $��1��$��Bottom=�$��0,0,0,5q�$��2��  �� $��* ��� $��* ��� $��* �.+��� -   $��FaturePermbledhese��$��50��$��Center=�$��Center=����#CE5A57$��2��$��Permbledhese��� $��Bottom=�$��2��$��0,0,0,5q�$��2��  �� $��* ��� $��* ��� $��* �.+��� -   $��MbyllFature�����#A1BE95$��80��$��0,0,5,0q�$��Center=�$��Stretch=�$��Mbyll Fature���� -   $
��Ruaj�����#78A5A3$��80��$��0,0,5,0q�$��Center=�$��Stretch=�$��1��$
��Ruaj���� -   ���#E1B16A$��80��$��2��$��Center=�$��Stretch=�$	��Dil��