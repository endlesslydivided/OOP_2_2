using DIVIDEDSHOP;
using Microsoft.Win32;
using OOP_2;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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
using System.Windows.Resources;
using System.Windows.Shapes;
using WearShop.Properties;

namespace WearShop
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static ClothesCollection clothes = new ClothesCollection();
        public static CaretakerWearList caretaker = new CaretakerWearList();
        public static CaretakerWearList caretakerTurnBack = new CaretakerWearList();
        public static ObservableCollection<Clothes> pageCloth { get; set; }
        public static ObservableCollection<Clothes> FilteredClothes { get; set; }
        public static Clothes LastSelectedItem;
        public string CurrentPage = "Одежда";
        public string local = @"..\Dictionary.ru-RU.xaml";
        string connectionString;
        SqlDataAdapter adapter;
        DataTable clothesTable;

        public MainWindow()
        {


            //SplashScreen splashScreen = new SplashScreen("WearShop.jpg");
            //splashScreen.Show(false,true);
            //splashScreen.Close(TimeSpan.FromSeconds(1));
            InitializeComponent();

            CommandBinding bindNew = new CommandBinding(ApplicationCommands.New);
            bindNew.Executed += AddNewClothOpen;
            this.CommandBindings.Add(bindNew);

            CommandBinding bindFind = new CommandBinding(ApplicationCommands.Find);
            bindFind.Executed += FilterClothOpen;
            this.CommandBindings.Add(bindFind);

            CommandBinding bindUndo = new CommandBinding(ApplicationCommands.Undo);
            bindUndo.Executed += Undo_Click;
            this.CommandBindings.Add(bindUndo);

            CommandBinding bindRedo = new CommandBinding(ApplicationCommands.Redo);
            bindRedo.Executed += Redo_Click;
            this.CommandBindings.Add(bindRedo);

            string filename = "..\\products.xml";
            clothes.ClothesList = XmlSerializeWrapper.Deserialize<ObservableCollection<Clothes>>(filename);
            if(clothes == null)
            {
                clothes.ClothesList = new ObservableCollection<Clothes>();
            }
            caretaker.History.Push(clothes.SaveState());
            ObservableCollection<Clothes> cloth = new ObservableCollection<Clothes>();
            Renew_List("Одежда");

            this.Cursor = Cursors.None;
            StreamResourceInfo sri = Application.GetResourceStream(new Uri("NeonWIB01-Red.ani", UriKind.Relative));
            Cursor customCursor = new Cursor(sri.Stream);
            this.Cursor = customCursor;

            

        }

        private void Redo_Click(object sender, RoutedEventArgs e)
        {
            if (caretakerTurnBack.History.Count != 0)
            {
                caretaker.History.Push(clothes.SaveState());
                clothes.RestoreState(caretakerTurnBack.History.Pop());
            }
            if (CurrentPage == "Одежда")
            {
                Renew_List("Одежда");
            }
            else if(CurrentPage == "Обувь")
            {
                Renew_List("Обувь");
            }
      
        }

        private void Undo_Click(object sender, RoutedEventArgs e)
        {
            if (caretaker.History.Count != 0)
            {
                caretakerTurnBack.History.Push(clothes.SaveState());
                clothes.RestoreState(caretaker.History.Pop());
            }
            if (CurrentPage == "Одежда")
            {
                Renew_List("Одежда");
            }
            else if (CurrentPage == "Обувь")
            {
                Renew_List("Обувь");
            }
        }

        private void AddNewClothOpen(object sender, ExecutedRoutedEventArgs e)
        {
            Window1 windowADD = new Window1(local);
            windowADD.Show();
        }
        private void FilterClothOpen(object sender, ExecutedRoutedEventArgs e)
        {
            FilteredClothes = new ObservableCollection<Clothes>();
            foreach(Clothes x in clothes.ClothesList)
            {
                FilteredClothes.Add(x);
            }
            Clothes_ListBox.ItemsSource = FilteredClothes;
            Filter windowFilter = new Filter(local);
            windowFilter.Show();
        }

        private void Clothes_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Renew_List("Одежда");
            CurrentPage = "Одежда";
        }

        private void Clothes_ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           Clothes p = (Clothes)Clothes_ListBox.SelectedItem;
            if (p != null)
            {
                ContextPopup.IsOpen = true;
                Image img = new Image();
                img.BeginInit();
                try { img.Source = new BitmapImage(new Uri(p.ImageAdress)); }
                catch(Exception exception)
                {
                    MessageBox.Show("Картинка не найдена!");
                }
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
            Renew_List("Обувь");
            CurrentPage = "Обувь";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Clothes p = (Clothes)Clothes_ListBox.SelectedItem;
            if (p != null)
            {
                caretaker.History.Push(clothes.SaveState());
                ContextPopup.IsOpen = false;
                ChangeValuesPopup.IsOpen = false;
                clothes.ClothesList.Remove(p);
                Clothes_ListBox.UnselectAll();
                if (CurrentPage == "Одежда")
                {
                    Renew_List("Одежда");
                }
                else if (CurrentPage == "Обувь")
                {
                    Renew_List("Обувь");
                }
            }
        }

        private void EditItemBTTN_Click(object sender, RoutedEventArgs e)
        {
            LastSelectedItem =  (Clothes)Clothes_ListBox.SelectedItem;
            ChangeValuesPopup.IsOpen = true;
            CostEditTB.Text = LastSelectedItem.Cost.ToString();
            RateEditSLDR.Value = LastSelectedItem.Rate;
            ColorEditCB.Text = LastSelectedItem.Color;
            CategoryEditCB.Text = LastSelectedItem.Category;
            FullNameEditTB.Text = LastSelectedItem.FullName;
            ShortNameEditTB.Text = LastSelectedItem.ShortName;
            DescriptionEditTB.Text = LastSelectedItem.Description;
            SizeEditTB.Text = LastSelectedItem.Size;
        }

        private void CloseEditPUP_Click(object sender, RoutedEventArgs e)
        {
            ChangeValuesPopup.IsOpen = false;
        }

        private void OkEditItemBTTN_Click(object sender, RoutedEventArgs e)
        {
            caretaker.History.Push(clothes.SaveState());
            LastSelectedItem.Cost = int.Parse(CostEditTB.Text);
            LastSelectedItem.Rate = (int)RateEditSLDR.Value;
            LastSelectedItem.Color = ColorEditCB.Text;
            LastSelectedItem.Category = CategoryEditCB.Text;
            LastSelectedItem.FullName = FullNameEditTB.Text;
            LastSelectedItem.ShortName = ShortNameEditTB.Text;
            LastSelectedItem.Description = DescriptionEditTB.Text;
            LastSelectedItem.Size = SizeEditTB.Text;
            ChangeValuesPopup.IsOpen = false;
          
            if (LastSelectedItem.Category == "Одежда")
            {
                Renew_List("Одежда");
            }
            else if(LastSelectedItem.Category == "Обувь")
            {
                Renew_List("Обувь");
            }   
        }

        private void AddPictureBTTN_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.ShowDialog();
            string filename = openFileDialog1.FileName;
            if (Regex.IsMatch(filename, $".jpg|.jfif|.jpg"))
            {
                caretaker.History.Push(clothes.SaveState());
                LastSelectedItem.ImageAdress = filename;
            }
            else
            {
                MessageBox.Show("Неверный формат файла!");
            }
        }

        public void Renew_List(string category)
        {
            pageCloth = new ObservableCollection<Clothes>();
            Clothes_ListBox.ItemsSource = pageCloth;
            if (clothes.ClothesList != null)
            {
                foreach (Clothes x in clothes.ClothesList)
                {
                    if (x.category == category)
                        pageCloth.Add(x);
                }
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            ResourceDictionary dict = new ResourceDictionary();
            dict.Source = new Uri(@"..\Dictionary.ru-RU.xaml", UriKind.Relative);
            local = @"..\Dictionary.ru-RU.xaml";
            Resources.MergedDictionaries.Add(dict);
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            ResourceDictionary dict = new ResourceDictionary();
            dict.Source = new Uri(@"..\Dictionary.eng-ENG.xaml", UriKind.Relative);
            local = @"..\Dictionary.eng-ENG.xaml";
            Resources.MergedDictionaries.Add(dict);
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            ResourceDictionary dict = new ResourceDictionary();
            dict.Source = new Uri(@"..\Style_black_n_white.xaml", UriKind.Relative);
            local = @"..\Style_black_n_white.xaml";
            Resources.MergedDictionaries.Add(dict);
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            ResourceDictionary dict = new ResourceDictionary();
            dict.Source = new Uri(@"..\Style_classic.xaml", UriKind.Relative);
            local = @"..\Style_classic.xaml";
            Resources.MergedDictionaries.Add(dict);
        }

        private void Stylish_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Lab9_Click(object sender, RoutedEventArgs e)
        {
            LAB9_window windowADD = new LAB9_window();
            windowADD.Show();
        }

        private void Lab10_Click(object sender, RoutedEventArgs e)
        {
            LAB10 windowADD = new LAB10();
            windowADD.Show();
        }
    }
}
