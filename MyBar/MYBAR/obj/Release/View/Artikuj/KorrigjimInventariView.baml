   M S B A M L   `   `   `  ���� @  <MYBAR, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:MYBAR.View.ArtikujMYBAR.View.Artikuj  /    )MYBAR.View.Artikuj.KorrigjimInventariView   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     2local clr-namespace:MYBAR.View.Artikuj     -   .���   � ColumnDefinitions  �� �� .+�&   System.Windows.Controls.DataGrid  -   $��KorrigjimList��   GridLinesVisibility$ 
Horizontal=�   HeadersVisibility$ Column=�   CanUserAddRows .     HeaderStyle   ColumnHeaderStyle# [     ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ *    AutoGenerateColumns .     Columns 0  *System.Windows.Controls.DataGridTextColumn     FontSize$ 18Q�,  &System.Windows.Controls.DataGridColumn	   
IsReadOnly	 . 
   
FontWeight$

 Bold"�   Header$ Asortimenti��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Emri+  $ 18Q�	 . $

 Bold"�$ Gjendje�� �� *SasiaAktuale+4  .System.Windows.Controls.DataGridTemplateColumn  $ 
Sasia e Re��   CellTemplate �� .R��� $��18(�$��0q�$
��Bold"����� *SasiRe+ �� Mode$ TwoWay=� �� NotifyOnSourceUpdated .  �� NotifyOnTargetUpdated .  �� UpdateSourceTrigger$ PropertyChanged=�  $ 	Diferenca�� �� .R��� $��18(�$
��Bold"����� *Ngjyra+���� *	Diferenca+$ TwoWay=� .  . $ PropertyChanged=�   	CellStyle ��  �� 
TargetType*  $System.Windows.Controls.DataGridCell"  .���  �� Property � �� �� Value �#f2f2f2��  � ��$ 30�� �� Triggers P�  P� Property �@ 
IsSelected P� Value . . ���  � �� �#7DA7D9��  � ��
 �   � � 	Resources =  7System.Windows.Controls.Primitives.DataGridColumnHeader��%-   '        �� "  .���  � ��$ 18(��� $��1��.+�� .+��� $��Center=�$��18(�.��Kerko�� -   $��	SearchBox��$	��300��$��60��$��Center=�$��18(��� -   $��FindPrevious��{�.  $��16(�.��
Gjej pas�� -   $��FindNext��$��16(�.��Gjej te radhes�� $��50��$��10,10q�$��Center=�$��15(��� -    �Name$ Indeks��.�0�� .�/�� -   $ Number��$��18(�$��
ExtraBlack"�$��Arial)�
���  ��.�0 rezultate nga kerkimi�� -   $��KorrigjoInventar�����#78a5a3
�������$��25(�.��Korrigjo Inventarin