   M S B A M L   `   `   `  ���� U  QSystem.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3aY=clr-namespace:System.Drawing.Printing;assembly=System.DrawingSystem.Drawing.Printing  @ <MYBAR, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:MYBAR.View.ArtikujMYBAR.View.Artikuj %   MYBAR.View.Artikuj.KategoriView   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     RPrinting=clr-namespace:System.Drawing.Printing;assembly=System.Drawing     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     2local clr-namespace:MYBAR.View.Artikuj       � Title$  KategoriView��$	��400��$	��400�� � WindowStartupLocation$ CenterScreen=� � 	Resources    
LabelStyle �� 
TargetType �� Property �� Value �� BasedOn��%w   &	        '�� P     7   �� " ��.���  � ��$ 20(���  � ��
 �������  � ��$ 3q��� " ��8   .��� $
��0,10q� � RowDefinitions �� $
��auto ��� $
��auto ��� $
��auto ��� $��* � � ColumnDefinitions �� $��* ��� .+��� .��
Emertimi�� -   $
��Emer��$��20(�$��3q�$��1��� $��1��.+�d� -   $��Switch��$��0,0,25,0q�$��30��  AnimatedSwitch#��[ �� 
������ $y�Visible=�.��	Printer�� -   $��cmbPrinterSelection��$��Center=�$y�Hidden=�$��1��$��1��-   'System.Drawing.Printing.PrinterSettings	   InstalledPrinters#��Z	 
 �� SelectedIndex$
 0��� $y�	Collapsed=�$��3q�$��1��$��1��.+��� -   $��PhotoChosenBtn��$��18(�.��Choose File�� -   $��
ClearPhoto��$��7,0,0,0q�$��18(�
�������
���  ��$��
Fshij foto���� -   $��
ImageViwer��$y�	Collapsed=�$	��200��$��2��$��2���� -   $
��Ruaj��$��3��
�������$��50��$��Bottom=�$��18(�.��Ruaj�� -   $��Fshij��$��3��$��1��
���  ��$��50��
�������$��Bottom=�$��18(�.��Fshij