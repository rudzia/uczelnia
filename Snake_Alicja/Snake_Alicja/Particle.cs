using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;


namespace Snake_Alicja
{
    public class Particle
    {
        public int x { get; set; }
        public int y { get; set; }
        public Rectangle Rectangle { get; set; }
        public Particle(int X, int Y)
        {
            x = X;
            y = Y;
            Rectangle = new Rectangle(); 
            Rectangle.Width = Rectangle.Height = 10;
        }

        public void Draw()
        {
            Grid.SetColumn(Rectangle, x);
            Grid.SetRow(Rectangle, y);
        }
              
    }
}
