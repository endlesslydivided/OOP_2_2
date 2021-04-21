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
using System.Windows.Shapes;

namespace DIVIDEDSHOP
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public string IMAGESTR = "D:\\ALEX\\STUDY\\4SEM_2COURSE\\ООТП\\Лабораторные работы\\6-7(WPF_shop_service)\\DIVIDEDSHOP\\DIVIDEDSHOP\\Pictures\\Без названия.jfif";
        public Window1()
        {
            InitializeComponent();
        }

        private void RateSLDR_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            RateValue.Content = Math.Round(RateSLDR.Value);
        }

        private void OkBTTNADD_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.clothes.Add(new Clothes(ShortNameTB.Text, FullNameTB.Text, DescriptionTB.Text, IMAGESTR, CategoryCB.Text, (int)Math.Round(RateSLDR.Value), int.Parse(CostTB.Text), ColorCB.Text, SizeTB.Text));
            ShortNameTB.Text = "Краткое название";
            FullNameTB.Text = "Полное название";
            DescriptionTB.Text = "Описание";
            IMAGESTR = "D:\\ALEX\\STUDY\\4SEM_2COURSE\\ООТП\\Лабораторные работы\\6-7(WPF_shop_service)\\DIVIDEDSHOP\\DIVIDEDSHOP\\Pictures\\Без названия.jfif";
            CategoryCB.Text = "";
            RateSLDR.Value = 0;
            CostTB.Text = "Цена";
            ColorCB.Text = "";
            SizeTB.Text = "Размер";
            string filename = "..\\products.xml";
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
    }
}
