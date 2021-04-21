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
using System.Windows.Shapes;

namespace WearShop
{
    /// <summary>
    /// Логика взаимодействия для LAB9_window.xaml
    /// </summary>
    public partial class LAB9_window : Window
    {
        public int circle = 0;
        public LAB9_window()
        {
            InitializeComponent();
        }

        private void TBLB_TextChanged(object sender, RoutedPropertyChangedEventArgs<Color> e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Random rand = new Random();
            Grid_bubble.Background = new SolidColorBrush(Color.FromRgb((byte)rand.Next(0, 255), (byte)rand.Next(0, 255), (byte)rand.Next(0, 255)));

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Grid_tunnel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            switch(circle)
            {
                case 0:
                    {
                        Red.Visibility = Visibility.Visible;
                        circle++;
                        break;
                    }
                case 1:
                    {
                        Green.Visibility = Visibility.Visible; circle++;
                        break;
                    }
                case 2:
                    {
                        Blue.Visibility = Visibility.Visible; circle++;
                        break;
                    }
                case 3:
                    {
                        Red.Visibility = Visibility.Hidden; circle++;
                        break;
                    }
                case 4:
                    {
                        Green.Visibility = Visibility.Hidden; circle++;
                        break;
                    }
                case 5:
                    {
                        Blue.Visibility = Visibility.Hidden; circle = 0;
                        break;
                    }

            }
        }

        private void TextBlock_MouseEnter(object sender, MouseEventArgs e)
        {
            TBDirect.Text = "Мышь внутри прямоугольника";
        }

        private void TextBlock_MouseLeave(object sender, MouseEventArgs e)
        {
            TBDirect.Text = "Мышь вне прямоугольника";
        }

        public static RoutedCommand ColorCommand = new RoutedUICommand("Получить цвет", "GetColor", typeof(MainWindow));

        private void GetColor_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
                e.CanExecute = true;
        }

        private void GetColor_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Код цвета: "+Grid_bubble.Background.ToString(),"Код цвета");
        }

        private void GetColor_PreviewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Command == ApplicationCommands.Paste)
            {
                e.Handled = true;
            }
        }

        private void TBLB_TextChanged_1(object sender, RoutedPropertyChangedEventArgs<string> e)
        {

        }
    }
}
