   M S B A M L   `   `   `  ���� @  <MYBAR, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:MYBAR.View.KerkoDialogMYBAR.View.KerkoDialog  3    -MYBAR.View.KerkoDialog.MinimumQuantityArtikuj   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     6local$clr-namespace:MYBAR.View.KerkoDialog       � Title$  Kujdes��$��Center=�$��Center=� � WindowStartupLocation$ CenterScreen=� � WindowStyle$ 
ToolWindow=�.���� .@��� $��45��$	��120��$��Stretch=�$��18(� �� 
IsSelected . $��Gjendje ne Perfundim��.��� -   $��MinimumaArtikuj�� � RowDefinitions �� $
��auto ��� $��* ��� $
��auto �.+��� ���#f4f4f7$��20(�.��1/Artikujt e meposhtem jane nen kufirin e limitit&   System.Windows.Controls.DataGrid  -   $��Lista��   HeaderStyle   ColumnHeaderStyle# [  $��1��   HeadersVisibility$ Column=�   AutoGenerateColumns .     ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 	   
IsReadOnly	 . 
   CanUserAddRows
 .     Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   
IsReadOnly .    
FontWeight$
 Bold"�   Header$ Asortimenti��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Asortimenti+   . $
 Bold"�$ Sasia�� �� *Sasi+   . $
 Bold"�$ Sasia Minimale�� �� *SasiaMinimale+   	CellStyle ��  �� 
TargetType*  $System.Windows.Controls.DataGridCell"  .���  �� Property � �� �� Value$ 40����  � �� �#f2f4f4��  � ��$ 18(���  � ��$ Aileron Thin)� �� Triggers P�  P� Property �@ 
IsSelected P� Value . . ���  � �� �#f2f4f4��  � ��
 �   � � 	Resources =  7System.Windows.Controls.Primitives.DataGridColumnHeader��%I   '        �� "  .���  � �� �#c5c9c9��  � ��$ 18(�� $��2�� � ColumnDefinitions �� �� .+��� -   $��BejFurnizim��$��40�����#444c5c$��25(�
�������.�� Bej Furnizim per keto Produkte�� -   $	��Dil��$��1��$��40�����#CE5A57$��25(�
�������.��Mbyll�� -   $��AnullimeTab��$	��120��$��18(�$��45��$��4,0,0,0q�$��Anullime��.���  �� $��2* ��� $��* �.+�  -   $��KerkesaPerAnullimList��  RowStyleWithAlternation   RowStyle# [ # [  $ Column=�$��1��	 . $ * �� $��1��.+�-� -   $��
FaturaShow��$��1��$��0�� -� Zoom$	 200Q�$��Stretch=�$��Stretch=�$��LeftToRight=��� -   $��Anullo��$��50��$y�Hidden=����#2B4D60
�������$��25(�$��	2,10,2,10q�$��Bottom=�.��Anullo