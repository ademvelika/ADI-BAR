   M S B A M L   `   `   `  ����@  <MYBAR, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:MYBAR.View.ArtikujMYBAR.View.Artikuj  5      ;"clr-namespace:MYBAR.CustomControlsMYBAR.CustomControls  5      '    !MYBAR.View.Artikuj.ShitjetArtikuj   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:MYBAR.View.Artikuj     5      6control"clr-namespace:MYBAR.CustomControls     5      $��Stretch=�5	      $��Stretch=�6*   $��20(�6H     � 	Resources  5       �� 
TargetType �� Property �� Value��%�   '��       �� 5   
   " ��6   .�5      ��  � �� �#fcfdfe6=   �� 5       � ��$ 0,5,5,5q�6'   �� 5       � ��$ 1,10,1,1q�6(   5      5      .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      �� 5      $
��auto �6   .+�5   
   � ���#f4f4f7 � ColumnDefinitions 5      �� 5      $
��auto �6$   �� 5      $
��auto �6$   �� 5      $��* �6$   �� 5       $��* �6$    5"      �� 5#      $
��auto �6      5&      ��%    5.      .+�5/      �� -   5        $��
DateFilter��5/      .��50      �� .+�51      ]� .+�52      �� $
��Left=�6   $��Nga Data��66   $��Black"�6I   6a   "   MYBAR.CustomControls.DateOre  53      -   5          Name$ 
StartClock��53   &   6=   54      ]� 55      $��0,10,0,0q�6    .+�56      �� $
��Left=�6!   $��Tek Data��6?   $��Black"�6R   6j     58      -   5        $ FinishClock��58   *   6B   5:      5;      5<      �� 5=      -   5        $��UserCategoryFilter��5=      $��1��62   .��5>      �� .+�5?      ]� .+�5@      �� $
��Left=�6!   $��
Perdoruesi��6=   $��Black"�6R   6j   �� 5A      -   5        $��PerdoruesiCombo��5A   j   $��Right=�6#   $��Right=�6:   $��0,0,0,0q�6W   5C      5D      ]� 5E      $y�	Collapsed=�6    .+�5F      �� $
��Left=�6!   $��	Kategoria��6=   $��Black"�6Q   6h   �� 5G      -   5        $��KategoriCombo��5G   j   $��Right=�6#   $��Right=�6:   $��0,0,0,20q�6W   6j   5H      �� 5I      -   5        $��ArtikujSearch��5I   }   $
��5,10q�6   $
��Left=�6,   ���#66a5ad$	��210��6]   
�������$��20(�6�   .��6�   Shto artikull ne filter6�   5J      5K      �� 5L      -   5        $��AdvancedFilter��5L      $��2��6/   .��5P      �� $
��Auto=�6%   $��Hidden=�6M   .��5Q      � -	   5        $��ListContainer��5Q   F   $��Center=�6$   5S      5T      5V      �� 5W      -
   5        $��CommandFilter��5W      $��3��6-   .��5Y      � .+�5Z      �� -   5        $��Filtro��5Z   r   $��50��6   $��22(�6)   ���#78a5a3
�������$��Filtro��6`   6�   �� 5[      -   5        $��Printo��5[   �   $��20(�6   ���#e1b16a
�������$��Printo��6T   $	��5,0q�6f   6�   �� 5\      -   5        $��ExportToExcel��5\   F   $��50��6    � ToolTip$ Eksporto ne excel��6\   
������ $��Right=�6�   $��Right=�6�   $��0,0,5,0q�6�   .��5]      �� $��Stretch=�6    $��/Images/Excel-icon.png��6=   5^      �� 5_      -   5        $��Loading��5_   1   $��
Loading...��6   $y�Hidden=�6@   $��Center=�6T   5`      5a      5l      &   System.Windows.Controls.DataGrid  5m   
   -   5        $��Result��5m   �      GridLinesVisibility$ 
Horizontal=�6      HeaderStyle	   ColumnHeaderStyle#	 [  65   
   AutoGenerateColumns
 .     HeadersVisibility$ Column=�6�      AlternatingRowBackground
 �����$��1��6�      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6�      
IsReadOnly .    Columns 5o      0  *System.Windows.Controls.DataGridTextColumn  5p         FontSize$ 18Q�6&   ,  &System.Windows.Controls.DataGridColumn   
IsReadOnly .    
FontWeight$
 Bold"�6H      Header$ Asortimenti��6[   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6p   �� *Asortimenti+  5q      $ 18Q�6&    . $
 Bold"�6H   $ Sasia��6[    6j   �� *Sasia+  5s      $ 18Q�6&    . $
 Bold"�6H   $ Cmimi��6[    6j   �� *Cmimi+ �� StringFormat$ N2��  5t      $ 18Q�6&    . $
 Bold"�6H   $ Vlera��6[    6j   �� *Vlera+$ N2��  5u      $ 18Q�6&    . $
 Bold"�6H   $ 	Kategoria��6[    6n   �� *	Kategoria+   	CellStyle 5x      �� 5y      *  $System.Windows.Controls.DataGridCell"  6   .�5}      ��  � ��$ 20(�61   �� 5~       � ��$ Aileron Thin)�63   6K   �� 5       � ��$ 30��6/    �� Triggers 5�      P� 5�       P� Property �@ 
IsSelected P� Value . . �5�      ��  � �� �#7DA7D96;   �� 5�       � ��
 �   �6;   5�      5�        5�      =  7System.Windows.Controls.Primitives.DataGridColumnHeader��%�   '        �� 5�      "  6   .�5�      ��  � �� �#41414463   �� 5�       � ��
 �����63   �� 5�       � ��$ 27(�61   6>   5�      5�      5�      ]� 5�   
   ���#363636$��50��6*   $��2��66   .+�5�      �� $
��Left=�6   $��Center=�6/   
�������$
��Bold"�6]   $��30(�6o   Total6�   �� 5�      -   5        $��Totali��5�   2   $��Right=�6   $��Center=�6@   $��Right=�6[   
�������$
��Bold"�6�   $��30(�6�   006�   5�      5�      5�      