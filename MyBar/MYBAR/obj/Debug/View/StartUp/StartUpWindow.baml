   M S B A M L   `   `   `  ����@  <MYBAR, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:MYBAR.View.StartUpMYBAR.View.StartUp  5   	   ;"clr-namespace:MYBAR.CustomControlsMYBAR.CustomControls  5   	   &     MYBAR.View.StartUp.StartUpWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:MYBAR.View.StartUp     5   	   6control"clr-namespace:MYBAR.CustomControls     5   	     � WindowStartupLocation$  CenterScreen=�5      $	��370��6?   $	��600��6L   .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   �� $��60��6   $��0��6   $��	0,10,0,10q�6)   $��/Images/LogoProgrami.png��6<   �� 5   
   $��1��6    �� Padding$ 10q�6"   ���#f4f4f7 �� TextAlignment$ Center=�6D   $��25(�6[   $��Arial)�6j   Regjistro Programin6�   � 5   
   $��2��6    � ColumnDefinitions 5      �� 5      $
��auto �6#   �� 5      .+�5      �� $��Center=�6   $��50��67   $��
ExtraBlack"�6C   $��	2,50,0,50q�6\   $��Center=�6o   .��6�   	Seriali6�   �� 5    
   -   5        $��
SerialText��5    S   $��Center=�6   $��1��64   $��22(�6E   $��50��6e   $��	10,2,10,2q�6q   $��Center=�6�   6�   5!      � 5"   
   $��3��6    5#      �� 5$      $
��AUTO �6    60   �� 5%      $��* �6    6-   .+�5'   
   "   MYBAR.CustomControls.Loading  -   5          Name$ LoadingAnimate��5'      $	��100��62   $y�	Collapsed=�6B   �� 5(   
   -   5        $��LoadingText��5(   W   $��0,0,0,20q�6   $��1��6(   $��WrapWithOverflow=�66   $y�	Collapsed=�6j   $��18(�6�   $ Center=�6�   
���   �
�������$"Duke u ngarkuar, ju lutem prisni !6�   5)   
   �� 5*   
   -   5        $��	Regjistro��5*   :   $��4��6   $��Bottom=�6   
�������$��22(�6^   ���#57bc90$��60��6�   .��6�   	Regjistro6�   5+      5,      