   M S B A M L   `   `   `  ����@  <MYBAR, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:MYBAR.View.ArtikujMYBAR.View.Artikuj  5      /    )MYBAR.View.Artikuj.KorrigjimInventariView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:MYBAR.View.Artikuj     5      -   5        .��5	      �   � ColumnDefinitions  5
   
   �� 5      �� 5      .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��KorrigjimList��5   k      GridLinesVisibility$ 
Horizontal=�6      HeadersVisibility$ Column=�66      CanUserAddRows .     HeaderStyle   ColumnHeaderStyle# [  6�      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6�      AutoGenerateColumns .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5         FontSize$ 18Q�6&   ,  &System.Windows.Controls.DataGridColumn	   
IsReadOnly	 . 
   
FontWeight$

 Bold"�6H      Header$ Asortimenti��6[   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6p   �� *Emri+  5      $ 18Q�6&   	 . $

 Bold"�6H   $ Gjendje��6[    6l   �� *SasiaAktuale+4  .System.Windows.Controls.DataGridTemplateColumn  5      $ 
Sasia e Re��6+      CellTemplate 5      �� 5      .R�5      �� $��18(�6'   $��0q�65   $
��Bold"�6I   ��6\   �� *SasiRe+ �� Mode$ TwoWay=� �� NotifyOnSourceUpdated .  �� NotifyOnTargetUpdated .  �� UpdateSourceTrigger$ PropertyChanged=�5      5        5      $ 	Diferenca��6+    5      �� 5      .R�5      �� $��18(�6(   $
��Bold"�67   ��6I   �� *Ngjyra+��6h   �� *	Diferenca+$ TwoWay=� .  . $ PropertyChanged=�5       5#         	CellStyle 5'      �� 5(       �� 
TargetType*  $System.Windows.Controls.DataGridCell"  6   .�5+      ��  �� Property � �� �� Value �#f2f2f263   �� 5,       � ��$ 30��6/    �� Triggers 50      P� 51       P� Property �@ 
IsSelected P� Value . . �52      ��  � �� �#7DA7D96;   �� 53       � ��
 �   �6;   55      58       � 	Resources 5:      =  7System.Windows.Controls.Primitives.DataGridColumnHeader��%W   '        �� 5;      "  6   .�5=      ��  � ��$ 18(�61   6>   5?      5@      5A      �� 5B   
   $��1��6   .+�5C      � .+�5D      �� $��Center=�6   $��18(�6:   .��6H   Kerko6O   �� 5E      -   5        $��	SearchBox��5E   a   $	��300��6   $��60��6%   $��Center=�61   $��18(�6S   6�   �� 5F      -   5        $��FindPrevious��5F   9   {�.  $��16(�6+   .��6i   
Gjej pas6s   �� 5G      -   5        $��FindNext��5G   '   $��16(�6   .��6O   Gjej te radhes6_   5H      �� 5I      $��50��6   $��10,10q�6$   $��Center=�63   $��15(�6O   �� 6_   -   5         �Name$ Indeks��5I   c   .�6q   06t   �� 6y   .�6}   /6�   �� 6�   -   5        $ Number��5I   �   $��18(�6�   $��
ExtraBlack"�6�   $��Arial)�6�   
���  ��.�6�   06�    rezultate nga kerkimi6   �� 5J      -   5        $��KorrigjoInventar��5J   =   ���#78a5a3
�������$��25(�6t   .��6�   Korrigjo Inventarin6�   5K      5M      5N      