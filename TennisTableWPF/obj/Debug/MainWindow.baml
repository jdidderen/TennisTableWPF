   M S B A M L   `   `   `  ����U  QMahApps.Metro, Version=1.5.0.23, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	   I ETennisTableWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:TennisTableWPF.ViewsTennisTableWPF.Views 5   	   A%clr-namespace:TennisTableWPF.ServicesTennisTableWPF.Services 5   	      TennisTableWPF.MainWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   Pcontrols;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local1"clr-namespace:TennisTableWPF.Views     5   	   :services%clr-namespace:TennisTableWPF.Services     5   	   -   5          � Title$1  +Gestion de compétitions de Tennis de Table��5
   	   $	��800��6<   $
��1280��6I    � Icon$ Resources/TennisTable.png��6V   ��5      �� 5   
    �� ImageSource$ Resources/background.jpg��6   .��5      ]� .+�5   
   �  � DataContext 6   �� *TabViewModel+   Locator �� Source# [   � ColumnDefinitions 5      �� 5      $
��auto �6#   �� 5      $��* �6#    � RowDefinitions 5      �� 5      $��* �6    .+�5      9� $��0q�6   $��4q�5      
������� 9� ExpandDirection$ Right=�5      $��0��5      $��0��5       9� 
IsExpanded . ���	#CC119EDA��5      �� 5      $
��Menu��6    $��14(�5        $
��Bold"�5!       	 � LayoutTransform	 5"      �� 5#      
 �� Angle$
 90Q�6.   5%      ��5'      � 5(      $��Stretch=�6   ���	#D8808080$	��168��6P   .+�5)      �� -   5         ��Name$ ShowTableauButton��5)   !   $��Tableau de bord��6k   $
��Left=�6�   $��	10,10,0,0q�6�   $	��Top=�6�   $	��148��6�    J� RenderTransformOrigin$ 	0.716,0.5&�6�   ��6<   �� *AddToTabTableauViewCommand+6�   �� 5*      -   5        $ ShowClubsButton��5*   !   $��Afficher les clubs��6g   $
��Left=�6�   $��	10,42,0,0q�6�   $	��Top=�6�   $	��148��6�   $ 	0.716,0.5&�6�   ��6:   �� *AddToTabClubsViewCommand+6�   �� 5+      -   5        $ ShowEquipesButton��5+   !   $��Afficher les équipes��6k   $
��Left=�6�   $��	10,74,0,0q�6�   $	��Top=�6�   $	��148��6�   $ 	0.716,0.5&�6�   ��6<   �� *AddToTabEquipesViewCommand+6�   �� 5,      -   5        $ ShowMatchsButton��5,   !   $��Afficher les matchs��6i   $
��Left=�6�   $��
10,106,0,0q�6�   $	��Top=�6�   $	��148��6�   $ 	0.716,0.5&�6�   ��6;   �� *AddToTabMatchsViewCommand+6�   �� 5-      -   5        $ ShowStaticDatasButton��5-   !   $��Données statiques��6s   $
��Left=�6�   $��
10,138,0,0q�6�   $	��Top=�6�   $	��148��6�   $ 	0.716,0.5&�6�   ��6@   �� * AddToTabStaticDatasViewCommand+6�   �� 5.      -   5        $ ShowJoueursButton��5.   !   $��Afficher les joueurs��6k   $
��Left=�6�   $��
10,170,0,0q�6�   $	��Top=�6�   $	��148��6�   $ 	0.716,0.5&�6�   ��6<   �� *AddToTabJoueursViewCommand+6�   5/      51      ,   &MahApps.Metro.Controls.MetroTabControl  52      $��1,4,4,4q�6'     Selector �� ContentTemplateSelector# [ 54      $��0��56       J� Opacity$
 0.95Q�57      $��1��58      ���	#D8808080��53      �� *Tabs+ �� SelectedItem 55      �� *TabsSelected+��59      �� 5:       �� 
TargetType)   #MahApps.Metro.Controls.MetroTabItem"  6   .�5;      ��  �� Property � �� �� Value 63   �� *Header+ �� UpdateSourceTrigger$ PropertyChanged=��� 5<       �@J�Opacity$
 0.95Q�65   �� 5=       �@ CloseButtonEnabled . 6?   �� 5>       � �� �	#D880808067   �� 5?      +   %MahApps.Metro.Controls.ControlsHelper �@ HeaderFontWeight$
 Bold"�6U   �� 5@       � ��$
 Auto��62   �� 5A       � ��$
 Auto��63   �� 5B       �@ HeaderFontSize$ 16Q�6S   5C      5E      5F      5G      5H      