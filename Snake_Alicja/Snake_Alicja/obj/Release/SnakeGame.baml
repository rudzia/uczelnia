   M S B A M L   `   `   `  ���� G  CSnake_Alicja, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Snake_AlicjaSnake_Alicja      Snake_Alicja.SnakeGame   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     ,localclr-namespace:Snake_Alicja     -     � Title$  Snake Game 2017��$	��600��$	��800�� � WindowStartupLocation$ CenterScreen=�.��� ����  �� ImageSource$m gC:\Users\Alicja\Documents\Visual Studio 2015\Projects\Snake_Alicja\Snake_Alicja\snakebackgroundGame.jpg�� j� Stretch$ UniformToFill=� �� Opacity$ 10Q�.+��� $	��530��$	��490��
���   �$��	15,14,0,0q�$	��Top=�$
��Left=�� -   $��gridGame��$	��490��$��	15,14,0,0q�$
��Left=�$	��530��$	��Top=�� -   $��grid2��$
��Left=�$	��540��$��
529,14,0,0q�$	��Top=�$	��253�� � RowDefinitions �� $	��59* ��� $	��31* �.+��� -    ��Name$ label��$��USER:��$
��Left=�$��	10,-4,0,0q�$	��Top=�$��42��$	��203��$��25(�$��Rockwell Extra Bold)����� �� -   $ label2��$��SCORE:��$
��Left=�$��	10,78,0,0q�$	��Top=�$��40��$	��203��$��25(�$��Rockwell Extra Bold)��� -    ��Name$ 
buttonExit��$��END GAME��$
��Left=�$��8,68,0,0q�$	��Top=�$	��235��$��48��$��25(�$��Rockwell Extra Bold)�$��1������ $i cC:\Users\Alicja\Documents\Visual Studio 2015\Projects\Snake_Alicja\Snake_Alicja\snakeTexturejpg.jpg��$	 0.5Q�$ UniformToFill=��� -   $ 
buttonMemu��$��BACK TO MENU��$
��Left=�$��	8,121,0,0q�$	��Top=�$	��235��$��48��$��25(�$��Rockwell Extra Bold)�$��1������ $i cC:\Users\Alicja\Documents\Visual Studio 2015\Projects\Snake_Alicja\Snake_Alicja\snakeTexturejpg.jpg��$	 0.5Q�$ UniformToFill=��� -    ��Name$ textBlockUser��$
��Left=�$��	10,38,0,0q�$
��Wrap=�$��40��$	��202��$��25(�$��Miriam)�$
��Bold"�$	��Top=����� �� -	   $ textBlockScore��$
��Left=�$��
10,118,0,0q�$
��Wrap=�$	��Top=�	 J� RenderTransformOrigin$	 -0.68,-0.375&�$��40��$	��203��$��25(�$��Miriam)�$
��Bold"��� -
   $ buttonTryAgain��$��	TRY AGAIN��$
��Left=�$��8,15,0,0q�$	��Top=�$	��235��$��48��$��25(�$��Rockwell Extra Bold)�$��1������ $i cC:\Users\Alicja\Documents\Visual Studio 2015\Projects\Snake_Alicja\Snake_Alicja\snakeTexturejpg.jpg��$	 0.5Q�$ UniformToFill=��� -   $ labelRekord��$��REKORD:��$
��Left=�$��
42,178,0,0q�$	��Top=�$��48��$	��182��$��25(�$
��Bold"�$��Rockwell Extra Bold)���Z� �� -   $ textBlockRekordUser��$
��Left=�$��
42,226,0,0q�$
��Wrap=�$	��Top=�$��48��$	��182��$��25(�$��Miriam Fixed)�$
��Bold"��� -   $ textBlockRecordScore��$
��Left=�$��
42,274,0,0q�$
��Wrap=�$	��Top=�$��48��$	��182��$��25(�$��Miriam Fixed)�$
��Bold"��� $
��Left=�$	��144��$��	0,178,0,0q�
���   �$	��Top=�$	��250��