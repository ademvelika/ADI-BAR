   M S B A M L   `   `   `  ���� @  <MYBAR, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:MYBAR.View.PorosiMYBAR.View.Porosi  "    MYBAR.View.Porosi.PorosiView   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     1localclr-namespace:MYBAR.View.Porosi     $��Stretch=�$��Stretch=�  � 	Resources     ScrollThumbs �� 
TargetType �� Property �� Value �� 
TargetType �Name ��Name �� CornerRadius �� Triggers	 P� Property
 P� Value �� 
TargetName � RowDefinitions ]�Name ]� Thumb n�Name ]� IncreaseRepeatButton ��Name J� Opacity ]� DecreaseRepeatButton P� 
SourceName  ButtonSelectBrush  	DarkBrush �� Angle  BaseButtonStyle J� SnapsToDevicePixels ��Name  ProductStyle �� Triggers  HeaderProdukt �� BasedOn��%	
  &	        '�� P    &	 ^    &	 �    &	 j	    '�� �	    7  �� " n�.���  � �� �� " n�.R�� $
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
 Left=���  � ��$ Center=���  � ��$ 2,0,2,0q���  � ��$ 0,0,0,2q���  � ��
 �������  � ��$ 20(���  � ��$ 65����  � �� �� " ��.R��� $ Chrome��#��z��#��z��#��z�� . ._��� $ 	Presenter��#��z��#��z��#��z����. # z  P� 	 � {�
 .  . ���  � �� �#333333P� 	 �@J�IsMouseOver
 . . ���  � �� �#67b8e0��  � �� �#cccccc��  � ��
 �����P� 	 � ��
 . . ���  � �� �#1ba1e2��  � �� �#1ba1e2��  � �� �#ffffffP� 	 �@J�	IsFocused
 . . ��� $ Chrome�� � �� �#1ba1e2�� " �.���  �@�FocusVisualStyle Z� ��  � �� �#57bc90��  � ��$ 2,0,2,4q���  � ��$ 65�� P� 	 �@J�IsMouseOver
 . . ���  � �� �#67b8e0�� " �.���  �@�FocusVisualStyle Z� ��  � �� �#f4f4f7�� " ��8   .���  �� $��4* ��� $��2* � � ColumnDefinitions �� $��2* ��� $��3* �.+�&   System.Windows.Controls.DataGrid  -   $��
PorositeDG��  HeaderStyle   ColumnHeaderStyle# [    
IsReadOnly .    CanUserAddRows .     AutoGenerateColumns .     ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * $��2��    Columns  0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn!   
IsReadOnly! . "   Header$
" User��1  +System.Windows.Controls.DataGridBoundColumn#   Binding# �� *Client_Name+  ! . $
" Koha��# �� *
Order_Time+  ! . $" Totali��# �� *Order_Total+  ! . $" Statusi��# �� *Order_Status+$   RowStyle$ �� )  #System.Windows.Controls.DataGridRow"   �� % �� Binding% �� *Order_Status+& �� Value& 	Cancelled.a���  � ��
 � E���� % �� *Order_Status+& Approved.a���  � �� �#75B84B'   	CellStyle' �� *  $System.Windows.Controls.DataGridCell"  .���  � ��$ 20(���  � ��$ Aileron Thin)���  � ��$ 30�� P� 	 �@ 
IsSelected
 . . ���  � �� �#7DA7D9��  � ��
 �   �  =  7System.Windows.Controls.Primitives.DataGridColumnHeader��%I   '        �� "  .���  � �� �#f4f4f7��  � ��$ 20(��� 
�������$��2��$��0��$��0,0,5,0q�.+�  -   $��
FatureBody�� . (   HeadersVisibility$( Column=� .  .  $ * ' �� "  .���  � ��
 �������  � ��$ 20(���  � ��$ Aileron Thin)���  � ��$ 30�� P� 	 �@ 
IsSelected
 . . ���  � �� �#7DA7D9��  � ��
 �   �  ��%I   '        �� "  .���  � �� �#f4f4f7��  � ��$ 27(�  -   $��
PorosiBody��# [  .   .  .  $ *     ! . $" Asortimenti��# �� *Name+  ! . $
" Sasi��# �� *
Quantity+  ! . $" Cmimi��# �� *	SalePrice+' �� "  .���  � ��
 ��ح���  � ��$ 20(���  � ��$ Aileron Thin)� P� 	 �@ 
IsSelected
 . . ���  � �� �#7DA7D9��  � ��
 �   �  ��%I   '        �� "  .���  � �� �#c5c9c9��  � ��$ 18(��� ���#f4f4f7$��2��$��1��.+�]� $
��0,10q�.+��� $��35(�	Tavolina:�� -   $��	FreeTable��
������ $��35(�$��50��� $��Right=�$��Right=�.+��� $��35(�$
��Bold"�$��0,0,5,0q�.��Totali�� $��Center=�$��45(�$
��Bold"�$��Arial)�
���  ��.���� -   ) �Name$) Total��.�0� $��Bottom=�$��0,0,0,50q� �� $��* ��� $��* ��� $��* �.+��� -   $��Aprovo��$��0,0,5,0q�$��Center=�$��Stretch=�$��Aprovo���� -   $��Refuzo��$��0,0,5,0q�$��Center=�$��Stretch=�$��1��$��Refuzo��