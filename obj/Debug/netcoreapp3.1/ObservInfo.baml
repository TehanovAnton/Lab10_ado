   M S B A M L   `   `   `  ����H  DLabWork10_ado, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:LabWork10_adoLabWork10_ado  5          LabWork10_ado.ObservInfo   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:LabWork10_ado     5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  61     N� Title$  
ObservInfo��5	       N� 
Background
 �����.��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� $��0��6   .+�5      �� -   5         ��Name$ image��5      $��2 2 2 2q�5      $t��nC:\Users\Anton\source\repos\pacei_NV_OOTP\лабораторные\решения\LabWork10_ado\images\Add.png��5      $	��387��5      5      5      �� 5   
   $��1��6   .+�5      �� $��5q�6   
���   � �� CornerRadius$ 10��5      ._�5      �� $��2 2 2 2q�6   .+�5      �� $
��Name��6   $��0 0 0 0q�5       �� 5!      -   5         ��Name$ 	nameInput��5!      
�������5"      5#      5$      �� 5&      $��5q�6   
���   �$ 10��5(      $��0 2 0 0q�5)      ._�5*      �� $��2 2 2 2q�6   .+�5+      �� $��LastName��6   $��0 0 0 0q�5,      �� 5-      -   5        $ lastNameInput��5-      
�������5.      5/      50      �� 52      $��5q�6   
���   �$ 10��54      $��0 2 0 0q�55      ._�56      �� $��2 2 2 2q�6   .+�57      �� $��Mail Adress��6   $��0 0 0 0q�58      �� 59      -   5        $ mailAdressInput��59      
�������5:      5;      5<      �� 5>      $��5q�6   
���   �$ 10��5@      $��0 2 0 0q�5A      ._�5B      �� $��2 2 2 2q�6   .+�5C      �� -   5         ��Name$ birthday��5C      $��Birthday��6.   $��0 0 0 0q�5D      (  "System.Windows.Controls.DatePicker  5E      -   5          Name$ birthdayInput��5E   !   5F      5G      �� 5H      $
��next��6   $��3 3 3 3q�5I      ��5H   $   �� *Next+5I      �� 5J      $��privious��6   $��3 3 3 3q�5K      ��5J   (   �� *
Privious+5K      �� 5L      $
��Edit��6   $��3 3 3 3q�5M      ��5L   $   �� *Edit+5M      �� 5N      $��Delete��6   $��3 3 3 3q�5O      ��5N   &   �� *Delete+5O      5P      5Q      5R      