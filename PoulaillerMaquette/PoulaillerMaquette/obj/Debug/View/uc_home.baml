   M S B A M L   `   `   `  ����M  IPoulaillerMaquette, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:PoulaillerMaquette.ViewPoulaillerMaquette.View  5      %    PoulaillerMaquette.View.uc_home   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:PoulaillerMaquette.View     5      .��5	      �   � ColumnDefinitions  5
   
   �� 5      $��* �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� -   5        $��	Lbl_porte��5   -   $��0��6   $��0��6   $��OUVERT��6>   $��80��6O   $	��250��6[   $��75,28,75,117q�6g   ���	#FFE1E1E7$��Center=�6�   $��center=�6�   �� 5   
   -   5        $��BTN_changeporte��5   .   $��0��6   $��0��6   $��OUVRIR/FERMER��6E   $��20��6]   $	��180��6i   $��110,132,110,73q�6u   6�   �� 5   
   -   5        $��BTN_confirm��5   .   $��1��6   $��1��6   $	��OUI��6A   $��20��6O   $��50��6[   $��0,132,110,73q�6f    K� ZIndex$ 1��6|   $y�Hidden=�6�   6�   �� 5   
   -   5        $��BTN_back��5   .   $��1��6   $��1��6   $	��NON��6>   $��20��6L   $��50��6X   $��200,132,110,73q�6c   $ 1��6{   $y�Hidden=�6�   6�   �� 5   
   -   5        $��TB_sub��5   /   $��1��6   $��1��6    �� 
IsReadOnly . $	��300��6O   $	��150��6[   6j   �� 5   
   -   5        $��TB_Debug��5   /   $��1��6   $��0��6    . $	��300��6Q   $	��150��6]   6l   �� 5   
   -   5        $��
TB_NbPoule��5   -   $��0��6   $��1��6   $	��x/x��6?   
���   �$��42(�6`   
������� J� RenderTransformOrigin$ 0.256,0.534&�6�   $	��150��6�   $��126,72,124,73q�6�   $��Center=�6�   $��center=�6�   � 5   
   $��1��6   $��0��6    5      �� 5      $��* �6    �� 5      $��* �6    �� 5       $��* �6    �� 5!      $��* �6    5#      5$      5%      