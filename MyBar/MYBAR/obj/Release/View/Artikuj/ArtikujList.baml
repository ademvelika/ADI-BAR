   M S B A M L   `   `   `  ���� @  <MYBAR, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:MYBAR.View.ArtikujMYBAR.View.Artikuj  $    MYBAR.View.Artikuj.ArtikujList   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     2local clr-namespace:MYBAR.View.Artikuj     -   $��Stretch=�$��Stretch=�  � 	Resources     BaseButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType ��Name J� SnapsToDevicePixels ��Name �� Triggers	 P� Property
 P� Value �� 
TargetName 	 Label  TextBoxProduct �� BasedOn��%m  &	        &	 c    &	 �    '�� �    7   '��     7  '��     7  �� " ��.���  �@�FocusVisualStyle Z� ��  � �� �#57bc90��  � �� �#cccccc��  � ��$ 0q���  � ��$ Black"���  � �� �#333333��  � ��$
 Left=���  � ��$ Center=���  � ��$ 2,0,2,0q���  � ��$ 0,0,5,2q���  � ��
 �������  � ��$ 20(���  � ��$ 2,0,0,0q���  � ��$ 65����  � �� �� " ��.R��� $ Chrome��#��z��#��z��#��z�� . ._��� $ 	Presenter��#��z��#��z��#��z����. # z  P� 	 � {�
 .  . ���  � �� �#333333P� 	 �@J�IsMouseOver
 . . ���  � �� �#67b8e0��  � �� �#cccccc��  � ��
 �����P� 	 � ��
 . . ���  � �� �#1ba1e2��  � �� �#1ba1e2��  � �� �#ffffffP� 	 �@J�	IsFocused
 . . ��� $ Chrome�� � �� �#1ba1e2�� " ��.���  � ��$ Center=���  � ��$ 20(��� " ��.���  � ��$ Center=���  � ��$ 20(���  � ��$ Stretch=��� " ��8   �� " ��8   �� " ��8   .���  � RowDefinitions ��  � ColumnDefinitions �� $��* ��� $��4* ��� $
��auto �.+��� $��2��$
��Auto=�.��� ���#f4f4f7 �� $
��auto ��� �� $��* �.+���   shiritibackgroud#��[ $��0,0,0,10q�
���   �$��0,0,0,1q�$��25(�$��70��$��Center=�$��Center=�$��Black"�.��
Kategorite�� -   $��Grupet��$��1���� -   $��ShtoKategori��$��0,0,0,5q�$��2�����#67b8e0$��Bottom=�.��� .+��� $��20(�
�������$��Center=�.��Shto Kategori� ���#f4f4f7$��1�� �� $
��auto ��� $��2* ��� $��* �.+�]� $
��10,0q�$��0��.+��� -   $��	KerkoText��$��0q�$��30(�$��Center=�$��Stretch=�$	��300��$�� ���� -   $��Kerko��$��30(�$��Center=�$��Stretch=�
�������
�������.���� $��/Images/search.png���� -   $��AllProducts��$y�	Collapsed=�$��5q����#78A5A3$
��Bold"�
�������$��Center=�$��	20,01,0,0q�$��Bottom=�.��Shfaq te gjitha Produktet�� -   $��ExportToExcel�� � ToolTip$ Eksporto ne excel��
������ $��Right=�$��Right=�$��0,0,5,0q�.���� $��Stretch=�$��/Images/Excel-icon.png��� -   $��
CenterGrid��$��1�� �� $��* ��� $
��auto �.+�� -	   $��RecepturaPanel��
�������$��1��$y�Visible=�.+��� $��5,0,5,0q�$
��auto��.+��� #��[ $��
Perberesit��&   System.Windows.Controls.DataGrid  -
   $��IngredientDataGrid��   HeadersVisibility$ Column=�   CanUserAddRows .    HeaderStyle   ColumnHeaderStyle# [    AutoGenerateColumns .     Columns 0  *System.Windows.Controls.DataGridTextColumn     FontSize$ 18Q�,  &System.Windows.Controls.DataGridColumn   MinWidth$	 150Q�   
IsReadOnly .    
FontWeight$
 Bold"�   Header$ Asortimenti��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Asortimenti+4  .System.Windows.Controls.DataGridTemplateColumn  $	 100Q�$
 Sasi��   CellTemplate �� .R��� $��0q�$
��Bold"����� *Sasi+ �� Mode$ TwoWay=� �� NotifyOnSourceUpdated .  �� NotifyOnTargetUpdated .  �� UpdateSourceTrigger$ PropertyChanged=�  $ 18Q�$ Njesi�� �� *
UnitName+    	CellStyle  �� *  $System.Windows.Controls.DataGridCell"  .���  � �� �#f2f2f2��  � ��$ 30��! �� Triggers! P� 	 �@ 
IsSelected
 . . ���  � �� �#7DA7D9��  � ��
 �   �  =  7System.Windows.Controls.Primitives.DataGridColumnHeader��%-   '        �� "  .���  � ��$ 18(��� $��12(����#c4dfe6$��0,20,0,0q�$
��Wrap=�Per te shtuar ne list �� 
���  ��.�Right-Click�� mbi produktet ne te majte�� $��12(����#c4dfe6$��0,10,0,0q�$
��Wrap=�Per te fshire nga lista�� �� 
���  ��.�Double-Click mbi produktin  -   $��ListArtikujContainer��$��0��"   GridLinesVisibility$" 
Horizontal=� .  # [ $
��10,0q�$ Column=�$��Stretch=�"#   VerticalScrollBarVisibility$
# Auto=�$   
IsReadOnly$ . %   ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$% *     . $ Asortimenti�� �� *Asortimenti+   . $ Gjendje��$
 Bold"� �� *Sasi+   . $ Njesia�� �� *
UnitName+   . $ Cmimi�� �� *Cmimi+& �� StringFormat$& N2��   . $ Sasi Minimale�� �� *SasiaMinimale+' � ContextMenu' �� .@�m� -   $��AddToIngredientList��$	��add��  �� "  .���  � ��
 �������  � ��$ 40����  � ��$ 20(���  � ��$ Aileron Thin)�! P� 	 �@ 
IsSelected
 . . ���  � �� �#7DA7D9��  � ��
 �   �  ��%-   '        �� "  .���  � ��$ 18(�� $��10,0,0,0q�$��2�� �� $��3* ��� .+�� -   $��ArtikullRiGrid��#��[  �� $
��AUTO ��� $
��135* ��� $
��auto ��� $
��Auto ��� $	��67* ��� $
��auto ��� $	��68* ��� $
��auto ��� $	��67* � �� $
��auto ��� $
��auto �.+��� $��26(�$
��0,15q�.��Emri�� -   $��EmerProduktiNew��$��26(�
���   �$��1���� $��26(�$��2��$��2��$
��0,15q�.��Cmim�� -   $��CmimProduktiNew��$��26(�
���   �$��4���� $��26(�$��5��$
��0,15q�.��	Sasia Min�� -   $��SasiaMinimale��$��26(�
���   �$��6���� $��26(�$��7��$
��0,15q�.��	Kategoria�� -   $��CategoryCombo��$��45��$��26(�$��Center=�$��8���� $��26(�$��1��$��3��.��Tipi�� -   $��	TipiCombo��$��45��$��1��$��4��$��26(��� $��26(�$��1��$��5��$
��0,15q�.��Njesia�� -   $��NjesiaCombo��$��45��$��1��$��6��$��26(�� $��1��$��0,0,0,5q�$��Bottom=� �� $��* ��� $��* ��� $��* �.+��� -   $��ShtoProduktBtn��$��Center=�$��Center=�$��Stretch=�.��Shto�� -   $��DeleteProduct��$��5,0,0,0q�$��1�����#CE5A57$��Center=�$y�	Collapsed=�.��Fshij�� -   $��CancelUpdate��$��5,0,5,0q�$��2�����#E1B16A$��Center=�$y�	Collapsed=�.��I Ri