   M S B A M L   `   `   `  ����U  QSystem.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3aY=clr-namespace:System.Drawing.Printing;assembly=System.DrawingSystem.Drawing.Printing  5   	   @ <MYBAR, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:MYBAR.View.ArtikujMYBAR.View.Artikuj 5   	   %   MYBAR.View.Artikuj.KategoriView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   RPrinting=clr-namespace:System.Drawing.Printing;assembly=System.Drawing     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:MYBAR.View.Artikuj     5   	     � Title$  KategoriView��5	   	   $	��400��6   $	��400��6,    � WindowStartupLocation$ CenterScreen=�68    � 	Resources 5         
LabelStyle �� 
TargetType �� Property �� Value �� BasedOn��%�   &	        '�� �     7   �� 5   
   " ��6#   .�5      ��  � ��$ 20(�6)   67   �� 5       � ��
 �����6+   �� 5       � ��$ 3q�6'   5      �� 5   
   " ��6   8   6K   5      .��5      � $
��0,10q�6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      .+�5!   
   �� .��6   
Emertimi6   �� 5#   
   -   5        $
��Emer��5#   ;   $��20(�6   $��3q�6    $��1��6+   6I   � 5$   
   $��1��6   .+�5%      d� -   5        $��Switch��5%      $��0,0,25,0q�6>   $��30��6R     AnimatedSwitch#��[ 6^   6�   �� 5'      
������ $y�Visible=�6-   .��6B   	Printer6K   5(      �� 5*   
   -   5        $��cmbPrinterSelection��5*      $��Center=�6.   $y�Hidden=�6P   $��1��6d   $��1��6t   -   'System.Drawing.Printing.PrinterSettings	   InstalledPrinters#��Z	 6�   
 �� SelectedIndex$
 0��6�   � 5+   
   $y�	Collapsed=�6   $��3q�6+   $��1��66   $��1��6C   .+�5-      �� -   5        $��PhotoChosenBtn��5-      $��18(�6H   .��6V   Choose File6c   �� 5.      -   5        $��
ClearPhoto��5.      $��7,0,0,0q�6(   $��18(�6R   
�������
���  ��$��
Fshij foto��6�   50      �� 51   
   -   5        $��
ImageViwer��51   V   $y�	Collapsed=�6   $	��200��6(   $��2��65   $��2��6B   6k   �� 52   
   -   5        $
��Ruaj��52      $��3��61   
�������$��50��6U   $��Bottom=�6b   $��18(�6}   .��6�   Ruaj6�   �� 53   
   -   5        $��Fshij��53      $��3��6   $��1��6A   
���  ��$��50��6b   
�������$��Bottom=�6�   $��18(�6�   .��6�   Fshij6�   54      55      