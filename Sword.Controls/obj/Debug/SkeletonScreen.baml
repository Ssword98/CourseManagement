   M S B A M L   `   `   `  ����I  ESword.Controls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Sword.ControlsSword.Controls  5      #    Sword.Controls.SkeletonScreen   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:Sword.Controls     5        � Triggers  5	      :� 5
   
    :� RoutedEvent$ UserControl.Loaded��6   .[�5      �� .��5      �� .��5      ��  g� Duration$ 0:0:1D�6%   	 �� To$ #F7F9FAX�66    �� 
TargetName$ imgBlock��6C    �� TargetProperty$* $(Background).(SolidColorBrush.Color)�5   %    g� RepeatBehavior$ Forever��5   %    g� AutoReverse . 6>   W� 5      $ 0:0:1.5D�6&   	 W� To$ 1X�69   $ border1��6@   $( "Background.GradientStops[1].Offset�5   &   $ Forever��5   %    . 6>   W� 5      $ 0:0:2D�6&   $ 1X�67   $ border2��6>   $( "Background.GradientStops[1].Offset�5      $ Forever��5       . 6*   W� 5      $ 0:0:1.3D�6&   $ 1X�69   $ border3��6@   $( "Background.GradientStops[1].Offset�5      $ Forever��5       . 6*   5      5      5      .��5      � $	��0,8q�6   	 � ColumnDefinitions	 5   
   �� 5      $	��160 �6   �� 5       .+�5"   
   �� -   5        $��imgBlock��5"   L   ���#DDD$��80��6#   $��65��6.   
 �� CornerRadius$
 10��6:   6L   �� 5#   
   $��1��6   $��Center=�6%   .+�5$      �� }�. ._�5%      �� -   5        $��border1��5%   L   $��16��6   $	��650��6%   $
��Left=�61   $��-200,0q�6[   ��5&      �� 5'       �� EndPoint$ 1,0.5&�6.    �� 
StartPoint$ 0,0.5&�6?   .��5(      �  � Color$
 #DDD��6+    � Offset$ 0Q�68   � 5)      $ #F7F9FA��6+   $ 0Q�6;   � 5*      $
 #DDD��6+   $ 1Q�68   5+      5-      5.      �� 5/      }�. ._�50      �� -   5        $��border2��50   5   $��16��6   $��-200,6q�6%   ��51      �� 52      $ 1,0.5&�6.   $ 0,0.5&�6?   .��53      � $
 #DDD��6+   $ 0Q�68   � 54      $ #F7F9FA��6+   $ 0Q�6;   � 55      $
 #DDD��6+   $ 1Q�68   56      58      59      �� 5:      }�. ._�5;      �� -   5        $��border3��5;   L   $��16��6   $	��580��6%   $
��Left=�61   $��-200,0q�6[   ��5<      �� 5=      $ 1,0.5&�6.   $ 0,0.5&�6?   .��5>      � $
 #DDD��6+   $ 0Q�68   � 5?      $ #F7F9FA��6+   $ 0Q�6;   � 5@      $
 #DDD��6+   $ 1Q�68   5A      5C      5D      5E      5F      5G      