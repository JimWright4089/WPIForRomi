   M S B A M L   `   `   `  ����L  HFRC4089AutoSetter, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:FRC4089AutoSetterFRC4089AutoSetter  5   	   "    FRC4089AutoSetter.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:FRC4089AutoSetter     5   	     � Title$  FRC 4089 Auto Set��5   	   $��243.334��6#   $��453.333��64   $��20(�6D   .��5	      � .+�5
      	� -   5         	�Name$ rbPositionOne��5
      $��Position One��6)   $
��Left=�6@   $��8,10,0,0q�6[   $	��Top=�6m   	� 5      -   5        $ rbPositionTwo��5      $��Position Two��6)   $
��Left=�6@   $��8,31,0,0q�6[   $	��Top=�6m   {�.  6�   	� 5      -   5        $ rbPositionThree��5      $��Position Three��6+   $
��Left=�6D   $��8,53,0,0q�6_   $	��Top=�6q    d� 	IsChecked$
 TrueY�6�   	� 5      -   5        $ rbPositionFour��5      $��Position Four��6*   $
��Left=�6B   $��8,76,0,0q�6]   $	��Top=�6o   	� 5      -   5        $ rbPositionFive��5      $��Position Five��6*   $
��Left=�6B   $��8,98,0,0q�6]   $	��Top=�6o   	� 5      -   5        $ rbScate��5      $��Scale before Switch��6#   $
��Left=�6A   $	��Top=�6\   $��
194,71,0,0q�6t    	� 	GroupName$ ScaleSwitch��6�   {�.  6�   	� 5      -   5        $ rbSwitch��5      $��Switch before Scale��6$   $
��Left=�6B   $	��Top=�6]   $��
194,96,0,0q�6u    J� RenderTransformOrigin$ 	1.996,0.6&�6�   $ ScaleSwitch��6�   {�.  6�   �� 5      -   5         ��Name$ cbCrossField��5      $��Cross The Field��6%   $
��Left=�6?   $	��Top=�6Z   $��
194,10,0,0q�6r   {�.  6�   �� 5      -	   5        $ cbGrabMulti��5      $��Grab more boxes��6$   $
��Left=�6>   $	��Top=�6Y   $��
194,41,0,0q�6q   {�.  6�   �� 5      -
   5         ��Name$ lStatus��5      $��Label��6   $
��Left=�6-   $	��Top=�6H   $��
10,127,0,0q�6`   $	��416��6t   $��75��6�   5      5      