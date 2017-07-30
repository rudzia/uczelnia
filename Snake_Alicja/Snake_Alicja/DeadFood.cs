using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Snake_Alicja
{
    class DeadFood : Particle
    {
        public DeadFood(int X, int Y) : base(X, Y)
        {           
            Rectangle.Fill = new ImageBrush
            {
                ImageSource = new System.Windows.Media.Imaging.BitmapImage(new Uri("C:\\Users\\Alicja\\Pictures\\skóry\\skulllll.png"))
            };
        }   
    }
}
