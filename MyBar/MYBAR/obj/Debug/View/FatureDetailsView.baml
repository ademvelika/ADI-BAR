   M S B A M L   `   `   `  ����@  <MYBAR, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:MYBAR.View
MYBAR.View  5   	   "    MYBAR.View.FatureDetailsView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:MYBAR.View     5   	   $��Stretch=�5      $��Stretch=�68   .��5	      �   � RowDefinitions  5   
   �� 5      $	��10* �6   6-   �� 5      $
��auto �6   6.    � ColumnDefinitions 5   
   �� 5      $
��auto �6   6.   �� 5      $��* �6   6+   .+�5   
   �� $��10,10,10,10q�6   $��2��6+   .+�5      �� 
����������#67b8e0 �� TextAlignment$ Center=�6@   $��20(�6W   $��Center=�6f   Koka6�   �� 5   
   -   5        $��KokaText��5      $	��100��6#   $��18(�64    �� TextWrapping$
 Wrap=�6B    �� AcceptsReturn . $��Stretch=�6k   $	��100��6�   6�   �� 5      
����������#67b8e0$ Center=�6A   $��20(�6X   $��Center=�6f   Fundi6�   �� 5   
   -   5        $��FundText��5      $	��100��6#   $
 Wrap=�64    . $��18(�6]   $��Stretch=�6k   $	��100��6�   6�   �� 5      
����������#67b8e0$ Center=�6>   $��20(�6U   $��Center=�6c   Imazh6�   �� 5      -   5        $��FatureImage��5      6*   �� 5      -   5        $��
FileChoser��5   $   $��20(�6   
����������#67b8e0.��6y   
ChooseFile6�   �� 5      -   5        $��
CleanImage��5   5   $��0,5,0,0q�6   $��20(�6&   
�������
���  ��.��6�   Clean Image6�   � 5      .+�5       �� $��0,10,0,0q�6   $��Georgia)�6+   $
 Left=�6B   $��20(�6W   $��Center=�6e   
Shfaq Cmim6�   d� 5!      -   5        $��Switch��5!      $
��30,0q�6*   $��25��69      AnimatedSwitch#��[  6E   6p   5#      � 5$      .+�5%      �� $��0,10,0,0q�6   $��Georgia)�6/   $
 Left=�6F   
��� E��$��20(�6r   $��Center=�6�   FULL BILL MODE*6�   d� 5&      -   5        $��FULLBILLSWITCH��5&      $
��30,0q�66   $��25��6E   #��[  6Q   6|   5'      5(      �� 5)   
   -   5        $��RuajFatureInfo��5)   t   $��50��6   $��20(�6   $��1��6+   $��1,1,10,1q�69   
����������#87b780.��6�   Ruaj6�   -� 5*   
   -	   5        $��	DocReader��5*   9    -� Zoom$	 200Q�6   $��1��6)   $	��200��6K   6^   �� 5+   
   -
   5        $��PreviewFatureInfo��5+   f   $��20(�6   $��1��6   $��2��6/   
����������#67b8e0.��6�   	Preview6�   5-      5.      