   M S B A M L   `   `   `  ���� @  <MYBAR, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:MYBAR.View
MYBAR.View      MYBAR.View.MbyllTurnin   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     *localclr-namespace:MYBAR.View     -     � WindowStartupLocation$  CenterScreen=�$	��400��$	��600��$��50q����#f4f4f7 � Title$ MbyllTurnin��.���  � RowDefinitions �� $
��auto ��� $
��auto ��� $��* ��� $��* � � ColumnDefinitions �� �� �� �� .+��� $��4��.+��� ���#22d0c0$��Center=�$��40(�$��Mbyllja e turnit���� �� $��4��$��1��.+�� .+��� -   $��
Labelxhiro��$��20(�$
��0,10q�$��Totali ���� -   $��Shuma��$��Center=�$��Center=�
���  ��$��Arial)�$��
ExtraBlack"�$��20(�$
��0,10q�$��0���� .��Turni i mbyllur per sot&   System.Windows.Controls.DataGrid  -   $��TurnetEPara��   
IsReadOnly .    AutoGenerateColumns .     Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   
IsReadOnly .    Header$
 Data��1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 �� *Data+   . 
   
FontFamily$
 Arial)�   
Foreground
 �  ��   
FontWeight$ 
ExtraBlack"�$ Total��	 �� *Total+ �� StringFormat$ N2��   . $
 Arial)�
 �  ��$ 
ExtraBlack"�$ Total��	 �� *Fiscal_Orders_Total_Sum+$ N2��   	CellStyle ��  �� 
TargetType*  $System.Windows.Controls.DataGridCell"  .���  �� Property � �� �� Value$ 20(���  � ��$ Aileron Thin)���  � ��$ 35�� �� Triggers P�  P� Property �@ 
IsSelected P� Value . . ���  � ��
 ��ح���  � ��
 �   �� -   $��OtherUsersPanel��$y�	Collapsed=�$��Center=�
�������$��2��$��4��.+��� $��20(�.��20Tavolinat e pambyllura do ti kalojne perdoruesit�� -   $��
OtherUsers��$��20(�
��������� -   $��MbyllTurnBtn��   HeaderBrush#��[  $��2q�  shiritibackgroud#��[ $��Bottom=�$��3��$��4��$��40��._��� -   $��OnlyBtn��$��Stretch=� �� Padding$ 0,3,0,0q�$��20(� �� TextAlignment$ Center=����� " �� P�  �@J�IsMouseOver . . ���  � ��
 ��ح�
Mbyll Turn