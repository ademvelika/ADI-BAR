   M S B A M L   `   `   `  ���� @  <MYBAR, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:MYBAR.View
MYBAR.View      MYBAR.View.MainView   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     *localclr-namespace:MYBAR.View     -   $��Stretch=�$��Stretch=�  � 	Resources     BaseButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType J� SnapsToDevicePixels �� Triggers P� Property P� Value	 �� 
TargetName  
ImageStyle  	MenuSiper
 �� BasedOn  MenuText  shiritibackgroud  ScrollBarTrackThumb �Name ��Name �� CornerRadius � RowDefinitions ]�Name ]� Thumb n�Name ]� IncreaseRepeatButton ��Name J� Opacity ]� DecreaseRepeatButton P� 
SourceName  ButtonSelectBrush  	DarkBrush �� Angle��%T
  &	        &	 
    &	 C    '�� h    7   '�� w    7  &	 �    '�� �    7  'o� �    7  'm�     &	 @    '�� �    �� " ��.���  �@�FocusVisualStyle Z� ��  � �� �#ffffff��  � �� �#cccccc��  � ��$ 10(���  � ��$ 1q���  � �� �#333333��  � ��$ Center=���  � ��$ Center=���  � ��$ 	16,3,16,3q���  � �� �� " ��.R��� $��Chrome��#��z��#��z��#��z�� . ._��� $��	Presenter��#��z��#��z��#��z����. # z  P�  � {� .  . ���  � �� �#333333P�  �@J�IsMouseOver . . ���  � �� �#dddddd��  � �� �#cccccc��  � �� �#333333P�  � �� . . ���  � �� �#1ba1e2��  � �� �#1ba1e2��  � �� �#ffffff��  � �� �#ddddddP�  �@J�	IsFocused . . ��� $	 Chrome�� � �� �#1ba1e2�� " ��.���  � ��$ 32����  � ��$ 32���� " ��.���  � ��
 ������� " ��8
   �� " ��8
   �� " ��.���  � ��$ 20(��� " ��8
   �� " o�.���  � ��$ 17(���  � ��$
 Thin"���  � ��8   �� " m�.���  � ��$ 17(���  � ��$
 Thin"��� " n�.���  � �� �� " n�.R�� $
 Grid��.+��� $��Stretch=�$��Stretch=�$
��Auto��$
��Auto��
������ �� $ CornerScrollBarRectangle��$ 5��$��Stretch=�$��Stretch=�$
��Auto��$
��Auto��$��0,1,0,1q�#��z�� P�  �@�Tag$ 
Horizontal��. ��� $	 CornerScrollBarRectangle�� � ��$
 Auto���� $	 CornerScrollBarRectangle�� � ��$ 6���� " ��.���  �@��IsFlicksEnabled .  ��  � �� �#ADABAB��  � ��
 ���� ��  � ��$ 7����  � �� �� " ��.R�� $ GridRoot��$��7��#��z�� �� $��0.00001* �.+�]� $ 
PART_Track��$��0����. |�.   n� $ Thumb��#��z��#���   �� $ PageUp��$��ScrollBar.PageDownCommand��$ 0Q�|�.   �� $ PageDown��$��ScrollBar.PageUpCommand��$ 0Q�|�.   P� $ Thumb�� �@J�IsMouseOver . . ��� # �  $	 Thumb�� � ��P� $ Thumb�� �@n�
IsDragging . . ��� # �  $	 Thumb�� � ��P�  � {� .  . ��� $	 Thumb�� � y�$ 	Collapsed=�P�  �@��Orientation$ 
Horizontal=�. ��� $	 GridRoot�� �@�LayoutTransform �� $	 -90Q��� $	 
PART_Track�� �@�LayoutTransform �� $	 -90Q���  � ��$
 Auto����  � ��$ 8���� $	 Thumb�� �@�Tag$ 
Horizontal���� $	 PageDown�� � ��$ ScrollBar.PageLeftCommand���� $	 PageUp�� � ��$  ScrollBar.PageRightCommand��.���  �� $
��auto ��� $
��auto ��� $
��auto ��� $	��10* �.+�o� $��0��.@�m� $y�	Collapsed=�$
��File��m� -   $��KonfigurimeMenu��$��Konfigurime��.@�m� -   $��FaturaKonfig��$��Fatura��m� -   $��
KasaConfig��$
��Kasa��m� -   $��TeTjera��$��Te tjera��m� -   $��ArtikujMenu��$��Artikuj��.@�m� -   $��ListaArtikuve��$��Lista e Artikujve��m� -   $��Furnizim��$��Furnizim��m� -	   $��ArtikullHitory��$��Kartela e Artikullit��m� -
   $��
ExelImport��$��Importo-Excel��m� -   $��KorrigjimInventari��$��Korrigjim Inventari��m� -   $��RaporteMenu��$��Raporte��.@�m� -   $��InventarRaport��$��Inventar��$��Stretch=�.@��� $��Stretch=�.+�� .+��� .��Data(  "System.Windows.Controls.DatePicker  -   $��DataInventarit��  styleCalendar   CalendarStyle# [ �� -   $��HapInventar��.��Hapm� -   $��Xhiroditore��$y�Visible=�$��
Statistika��m� -   $��Turnet��$��Turnet��m� -   $��
FaturaMenu��$��Fatura��.@�m� -   $��Lista_e_Faturave��$��Lista e Faturave���� $
��Auto=�$��Hidden=�$��1��.���� $��	15,5,15,5q�.+�� 
�������.+��� $��2,2,10,2q�.+��� -   $
��Exit��$��0q�.���� .+��� $��/Images/Exit.png����  �� TextAlignment$ Center=��� $	�Dil���� $��2,2,10,2q�.+��� -   $��Tavolina��$��0q�.���� .+��� $��/Images/Tablen.png���� $ Center=�
Tavolina�� $��2,2,10,2q�.+��� -   $��Faturat��$��0q�.���� .+��� $��/Images/Bill2.png���� $ Center=�	Faturat�� $��2,2,10,2q�.+��� -   $��Raporte��$��0q�.���� .+��� $��/Images/Finance.png���� $ Center=�Shitjet e Artikujve�� $��2,2,10,2q�.+��� -   $��MbyllTurnin��$��0q�.���� .+��� $��/Images/FINISH.png���� $ Center=�Mbyll Turnin�� $��2,2,10,2q�.+��� -   $��PorositeOnline��$��0q�.���� .+��� ._�� 
������  � ColumnDefinitions �� �� $
��auto �.+��� $��/Images/Porosi.png���� $��25��$��25��$ 12��
�������$	��Top=�$��1��._��� -   $��PorosiNumber��$��Center=�$��Center=�$��
UltraBlack"�$��22(�$��Arial)�
���  ��$��0��� .+��� $ Center=�
Porosite�� $��2,2,10,2q�.+��� -   $��Notifications��$��0q�.���� .+��� $��/Images/Notification.png���� $ Center=�	Njoftimet�� $��2,2,10,2q�.+��� -   $��Users��$y�Visible=�$��0q�.���� .+��� $��/Images/User.png���� $ Center=�Perdoruesit�� $��2,2,10,2q�.+��� -   $��ChangePassword��$��0q�.���� .+��� $��/Images/key.png���� $ Center=�
# Password�� $��2,2,10,2q�.+��� -   $��Tutorial��$��0q�.���� .+��� $��/Images/About.png���� $ Center=�Info�� -   $��MyTest��$y�	Collapsed=�.��	Rrregullo� $��Center=�$��Center=�.+�A� -    $��KasaNote��$
��10,0q�$��15��
��� � �$��15���� -!   $��KasaShow��$
��10,0q�$��15��$��15��
��� � ��� -"   $
��Line��$��2�����#e4e4e4$��7���� -#   $��
WindowUser��$��3��.��� .+��� .��Wecome to G-H Dialog