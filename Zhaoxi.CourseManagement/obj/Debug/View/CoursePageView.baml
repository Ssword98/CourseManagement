   M S B A M L   `   `   `  ����R  NZhaoxi.CourseManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:Zhaoxi.CourseManagement.ViewZhaoxi.CourseManagement.View  5      I ESword.Controls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG4clr-namespace:Sword.Controls;assembly=Sword.ControlsSword.Controls 5      O,clr-namespace:Zhaoxi.CourseManagement.CommonZhaoxi.CourseManagement.Common  5      1    +Zhaoxi.CourseManagement.View.CoursePageView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      <local*clr-namespace:Zhaoxi.CourseManagement.View     5      Csc4clr-namespace:Sword.Controls;assembly=Sword.Controls     5      =comm,clr-namespace:Zhaoxi.CourseManagement.Common     5        � 	Resources  5       �� 
TargetType   CategoryItemButtonTemplate �� CornerRadius �� Triggers P� Property P� Value �� 
TargetName �� Property �� Value  courseTemplate	 � ColumnDefinitions
 J� Effect3  -System.Windows.Media.Effects.DropShadowEffect   Color   ShadowDepth   
BlurRadius   Opacity   	Direction j� Stretch �� ImageSource �� Orientation �� Command �� RelativeSource �� AncestorType �� Mode �� CommandParameter �� Triggers }� Location $� Orientation �� 
LineHeight  skeletonTemplate#  Sword.Controls.SkeletonScreen��%�  &	        &	 �    &	 R    �� 5   
   " 	�6   .R�5      � 
������ $	��5,0q�6,   .+�5      �� $
��back��6<   ���#EEE$ 5��6+   ._�5      �� #��z��6    $
��15,6q�6A   $��Center=�6O   $��Center=�6j   5      5       5      P� 5       �@d�	IsChecked$
 TrueY�6/   . �5      �� $
 back��6B    � ��
 � ����� 5       � ��
 �����63   5      5      �� 5   
   .R�5      � .+�5      � $��courseContent��6   	 5      �� 5      $	��150 �6+   �� 5      �� 5      $	��100 �6+   .+�5!      �� $��90��6   $��60��6(   $ 5��64   $
��0,15q�6E   
 5"        5#      $
 Gray��6/   $ 0Q�6<   $ 10Q�6L   $	 0.3Q�6\   $ 0Q�6j   ��5%      �� 5&      $ UniformToFill=�6M    6)   �� *CourseCover+6M   5(      �� 5)      $��1��6!   $��Center=�61   .+�5*      �� $ 
Horizontal=�6%   $��0,0,0,10q�6>   .+�5+      �� $��16(�6(   �� 5,      ���#333 62   �� *" DataContext.OpenCourseUrlCommand+ �� $ UserControlL�$ FindAncestor=� 5-       �� *	CourseUrl+.�6G   ��5.      �� 5/      .�50   "   ��  � �� 6N   Z�  51   "   P� 52   &    �@��IsMouseOver . . �53   *   ��  � �� 54   .   |� 55   2   }� 56   6   $ 	Underline=�6E   57   3   59   +   5:   '   5<      .�5=   +   .�5>      �� ��6$   �� *
CourseName+5?      5@      �� 5A      $
��15,0q�6+   ��69   �� *
Teachers+��5B   "   �� 5C   &   .R�5D   *   $� $ 
Horizontal=�6A   5E   '   ��5G   "   �� 5H   &   .R�5I   *   �� ���#EEE$	��5,0q�6C   $ 5��6P   ._�5J   .   �� $
��12,3q�6I   ��68   �� 6I   5K   +   5L   '   5N      5O      �� 5P      $
��Wrap=�5Q      $ 23��6(   ���#AAA��5P   $   �� *CourseDescription+5Q   8   5R      �� 5S      $ 
Horizontal=�6!   $��2��6:   $��Center=�6J   $��Center=�6e   .+�5T      �� $	��5,0q�6$   �� 5U      .�6   详情6    5V      �� 5W      $	��5,0q�6$   �� 5X      .�6   删除6    5Y      5Z      5[      5^      5_      �� 5`   
   .R�5a        $��skeleton��6    5b      5c      .��5d      �� 
�������$ 5��6    ._�5e   
   �  � RowDefinitions 5f      �� 5g      $
��auto �6    �� 5h      .+�5j      �� ���#DDD$��0,0,0,1q�6(   $
��20,0q�6B   ._�5k      � $��10,18q�6    5l      �� 5m      $��35��6(   $
��auto �67   �� 5n      $��35��6(   $
��auto �67   �� 5o      $��35��6(   $
��auto �67   .+�5q      �� $ 
Horizontal=�6!   $��Center=�6:   .+�5r      �� $��课程分类��6$   $��Center=�60   $��0,0,10,0q�6K   ���#6666]   �� 5s      ��6'   �� *CategoryCourses+��5t      �� 5u   "   .R�5v   &   �� $ 
Horizontal=�61   5w   #   ��5y      �� 5z   "   .R�5{   &   	� #��[  62    	� 	GroupName$ course��6i   ��5|   2   �� *CategoryName+ d� 	IsChecked 6S   �� *
IsSelected+5}   #   5      5�      �� 5�      $ 
Horizontal=�6!   $��Center=�6:   $��1��6U   .+�5�      �� $��技术分类��6$   $��Center=�60   $��0,0,10,0q�6K   ���#6666]   �� 5�      ��6'   �� *CategoryTechnology+��5�      �� 5�   "   .R�5�   &   �� $ 
Horizontal=�61   5�   #   ��5�      �� 5�   "   .R�5�   &   	� #��[  62   $ 
technology��6i   ��5�   2   �� *CategoryName+ 6S   �� *
IsSelected+5�   #   5�      5�      �� 5�      $ 
Horizontal=�6!   $��Center=�6:   $��2��6U   .+�5�      �� $��授课老师��6$   $��Center=�60   $��0,0,10,0q�6K   ���#6666]   �� 5�      ��6'   �� *CategoryTeacher+��5�      �� 5�   "   .R�5�   &   �� $ 
Horizontal=�61   5�   #   ��5�      �� 5�   "   .R�5�   &   	� -   5        #��[  5�   2   $ teacher��6i   ��5�   2   �� *CategoryName+ 6S   �� *
IsSelected+5�   2   5�   #   5�      5�      5�      5�      �� 5�      $	��100��6   $��30��6!   $��+ 添加课程��6-   $��0q�6>   ���#DDD$��Right=�5�      $��Bottom=�61   $��	0,0,30,20q�6L   �� 5�      $��1��6   $��Hidden=�6(   .��5�      �� -   5        $��	icCourses��5�   B   ��6   �� *
CourseList+��5�      �� 5�      .R�5�      $� 5�      ��5�      ?   9Zhaoxi.CourseManagement.Common.CourseDataTemplateSelector  5�         DefaultTemplate# [ 6:       SkeletonTemplate#  [ 5�   :   5�      5�      5�      5�      5�      