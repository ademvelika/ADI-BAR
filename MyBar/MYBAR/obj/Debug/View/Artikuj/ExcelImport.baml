   M S B A M L   `   `   `  ����@  <MYBAR, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:MYBAR.View.ArtikujMYBAR.View.Artikuj  5      $    MYBAR.View.Artikuj.ExcelImport   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:MYBAR.View.Artikuj     5      $��Stretch=�5      $��Stretch=�6)   .��5	      �   � RowDefinitions  5
   
   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   � $
��0,15q�6   $��0��6    � ColumnDefinitions 5      �� 5      $
��auto �6#   �� 5      $
��auto �6$   �� 5      $
��auto �6#   �� 5      $
��auto �6#   .+�5      �� -   5        $
��Path��5   E   $��25(�6   $��Stretch=�6'   6S   �� 5      -   5        $��Chose��5   %   $��1��6   $��25(�6F   .��6T   
Chose File6`   �� 5      -   5        $��Import��5   7   $��2��6   $��10,0,0,0q�6%   $��20(�6Z   
�������.��6�   Import6�   �� 5      $��3��6   .+�5      �� -   5        $
��Info��5      .��5      �� $��50��6   $��/Images/info.png��6$   5      � 5      -   5        $��	PopupInfo��5   ,   $��Mouse=�6   $
��Fade=�6>    � AllowsTransparency . .��5      �� -   5        $��CatetegoryDesctription��5   T    �� Padding$ 10q�6   
����������#011a27$
��Wrap=�6r   6�   5       5!      5"      &   System.Windows.Controls.DataGrid  5#   
   -   5        $��ViewData��5#   �      HeaderStyle   ColumnHeaderStyle# [  6   $��0q�6E   $��1��6Z      AutoGenerateColumns .     CanUserAddRows .     ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6�      Columns 5$      4  .System.Windows.Controls.DataGridTemplateColumn  5%      ,  &System.Windows.Controls.DataGridColumn	   Header$
	 Emer��6)   
   CellTemplate
 5&      �� 5'      .R�5(      �� $��Arial)�6&   $��0q�69   $
��Bold"�6M   ��6`   �� *	Emertim+ �� Mode$ TwoWay=� �� NotifyOnSourceUpdated .  �� NotifyOnTargetUpdated .  �� UpdateSourceTrigger$ PropertyChanged=�5)      5,        5-      $
	 Cmim��6)   
 5.      �� 5/      .R�50      �� $��0q�6'   $��	ExtraBold"�6;   $��Arial)�6R   
���������6g   �� *	CmimError+��6�   �� *Cmim+$ TwoWay=� .  . $ PropertyChanged=�51      54        55      $	 	Kategoria��6)   
 56      �� 57      .R�58      �� $��0q�6&   $
��Bold"�6:   ��6O   �� *
Kategori+$ TwoWay=� .  . $ PropertyChanged=�59      5<         	CellStyle 5?      �� 5@       �� 
TargetType*  $System.Windows.Controls.DataGridCell"  6   .�5D      ��  �� Property � �� �� Value$ 20(�61   �� 5F       � ��$ 35��6/   5H       � 	Resources 5L      =  7System.Windows.Controls.Primitives.DataGridColumnHeader��%W   '        �� 5M      "  6   .�5P      ��  � ��$ 27(�61   6>   5R      5S      5T      5U      5V      