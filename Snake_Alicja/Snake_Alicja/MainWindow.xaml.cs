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

namespace Snake_Alicja
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        static public string user_name;
        public string comboCellSnake;
        static public string color_snake;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_start_Click(object sender, RoutedEventArgs e)
        {
            user_name = textBoxUser.Text;
            color_snake = comboBoxColors.SelectionBoxItem.ToString();            
        
            if (user_name != "" && color_snake != "")
            {
                SnakeGame win2 = new SnakeGame();
                win2.Show();
                this.Close();
            }
            else if (user_name != "" && color_snake == "")
            {
                MessageBox.Show("Select color your snake");
            }
            else if (user_name == "" && color_snake != "")
            {
                MessageBox.Show("Write user name");
            }
            else
            {
                MessageBox.Show("Write user name and select color your snake");
            }         
        }

        private void listBoxColors_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void buttonLegend_Click(object sender, RoutedEventArgs e)
        {
            Legend win3 = new Legend();
            win3.Show();
        }

        private void buttonExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void textBoxUser_TextChanged(object sender, TextChangedEventArgs e)
        {
                        
        }
    }
}
