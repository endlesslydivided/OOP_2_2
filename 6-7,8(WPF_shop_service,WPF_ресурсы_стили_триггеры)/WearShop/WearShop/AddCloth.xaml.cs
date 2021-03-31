using Microsoft.Win32;
using OOP_2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using WearShop;

namespace DIVIDEDSHOP
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public string IMAGESTR = "default.jfif";
        public Window1(string file)
        {
            InitializeComponent();
            ResourceDictionary dict = new ResourceDictionary();
            dict.Source = new Uri(file, UriKind.Relative);
            Resources.MergedDictionaries.Add(dict);
            this.Cursor = Cursors.None;
            StreamResourceInfo sri = Application.GetResourceStream(new Uri("NeonWIB01-Red.ani", UriKind.Relative));
            Cursor customCursor = new Cursor(sri.Stream);
            this.Cursor = customCursor;
        }

        private void RateSLDR_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            RateValue.Content = Math.Round(RateSLDR.Value);
        }

        private void OkBTTNADD_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.clothes.ClothesList.Add(new Clothes(ShortNameTB.Text, FullNameTB.Text, DescriptionTB.Text, IMAGESTR, CategoryCB.Text, (int)Math.Round(RateSLDR.Value), int.Parse(CostTB.Text), ColorCB.Text, SizeTB.Text));
            DescriptionTB.Text = "Описание";
            IMAGESTR = "default.jfif";
            CategoryCB.Text = "";
            RateSLDR.Value = 0;
            CostTB.Text = "Цена";
            ColorCB.Text = "";
            SizeTB.Text = "Размер";
            string filename = "..\\products.xml";
            MainWindow.caretaker.History.Push(MainWindow.clothes.SaveState());
            if (Regex.IsMatch(filename, $".xml$"))
            {
                XmlSerializeWrapper.Serialize(MainWindow.clothes, filename);
            }
            else
            {
                MessageBox.Show("Неверный формат файла!");
            }
        }

        private void AddPictureBTTN_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.ShowDialog();
            string filename = openFileDialog1.FileName;
            if (Regex.IsMatch(filename, $".jpg|.jfif|.jpg"))
            {
                MainWindow.caretaker.History.Push(MainWindow.clothes.SaveState());
                IMAGESTR = filename;
            }
            else
            {
                MessageBox.Show("Неверный формат файла!");
            }
        }

        private void CancelBTTNADD_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BlockButton_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
