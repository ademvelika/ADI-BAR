   M S B A M L   `   `   `  ���� @  <MYBAR, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:MYBAR.View
MYBAR.View      MYBAR.View.Turnet   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     *localclr-namespace:MYBAR.View     -   $��Stretch=�$��Stretch=�  � 	Resources   �� 
TargetType �� Property �� Value �� Triggers P� Property P� Value��%�   'Q�       �� " Q�.���  � ��
 �   ���  � ��$ 20(���  � ��$ 0,5,25,5q���  � ��$
 Bold"� P�  �@Q�
IsSelected . . ���  � ��
 �   ���  � �� �#f4f4f7.���  � ColumnDefinitions �� $��* ��� $��4* �.+��� $��0�����#f4f4f7.+�� .+��� $��20(�.��
Nga Data(  "System.Windows.Controls.DatePicker  -   $��	DateStart��   styleCalendar   CalendarStyle# [  $��20(�� .+��� $��0,0,12,0q�$��20(�.��	Ne Date  -   $��DateEnd��# [  $��20(��� -   $��Perdoruesit��.+��� -   $��AllUsers��$��40��$��20(�.��	Te gjithe� $��1��	 � RowDefinitions	 �� $��* ��� $
��auto �.+�&   System.Windows.Controls.DataGrid  -   $��
TurnetGrid��  HeaderStyle
   ColumnHeaderStyle#
 [    AutoGenerateColumns .     CanUserAddRows .     ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ *   =  7System.Windows.Controls.Primitives.DataGridColumnHeader��%I   '        �� "  .���  � �� �#c5c9c9��  � ��$ 25(�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   
IsReadOnly .    Header$ Numer Faturash��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *NumerFaturash+   . $ Numer Produktesh�� �� *NrProduktesh+   . $
 Data�� �� *Data+   . $ 
Perdoruesi�� �� *
UserName+ �� StringFormat$ N2��   .    
FontFamily$ Arial)�   
Foreground
 �  ��   
FontWeight$ 
ExtraBlack"�$ Total�� �� *Total+$ N2��   . $ Georgia)�
 �  ��$ 
ExtraBlack"�$ total�� �� *Fiscal_Orders_Total_Sum+$ N2�� � ContextMenu �� .@�m� -   $��
PrintoTurn��$��Print��   	CellStyle �� *  $System.Windows.Controls.DataGridCell"  .���  � ��$ 20(���  � ��$ Aileron Thin)���  � ��$ 35�� P�  �@ 
IsSelected . . ���  � ��
 ��ح���  � ��
 �   �   RowStyle �� )	  #System.Windows.Controls.DataGridRow" 	 .���  � �� �� *RowBackground+]� $��1��.+��� $��30(�$
��Bold"�$��Arial)�$
��Left=�Totali�� -   $��Total��$��Right=�$
��Bold"�$��Arial)�$��Right=�$��30(�
���  ��