using OOP_2;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DIVIDEDSHOP
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static ObservableCollection<Clothes> clothes { get; set; }
        
        public MainWindow()
        {
            
            InitializeComponent();

            CommandBinding bind = new CommandBinding(ApplicationCommands.New);
            bind.Executed += AddNewClothOpen;
            this.CommandBindings.Add(bind);

            string filename = "..\\products.xml";
            clothes = XmlSerializeWrapper.Deserialize<ObservableCollection<Clothes>>(filename);
            if(clothes == null)
            {
                clothes = new ObservableCollection<Clothes>();
            }
            ObservableCollection<Clothes> cloth = new ObservableCollection<Clothes>();
            Clothes_ListBox.ItemsSource = cloth;
            if (clothes != null)
            {
                foreach (Clothes x in clothes)
                {
                    if (x.category == "Одежда")
                        cloth.Add(x);
                }
            }

        }
        private void AddNewClothOpen(object sender, ExecutedRoutedEventArgs e)
        {
            Window1 windowADD = new Window1();
            windowADD.Show();
        }

        private void Clothes_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void Clothes_MouseUp(object sender, MouseButtonEventArgs e)
        {
            ObservableCollection<Clothes> cloth = new ObservableCollection<Clothes>();
            Clothes_ListBox.ItemsSource = cloth;
            Clothes_ListBox.ItemsSource = cloth;
            if (clothes != null)
            {
                foreach (Clothes x in clothes)
                {
                    if (x.category == "Одежда")
                        cloth.Add(x);
                }
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Clothes_ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           Clothes p = (Clothes)Clothes_ListBox.SelectedItem;
            if (p != null)
            {
                ContextPopup.IsOpen = true;
                Image img = new Image();
                img.BeginInit();
                img.Source = new BitmapImage(new Uri(p.ImageAdress));
                img.EndInit();

                ImagePU.Source = img.Source;
                FullNamePU.Text = p.FullName;
                CostPU.Text = p.Cost.ToString() + "$";
                ColorPU.Text = p.Color;
                RatePU.Text = p.Rate.ToString() + "/10";
                SizePU.Text = p.Size;
                DescriptionPU.Text = p.Description;
            }
        }

        private void ContextPopup_MouseLeave(object sender, MouseEventArgs e)
        {
            ContextPopup.IsOpen = false;
            Clothes_ListBox.UnselectAll();
        }

        private void Shoes_MouseUp(object sender, MouseButtonEventArgs e)
        {
            ObservableCollection<Clothes> shooes = new ObservableCollection<Clothes>();
            Clothes_ListBox.ItemsSource = shooes;
            Clothes_ListBox.ItemsSource = shooes;
            if (clothes != null)
            {
                foreach (Clothes x in clothes)
                {
                    if (x.category == "Обувь")
                        shooes.Add(x);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Clothes p = (Clothes)Clothes_ListBox.SelectedItem;
            if (p != null)
            {
                clothes.Remove(p);
                Clothes_ListBox.UnselectAll();
                ObservableCollection<Clothes> cloth = new ObservableCollection<Clothes>();
                Clothes_ListBox.ItemsSource = cloth;
                if (clothes != null)
                {
                    foreach (Clothes x in clothes)
                    {
                        if (x.category == "Одежда")
                            cloth.Add(x);
                    }
                }
            }
        }

        private void EditItemBTTN_Click(object sender, RoutedEventArgs e)
        {
            Clothes p = (Clothes)Clothes_ListBox.SelectedItem;
        }
    }
}
