   M S B A M L   `   `   `  ����I  ETimeZoneFinder, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:TimeZoneFinderTimeZoneFinder  5   	       TimeZoneFinder.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:TimeZoneFinder     5   	   \ XHardcodet.Wpf.TaskbarNotification, Version=1.0.5.0, Culture=neutral, PublicKeyToken=null)tb http://www.hardcodet.net/taskbar  5      -   5          � Title$  	Time Zone��5	   	   $	��180��6   $	��820��6(    � 
ResizeMode$ NoResize=�64    � Icon$ icons/watch.ico��6�    � 	Resources 5         cmbTemplate��%J  &	        �� 5   
   .R�5      � $��0 2 0 2q�6   $��35��6)   .+�5      �� $��50��6   $��30��6#   $
��Fill=�6/   $��Center=�6W   $��Center=�6r   $��0,0,15,0q�6�   ��6>   �� *Photo+6�   �� 5      $��Center=�61   $��Center=�6L   $��18(�6i   ��6   �� *Name+6i   5      5      5      .��5      � -   5         �Name$ formGrid��5      ��5   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ 	AliceBlue��6   � 5      $ AntiqueWhite��6    � Offset$ 1Q�64   5      	 � RowDefinitions	 5   
   �� 5      $��50 �6   �� 5      $��20 �6   �� 5      $��35 �6   �� 5      $��35 �6   
 � ColumnDefinitions
 5    
   �� 5!      $	��405 �6   �� 5"      $	��415 �6   .+�5$   
   �� $��0��6   $��0��6"    �� Orientation$ 
Horizontal=�62   .+�5%      �� -   5         ��Name$ lstFirst��5%      $��Center=�6)   $	��Top=�6F   #��[  6^   $��40��6�   $	��200��6�   $��4q�6�   ���	#ffe4a7a7 J� 	AllowDrop .  J� Opacity$	 0.7Q�6�   $
��aril)�6�   |�.   � Cursor$
 Hand��6  }�. ��5&      �� 5'      $	 0,1&�6*   $	 0,0&�69   .��5(      � $ 	#ffdcd53c��6'   $ 0Q�69   � 5)      $ 	#ff4fb0e8��6'   $ 1Q�69   5*      5,      �� 5-      -   5        $��lblIndiaTime��5-   #   $
��time��6   $��Arial Rounded MT BOld)�67   $��30(�6Z   $��ExtraExpanded&�6h   ��5.      �� 5/      $ 0.5,1&�6*   $ 0.5,0&�6;   .��50      � $ 	#ffe04545��6'   $ 0Q�69   � 51      $ 	#ff151313��6'   $ 1Q�69   52      54      55      �� 56   
   $��0��6   $��1��6"   $ 
Horizontal=�62   .+�57      �� -   5        $ 	lstSecond��57      $��Center=�6*   $	��Top=�6G   #��[  6_   $��40��6�   $	��200��6�   $��4q�6�   ���	#ffe4a7a7 . $	 0.7Q�6�   $
��aril)�6�   |�.  $
 Hand��6	  }�. ��58      �� 59      $	 0,1&�6*   $	 0,0&�69   .��5:      � $ 	#ffdcd53c��6'   $ 0Q�69   � 5;      $ 	#ff4fb0e8��6'   $ 1Q�69   5<      5>      �� 5?      -   5        $��	lblUSTime��5?   #   $
��time��6   $��Arial Rounded MT BOld)�64   $��30(�6W   $��ExtraExpanded&�6e   ��5@      �� 5A      $ 0.5,1&�6*   $ 0.5,0&�6;   .��5B      � $ 	#ffe04545��6'   � 5C      $ 	#ff151313��6'   $ 1Q�69   5D      5F      5G      �� 5H   
   -   5        $��stkRowIndia��5H   _   $��2��6   $��0��6"   $ 
Horizontal=�62   $��2��6K   .+�5I      �� -   5        $��lblFirstTimeChart��5I   '   $��India : ��6   $��Berlin Sans Fb Demi)�6@   $��17(�6a   $��80��6o   ���	#ffc95124 � ForceCursor . 6�   5J      �� 5K   
   -	   5        $��stkRowUS��5K   _   $��3��6   $��0��6"   $ 
Horizontal=�62   $��2��6K   .+�5L      �� -
   5        $��lblSecondTimeChart��5L   $   $��US : ��6   $��Berlin Sans Fb Demi)�6>   $��17(�6_   $��80��6m   ���	#ffc95124 . 6�   5M      3  -Hardcodet.Wpf.TaskbarNotification.TaskbarIcon  5N   
   -   5          Name$ MyNotifyIcon��5N         
IconSource$ Icons/Watch.ico��6/    � ToolTip$ Click to get Time��6�    � ContextMenu 5O      �� 5P      .@�5Q      m� -   5        $
��Open��5Q      $
��Bold"�6D   �� 5R      m� 5S      -   5        $
��Exit��5S      6-   5T      5V      5W      5X      