   M S B A M L   `   `   `  ���� @  <MYBAR, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:MYBARMYBAR      	MYBAR.App   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     %localclr-namespace:MYBAR       �� 	Resources     styleCalendar �� 
TargetType&   System.Windows.Controls.Calendar �� Property �� Value �� 
TargetType5  /System.Windows.Controls.Primitives.CalendarItem  Name  HeaderBrush �� 
StartPoint �� EndPoint � SpreadMethod	 � ColorInterpolationMode
 � Color � Offset  HeaderBorderBrush  HeaderStyle=  7System.Windows.Controls.Primitives.DataGridColumnHeader  RowStyleWithAlternation)  #System.Windows.Controls.DataGridRow �� Triggers P� Property P� Value3  -System.Windows.Media.Effects.DropShadowEffect   Color   ShadowDepth   
BlurRadius  shiritibackgroud  AnimatedSwitch (� Stretch �� Left
 �� Top A�Name T� X T� Y J� BitmapEffect F� Softness F� ShadowDepth F� 	Direction F� Color �� Triggers N� EnterActions �� TargetProperty	  �� To! g� Duration" �� 
TargetName# O� KeyTime$ O� Value% �� 	KeySpline& N� ExitActions' �� MergedDictionaries( �� Source�� ' �� $e( _pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Light.xaml?��� $h( bpack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Defaults.xaml?��� $z( tpack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.DeepPurple.xaml?��� $s( mpack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Accent/MaterialDesignColor.Lime.xaml?�%
  &	        &	 y     &	 !    &	 �    7  &	 �    &	 �    &	 `    �� "  .���  � �� �� "  .R�(� $	��250��$	��250��.��  $ PART_CalendarItem��#��z��#��z��#��z���� $ 0.5,0&�$ 0.5,1&�$	 Pad=�$	 SRgbLinearInterpolation=�.��� $
 	#FF89D0B1��$
 0.01Q�� $
 	#FF57BC90��$
 0.94Q�� $
 	#FF4EA981��$
 0.52Q��� $ 0.5,0&�$ 0.5,1&�.��� $
 	#FF1D1D1D��$ 0.614Q�� $
 	#FF007F96��$ 0.853Q�� $
 	#FF0AEAFA��$ 1Q��� "  .���  � ��8   ��  � ��
 �������  � ��$ 1q���  �@J�SnapsToDevicePixels . ��  � ��$
 Left=���  � ��$ 0����  � ��$ 30����  �@�Cursor$
 Hand����  � ��$ 20(���  � ��$ 40���� "  .���  �@J�SnapsToDevicePixels . ��  � ��
 �������  � ��$ Normal"���  � ��$ 22(���  �@�ContextMenu Z�  P�  �@ AlternationIndex$ 1��. ���  � �� �	#FFD0D0E0P�  �@J�IsMouseOver . . ���  � �� �#F9F99FP�  �@ 
IsSelected . . ���  � �� �#F9F99FP�  �@=�HasError . . ���  �@J�Effect   $	 Red��$ 0Q�$ 20Q���  � ��$ 2q���  � ��
 �  ����  � ��
 ��  ���  � ��$ 12(��� $	 0,0&�$	 0,1&�$	 Pad=�$	 SRgbLinearInterpolation=�.��� $
 	#FFC7C7C7��$
 0.86Q�� $
 	#FFE6E7E7��$
 0.49Q�� $
 	#FFFFFFFF��$
 0.12Q��� " d�.���  � ��
 �   ���  � �� �#FAFAFB��  � �� �#EAEAEB��  � �� �� " d�.R�(� $ Uniform=�.���� $��Layer_1��$��20��$��20��$ 10��$ 0��.+�A� $ 0��$��20��$��20��#��z��#��z��$	��0.5��A� $ 15��$��20��$��20��#��z��#��z��$	��0.5���� $��
rect416927��$ 10��$��15��$��20��#��z��#��z��$��0,0.5,0,0.5q�A� $ ellipse��$ 0��$��20��$��20��
�������#��z��$	��0.3��z�T� $ 0Q�$ 0Q� F� $	 0.1Q�$	 0.7Q�$	 270Q�$ #BBBBBB�� P�  �@d�	IsChecked$
 TrueY� �� .���� .���� $ Background.Color�$  #52D468X�$! 0:0:0.2D��� $ BorderBrush.Color�$  #41C955X�$! 0:0:0.2D�U� $6 0(Ellipse.RenderTransform).(TranslateTransform.X)�$" ellipse��.\��� $# 0��$ 0�� $# 0:0:0.4��$% 0, 1, 0.6, 1��$ 15& �� .���� .���� $ Background.Color�$  #FAFAFBX�$! 0:0:0.2D��� $ BorderBrush.Color�$  #EAEAEBX�$! 0:0:0.2D�U� $6 0(Ellipse.RenderTransform).(TranslateTransform.X)�$" ellipse��.\��� $# 0��$ 15�� $# 0:0:0.3��$% 0, 0.5, 0.5, 1��$ 0