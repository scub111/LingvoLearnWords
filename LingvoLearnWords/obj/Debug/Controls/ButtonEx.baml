   M S B A M L   `   `   `  ����O  KLingvoLearnWords, Version=1.0.0.40431, Culture=neutral, PublicKeyToken=null3clr-namespace:LingvoLearnWordsLingvoLearnWords  5          LingvoLearnWords.ButtonEx   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v17.1, Version=17.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      0localclr-namespace:LingvoLearnWords     5      $   LingvoLearnWords.UserControlEx    MouseLeftButtonDown$!  HMIBase_MouseLeftButtonDown��5	         MouseLeftButtonUp$ HMIBase_MouseLeftButtonUp��6L      
MouseLeave$ HMIBase_MouseLeave��6z   $	��150��6   $��40��6   .��5
      � '  !System.Windows.VisualStateManager   VisualStateGroups 5   
   %  System.Windows.VisualStateGroup  5      -   5        MouseStateGroup��   Transitions 5      %  System.Windows.VisualTransition  5         GeneratedDuration$ 0D�6'      States. 5         System.Windows.VisualState  -   5        ControlMouseEnter��   
Storyboard. 5      �� .��5      W�  g� Duration$ 0D�6*   		 W� To$	 4X�67   
 �� TargetProperty$
 (Shape.StrokeThickness)�6>    �� 
TargetName$ recMouse��6r   �� 5      $ 0D�6)   	 �� To$
 BlueX�66   $,
 &(Shape.Stroke).(SolidColorBrush.Color)�6@   $ recMouse��6�   5      5        5      -   5        ControlMouseLeave��5      5        5      -   5        ValueStateGroup��5        5       -   5        ActualStateGroup��. 5!        -   5        ControlActualTrue��. 5"      �� .��5#      T� $
 (UIElement.Visibility)�68   $ 	vwWarning��6k   ..�5$      i�  R� KeyTime$ 0��65    R� Value 5%   "     System.Windows.Visibility 5&   &   	Collapsed=�6<   5(      5)      5*      5+        5,      -   5        ControlActualFalse��. 5-      �� .��5.      T� $
 (UIElement.Visibility)�68   $ 	vwWarning��6k   ..�5/      i� $ 0��65    50   "    51   &   Visible=�6:   53      54      55      56      57      .+�59   
   �� -   5         ��Name$ recMouse��59       �� RadiusY$ 10��6&    �� RadiusX$ 10��63   
���   ���5:      �� 5;       �� 
StartPoint$ 0.5,0&�6&    �� EndPoint$ 0.5,1&�69    � MappingMode$ RelativeToBoundingBox=�6J   .��5<      �  � Color$ 	#FFFFFFFE��6#    � Offset$ 0Q�65   � 5=      $ 	#FFA2A2A2��6#   $ 1Q�65   5>      5@      �� 5A   
   -	   5         ��Name$ 
txtCaption��5A      $
��Wrap=�6(   
 �� Top$ 6.002��6<   $��18(�6O   $��Center=�6]   $��Center=�6z   $	��???��6�   (� 5B   
   -
   5         (�Name$ 	vwWarning��5B       �� Left$ 60��6%   $ 5��66   $y�	Collapsed=�6E   .��5C      � $��31��6   $��31��6   .+�5D      F� '����Ԅ� ���єf�����(v�U�?���	 �� Stretch$
 Fill=�6V   
���   � � UseLayoutRounding .  ��5E      �� 5F      $ 0.5,1&�6.   $ 0.5,0&�6?   .��5G      � $ 	#FFC2E000��6+   $ 0Q�6=   � 5H      $ 	#FFF0410E��6+   $ 1Q�6=   5I      5K      �� 5L      $
��Wrap=�6   $��!��60   $��26.667(�69    �� TextAlignment$ Center=�6K   5M      5N      �� 5O   
   -   5        $ recFill��5O      $ 10��6%   $ 10��62   
���   �$��0��6N   5P      5Q      