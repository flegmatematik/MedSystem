   M S B A M L   `   `   `  ����F  BUIMedSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:UIMedSystem.ObjednavkaUIMedSystem.Objednavka  5      +    %UIMedSystem.Objednavka.ShowObjednavky   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6local$clr-namespace:UIMedSystem.Objednavka     5      
���iii�$	��400��5	   "   .��5
      �   � ColumnDefinitions  5   
   �� 5      $��20 �6   �� 5      �� 5      $��20 �6    � RowDefinitions 5   
   �� 5      $��0 �6   �� 5      �� 5      $��0 �6   .+�5   
   � $��1��6   $��1��6   $��Center=�6,     5      �� 5      $
��Auto �6#   �� 5      �� 5       5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5       $
��Auto �6    �� 5!      $
��Auto �6    �� 5"      $
��Auto �6    �� 5#      $
��Auto �6    �� 5$      $
��Auto �6    �� 5%      $
��Auto �6    �� 5&      .+�5)      �� -   5         ��Name$ 
GreetBlock��5)      $��0��6,   $��0��69   $��3��6I   
�������$��25(�6p   $
��Bold"�6~   $��Dubai Medium)�6�   $��	História��6�   �� 5*      -   5        $ ListedAppsLabel��5*      $��0��61   $��1��6A   
�������$��20(�6a   $��Dubai Medium)�6o   $��Center=�6�   Najbližšie termíny6�   �� 5+      -   5         ��Name$ 
ListedApps��5+      $��0��6+   $��2��6;   $��3��6H   $��Center=�6\   $	��120��6w   
���� ��6�   �� 5-      -   5        $ NonAppsLabel��5-      $��0��6.   $��3��6>   
�������$��20(�6^   $��Dubai Medium)�6l   $��Center=�6�   Neobjednané vyšetrenia6�   �� 5.      -   5        $ NonListedApps��5.      $��0��6.   $��4��6>   $
��auto��6K   $��3��6X   $��Center=�6l   $	��120��6�   
���� ��6�   �� 50      -   5        $ PastAppsLabel��50      $��0��6/   $��5��6?   
�������$��20(�6_   $��Dubai Medium)�6m   $��Center=�6�   História vyšetrení6�   �� 51      -   5        $ PastApps��51      $��0��6)   $��6��69   $
��auto��6F   $��3��6S   $��Center=�6g   $	��120��6�   
���� ��6�   �� 53      -   5         ��Name$ ErrorBox��53   E   $��1��6   $��7��6$   $��2��61   $��Center=�6W   
��� E��
�������$��2q�6�   $��15(�6�   $��Dubai Medium)�6�   $
��auto��6�   $y�	Collapsed=�6�   .��6�   Chyba6�   54      55      56      