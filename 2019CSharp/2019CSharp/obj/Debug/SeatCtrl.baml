   M S B A M L   `   `   `  ����E  A2019CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:_2019CSharp_2019CSharp  5          _2019CSharp.SeatCtrl   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      +localclr-namespace:_2019CSharp     5        � 	Resources  5	         main �� 
TargetType �� Property �� Value 	 clock  logo  payBord  payGrid 
 payTxt 
 payBtn��%�  &	        &	 l     &	 -    &	 �    &	 
    &	 �    &	 �    �� 5
   
   " ��6   .�5      ��  � ��$ 70��6'   �� 5       � ��$ 70��6&   5      �� 5   
   " ��6   .�5      ��  � ��$ 32(�6)   �� 5       � ��$ 0, 30, 0, 0q�6'   �� 5       � ��$ 80��6'   �� 5       � ��$ Center=�64   5      �� 5   
   " ��6   .�5      ��  � ��$ Right=�64   �� 5       � ��$ 5q�6'   �� 5       � ��$	 120��6'   5      �� 5   
   " ��6    .�5      ��  � ��
 ��ح�6+   5      �� 5   
   " �6    .�5      ��  � ��$
 1000��6&   �� 5       � ��$	 500��6'   �� 5       � ��$ 2��6-   �� 5        � ��$ 2��60   5!      �� 5"   
   " ��6   .�5#      ��  � ��$ Center=�62   �� 5$       � ��$ Center=�64   �� 5%       � ��$ 36(�6)   �� 5&       � ��$
 Bold"�6+   �� 5'       � ��$ 0, 0, 0, 20q�6'   5(      �� 5)   
   " ��6   .�5*      ��  � ��$ 50��6'   �� 5+       � ��$	 100��6&   �� 5,       � ��$ Center=�64   �� 5-       � ��$ Bottom=�62   �� 5.       � ��$ 400, 0, 0, 20q�6'   5/      50      .��52      � .+�53   
      _2019CSharp.OrderCtrl  -   5          Name$ 	orderCtrl��53      $y�	Collapsed=�6-   6F   � 55   
   -   5         �Name$ seatCtrl��55      $y�Visible=�6!    � RowDefinitions 56      �� 57      $	��150 �6    �� 58      $��* �6     � ColumnDefinitions 5:      �� 5;      $
��0.5* �6#   �� 5<      $
��0.5* �6#   .+�5>      � $��0��6   $��0��6    .+�5?      �� -   5         ��Name$ clock��5?      #��[ 6+   6L   5@      � 5A      $��0��6   $��1��6    .+�5B      �� $��Assets/bi.png��6   #��[ 6/   $��Center=�6M   5C      � 5D      $��1��6   $��0��6    .+�5E      �� -   5        	 ��Name$	 salesBtn��5E      $��통계 화면��6+   $	��200��6;   $��80��6G   $��36(�6S   $
��Bold"�6a   $y�Visible=�6s   6�   5F      � 5G      $��1��6   $��1��6    .+�5H      �� -   5        
 ��Name$
 lvSeat��5H      $��Disabled=�5I      $��Stretch=�5K      $��Stretch=�5L      ��5M      �� 5N      .R�5O      �  � Orientation$ 
Horizontal=�6(   5P      ��5R      �� 5S      .R�5T      �  5U   "   �� 5V   &   $��50 �67   �� 5W   &   $��* �67   .+�5Y   "   �� $��1��6+    �� View 5Z   &   �� 5[   *   .P�5\   .   �� $��메뉴��6=    �� Width$	 250��6o    �� DisplayMemberBinding 6I   �� *Name+6o   �� 5]   .   $��수량��6=   $ 40��6p    6I   �� *Count+6p   5^   +   5`   #   �� 5a   "   $��0��6-   $
��1000��6=   $	��100��6J   .+�5b   &   �� ��60   �� *id+6F   5c   #   5d      5e      5g      5h      5i         _2019CSharp.StatisticCtrl  5j   
   -   5          Name$ 
statisCtrl��5j      $y�	Collapsed=�62   6K   5k      5l      