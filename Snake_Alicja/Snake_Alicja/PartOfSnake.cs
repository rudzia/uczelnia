using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Snake_Alicja
{ 
    class PartOfSnake : Particle
    {
        public PartOfSnake(int X, int Y) : base(X, Y)
        {
          
            if (MainWindow.color_snake == "black")
            {
                Rectangle.Fill = Brushes.Black;
            }
            else if (MainWindow.color_snake == "purple")
            {
                Rectangle.Fill = Brushes.Purple;
            }
            else if (MainWindow.color_snake == "orange")
            {
                Rectangle.Fill = Brushes.Orange;
            }
            else if (MainWindow.color_snake == "pink")
            {
                Rectangle.Fill = Brushes.Pink;
            }
            else if (MainWindow.color_snake == "white")
            {
                Rectangle.Fill = Brushes.White;
            }
        }
    }
}
