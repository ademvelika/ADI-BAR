   M S B A M L   `   `   `  ���� @  <MYBAR, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:MYBAR.View
MYBAR.View      MYBAR.View.LoginView   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     *localclr-namespace:MYBAR.View     -   $��Stretch=�$��Stretch=����#f4f4f7  � 	Resources     ScrollThumbs �� 
TargetType �� Property �� Value �� 
TargetType �Name ��Name �� CornerRadius �� Triggers	 P� Property
 P� Value �� 
TargetName � RowDefinitions ]�Name ]� Thumb n�Name ]� IncreaseRepeatButton ��Name J� Opacity ]� DecreaseRepeatButton P� 
SourceName  ButtonSelectBrush  	DarkBrush �� Angle  ListBoxStyle1 �� RadiusX �� RadiusY �� Padding J� SnapsToDevicePixels   ScrollViewerControlTemplate1  BaseButtonStyle ��Name �� BasedOn��%�
  &	        '�� P    &	 ^    &	 p    '�� �
    7  �� " n�.���  � �� �� " n�.R�� $
 Grid��.+��� $��Stretch=�$��Stretch=�$
��Auto��$
��Auto��
������ �� $ 
Rectangle1��$ 10��$��Stretch=�$��Stretch=�$
��Auto��$
��Auto��#��z�� P� 	 �@�Tag$
 
Horizontal��. ��� $ 
Rectangle1�� � ��$
 Auto���� $ 
Rectangle1�� � ��$ 7���� " ��.���  �@��IsFlicksEnabled .  ��  � ��
 �������  � ��
 �������  � ��$ 10����  � �� �� " ��.R�� $ GridRoot��$��19��#��z�� �� $��0.00001* �.+�]� $ 
PART_Track��$��0����. |�.   n� $ Thumb��#��z��#���    �� $ PageUp��$��ScrollBar.PageDownCommand��$ 0Q�|�.   �� $ PageDown��$��ScrollBar.PageUpCommand��$ 0Q�|�.   P� $ Thumb��	 �@J�IsMouseOver
 . . ��� # �  $ Thumb�� � ��P� $ Thumb��	 �@n�
IsDragging
 . . ��� # �  $ Thumb�� � ��P� 	 � {�
 .  . ��� $ Thumb�� � y�$ 	Collapsed=�P� 	 �@��Orientation$
 
Horizontal=�. ��� $ GridRoot�� �@�LayoutTransform �� $	 -90Q��� $ 
PART_Track�� �@�LayoutTransform �� $	 -90Q���  � ��$
 Auto����  � ��$ 12���� $ Thumb�� �@�Tag$ 
Horizontal���� $ PageDown�� � ��$ ScrollBar.PageLeftCommand���� $ PageUp�� � ��$  ScrollBar.PageRightCommand���� " ��.���  � ��# � ����  � ��$ 1q���  � ��# � ����  � ��$
 Auto=���  � ��$
 Auto=���  � �� . ��  �@��PanningMode$
 Both=���  �@��IsFlicksEnabled .  ��  � ��$ Center=���  � �� �� " ��.R�� .+��� 
�������$ 10��$ 10��$ 0.195Q��� $ Bd��$ 10��#��z��#��z��$ 1q� . ._��� |�.  #��z��#���  .���� # z  P� 	 � {�
 .  . ��� $ Bd��# � �� � ��P� 	 �@��
IsGrouping
 . . ���  � �� .  �� " ��.���  �@�FocusVisualStyle Z� ��  � �� �#57bc90��  � �� �#cccccc��  � ��$ 0q���  � ��$
 Bold"���  � �� �#333333��  � ��$ Center=���  � ��$ Center=���  � ��$ 2,0,2,0q���  � ��$ 0,4,4,0q���  � ��
 �������  � ��$ 18(���  � ��$ 60����  � �� �� " ��.R��� $ Chrome��#��z��#��z��#��z�� . ._��� $ 	Presenter��#��z��#��z��#��z����. # z  P� 	 � {�
 .  . ���  � �� �#333333P� 	 �@J�IsMouseOver
 . . ���  � �� �#67b8e0��  � �� �#cccccc��  � ��
 �����P� 	 � ��
 . . ���  � �� �#1ba1e2��  � �� �#1ba1e2��  � �� �#ffffffP� 	 �@J�	IsFocused
 . . ��� $ Chrome�� � �� �#1ba1e2�� " ��8   .���  �� $��* � � ColumnDefinitions �� $��2* ��� $��3* �.+�� $��0��.+��� $��UniformToFill=� �� StretchDirection$ DownOnly=� . $"��/Images/LoginImageCroped.jpg��� -   $��	RightGrid��$��1�� �� $��* ��� $
��auto ��� $��* �.+��� $��80��$��0,10,0,0q�$��Center=�$��/Images/LogoProgrami.png��� $��1��$	��500��$��20,20,20,20q� �� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto �.+��  �� $
��auto ��� $
��auto ��� $	��200 �.+��� $��DemiBold"����#57bc90$��Center=�$��20(� �� TextAlignment$ Center=�Users�� $��1���� $��2��$
��Auto=�.��A� -   $��usertest�� A� Columns$ 2��� $��1�� �� �� $
��AUTO �.+�G� -   $��password��$��50��$��	ExtraBold"�$��25(�$��0,10,0,0q��� -   $��KeyBoardBtn��
������ $��0,10,0,0q�$��50��$��1��.���� $��/Images/EnterPin.png���� -   $��2�����#57bc90$��20(�$��Heavy"�
�������$��0q�$��50��$��0,10,0,0q�.��Log In�� -   $��ErrorMessage��$��3��$
��Wrap=�$��0,10,0,0q�$��18(�
���  ��A� -   $��KeyBoard��$��Center=�$��2��$y�	Collapsed=�
������   A� Rows$  4��$ 3��