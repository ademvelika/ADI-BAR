   M S B A M L   `   `   `  ���� 	  MYBAR"    MYBAR.CustomControls.TaskBar   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     \ XHardcodet.Wpf.TaskbarNotification, Version=1.0.5.0, Culture=neutral, PublicKeyToken=null)tb http://www.hardcodet.net/taskbar  -     >�Name$  me��$	��150��$
��auto�� � 	Resources  
  FadeIn g� 	BeginTime �� 
TargetName �� TargetProperty O� KeyTime O� Value  HighlightCloseButton  FadeCloseButton  FadeBack  FadeOut��%�  &	        &	 �     &	 (    &	 �    &	 6    �� .��U� $ 00:00:00X�$
 grid��$ (UIElement.Opacity)�.\��� $ 00:00:00��$ 0Q��� $ 00:00:01��$
 0.95Q��� $ 00:00:03��$
 0.95Q��� .��U� $ 00:00:00X�$ imgClose��$ (UIElement.Opacity)�.\��� $ 00:00:00��$	 0.4Q��� $ 00:00:00.3000000��$ 1Q��� .��U� $ 00:00:00X�$ imgClose��$ (UIElement.Opacity)�.\��� $ 00:00:00��$ 1Q��� $ 00:00:00.3000000��$	 0.4Q��� .��U� $ 00:00:00X�$
 grid��$ (UIElement.Opacity)�.\��� $ 00:00:00��$ 1Q��� $ 00:00:00.3000000��$ 1Q��� -   .��U� $ 00:00:00X�$
 grid��$ (UIElement.Opacity)�.\��� $ 00:00:00��$ 1Q��� $ 00:00:00.3000000��$	 0.2Q� � Triggers :�  :� RoutedEvent$# tb:TaskbarIcon.BalloonShowing��.[��� -   	 ��Name$	 FadeIn_BeginStoryboard��#��[  :� $ Mouse.MouseEnter��
 :� 
SourceName$
 imgClose��.[��� -   $*	 $HighlightCloseButton_BeginStoryboard��#��[ :� $ Mouse.MouseLeave��$
 imgClose��.[��� -   $%	 FadeCloseButton_BeginStoryboard��#��[ :� $ Mouse.MouseEnter��.[���  �� BeginStoryboardName$ FadeIn_BeginStoryboard���� -   $	 FadeBack_BeginStoryboard1��#��[ :� $# tb:TaskbarIcon.BalloonClosing��.[��� -   $	 FadeOut_BeginStoryboard��#��[ .��� -    �Name$
 grid��.+��� 
�������$��Stretch=�$��5,5,5,5q�$��1,1,1,1q����#FFD700 J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     Color$ 	#FF747474���� -	   $��Imazhi��$
��Left=�$��	10,10,0,0q�$��50��$��/Images/Sync.png��$
��Fill=�$��50��$	��Top=��� $��72,49.2,10,0q�$	��Top=�$
��Wrap=��� -
    �Name$ Mesazhi��$��22(�$�Your System in online ! �� �� $��Italic$�$
��Bold"�$� ���� -   $��StopOfflineNotif��$y�	Collapsed=�
���  ��.��Mos me lajmero me ! ��  �� -   $
��Link��$��5q�$y�	Collapsed=�
����� �$��Shko tek porosite�� � Cursor$
 Hand������  �� 
TargetType" ��.R��� $��	Underline{��� ����  �� 
TargetType" ��.���  �� Property � �� �� Value
 ��  � �� Triggers P�  P� Property �@J�IsMouseOver P� Value . . ���  � ��
 �  ��F� ���	#FFFFFFFF �� Stretch$
 Fill=�$��72,38.2,34,0q�$	��Top=�$��1�����Ѐ����`����`	 J� SnapsToDevicePixels . ����  �� EndPoint$ 	0.973,0.5&� �� 
StartPoint$ 	0.005,0.5&�.���  � Color$ 	#00ECAD25�� � Offset$ 1Q�� $ 	#87ECAD25��$ 0Q��� $��
72,10,10,0q�$	��Top=�$
��23.2��$
��Wrap=����	#FFECAD25$
��Bold"�����  �� Path$ BalloonText� �� ElementName$ me��  �� Mode$  Default=��� -   ! ��Name$! imgClose��$��Right=�$��	0,10,10,0q�$	��Top=�$��16��$��16��$��/Images/delete.png��$
��Fill=�" J� Opacity$	" 0.4Q�# � ToolTip$# Close Balloon��