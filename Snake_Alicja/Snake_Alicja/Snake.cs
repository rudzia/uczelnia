using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Snake_Alicja
{//przed tem nazywala sie Snake
    class Snake
    {
        public PartOfSnake HeadSnake { get; private set; }
        public List<PartOfSnake> partsSnake = new List<PartOfSnake>();
        
        public Snake()
        {
            HeadSnake = new PartOfSnake(30, 30);
            HeadSnake.Rectangle.Width = HeadSnake.Rectangle.Height = 12;
            HeadSnake.Rectangle.Fill = System.Windows.Media.Brushes.Beige;
        }

        public void DrawSnake()
        {
            Grid.SetColumn(HeadSnake.Rectangle, HeadSnake.x);
            Grid.SetRow(HeadSnake.Rectangle, HeadSnake.y);

            for (int i = 0; i < partsSnake.Count; i++)
            {
                partsSnake[i].Draw();
            }
        }
        public PartOfSnake AddParts(int x, int y)
        {
            PartOfSnake part = new PartOfSnake(x, y);
            partsSnake.Add(part);
            return part;
        }

        public void updateList(int xDirection, int yDirection)
        {
            PartOfSnake prev = new PartOfSnake(HeadSnake.x, HeadSnake.y);
            for(int i = 0; i < partsSnake.Count; i++)
            {
                PartOfSnake tmp = new PartOfSnake(partsSnake[i].x, partsSnake[i].y);
                partsSnake[i].x = prev.x;
                partsSnake[i].y = prev.y;
                prev.x = tmp.x;
                prev.y = tmp.y;
            }

            HeadSnake.x += xDirection;
            HeadSnake.y += yDirection;
        }
    }
}
