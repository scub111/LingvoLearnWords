   M S B A M L   `   `   `  ����O  KLingvoLearnWords, Version=1.0.0.40431, Culture=neutral, PublicKeyToken=null3clr-namespace:LingvoLearnWordsLingvoLearnWords  5   	   !    LingvoLearnWords.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v17.1, Version=17.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  5   	   *localclr-namespace:LingvoLearnWords  5   	   e aDevExpress.Xpf.Controls.v17.1, Version=17.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aDdxnav8http://schemas.devexpress.com/winfx/2008/xaml/navigation  5   	   ] YDevExpress.Mvvm.v17.1, Version=17.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aAdxmvvm2http://schemas.devexpress.com/winfx/2008/xaml/mvvm   5	   	   -   5          �Name$  
mainWindow��5
   	   $	��870��5   	   $
��1010��6    � WindowStyle$
 None=�6#    � 
ResizeMode$ CanResizeWithGrip=�5   	    � AllowsTransparency .   � WindowStartupLocation$ CenterScreen=�5   	    � DataContext 5   	   1  +DevExpress.Mvvm.UI.ViewModelSourceExtension     Type*   $LingvoLearnWords.NavigationViewModel"   � 	Resources 5       �� DataType*   $LingvoLearnWords.DictionaryViewModel%   LingvoLearnWords.DictionaryView��%G   (��       5      *, +)�� 6
   "  6   .R�5        5      5      '  !System.Windows.Shell.WindowChrome	   WindowChrome	 5        5   
   
   CaptionHeight$
 0Q�5   	      ResizeBorderThickness$ 5q�5   	   .��5      ��    	FormBrush#��[  6   .+�5   
   +  %DevExpress.Xpf.Navigation.TileNavPane  -   5          Name$ navPane��5         
NavButtons 5      )  #DevExpress.Xpf.Navigation.NavButton  5      $
��Home��6"   5  /DevExpress.Xpf.Controls.Primitives.veButtonBase   Glyph 61   *	  $DevExpress.Xpf.Core.DXImageExtension	   	  Image1
  +DevExpress.Xpf.Core.Native.DXImageConverter$ Home_32x32.png
    Command 6[   �� *DictionaryViewCommand+  5      $
��Test��6"    61   	  $ ForceTesting_32x32.png
   5          IsMain .  $��Right=�6\      DisplayMode$ Glyph=�6�    6"   	  $ Close_32x32.png
  6x   �� *ExitCommand+6�   5"      �� 5#   
   -   5         ��Name$ Pages��5#   4   $
��Left=�6   ��6C   �� *SelectedViewModel+5$      5%      