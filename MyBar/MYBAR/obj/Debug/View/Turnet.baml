   M S B A M L   `   `   `  ����@  <MYBAR, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:MYBAR.View
MYBAR.View  5          MYBAR.View.Turnet   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:MYBAR.View     5      -   5        $��Stretch=�5	      $��Stretch=�6*     � 	Resources  5
       �� 
TargetType �� Property �� Value �� Triggers P� Property P� Value��%Y  'Q�       �� 5   
   " Q�6   .�5      ��  � ��
 �   �6+   �� 5       � ��$ 20(�6)   �� 5       � ��$ 0,5,25,5q�6'   �� 5       � ��$
 Bold"�6+    5      P� 5       �@Q�
IsSelected . . �5      ��  � ��
 �   �64   �� 5       � �� �#f4f4f763   5      5      5      .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   6+   �� 5      $��4* �6   6,   .+�5       �� $��0��6   ���#f4f4f7.+�5"      � .+�5#      �� $��20(�6   .��6'   
Nga Data61   (  "System.Windows.Controls.DatePicker  5$      -   5        $��	DateStart��5$   Z      styleCalendar   CalendarStyle# [  6   $��20(�6L   6m   5%      � 5&      .+�5'      �� $��0,0,12,0q�6   $��20(�6*   .��69   	Ne Date6C     5(      -   5        $��DateEnd��5(   Z   # [  6   $��20(�6L   6k   5)      �� 5*      -   5        $��Perdoruesit��5*      .+�5+      �� -   5        $��AllUsers��5+   )   $��40��6   $��20(�6P   .��6^   	Te gjithe6i   5-      5.      � 51   
   $��1��6   	 � RowDefinitions	 52      �� 53      $��* �6    �� 54      $
��auto �6    .+�56      &   System.Windows.Controls.DataGrid  -   5        $��
TurnetGrid��56   H     HeaderStyle
   ColumnHeaderStyle#
 [ 6      AutoGenerateColumns .     CanUserAddRows .     ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6�     57      =  7System.Windows.Controls.Primitives.DataGridColumnHeader��%�   '        �� 58      "  6   .�59      ��  � �� �#c5c9c967   �� 5:       � ��$ 25(�65   6B   5<      5?         Columns 5@      0  *System.Windows.Controls.DataGridTextColumn  5B      ,  &System.Windows.Controls.DataGridColumn   
IsReadOnly .    Header$ Numer Faturash��6;   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6S   �� *NumerFaturash+  5C       . $ Numer Produktesh��6;    6U   �� *NrProduktesh+  5D       . $
 Data��6;    6I   �� *Data+  5E       . $ 
Perdoruesi��6<    6P   �� *
UserName+ �� StringFormat$ N2��  5G       .    
FontFamily$ Arial)�6<      
Foreground
 �  ��   
FontWeight$ 
ExtraBlack"�6a   $ Total��6y    6�   �� *Total+$ N2��  5H       . $ Georgia)�6;   
 �  ��$ 
ExtraBlack"�6a   $ total��6y    6�   �� *Fiscal_Orders_Total_Sum+$ N2�� � ContextMenu 5K      �� 5L      .@�5M      m� -   5        $��
PrintoTurn��5M   $   $��Print��6O   6`   5N         	CellStyle 5P      �� 5Q      *  $System.Windows.Controls.DataGridCell"  6   .�5R      ��  � ��$ 20(�65   �� 5S       � ��$ Aileron Thin)�63   6K   �� 5T       � ��$ 35��6/    5V      P� 5W       �@ 
IsSelected . . �5X      ��  � ��
 ��ح�6;   �� 5Y       � ��
 �   �6;   5[      5^         RowStyle 5b      �� 5c      )	  #System.Windows.Controls.DataGridRow" 	 6   .�5d      ��  � �� 67   �� *RowBackground+5e      5g      ]� 5h      $��1��6   .+�5i      �� $��30(�6   $
��Bold"�6*   $��Arial)�6<   $
��Left=�6O   Totali6m   �� 5j      -   5        $��Total��5j   �   $��Right=�6   $
��Bold"�63   $��Arial)�6E   $��Right=�6X   $��30(�6t   
���  ��6�   5k      5l      5m      5n      