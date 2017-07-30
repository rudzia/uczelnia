using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Snake_Alicja
{
    class NormalFood : Particle
    {
        public NormalFood(int X, int Y) : base(X, Y)
        {
            Rectangle.Fill = System.Windows.Media.Brushes.Red;
        }       
    }
}
