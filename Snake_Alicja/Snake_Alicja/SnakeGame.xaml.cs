using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.IO;

namespace Snake_Alicja
{
    /// <summary>
    /// Interaction logic for SnakeGame.xaml
    /// </summary>
    /// Nazywalo sie Mainwindow, _DirectionX, timer, SIZE
    struct Point
    {
        public int x;
        public int y;
    }

    public partial class SnakeGame : Window
    {
        private Snake mySnake;
        private NormalFood normfood;
        private DeadFood deadfood;
        private PremiumFood premfood;
        private int X_Direction = 0;
        private int Y_Direction = 1;
        private DispatcherTimer time;
        private static int SIZE_CELL = 10;
        static public int score;
        static public int recordScore;
        static public string recordUser;
        static public bool premiumFoodVisible = true;
        private int StarVisible;
        private int amountNormFood;

        public SnakeGame()
        {
            InitializeComponent(); 
            CreateBoard();
            CreateSnake();
            StartTime();
            MakeFood();            

            textBlockUser.Text = MainWindow.user_name;
            score = 0;
            textBlockScore.Text = score.ToString();

            using (var reader = new StreamReader("C:\\Users\\Alicja\\Documents\\Visual Studio 2015\\Projects\\Snake_Alicja\\Snake_Alicja\\record.txt"))
            {
                recordUser = reader.ReadLine();
                recordScore = Int16.Parse(reader.ReadLine());
                reader.Close();
            }

            textBlockRekordUser.Text = recordUser;
            textBlockRecordScore.Text = recordScore.ToString();
        }
        void CreateBoard()
        {
            for (int i = 0; i < gridGame.Width / SIZE_CELL; i++)
            {
                ColumnDefinition columnProperties = new ColumnDefinition();
                columnProperties.Width = new GridLength(SIZE_CELL);
                gridGame.ColumnDefinitions.Add(columnProperties);
            }
            for (int j = 0; j < gridGame.Height / SIZE_CELL; j++)
            {
                RowDefinition rowProperties = new RowDefinition();
                rowProperties.Height = new GridLength(SIZE_CELL);
                gridGame.RowDefinitions.Add(rowProperties);
            }
        }
        void CreateSnake()
        {
            mySnake = new Snake();
            gridGame.Children.Add(mySnake.HeadSnake.Rectangle);

            PartOfSnake part = mySnake.AddParts(31, 30);
            gridGame.Children.Add(part.Rectangle);

            mySnake.DrawSnake();        
        }
        

        void StartTime()
        {
            time = new DispatcherTimer();
            time.Tick += new EventHandler(TimeUpdate);
            time.Interval = new TimeSpan(0, 0, 0, 0, 120);
            time.Start();
        }

        void TimeUpdate(object sender, EventArgs e)
        {
            UpdateGame();
        }
        private void UpdateGame()
        {
            mySnake.updateList(X_Direction, Y_Direction);
            if (BoardCollision())
            {
                GameOver();
            }
            else
            {
                BadColiision();
                GoodCollision();
                mySnake.DrawSnake();
            }
        }

        void GameOver()
        {
            time.Stop();

            if (CheckRecord(score))
                MessageBox.Show("GAME OVER./n CONGRATULATION!! /n NEW RECORD! ");
            else
                MessageBox.Show("GAME OVER");
        }

        bool CheckRecord(int result)
        {
            if (result > recordScore)
            {
                StreamWriter sw = new StreamWriter("C:\\Users\\Alicja\\Documents\\Visual Studio 2015\\Projects\\Snake_Alicja\\Snake_Alicja\\record.txt");
                sw.WriteLine(MainWindow.user_name);
                sw.WriteLine(score);
                sw.Close();
                return true;
            }

            return false;
        }
        void MakeFood()
        {
            normfood = new NormalFood(10, 10);
            gridGame.Children.Add(normfood.Rectangle);
            normfood.Draw();

            deadfood = new DeadFood(30, 10);
            gridGame.Children.Add(deadfood.Rectangle);
            deadfood.Draw();

            premfood = new PremiumFood(40, 20);
            gridGame.Children.Add(premfood.Rectangle);
            premfood.Draw();
        }

        bool BoardCollision()
        {
            if (mySnake.HeadSnake.x < 0 || mySnake.HeadSnake.x > gridGame.Width / SIZE_CELL)
                return true;
            if (mySnake.HeadSnake.y < 0 || mySnake.HeadSnake.y > gridGame.Height / SIZE_CELL)
                return true;
            return false;
        }
        void GoodCollision()
        {
            if (mySnake.HeadSnake.x == normfood.x && mySnake.HeadSnake.y == normfood.y)
            {
                ++score;
                textBlockScore.Text = score.ToString();

                Random rnd = new Random();
                StarVisible = rnd.Next(0, 3);
                if (StarVisible == 1)
                {
                    Point point = NewLocation();
                    premfood.x = point.x;
                    premfood.y = point.y;
                    gridGame.Children.Add(premfood.Rectangle);
                    premfood.Draw();
                }
                else
                {
                    gridGame.Children.Remove(premfood.Rectangle);
                }

                PartOfSnake part = mySnake.AddParts(mySnake.partsSnake.Last().x, mySnake.partsSnake.Last().y);
                gridGame.Children.Add(part.Rectangle);
                mySnake.DrawSnake();

                //gridGame.Children.Remove(normfood.Rectangle);


                amountNormFood = rnd.Next(0, 3);


                Point pt = NewLocation();
                normfood.x = pt.x;
                normfood.y = pt.y;
                normfood.Draw();

                pt = NewLocation();
                deadfood.x = pt.x;
                deadfood.y = pt.y;
                deadfood.Draw();

            }
            
            if (mySnake.HeadSnake.x == premfood.x && mySnake.HeadSnake.y == premfood.y)
            {
                score += 10;
                textBlockScore.Text = score.ToString();
                PartOfSnake part = mySnake.AddParts(mySnake.partsSnake.Last().x, mySnake.partsSnake.Last().y);
                gridGame.Children.Add(part.Rectangle);
                mySnake.DrawSnake();
                gridGame.Children.Remove(premfood.Rectangle);                
            }
        }

        Point NewLocation()
        {
            Random rnd = new Random();
            Point point = new Point();
            do
            {
                point.x = rnd.Next(0, 43);
                point.y = rnd.Next(0, 53);
            }
            while (!isGridFree(point.x, point.y));

            return point;     
        }
        void BadColiision()
        {
            if (mySnake.HeadSnake.x == deadfood.x && mySnake.HeadSnake.y == deadfood.y)
                GameOver();
        }

        bool isGridFree(int X, int Y)
        {
            if (mySnake.HeadSnake.x == X && mySnake.HeadSnake.y == Y)
                return false;
            //if (mySnake.HeadSnake.x == X && mySnake.partsSnake.y)
                //return false;
            if (normfood.x == X && normfood.y == Y)
                return false;
            if (premfood.x == X && premfood.y == Y)
                return false;
            if (deadfood.x == X && deadfood.y == Y)
                return false;
            
            return true;
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left)
            {
                if (!(X_Direction == 1))
                { 
                    X_Direction = -1;
                    Y_Direction = 0;
                }
            }

            if (e.Key == Key.Right)
            {
                if (!(X_Direction == -1))
                {
                    X_Direction = 1;
                    Y_Direction = 0;
                }
            }

            if (e.Key == Key.Up)
            {
                if (!(Y_Direction == 1))
                {
                    X_Direction = 0;
                    Y_Direction = -1;
                }
            }

            if (e.Key == Key.Down)
            {
                if (!(Y_Direction == -1))
                {
                    X_Direction = 0;
                    Y_Direction = 1;
                }
            }
        }
        private void buttonExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void buttonMemu_Click(object sender, RoutedEventArgs e)
        {
            time.Stop();
            MainWindow win1 = new MainWindow();
            win1.Show();
            this.Close();
        }
        private void buttonTryAgain_Click(object sender, RoutedEventArgs e)
        {
            time.Stop();
            SnakeGame wintry = new SnakeGame();
            wintry.Show();
            this.Close();
        }
    }
}
