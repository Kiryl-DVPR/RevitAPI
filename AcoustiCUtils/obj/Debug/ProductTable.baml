   M S B A M L   `   `   `  ����H  DAcoustiCUtils, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:AcoustiCUtilsAcoustiCUtils  5           AcoustiCUtils.ProductTable   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:AcoustiCUtils     5      $	��460��5   	   $	��460��6   $	��680��6,   $	��680��6;   
�������  � WindowStartupLocation$  CenterScreen=�6_   
������ $��Center=�5
      $��Center=�6"    � WindowStyle$
 None=�6=    � 	Resources 5         FocusVisual �� Property �� Value �� StrokeDashArray J� SnapsToDevicePixels  Button.Static.Background �� Color  Button.Static.Border  Button.MouseOver.Background  Button.MouseOver.Border  Button.Pressed.Background  Button.Pressed.Border  Button.Disabled.Background  Button.Disabled.Border 	 Button.Disabled.Foreground 
 ButtonStyleRounded �� 
TargetType	 �� 
TargetType
 ��Name �� CornerRadius ��Name �� Triggers P� Property P� Value �� 
TargetName��%b  &	        &	 �     &	 �     &	 �     &	     &	 6    &	 Y    &	 |    &	 �    &		 �    &	
 �    7   7  7  7  7  7 	 �� 5   
   .�5      ��  � �� 5      �� 5      .R�5      �� $��0q�6$   $	 1 2R�6/   #��� ��6E    . $��1��6�   5      5      5      �� 5   
   $ 	#FFDDDDDD��6;   �� 5   
   $ 	#FF707070��67   �� 5   
   $ 	#FFBEE6FD��6>   �� 5   
   $ 	#FF3C7FB1��6:   �� 5   
   $ 	#FFC4E5F6��6<   �� 5   
   $ 	#FF2C628B��68   �� 5   
   $ 	#FFF4F4F4��6=   �� 5   
   $ 	#FFADB2B5��69   �� 5   
   $ 	#FF838383��6=   �� 5   
   " ��6+   .�5      ��  �@�FocusVisualStyle8   61   �� 5        � ��8  6+   �� 5!       � ��8  6,   �� 5"       � ��# � ��6+   �� 5#       � ��$ 0q�60   �� 5$       � ��$ Center=�6;   �� 5%       � ��$ Center=�69   �� 5&       � ��$ 0q�6(   �� 5'       � �� 5(      �� 5)      "	 ��6&   .R�5*      �� $
 border��6!   $ 10��61   #��z��6C   #��z��6m   #��z��6�    . ._�5+      �� $ contentPresenter��6/   |�.  #��z��6[   #��z��6�   ��. # z 6�   #��z��6  5,       5-      P� 5.       �@��IsDefaulted . . �5/   "   �� $ border��6@   # � ��6T    � ��50      P� 51       �@J�IsMouseOver . . �52   "   �� $ border��6?    � �� �#87CEFA6S   �� 53   "   $ border��6@    � �� �#87CEFA6T   54      P� 55       � �� . . �56   "   �� $ border��6?    � �� �#87CEFA6S   �� 57   "   $ border��6@    � �� �#87CEFA6T   58      P� 59       � {� .  . �5:   "   �� $ border��6?   8   � ��6S   �� 5;   "   $ border��6@   8   � ��6T   �� 5<   "   $ contentPresenter��6K   8   � ��6i   5=      5?      5A      5B      5F      .��5I      � 
������ $	��450��6%   $	��670��63   .+�5M   
   �� $9��3C:\Program Files\AcousticConstructor\images\fon.png��6   $	��477��6M   $	��690��6[   $��Center=�6g   $��Center=�6�   �� 5O   
   -   5        #��� 
 5O      
�������$��Х��6R   $��Normal$�6`   $��13(�6s   ���#FD7C6E$��620,12,30,419q�5P   &   �� 5Q   
   -   5        #��� 
 5Q      
�������$��-��6R   $��Normal$�6`   $��13(�6s   
����d�$��595,12,55,419q�5R   -   �� 5T   
   $��20(�6   $��252,18,198,406q�6"   $��Arial)�6:   $��Normal$�6M   ���	#FF4788E0Спецификация AG6�   �� 5V   
   $��10,45,10,10q�6   $y�Visible=�6*   .+�5X      �� $/��)Ведомость конструкций��6   ���	#FF4788E0$��15(�6L   $��Light"�6Z   $��	20,15,0,0q�6m   $��Arial)�6�   6�   &   System.Windows.Controls.DataGrid  5Z      -   5          Name$ ConstrListTable��5Z      
������ $��Arial)�6J   $��0��6]      AutoGenerateColumns .  $��Center=�6�   $ �� IsSynchronizedWithCurrentItem$ FalseY�6�   $��Center=�5[      $	��130��6?   $	��130��6L   $	��130��6\   $��5,0,5,5q�6n      HorizontalGridLinesBrush �#f0f0f1   VerticalGridLinesBrush �#f0f0f1��5\      �� 5]         Columns 5`      0  *System.Windows.Controls.DataGridTextColumn  5a      ,  &System.Windows.Controls.DataGridColumn   
IsReadOnly .     Header$	 №��6<      Width5  /System.Windows.Controls.DataGridLengthConverter$ 30 6G   6U     5b       .  $ Наименование��6V   $	 270 6l   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6)   �� *Name+6{     5c       .  $ Шифр��6V   $ 70 6d    6)   �� *Code+6r     5d       .  $ Ед.изм.��6W   $ 50 6h    6)   �� *Units+6u     5e       .  $ Кол-во��6Z   $ 50 6j    6)   �� *
Quantity+6w     5f       .  $ 
Масса��6X   $ 60 6g    6)   �� *Weight+6t     5g       .  $ Примечание��6]   $ * 6q    6)   �� *Discription+6}   5i      �� 5k      $-��'Ведомость материалов��6   ���	#FF4788E0$��15(�6K   $��
ExtraLight"�6Y   $��Arial)�6q   $��20,0,0,0q�6�   6�     5m      -   5        $ ProductsListTable��5m      
������ $��Arial)�6L   $��2q�6_    .  $��Center=�6�   $��Center=�5n      $	��170��6?   $	��170��6L   $	��170��6\   $��5,0,5,5q�6n      RowBackground
 ����� �#f0f0f1 �#f0f0f1��5o      �� 5p       5s        5t       .  $	 №��6<   $ 30 6G   6U     5u       .  $ Наименование��6V   $	 250 6l    6)   �� *Name+6{     5v       .  $ Ед.изм.��6W   $ 50 6h    6)   �� *Units+6u     5w       .  $ Кол-во��6[   $ 70 6k    6*   �� *
Quantity+6x     5x       .  $ Артикул��6V   $	 100 6g    6)   �� *Code+6u     5y       .  $ Примечание��6=   $ * 6Q   6]   5{      �� 5}      -   5        #��� 
 5}      $��Excel��6C   $��Normal$�6V   $��13(�6i   $��Right=�5~      $��22��66   $��62��6B   $��	10,5,20,0q�6N   ���	#FF19A071
�������5�      5�      �� 5�   
   $<��6C:\Program Files\AcousticConstructor\images\logoAG.png��6   $��10,-1,513,397q�6P   5�      5�      