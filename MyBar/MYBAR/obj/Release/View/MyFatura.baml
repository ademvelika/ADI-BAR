   M S B A M L   `   `   `  ���� @  <MYBAR, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:MYBAR.View
MYBAR.View      MYBAR.View.MyFatura   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     *localclr-namespace:MYBAR.View     $��Stretch=�$��Stretch=�.���   � ColumnDefinitions  �� $��3* ��� $��* � � RowDefinitions �� $��4* ��� $��* �.+�� 
�������$��2�� �� $
��auto ��� �� $
��auto �.+��� ���#3f89bf$��0,0,1,0q�._�� ���#f2f2f2$��	2,10,0,10q�  �� �� $
��auto �.+��� -   $��	FilterGUI���� -   $��Filtro��$��1��$��Bottom=�$��Arial)�$��20(�$
��Bold"�
��� � �$��50��$��Filtro��&   System.Windows.Controls.DataGrid  -   $��
FaturaList��   GridLinesVisibility$ 
Horizontal=�   CanUserAddRows .     HeaderStyle   ColumnHeaderStyle# [     HeadersVisibility$ Column=�$��1��   ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ *    AutoGenerateColumns .     Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn	   
IsReadOnly	 . 
   Header$
 	Nr Fature��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *
NrFature+  	 . $
 	Kamarieri�� �� *	Kamarieri+  	 .    FontSize$ 19Q�$

 Data�� �� *Data+ �� StringFormat$ g�� �� ConverterCulture$ it��  	 .    
FontFamily$ Arial)�   
FontWeight$ 	ExtraBold"�   
Foreground �#1e1f26$
 Total�� �� *Total+$ N2��  	 . $
 Tavolina�� �� *
Tavolina+  	 . $
 Statusi�� �� *	Statusi+ � ContextMenu �� .@�m� -   $��Anullo_Fature��$��Anullo��   RowStyle ��  �� 
TargetType)  #System.Windows.Controls.DataGridRow"  .���  �� Property � �� �� Value$ 22(� �� Triggers ��  �� Binding �� *	Statusi+ �� Value 	Cancelled.a���  � �� �#ce5a57��  �� *	Statusi+
 Closed.a���  � �� �#a1be95��  �� *	Statusi+ 	Collected.a���  � �� �#9a9eab��  �� *	Fiskale+ True.a���  � ��
 �����]� $��50��$��2��.+��� $
��Left=�$��Center=�
�������$
��Bold"�$��30(�Total�� -   $��Totali��$��Right=�$��Center=�$��Right=�
���  ��$
��Bold"�$��30(�00-� -   $��
FaturaShow��$��1��$��0�� -� Zoom$	 200Q�$��Stretch=�$��Stretch=�$��LeftToRight=��� $��Bottom=�$��1��$��1��.+�� $��Center=�.+��� -   $��ProgresNumber��$
��Bold"�$��Arial)�$��Center=�.��1�� -   $��Slash��$
��Bold"�$��Arial)�$��Center=�.��/�� -	   $��TotalProgres��$
��Bold"�$��Arial)�$��Center=�.��1� $��0,0,0,10q�$��Center=�.+��� -
   $	��Pas��$��
ExtraBlack"�$��50��$��Center=�$��30(�.���� $��/Images/back.png���� -   $
��Para��$��50��$��30(�$��
ExtraBlack"�$��10,0,0,0q�.���� $��/Images/next.png��