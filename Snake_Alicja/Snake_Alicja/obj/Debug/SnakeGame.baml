   M S B A M L   `   `   `  ����G  CSnake_Alicja, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Snake_AlicjaSnake_Alicja  5   	       Snake_Alicja.SnakeGame   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Snake_Alicja     5   	   -   5          � Title$  Snake Game 2017��5   	   $	��600��6!   $	��800��6.    � WindowStartupLocation$ CenterScreen=�5
   	   .��5      � ��5   
   �� 5       �� ImageSource$m gC:\Users\Alicja\Documents\Visual Studio 2015\Projects\Snake_Alicja\Snake_Alicja\snakebackgroundGame.jpg��6    j� Stretch$ UniformToFill=�6�    �� Opacity$ 10Q�6�   .+�5   
   �� $	��530��6   $	��490��6!   
���   �$��	15,14,0,0q�6<   $	��Top=�6O   $
��Left=�6g   � 5   
   -   5        $��gridGame��5      $	��490��6   $��	15,14,0,0q�6+   $
��Left=�6>   $	��530��6Y   $	��Top=�6f   � 5   
   -   5        $��grid2��5      $
��Left=�6   $	��540��68   $��
529,14,0,0q�6E   $	��Top=�6Y   $	��253��6q    � RowDefinitions 5      �� 5      $	��59* �6    �� 5      $	��31* �6    .+�5      �� -   5         ��Name$ label��5      $��USER:��6#   $
��Left=�63   $��	10,-4,0,0q�6N   $	��Top=�6a   $��42��6y   $	��203��6�   $��25(�6�   $��Rockwell Extra Bold)�6�   ��5      �� 5      5      �� 5      -   5        $ label2��5      $��SCORE:��6$   $
��Left=�65   $��	10,78,0,0q�6P   $	��Top=�6c   $��40��6{   $	��203��6�   $��25(�6�   $��Rockwell Extra Bold)�6�   �� 5      -   5         ��Name$ 
buttonExit��5      $��END GAME��6)   $
��Left=�6<   $��8,68,0,0q�6W   $	��Top=�6i   $	��235��6�   $��48��6�   $��25(�6�   $��Rockwell Extra Bold)�6�   $��1��6�   ��5      �� 5      $i cC:\Users\Alicja\Documents\Visual Studio 2015\Projects\Snake_Alicja\Snake_Alicja\snakeTexturejpg.jpg��6!   $	 0.5Q�6�   $ UniformToFill=�6�   5       �� 5!      -   5        $ 
buttonMemu��5!      $��BACK TO MENU��6)   $
��Left=�6@   $��	8,121,0,0q�6[   $	��Top=�6n   $	��235��6�   $��48��6�   $��25(�6�   $��Rockwell Extra Bold)�6�   $��1��6�   ��5"      �� 5#      $i cC:\Users\Alicja\Documents\Visual Studio 2015\Projects\Snake_Alicja\Snake_Alicja\snakeTexturejpg.jpg��6!   $	 0.5Q�6�   $ UniformToFill=�6�   5%      �� 5&      -   5         ��Name$ textBlockUser��5&      $
��Left=�6/   $��	10,38,0,0q�6J   $
��Wrap=�6]   $��40��6q   $	��202��6}   $��25(�6�   $��Miriam)�6�   $
��Bold"�6�   $	��Top=�6�   ��5'      �� 5(      5*      �� 5+      -	   5        $ textBlockScore��5+      $
��Left=�60   $��
10,118,0,0q�6K   $
��Wrap=�6_   $	��Top=�6s   	 J� RenderTransformOrigin$	 -0.68,-0.375&�6�   $��40��6�   $	��203��6�   $��25(�6�   $��Miriam)�6�   $
��Bold"�6�   �� 5,      -
   5        $ buttonTryAgain��5,      $��	TRY AGAIN��6-   $
��Left=�6A   $��8,15,0,0q�6\   $	��Top=�6n   $	��235��6�   $��48��6�   $��25(�6�   $��Rockwell Extra Bold)�6�   $��1��6�   ��5-      �� 5.      $i cC:\Users\Alicja\Documents\Visual Studio 2015\Projects\Snake_Alicja\Snake_Alicja\snakeTexturejpg.jpg��6!   $	 0.5Q�6�   $ UniformToFill=�6�   50      �� 51      -   5        $ labelRekord��51      $��REKORD:��6)   $
��Left=�6;   $��
42,178,0,0q�6V   $	��Top=�6j   $��48��6�   $	��182��6�   $��25(�6�   $
��Bold"�6�   $��Rockwell Extra Bold)�6�   ��6�   Z� 6�   �� 52      -   5        $ textBlockRekordUser��52      $
��Left=�65   $��
42,226,0,0q�6P   $
��Wrap=�6d   $	��Top=�6y   $��48��6�   $	��182��6�   $��25(�6�   $��Miriam Fixed)�6�   $
��Bold"�6�   �� 53      -   5        $ textBlockRecordScore��53      $
��Left=�66   $��
42,274,0,0q�6Q   $
��Wrap=�6e   $	��Top=�6y   $��48��6�   $	��182��6�   $��25(�6�   $��Miriam Fixed)�6�   $
��Bold"�6�   �� 54      $
��Left=�6   $	��144��63   $��	0,178,0,0q�6@   
���   �$	��Top=�6b   $	��250��6z   55      56      57      