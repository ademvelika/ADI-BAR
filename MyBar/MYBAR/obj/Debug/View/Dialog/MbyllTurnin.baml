   M S B A M L   `   `   `  ����@  <MYBAR, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:MYBAR.View
MYBAR.View  5   	       MYBAR.View.MbyllTurnin   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:MYBAR.View     5   	   -   5          � WindowStartupLocation$  CenterScreen=�5   0   $	��400��5      $	��600��6'   $��50q�63   ���#f4f4f7 � Title$ MbyllTurnin��5   	   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      .+�5   
   �� $��4��6   .+�5      �� ���#22d0c0$��Center=�6*   $��40(�6G   $��Mbyllja e turnit��6V   6t   �� 5      6   5      �� 5   
   $��4��6   $��1��6*   .+�5      � .+�5      �� -   5        $��
Labelxhiro��5      $��20(�6+   $
��0,10q�69   $��Totali ��6G   �� 5      -   5        $��Shuma��5      $��Center=�6%   $��Center=�6G   
���  ��$��Arial)�6s   $��
ExtraBlack"�6�   $��20(�6�   $
��0,10q�6�   $��0��6�   5      �� 5       .��6   Turni i mbyllur per sot6-   &   System.Windows.Controls.DataGrid  5!      -   5        $��TurnetEPara��5!   E      
IsReadOnly .    AutoGenerateColumns .     Columns 5"      0  *System.Windows.Controls.DataGridTextColumn  5$      ,  &System.Windows.Controls.DataGridColumn   
IsReadOnly .    Header$
 Data��6;   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6I   �� *Data+  5%       . 
   
FontFamily$
 Arial)�6;      
Foreground
 �  ��   
FontWeight$ 
ExtraBlack"�6_   $ Total��6w   	 6�   �� *Total+ �� StringFormat$ N2��  5&       . $
 Arial)�6;   
 �  ��$ 
ExtraBlack"�6_   $ Total��6w   	 6�   �� *Fiscal_Orders_Total_Sum+$ N2��   	CellStyle 5(      �� 5)       �� 
TargetType*  $System.Windows.Controls.DataGridCell"  6   .�5*      ��  �� Property � �� �� Value$ 20(�65   �� 5+       � ��$ Aileron Thin)�67   6O   �� 5,       � ��$ 35��63    �� Triggers 5.      P� 5/       P� Property �@ 
IsSelected P� Value . . �50   "   ��  � ��
 ��ح�6?   �� 51   "    � ��
 �   �6?   53      56      58      59      � 5=   
   -   5        $��OtherUsersPanel��5=   +   $y�	Collapsed=�6   $��Center=�6B   
�������$��2��6p   $��4��6}   .+�5>      �� $��20(�6   .��6#   20Tavolinat e pambyllura do ti kalojne perdoruesit6U   �� 5?      -   5        $��
OtherUsers��5?   %   $��20(�6   
�������67   5@      �� 5A   
   -   5        $��MbyllTurnBtn��5A         HeaderBrush#��[  6   $��2q�6<     shiritibackgroud#��[ 6P   $��Bottom=�6�   $��3��6�   $��4��6�   $��40��6  ._�5C      �� -   5        $��OnlyBtn��5C   l   $��Stretch=�6    �� Padding$ 0,3,0,0q�65   $��20(�6G    �� TextAlignment$ Center=�6U   ��5D      �� 5E      " ��6    5F      P� 5H       �@J�IsMouseOver . . �5I      ��  � ��
 ��ح�5K      5L      5N      
Mbyll Turn5Q      5R      5U      5V      