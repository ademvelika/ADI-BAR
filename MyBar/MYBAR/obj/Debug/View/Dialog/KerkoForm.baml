   M S B A M L   `   `   `  ����@  <MYBAR, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:MYBAR.CustomControls.FatureFilter!MYBAR.CustomControls.FatureFilter  5   
   &     MYBAR.View.KerkoDialog.KerkoForm   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Ccontrol/clr-namespace:MYBAR.CustomControls.FatureFilter     5   
   -   5          � Title$  	KerkoForm��5   	   $	��600��6   $
��1000��6(   
������ ���#f4f4f7$��0q�6}    � WindowStartupLocation$ CenterScreen=�6�    � WindowStyle$
 None=�6�   .��5      � .+�5	   
   ]� .+�5
      �� $	��Top=�6   .+�5      �� -   5        $��30��5      $��Right=�6%   $��20(�6B   
������ .��5      �� $��/Images/delete.png��6   6:   5      �� 6   .+�5      � $
��Left=�6   .+�5      �� -   5        $��LabelKryesor��5      $��20(�6,   6<   �� 5      -   5        $��
Searchtext��5      $	��200��6/   6Y   �� 5      -   5        $��	SearchBtn��5   :   .��5      �� $��20��6$   $��/Images/search.png��62   5      �� 5      �� 6%   -   5         �Name$ MesazhiHelp��5   )   6>   6D   � 5      -   5        $��
TotalPanel��5   }   
�������$��Center=�68   $��20,0,0,0q�6T   $y�	Collapsed=�6f   .+�5      �� $��Center=�6)   $��Arial)�6D   $��22(�6W   
Totali :6p   �� 5      -   5        $��
TotalLabel��5   U   $��10,0,0,0q�6(   $��Center=�6:   $��22(�6g   $
��Bold"�6u   
���  ��$��Arial)�6�   006�   5      5      � 5      -	   5        $��advancedsearch��5   !   .+�5      9�  9� 
IsExpanded .  $��Kerkim i avancuar��67   .��5      �� -
   5        $��AdvancedControls��5   -   .��5   "   8   2MYBAR.CustomControls.FatureFilter.FatureUserFilter  -   5          Name$ 
DateFilter��5   ;   6R   5      5!      5"      5#      5%      &   System.Windows.Controls.DataGrid  5'      -   5        $��DynamicDataGrid��5'   �      HeaderStyle   ColumnHeaderStyle# [  6   
�������   
IsReadOnly .    HeadersVisibility$ Column=�6�   	   RowBackground
	 ���� $��Stretch=�6�   $��Stretch=�6C  
   ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$
 * 6a  $��18(�6q  $��Aileron)�6�  ��6�  �� *ListaDinamike+   	CellStyle 5,      �� 5-       �� 
TargetType*  $System.Windows.Controls.DataGridCell"  6   .�5/      ��  �� Property � �� �� Value
 �����67   �� 50       � ��
 ���� 67   �� 51       � ��$ 18(�65    �� Triggers 54      P� 55       P� Property �@ 
IsSelected P� Value . . �56   "   ��  � �� �#7DA7D96?   �� 57   "    � ��
 �   �6?   59      5<      5>      5A   	   5C      5D      