   M S B A M L   `   `   `  ���� @  <MYBAR, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:MYBAR.View.DialogMYBAR.View.Dialog  .    (MYBAR.View.Dialog.AdvancedArtikullSelect   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     1localclr-namespace:MYBAR.View.Dialog     -     � WindowStyle$  
ToolWindow=� � Title$ AdvancedArtikullSelect�� � 	Resources    ScrollThumbs �� 
TargetType �� Property �� Value �� 
TargetType �Name ��Name	 �� CornerRadius
 �� Triggers P� Property P� Value �� 
TargetName � RowDefinitions ]�Name ]� Thumb n�Name ]� IncreaseRepeatButton ��Name J� Opacity ]� DecreaseRepeatButton P� 
SourceName  ButtonSelectBrush  	DarkBrush �� Angle  BaseButtonStyle J� SnapsToDevicePixels ��Name  ProductStyle  shiritibackgroud �� Triggers  HeaderProdukt �� BasedOn  BottomButons �� 
StartPoint �� EndPoint � SpreadMethod � ColorInterpolationMode  � Color! � Offset��%�
  &	        '�� P    &	 ^    &	 �    7  &	 r	    '�� �	    7  &	 �	    �� " n�.���  � �� �� " n�.R�� $
 Grid��.+��� $��Stretch=�$��Stretch=�$
��Auto��$
��Auto��
������ �� $ 
Rectangle1��$	 10��$��Stretch=�$��Stretch=�$
��Auto��$
��Auto��#��z��
 P�  �@�Tag$ 
Horizontal��. ��� $ 
Rectangle1�� � ��$
 Auto���� $ 
Rectangle1�� � ��$ 7���� " ��.���  �@��IsFlicksEnabled .  ��  � ��
 �������  � ��
 �������  � ��$ 10����  � �� �� " ��.R�� $ GridRoot��$��19��#��z�� �� $��0.00001* �.+�]� $ 
PART_Track��$��0����. |�.   n� $ Thumb��#��z��#���    �� $ PageUp��$��ScrollBar.PageDownCommand��$ 0Q�|�.   �� $ PageDown��$��ScrollBar.PageUpCommand��$ 0Q�|�.  
 P� $ Thumb�� �@J�IsMouseOver . . ��� # �  $ Thumb�� � ��P� $ Thumb�� �@n�
IsDragging . . ��� # �  $ Thumb�� � ��P�  � {� .  . ��� $ Thumb�� � y�$ 	Collapsed=�P�  �@��Orientation$ 
Horizontal=�. ��� $ GridRoot�� �@�LayoutTransform �� $	 -90Q��� $ 
PART_Track�� �@�LayoutTransform �� $	 -90Q���  � ��$
 Auto����  � ��$ 12���� $ Thumb�� �@�Tag$ 
Horizontal���� $ PageDown�� � ��$ ScrollBar.PageLeftCommand���� $ PageUp�� � ��$  ScrollBar.PageRightCommand���� " ��.���  �@�FocusVisualStyle Z� ��  � �� �#57bc90��  � �� �#cccccc��  � ��$ 0q���  � ��$ Black"���  � �� �#333333��  � ��$
 Left=���  � ��$ Center=���  � ��$ 7,0,10,0q���  � ��$ 0,0,0,2q���  � ��
 �������  � ��$ 20(���  � ��$ 65����  � �� �� " ��.R��� $ Chrome��#��z��#��z��#��z�� . ._��� $ 	Presenter��#��z��#��z��#��z����. # z 
 P�  � {� .  . ���  � �� �#333333P�  �@J�IsMouseOver . . ���  � �� �#67b8e0��  � �� �#cccccc��  � ��
 �����P�  � �� . . ���  � �� �#1ba1e2��  � �� �#1ba1e2��  � �� �#ffffffP�  �@J�	IsFocused . . ��� $ Chrome�� � �� �#1ba1e2�� " ��.���  �@�FocusVisualStyle Z� ��  � ��8   ��  � ��$ 5q���  � ��$ 70����  � ��$	 100�� P�  �@J�IsMouseOver . . ���  � �� �#67b8e0�� " �.���  �@�FocusVisualStyle Z� ��  � �� �#f4f4f7�� " ��8   �� $	 0,0&�$	 0,1&�$	 Pad=�$ SRgbLinearInterpolation=�.��� $  	#FF58839A��$
! 0.86Q�� $  	#FF59849B��$	! 0.5Q�� $  	#FF538099��$
! 0.14Q�.���  �� $��* ��� $
��auto �" � ColumnDefinitions" �� $��* ��� $��2* ��� $
��auto �.+��� $��0��$
��Auto=�.���� -   $��KategoriteContainer��$��5,0,0,0q����#f4f4f7.+�� -   $��GrupetHeader��#��[ #��[ " �� $��* �.+��� $��Center=�$��22(�$��Black"�$��0��.��
Kategori�� -   $��Grupet��� $��Stretch=�$��1��$��Bottom=�.+��� $��22(�$��Arial)�$��Center=�.��Kerko�� -   $��
FastSearch��$	��250��$��22(�|�. $��40���� $��1��$��2��$
��Auto=�.��� -   $��ProduktePanel�����#f4f4f7$��	10,0,10,0q�.+�� -   $��	Produktet��