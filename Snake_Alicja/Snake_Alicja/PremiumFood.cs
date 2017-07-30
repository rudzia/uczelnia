using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Snake_Alicja
{
    class PremiumFood : Particle
    {
        public PremiumFood(int X, int Y) : base(X, Y)
        { 
            Rectangle.Fill = new ImageBrush
            {
                ImageSource = new System.Windows.Media.Imaging.BitmapImage(new Uri("C:\\Users\\Alicja\\Pictures\\skóry\\star.png"))
            };
        }
    }
}
