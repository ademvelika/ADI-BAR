   M S B A M L   `   `   `  ����@  <MYBAR, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:MYBAR.View.POSMYBAR.View.POS  5      C&clr-namespace:MYBAR.CustomControls.POSMYBAR.CustomControls.POS  5          MYBAR.View.POS.POSView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:MYBAR.View.POS     5      :control&clr-namespace:MYBAR.CustomControls.POS     5      -   5        $��Aileron Thin)�5	      ���#D6DBE9  � 	Resources  5         BorderBrush �� Color  
Background  
Foreground  ScrollBarButton �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius �� Path �� RelativeSource	 �� Triggers
 P� Property P� Value �� 
TargetName  ScrollBarThumb  ScrollBarPageButton J� Opacity  VerticalScrollBar � RowDefinitions ]� DecreaseRepeatButton ]� Thumb ]� IncreaseRepeatButton  HorizontalScrollBar � ColumnDefinitions �� Triggers��%�  &	        &	 %     &	 F     &	 i     7  7   7  &	 �    7  7  &	 �    7  &	 f    7  7  7  7  7  &	 ~
    7  7  7  7  7  '�� �    7  7  �� 5   
   $ Transparent��6.   �� 5   
   $ DimGray��6-   �� 5   
   $ 	LightGray��6-   �� 5   
   " ��6(   .�5      ��  �@K�ZIndex$ 1��6-   �� 5       �@J�SnapsToDevicePixels . 64   �� 5       �@�OverridesDefaultStyle . 66   �� 5       � |� .  6*   �� 5       � ��$ 40��6&   �� 5       � ��$ 40��6'   �� 5       �@J�Opacity$	 0.7Q�6(   �� 5       � �� 5       �� 5!      " ��6&   .R�5"      �� $��Border��5#      $ 40��5$      8��  8�� $��2q�5'      ._�5(      F� $��Center=�5)      $��Center=�5*      8�� ��5,      �� $ Content� �� *TemplatedParent+5-      	 5.      P� 5/      
 � �� . . �50   "   �� $ Border��6)    � ��$ -5q�6O   �� 51   "   $ Border��6)    �@K�ZIndex$ 99999��6U   52      54      56      57      �� 59   
   " n�6'   .�5:      ��  �@K�ZIndex$ 1��6-   �� 5;       �@J�SnapsToDevicePixels . 64   �� 5<       �@�OverridesDefaultStyle . 66   �� 5=       � �� .  6*   �� 5>       � |� .  6*   �� 5?       �@J�Opacity$	 0.7Q�6(   �� 5@       � �� 5A      �� 5B      " n�6&   .R�5C      �� $��Border��6!   $ 3��5D      8��  
������ $��1q�5G      	 5H      P� 5I      
 �@n�
IsDragging . . �5J   "   �� $ Border��6)   8   � ��6S   5K      5M      5O      5P      �� 5Q   
   " ��6,   .�5R      ��  �@K�ZIndex$ 0��6-   �� 5S       �@J�SnapsToDevicePixels . 64   �� 5T       �@�OverridesDefaultStyle . 66   �� 5U       � �� .  6*   �� 5V       � |� .  6*   �� 5W       � �� 5X      �� 5Y      " ��6&   .R�5Z      �� 8��  $ 3��6J   $	 0.2Q�5[      
������ 6   5\      5^      5_      �� 5a   
   " ��65   .R�5b      �  5c      �� 5d      $��40��6$   �� 5e      $��* �6$   �� 5f      $��40��6$   .+�5h      �� $��3��5i      
������ 
������ 5k      �� 5l      $��0��5m      8��  $��40��5o      $��ScrollBar.PageUpCommand��5p      $��M 0 4 L 8 4 L 4 0 Z��5q      ]� 5r      $��
PART_Track��5s      $��1��5t      ��.  5v      �� 5w      8�� $��9,2,9,2q�5y      $��ScrollBar.PageUpCommand��5z       5|      n� 5}      8�� $��6,1,6,1q�6H    5      �� 5�      8�� $��9,2,9,2q�5�      $��ScrollBar.PageDownCommand��5�      5�      �� 5�      $��3��5�      8�� $��40��5�      $��ScrollBar.PageDownCommand��5�      $��M 0 0 L 4 4 L 8 0 Z��5�      5�      5�      �� 5�   
   " ��66   .R�5�      �  5�      �� 5�      $��40��6'   �� 5�      $��* �6'   �� 5�      $��40��6'   .+�5�      �� $��3��5�      
������ 
������ 5�      �� 5�      $��0��5�      8��  $��40��5�      $��ScrollBar.LineLeftCommand��5�      $��M 4 0 L 4 8 L 0 4 Z��5�      ]� 5�      $��
PART_Track��5�      $��1��5�      ��.   5�      �� 5�      8�� $��2,9,2,9q�5�      $��ScrollBar.PageLeftCommand��5�       5�      n� 5�      8�� $��1,6,1,6q�6H    5�      �� 5�      8�� $��2,9,2,9q�5�      $ ��ScrollBar.PageRightCommand��5�      5�      �� 5�      $��3��5�      8�� $��40��5�      $ ��ScrollBar.LineRightCommand��5�      $��M 0 0 L 4 4 L 0 8 Z��5�      5�      5�      �� 5�   
   " ��6   .�5�      ��  �@J�SnapsToDevicePixels . 64   �� 5�       �@�OverridesDefaultStyle . 66   �� 5�       �@�SmallChange$	 150Q�6,   �� 5�       �@�LargeChange$	 150Q�6,    5�      P� 5�      
 �@��Orientation$ 
Horizontal=�61   . �5�      ��  � ��$
 Auto��6.   �� 5�       � ��$ 40��6/   �� 5�       � ��8   61   5�      P� 5�      
 �@��Orientation$ Vertical=�61   . �5�      ��  � ��$ 40��6.   �� 5�       � ��$
 Auto��6/   �� 5�       � ��8  61   5�      5�      5�      .��5�      �  5�   
   �� 5�      $
��auto �6   �� 5�      $��2* �6   �� 5�      $��* �6    5�   
   �� 5�      $��4* �6   �� 5�      $��5* �6   �� 5�      $
��auto �6   .+�5�   
   �� -   5        $��
FastSearch��5�   �   $��
20,20,20,0q�6+   $��22(�6?   |�. $��Bottom=�6^   $��40��6{   6�   �� 5�   
   $��
20,50,20,0q�6   $
��Auto=�6+   $��1��6O   .��5�   
   �� 
�������.+�5�   
   �� .��5�      )   #MYBAR.CustomControls.POS.FatureGrid  -   5          Name$ MYGRID��5�      5�      5�      �� 5�      
���   �$��1��6,   69   �� 5�      .��5�        -   5        $ 
MYGRIDOPEN��5�   '   5�      5�      5�      5�      �� 5�   
    �� PanningMode$
 Both=�6   $
��Auto=�6+   $��1��6N   $��2��6[   $��1��6l   .��5�   
   � -   5        $��Artikujt��5�   j   ��. 
������ $��10,50,30,20q�6U   6~   5�   
   � 5�   
   ���#f3f3f3$��	20,0,20,0q�6%   $��2��69    5�      �� 5�      6"   �� 5�      6"   .+�5�      �� .+�5�      �� $��20��6   6+   � 5�      $
��0,10q�6   $��Center=�6*   .+�5�      �� $��28(�6!   	Tavolina:6:   �� 5�      -   5        $��	FreeTable��5�   �   
������ $��28(�68   $��50��6F   6�   �� 5�      $��28(�6    $��Arial)�6.   .��6B   Total6I   �� 5�      -   5        $��Total��5�   R   $	��100��6   
��� E��$��30(�6D   $��	ExtraBold"�6`   $��Arial)�6x   .��6�   06�   5      5     A� 5     $��1��6    A� Columns$ 2��6'   .+�5     �� -   5        $��MbyllFature��5  �   ���#A1BE95
�������$��20(�6=   $��0,0,0,2q�6L   $��Center=�6_   $��Stretch=�6�   $��Mbyll Fature��6�   �� 5     -	   5        $
��Ruaj��5  �   ���#78A5A3
�������$��20(�6A   $��5,0,0,2q�6R   $��Center=�6d   $��Stretch=�6�   $��1��6�   $
��Ruaj��6�   �� 5
     -
   5        ���#E1B16A
�������$��20(�5
  A   $��2��6P   $��Center=�6`   $��Stretch=�6�   $	��Dil��6�   �� 5     -   5        $��FaturePermbledhese��5  �   $��20(�6   
�������$��Center=�6<   $��5,0,0,0q�6_   $��Center=�6p   ���#CE5A57$��3��6�   $��Permb.��6�   5     5     � 5  
   $��1��6   $��2��6   $��3��6,    5     �� 5     $
��auto �6#   �� 5     .+�5     �� $��	ExtraBold"�6   
�������$��5,5,5,5q�6D   $��20(�6U    � LayoutTransform 5     �� 5      �� Angle$ 90Q�6&   5     �� 5     $��0,0,15,0q�6   $
 Both=�6-   $��1��6@   $
��Auto=�6P   .��5     �� -   5        $��Grupet��5  W   ��. $��	0,50,10,0q�6D   6h   5     5!     5#     5$     