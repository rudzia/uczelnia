   M S B A M L   `   `   `  ���� G  CSnake_Alicja, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Snake_AlicjaSnake_Alicja      Snake_Alicja.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     ,localclr-namespace:Snake_Alicja       � Title$  Settings snake game��$	��600��$	��800�� � WindowStartupLocation$ CenterScreen=�.��� ����  �� ImageSource$i cC:\Users\Alicja\Documents\Visual Studio 2015\Projects\Snake_Alicja\Snake_Alicja\snakebackground.jpg�� j� Stretch$ UniformToFill=�.+��� -    ��Name$ label��$
��Left=�$��	74,81,0,0q�$	��Top=�� $��Center=�$	��550��$	��Top=�$	��750��.+��� -   $ 
label_user��$
��Left=�$��105,166,0,0q�$	��Top=�$��70��$	��173��$��25(�.���� -   $ label1��$��	User name��$1��+/Snake_Alicja;component/Fonts/#Chicken Butt)�$	��165��$��35(��� -   $ label_colors��$��Choose snake color��$
��Left=�$��
10,251,0,0q�$	��Top=�$��62��$	��268��$��35(�$1��+/Snake_Alicja;component/Fonts/#Chicken Butt)��� -    ��Name$ textBoxUser��$
��Left=�$��70��$��301,166,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$	��225�����	#FFCFF973$��25(�$��Rockwell Extra Bold)��� -    ��Name$ button_start��$��
START GAME��$
��Left=�$��120,337,0,0q�$	��Top=�$	��338��$	��126��$��30(�$
��Bold"�
���   �$��Rockwell Extra Bold)���. ���� $i cC:\Users\Alicja\Documents\Visual Studio 2015\Projects\Snake_Alicja\Snake_Alicja\snakeTexturejpg.jpg�� �� Opacity$	 0.5Q�$ UniformToFill=��� -   $ 
labelSNAKE��$��Snake��   
CustomFont#��[  $��Center=�$��221,0,172,0q�$	��Top=�$	��150(�$	��161��$	��357���� -   $ 
labelAutor��$ ��Autor: Alicja Strąk, 2017��$
��Left=�$��
0,532,0,-8q�$	��Top=�$	��195���� -	   $ 
buttonExit��$
��EXIT��$
��Left=�$��234,491,0,0q�$	��Top=�$	��106�����	#FF7CA412$��20(�$��Rockwell Extra Bold)�$��49�����	#FF7CA412�� -
   	 ��Name$	 comboBoxColors��$
��Left=�$��301,251,0,0q�$	��Top=�$	��225��
 J� RenderTransformOrigin$
 -0.483,-0.136&�$��62�����	#FFCFF973���	#FFCFF973$��25(�$��Rockwell Extra Bold)�.@��� .��black�� .��purple�� .��orange�� .��pink�� .��white