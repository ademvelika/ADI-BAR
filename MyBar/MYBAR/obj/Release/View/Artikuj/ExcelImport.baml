   M S B A M L   `   `   `  ���� @  <MYBAR, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:MYBAR.View.ArtikujMYBAR.View.Artikuj  $    MYBAR.View.Artikuj.ExcelImport   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     2local clr-namespace:MYBAR.View.Artikuj     $��Stretch=�$��Stretch=�.���   � RowDefinitions  �� $
��auto ��� $��* �.+�� $
��0,15q�$��0�� � ColumnDefinitions �� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto �.+��� -   $
��Path��$��25(�$��Stretch=��� -   $��Chose��$��1��$��25(�.��
Chose File�� -   $��Import��$��2��$��10,0,0,0q�$��20(�
�������.��Import�� $��3��.+��� -   $
��Info��.���� $��50��$��/Images/info.png��� -   $��	PopupInfo��$��Mouse=�$
��Fade=� � AllowsTransparency . .���� -   $��CatetegoryDesctription�� �� Padding$ 10q�
����������#011a27$
��Wrap=�&   System.Windows.Controls.DataGrid  -   $��ViewData��   HeaderStyle   ColumnHeaderStyle# [  $��0q�$��1��   AutoGenerateColumns .     CanUserAddRows .     ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ *    Columns 4  .System.Windows.Controls.DataGridTemplateColumn  ,  &System.Windows.Controls.DataGridColumn	   Header$
	 Emer��
   CellTemplate
 �� .R��� $��Arial)�$��0q�$
��Bold"����� *	Emertim+ �� Mode$ TwoWay=� �� NotifyOnSourceUpdated .  �� NotifyOnTargetUpdated .  �� UpdateSourceTrigger$ PropertyChanged=�  $
	 Cmim��
 �� .R��� $��0q�$��	ExtraBold"�$��Arial)�
����������� *	CmimError+���� *Cmim+$ TwoWay=� .  . $ PropertyChanged=�  $	 	Kategoria��
 �� .R��� $��0q�$
��Bold"����� *
Kategori+$ TwoWay=� .  . $ PropertyChanged=�   	CellStyle ��  �� 
TargetType*  $System.Windows.Controls.DataGridCell"  .���  �� Property � �� �� Value$ 20(���  � ��$ 35�� � 	Resources =  7System.Windows.Controls.Primitives.DataGridColumnHeader��%-   '        �� "  .���  � ��$ 27(�