   M S B A M L   `   `   `  ���� @  <MYBAR, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:MYBAR.View.ArtikujMYBAR.View.Artikuj  ;"clr-namespace:MYBAR.CustomControlsMYBAR.CustomControls  '    !MYBAR.View.Artikuj.ShitjetArtikuj   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     2local clr-namespace:MYBAR.View.Artikuj     6control"clr-namespace:MYBAR.CustomControls     $��Stretch=�$��Stretch=�$��20(�  � 	Resources   �� 
TargetType �� Property �� Value��%j   '��       �� " ��.���  � �� �#fcfdfe��  � ��$ 0,5,5,5q���  � ��$ 1,10,1,1q�.���  � RowDefinitions �� $
��auto ��� �� $
��auto �.+�� ���#f4f4f7 � ColumnDefinitions �� $
��auto ��� $
��auto ��� $��* ��� $��* � �� $
��auto �  ��%    .+��� -   $��
DateFilter��.���� .+�]� .+��� $
��Left=�$��Nga Data��$��Black"�"   MYBAR.CustomControls.DateOre  -     Name$ 
StartClock��]� $��0,10,0,0q�.+��� $
��Left=�$��Tek Data��$��Black"�  -   $ FinishClock���� -   $��UserCategoryFilter��$��1��.���� .+�]� .+��� $
��Left=�$��
Perdoruesi��$��Black"��� -   $��PerdoruesiCombo��$��Right=�$��Right=�$��0,0,0,0q�]� $y�	Collapsed=�.+��� $
��Left=�$��	Kategoria��$��Black"��� -   $��KategoriCombo��$��Right=�$��Right=�$��0,0,0,20q��� -   $��ArtikujSearch��$
��5,10q�$
��Left=����#66a5ad$	��210��
�������$��20(�.��Shto artikull ne filter�� -   $��AdvancedFilter��$��2��.���� $
��Auto=�$��Hidden=�.��� -	   $��ListContainer��$��Center=��� -
   $��CommandFilter��$��3��.��� .+��� -   $��Filtro��$��50��$��22(����#78a5a3
�������$��Filtro���� -   $��Printo��$��20(����#e1b16a
�������$��Printo��$	��5,0q��� -   $��ExportToExcel��$��50�� � ToolTip$ Eksporto ne excel��
������ $��Right=�$��Right=�$��0,0,5,0q�.���� $��Stretch=�$��/Images/Excel-icon.png���� -   $��Loading��$��
Loading...��$y�Hidden=�$��Center=�&   System.Windows.Controls.DataGrid  -   $��Result��   GridLinesVisibility$ 
Horizontal=�   HeaderStyle	   ColumnHeaderStyle#	 [  
   AutoGenerateColumns
 .     HeadersVisibility$ Column=�   AlternatingRowBackground
 �����$��1��   ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ *    
IsReadOnly .    Columns 0  *System.Windows.Controls.DataGridTextColumn     FontSize$ 18Q�,  &System.Windows.Controls.DataGridColumn   
IsReadOnly .    
FontWeight$
 Bold"�   Header$ Asortimenti��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Asortimenti+  $ 18Q� . $
 Bold"�$ Sasia�� �� *Sasia+  $ 18Q� . $
 Bold"�$ Cmimi�� �� *Cmimi+ �� StringFormat$ N2��  $ 18Q� . $
 Bold"�$ Vlera�� �� *Vlera+$ N2��  $ 18Q� . $
 Bold"�$ 	Kategoria�� �� *	Kategoria+   	CellStyle �� *  $System.Windows.Controls.DataGridCell"  .���  � ��$ 20(���  � ��$ Aileron Thin)���  � ��$ 30�� �� Triggers P�  P� Property �@ 
IsSelected P� Value . . ���  � �� �#7DA7D9��  � ��
 �   �  =  7System.Windows.Controls.Primitives.DataGridColumnHeader��%a   '        �� "  .���  � �� �#414144��  � ��
 �������  � ��$ 27(�]� ���#363636$��50��$��2��.+��� $
��Left=�$��Center=�
�������$
��Bold"�$��30(�Total�� -   $��Totali��$��Right=�$��Center=�$��Right=�
�������$
��Bold"�$��30(�00