   M S B A M L   `   `   `  ����@  <MYBAR, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:MYBAR.View.ArtikujMYBAR.View.Artikuj  5      $    MYBAR.View.Artikuj.ArtikujList   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      ,local clr-namespace:MYBAR.View.Artikuj  5      -   5        $��Stretch=�5	      $��Stretch=�6,     � 	Resources  5         BaseButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType ��Name J� SnapsToDevicePixels ��Name �� Triggers	 P� Property
 P� Value �� 
TargetName �� BasedOn��%�  &	        '�� �    7   �� 5   
   " ��6(   .�5      ��  �@�FocusVisualStyle 61   Z� �� 5       � �� �#57bc906+   �� 5       � �� �#cccccc6,   �� 5       � ��$ 0q�60   �� 5       � ��$ Black"�6+   �� 5       � �� �#3333336+   �� 5       � ��$
 Left=�6;   �� 5       � ��$ Center=�69   �� 5       � ��$ 2,0,2,0q�6(   �� 5       � ��$ 0,0,5,2q�6'   69   �� 5       � ��
 �����6;   �� 5       � ��$ 20(�6)   66   �� 5       � ��$ 2,0,0,0q�6(   6:   �� 5       � ��$ 65��6'   65   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� $ Chrome��6!   #��z��5      #��z��5       #��z��5!       . ._�5#      �� $ 	Presenter��6/   #��z��6B   #��z��5$      #��z��5%      ��. # z 5'      5(       5)      P� 5*      	 � {�
 .  . �5+   "   ��  � �� �#3333336?   5,      P� 5-      	 �@J�IsMouseOver
 . . �5.   "   ��  � �� �#67b8e06?   �� 5/   "    � �� �#cccccc6@   �� 50   "    � ��
 �����6?   51      P� 52      	 � ��
 . . �53   "   ��  � �� �#1ba1e26?   �� 54   "    � �� �#1ba1e26@   �� 55   "    � �� �#ffffff6?   56      P� 57      	 �@J�	IsFocused
 . . �58   "   �� $ Chrome��6)    � �� �#1ba1e26T   59      5;      5=      5>      �� 5B   
   " ��6   8   6Q   5E      .��5F      �  � RowDefinitions 5H   
   �� 5I       � ColumnDefinitions 5M   
   �� 5N      $��* �6   �� 5O      $��4* �6   �� 5P      $
��auto �6   .+�5S   
   �� $��2��6   $
��Auto=�6(   .��5T      � ���#f4f4f7 5U      �� 5V      $
��auto �6$   �� 5W      �� 5X      $��* �6$   .+�5[      �� -   5        $��Grupet��5[   *   $��1��6   5]      �� 5^      -   5        $��ShtoKategori��5^   n     MaterialDesignRaisedButton#��[ 6   $��0,0,0,5q�6O   $��2��6`   $��Bottom=�6�   .��6�   Shto Kategori5`      5d      5e      � 5f   
   ���#f4f4f7$��1��6&    5h      �� 5i      $
��auto �6    �� 5j      $��2* �6    �� 5k      $��* �6    .+�5m      ]� $
��10,5q�6   $��0��6'   .+�5o      ]� $
��5,10q�6    .+�5q      ��  �� Orientation$ 
Horizontal=�5r      +  %MaterialDesignThemes.Wpf.RippleAssist   
IsCentered . .+�5u      (  "MaterialDesignThemes.Wpf.ColorZone     Mode$ Standard=�5v   	   $��8 4 8 4q�5w   	      CornerRadius$ 2��5x   	    K� ZIndex$ 1��5y   	   $��16 0 0 0q�5z   	   +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth1=�5{   	   .��5|   "   �  5}   &   �� 5~   *   $
��Auto �5      �� 5�   *   $��* �5�      �� 5�   *   $
��Auto �5�      .+�5�   &   �� -   5        $��Kerko��5�   -     MaterialDesignToolButton#���  5�      .��5�   *   '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=null]]   Kind$ Magnify=�5�       J� Opacity$	 .56Q�5�      5�   '   �� 5�   &   -   5        $��	KerkoText��5�      $��1��5�      $��8 0 0 0q�5�      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Build a search bar��5�      .  (MaterialDesignThemes.Wpf.TextFieldAssist   DecorationVisibility$ Hidden=�5�      $��0q�5�      $	��200��5�      $��Center=�5�      5�   #   5�      5�      5�      �� 5�      -   5        $��AllProducts��5�   x   $y�	Collapsed=�6   $��5q�62   ���#78A5A3$
��Bold"�6S   
�������$��Center=�6�   $��	20,01,0,0q�6�   $��Bottom=�6�   .��6�   Shfaq te gjitha Produktet6  �� 5�      -   5        $��ExportToExcel��5�   7    � ToolTip$ Eksporto ne excel��6M   
������ $��Right=�6�   $��Right=�6�   $��0,0,5,0q�6�   .��5�      �� $��Stretch=�6   $��/Images/Excel-icon.png��69   5�      5�      � 5�      -   5        $��
CenterGrid��5�       $��1��6    5�      �� 5�      $��* �6'   �� 5�      $
��auto �6'   .+�5�      � -	   5        $��RecepturaPanel��5�   :   
�������$��1��6*   $y�Visible=�6P   .+�5�      �� $��5,0,5,0q�6!   $
��auto��62   .+�5�      ��   shiritibackgroud#��[ 6    $��
Perberesit��6O   &   System.Windows.Controls.DataGrid  5�      -
   5        $��IngredientDataGrid��5�   �      HeadersVisibility$ Column=�6%      CanUserAddRows .     AutoGenerateColumns .     Columns 5�      9	  3MaterialDesignThemes.Wpf.MaterialDataGridTextColumn	  5�   "   0
  *System.Windows.Controls.DataGridTextColumn 
  FontSize$ 18Q�6M   ,  &System.Windows.Controls.DataGridColumn   MinWidth$	 150Q�6\       
IsReadOnly  . ! 
  
FontWeight$
! Bold"�6}   "   Header$" Asortimenti��6�   1  +System.Windows.Controls.DataGridBoundColumn#   Binding# 6�   �� *Asortimenti+4  .System.Windows.Controls.DataGridTemplateColumn  5�   "   $	 100Q�69   $
" Sasi��6H   $   CellTemplate$ 5�   &   �� 5�   *   .R�5�   .   �� $��0q�66   $
��Bold"�6J   ��6]   �� *Sasi+% �� Mode$% TwoWay=�& �� NotifyOnSourceUpdated& . ' �� NotifyOnTargetUpdated' . ( �� UpdateSourceTrigger$( PropertyChanged=�5�   +   5�   #   
  5�   "   $ 18Q�65   $" Njesi��6D   # 6T   �� *
UnitName+6t   )   	CellStyle) 5�      �� 5�   "   *  $System.Windows.Controls.DataGridCell"  6(   .�5�   &   ��  � �� �#f2f2f26C   �� 5�   &    � ��$ 30��6?   * �� Triggers* 5�   &   P� 5�   *   	 �@ 
IsSelected
 . . �5�   .   ��  � �� �#7DA7D96K   �� 5�   .    � ��
 �   �6K   5�   +   5�   #     5�      =  7System.Windows.Controls.Primitives.DataGridColumnHeader��%W   '        �� 5�   "   "  6(   .�5�   &   ��  � ��$ 18(�6A   6N   5�   #   5�      5�      �� 5�      $��12(�6$   ���#c4dfe6$��0,20,0,0q�6H   $
��Wrap=�6[   Per te shtuar ne list �� 6�   
���  ��.�6�   Right-Click6�   �� 6�   6�   mbi produktet ne te majte6�   �� 5�      $��12(�6$   ���#c4dfe6$��0,10,0,0q�6G   $
��Wrap=�6Z   Per te fshire nga lista�� 6�   6�   �� 6�   
���  ��.�6�   Double-Click6�    mbi produktin6�   5�      5�        5�      -   5        $��ListArtikujContainer��5�   �  -  'MaterialDesignThemes.Wpf.DataGridAssist+   CellPadding$+ 13,8,8,8q�6   ,   ColumnHeaderPadding$, 8q�6Q   $��0��6�   -   GridLinesVisibility$- 
Horizontal=�6�    .  $
��10,0q�6�   $ Column=�6�   $��Stretch=�6  ".   VerticalScrollBarVisibility$
. Auto=�6Z  /   
IsReadOnly/ . 0   ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$0 * 6�   5�      	  5�       0 ,MaterialDesignDataGridTextColumnEditingStyle1   EditingElementStyle#1 [ 6F     . $" Asortimenti��6�   # 6�   �� *Asortimenti+	  5�      #1 [ 6E     . $" Gjendje��6�   $
! Bold"�6�   # 6�   �� *Sasi+	  5�        . $" Njesia��6V   # 6f   �� *
UnitName+	  5�        . $" Cmimi��6V   # 6e   �� *Cmimi+2 �� StringFormat$2 N2��	  5�        . $" Sasi Minimale��6V   # 6m   �� *SasiaMinimale+3 � ContextMenu3 5�      �� 5�      .@�5�      m� -   5        $��AddToIngredientList��5�   '   $	��add��6d   6t   5�      5�      5�      � 5�      $��10,0,0,0q�6   $��2��6&    5�      �� 5�      $��3* �6$   �� 5�      .+�5�      � -   5        $��ArtikullRiGrid��5�   ,   
������� 5�      �� 5�      $
��AUTO �6+   6:   �� 5�      $
��135* �6+   6:   �� 5�      $
��auto �6+   6:   �� 5�      $
��Auto �6+   �� 5�      $	��67* �6+   69   �� 5�      $
��auto �6+   6:   �� 5�      $	��68* �6+   6:   �� 5�      $
��auto �6+   6:   �� 5�      $	��67* �6+   69    5      �� 5     $
��auto �6(   �� 5     $
��auto �6(   .+�5     �� $��26(�6   $��Bottom=�6*   .��6F   Emri6L   �� 5     -   5        $��EmerProduktiNew��5  ,   $��26(�6   $��1��6C   6V   �� 5     $��Bottom=�6   $��26(�67   $��2��6E   $��2��6U   .��6i   Cmim6o   �� 5     -   5        $��CmimProduktiNew��5  A   $��26(�6   
���   �$��4��6Y   6l   �� 5     $��Bottom=�6   $��26(�67   $��5��6E   .��6V   	Sasia Min6a   �� 5	     -   5        $��SasiaMinimale��5	  @   $��26(�6   
���   �$��6��6U   6i   �� 5
     $��Bottom=�6   $��26(�67   $��7��6E   $
��0,15q�6U   .��6d   	Kategoria6o   �� 5     -   5        $��CategoryCombo��5  V   $��45��6   $��26(�6+   $��Center=�6:   $��8��6k   6~   �� 5     $��Center=�6   $��26(�67   $��1��6E   $��3��6R   .��6d   Tipi6j   �� 5     -   5        $��	TipiCombo��5  }   $��45��6   $��1��6Q   $��4��6^   $��26(�6n   6�   �� 5     $��Bottom=�6   $��26(�68   $��1��6F   $��5��6S   $
��0,15q�6c   .��6r   Njesia6z   �� 5     -   5        $��NjesiaCombo��5  X   $��45��6   $��1��6+   $��6��68   $��26(�6H   6o   5     � 5     $��1��6   $��0,0,0,5q�6$   $��Bottom=�65    5     �� 5     $��* �6+   �� 5     $��* �6+   �� 5     $��* �6+   .+�5     �� -   5        $��ShtoProduktBtn��5     $��Center=�65   $��Center=�6P   $��Stretch=�6v   .��6�   Shto5     �� 5     -   5        $��DeleteProduct��5  �   $��5,0,0,0q�6   $��1��6.   ���#CE5A57$��Center=�6T   $y�	Collapsed=�6y   .��6�   Fshij6�   �� 5     -   5        $��CancelUpdate��5  �   $��5,0,5,0q�6   $��2��6.   ���#E1B16A$��Center=�6S   $y�	Collapsed=�6x   .��6�   I Ri6�   5      5!     5#     5%     5&     