   M S B A M L   `   `   `  ����@  <MYBAR, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:MYBAR.View
MYBAR.View  5          MYBAR.View.MyFatura   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:MYBAR.View     5      $��Stretch=�5      $��Stretch=�6,   .��5	      �   � ColumnDefinitions  5
   
   �� 5      $��3* �6   6-   �� 5      $��* �6   6,    � RowDefinitions 5   
   �� 5      $��4* �6   �� 5      $��* �6   .+�5   
   � 
�������$��2��6"    5      �� 5      $
��auto �6    �� 5      �� 5      $
��auto �6    .+�5      �� ���#3f89bf$��0,0,1,0q�6+   ._�5      � ���#f2f2f2$��	2,10,0,10q�6,     5      �� 5      �� 5      $
��auto �6+   .+�5      �� -   5        $��	FilterGUI��5   "   �� 5       -   5        $��Filtro��5    �   $��1��6   $��Bottom=�6)   $��Arial)�6E   $��20(�6X   $
��Bold"�6f   
��� � �$��50��6�   $��Filtro��6�   6�   5!      5"      &   System.Windows.Controls.DataGrid  5#      -   5        $��
FaturaList��5#   �      GridLinesVisibility$ 
Horizontal=�6      CanUserAddRows .     HeaderStyle   ColumnHeaderStyle# [  6S      HeadersVisibility$ Column=�6�   $��1��6�      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6�      AutoGenerateColumns .     Columns 5$      0  *System.Windows.Controls.DataGridTextColumn  5%      ,  &System.Windows.Controls.DataGridColumn	   
IsReadOnly	 . 
   Header$
 	Nr Fature��6=   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6P   �� *
NrFature+  5&      	 . $
 	Kamarieri��6<    6P   �� *	Kamarieri+  5'      	 .    FontSize$ 19Q�6<   $

 Data��6J    6Y   �� *Data+ �� StringFormat$ g�� �� ConverterCulture$ it��  5(      	 .    
FontFamily$ Arial)�6;      
FontWeight$ 	ExtraBold"�6N      
Foreground �#1e1f26$
 Total��6{    6�   �� *Total+$ N2��  5)      	 . $
 Tavolina��6;    6M   �� *
Tavolina+  5*      	 . $
 Statusi��6;    6L   �� *	Statusi+ � ContextMenu 5,      �� 5-      .@�5.      m� -   5        $��Anullo_Fature��5.   3   $��Anullo��6#   6f   5/         RowStyle 52      �� 53       �� 
TargetType)  #System.Windows.Controls.DataGridRow"  6   .�55      ��  �� Property � �� �� Value$ 22(�65    �� Triggers 56      �� 57       �� Binding 6*   �� *	Statusi+ �� Value 	Cancelled6F   .a�58   "   ��  � �� �#ce5a576Q   59      �� 5:       6*   �� *	Statusi+
 Closed6F   .a�5;   "   ��  � �� �#a1be956Q   5<      �� 5=       6*   �� *	Statusi+ 	Collected6F   .a�5>   "   ��  � �� �#9a9eab6Q   5?      �� 5@       6*   �� *	Fiskale+ True6F   .a�5A   "   ��  � ��
 �����6U   5B      5D      5G      ]� 5H      $��50��6   $��2��6%   .+�5I      �� $
��Left=�6   $��Center=�63   
�������$
��Bold"�6a   $��30(�6s   Total6�   �� 5J      -   5        $��Totali��5J   5   $��Right=�6   $��Center=�6C   $��Right=�6^   
���  ��$
��Bold"�6�   $��30(�6�   006�   5K      5N      -� 5Q   
   -   5        $��
FaturaShow��5Q   �   $��1��6J   $��0��6Z    -� Zoom$	 200Q�6h   $��Stretch=�6s   $��Stretch=�6�   $��LeftToRight=�6�   5S      �� 5W   
   $��Bottom=�6   $��1��62   $��1��6B   .+�5X      � $��Center=�6   .+�5Y      �� -   5        $��ProgresNumber��5Y   Z   $
��Bold"�6   $��Arial)�6*   $��Center=�6=   .��6o   16r   �� 5Z      -   5        $��Slash��5Z   Z   $
��Bold"�6   $��Arial)�6*   $��Center=�6=   .��6g   /6j   �� 5[      -	   5        $��TotalProgres��5[   \   $
��Bold"�6   $��Arial)�6,   $��Center=�6?   .��6p   16s   5\      � 5^   
   $��0,0,0,10q�6   $��Center=�6'   .+�5_      �� -
   5        $	��Pas��5_   )   $��
ExtraBlack"�64   $��50��6L   $��Center=�6X   $��30(�6z   .��5`      �� $��/Images/back.png��6   5a      �� 5b      -   5        $
��Para��5b   *   $��50��66   $��30(�6C   $��
ExtraBlack"�6R   $��10,0,0,0q�6j   .��5c      �� $��/Images/next.png��6   5d      5e      5f      5i      5j      