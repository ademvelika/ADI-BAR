   M S B A M L   `   `   `  ���� @  <MYBAR, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:MYBAR.View.POSMYBAR.View.POS  C&clr-namespace:MYBAR.CustomControls.POSMYBAR.CustomControls.POS      MYBAR.View.POS.POSView   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     .localclr-namespace:MYBAR.View.POS     :control&clr-namespace:MYBAR.CustomControls.POS     -   $��Aileron Thin)����#D6DBE9  � 	Resources     BorderBrush �� Color  
Background  
Foreground  ScrollBarButton �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius �� Path �� RelativeSource	 �� Triggers
 P� Property P� Value �� 
TargetName  ScrollBarThumb  ScrollBarPageButton J� Opacity  VerticalScrollBar � RowDefinitions ]� DecreaseRepeatButton ]� Thumb ]� IncreaseRepeatButton  HorizontalScrollBar � ColumnDefinitions �� Triggers��%
  &	        &	      &	 *     &	 ?     7  7   7  &	 *    7  7  &	 �    7  &	 i    7  7  7  7  7  &	 -    7  7  7  7  7  '�� �    7  7  �� $ Transparent���� $ DimGray���� $ 	LightGray���� " ��.���  �@K�ZIndex$ 1����  �@J�SnapsToDevicePixels . ��  �@�OverridesDefaultStyle . ��  � |� .  ��  � ��$ 40����  � ��$ 40����  �@J�Opacity$	 0.7Q���  � �� �� " ��.R��� $��Border��$ 40��8��  8�� $��2q�._�F� $��Center=�$��Center=�8�� ���� $ Content� �� *TemplatedParent+	 P� 
 � �� . . ��� $ Border�� � ��$ -5q��� $ Border�� �@K�ZIndex$ 99999���� " n�.���  �@K�ZIndex$ 1����  �@J�SnapsToDevicePixels . ��  �@�OverridesDefaultStyle . ��  � �� .  ��  � |� .  ��  �@J�Opacity$	 0.7Q���  � �� �� " n�.R��� $��Border��$ 3��8��  
������ $��1q�	 P� 
 �@n�
IsDragging . . ��� $ Border��8   � ���� " ��.���  �@K�ZIndex$ 0����  �@J�SnapsToDevicePixels . ��  �@�OverridesDefaultStyle . ��  � �� .  ��  � |� .  ��  � �� �� " ��.R��� 8��  $ 3��$	 0.2Q�
������ �� " ��.R��  �� $��40���� $��* ��� $��40��.+��� $��3��
������ 
������ �� $��0��8��  $��40��$��ScrollBar.PageUpCommand��$��M 0 4 L 8 4 L 4 0 Z��]� $��
PART_Track��$��1����.  �� 8�� $��9,2,9,2q�$��ScrollBar.PageUpCommand�� n� 8�� $��6,1,6,1q� �� 8�� $��9,2,9,2q�$��ScrollBar.PageDownCommand���� $��3��8�� $��40��$��ScrollBar.PageDownCommand��$��M 0 0 L 4 4 L 8 0 Z���� " ��.R��  �� $��40���� $��* ��� $��40��.+��� $��3��
������ 
������ �� $��0��8��  $��40��$��ScrollBar.LineLeftCommand��$��M 4 0 L 4 8 L 0 4 Z��]� $��
PART_Track��$��1����.   �� 8�� $��2,9,2,9q�$��ScrollBar.PageLeftCommand�� n� 8�� $��1,6,1,6q� �� 8�� $��2,9,2,9q�$ ��ScrollBar.PageRightCommand���� $��3��8�� $��40��$ ��ScrollBar.LineRightCommand��$��M 0 0 L 4 4 L 0 8 Z���� " ��.���  �@J�SnapsToDevicePixels . ��  �@�OverridesDefaultStyle . ��  �@�SmallChange$	 150Q���  �@�LargeChange$	 150Q� P� 
 �@��Orientation$ 
Horizontal=�. ���  � ��$
 Auto����  � ��$ 40����  � ��8   P� 
 �@��Orientation$ Vertical=�. ���  � ��$ 40����  � ��$
 Auto����  � ��8  .���  �� $
��auto ��� $��2* ��� $��* � �� $��4* ��� $��5* ��� $
��auto �.+��� -   $��
FastSearch��$��
20,20,20,0q�$��22(�|�. $��Bottom=�$��40���� $��
20,50,20,0q�$
��Auto=�$��1��.���� 
�������.+��� .��)   #MYBAR.CustomControls.POS.FatureGrid  -     Name$ MYGRID���� 
���   �$��1���� .��  -   $ 
MYGRIDOPEN����  �� PanningMode$
 Both=�$
��Auto=�$��1��$��2��$��1��.��� -   $��Artikujt����. 
������ $��10,50,30,20q�� ���#f3f3f3$��	20,0,20,0q�$��2�� �� �� .+��� .+��� $��20��� $
��0,10q�$��Center=�.+��� $��28(�	Tavolina:�� -   $��	FreeTable��
������ $��28(�$��50���� $��28(�$��Arial)�.��Total�� -   $��Total��$	��100��
��� E��$��30(�$��	ExtraBold"�$��Arial)�.��0A� $��1�� A� Columns$ 2��.+��� -   $��MbyllFature�����#A1BE95
�������$��20(�$��0,0,0,2q�$��Center=�$��Stretch=�$��Mbyll Fature���� -	   $
��Ruaj�����#78A5A3
�������$��20(�$��5,0,0,2q�$��Center=�$��Stretch=�$��1��$
��Ruaj���� -
   ���#E1B16A
�������$��20(�$��2��$��Center=�$��Stretch=�$	��Dil���� -   $��FaturePermbledhese��$��20(�
�������$��Center=�$��5,0,0,0q�$��Center=����#CE5A57$��3��$��Permb.��� $��1��$��2��$��3�� �� $
��auto ��� .+��� $��	ExtraBold"�
�������$��5,5,5,5q�$��20(� � LayoutTransform ��  �� Angle$ 90Q��� $��0,0,15,0q�$
 Both=�$��1��$
��Auto=�.���� -   $��Grupet����. $��	0,50,10,0q�