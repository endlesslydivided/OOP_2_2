using DIVIDEDSHOP;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

using System.Windows.Media;
using System.Drawing;
using System.Text.RegularExpressions;
using System;
using System.Windows.Input;
using System.Windows.Resources;

namespace WearShop
{
    /// <summary>
    /// Логика взаимодействия для Filter.xaml
    /// </summary>
    public partial class Filter : Window
    {
        public string FullNameSTR;
        public string ShortNameSTR;
        public string RateValue;
        public string CostMinSTR;
        public string CostMaxSTR;
        public string ColorSTR;
        public string CategorySTR;
        public string SizeSTR;

        public Filter(string file)
        {
        InitializeComponent();
        FullNameSTR = "";
        ShortNameSTR = "";
        RateValue = "";
        CostMinSTR = "";
        CostMaxSTR = "";
        ColorSTR = "";
        CategorySTR = "";
        SizeSTR = "";
            ResourceDictionary dict = new ResourceDictionary();
            dict.Source = new Uri(file, UriKind.Relative);
            Resources.MergedDictionaries.Add(dict);
            this.Cursor = Cursors.None;
            StreamResourceInfo sri = Application.GetResourceStream(new Uri("NeonWIB01-Red.ani", UriKind.Relative));
            Cursor customCursor = new Cursor(sri.Stream);
            this.Cursor = customCursor;
        }

        private void RateFilterSLDR_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            RateFilterVL.Content = (int)RateFilterSLDR.Value;
        }

        private void OkFilterButton_Click(object sender, RoutedEventArgs e)
        {
            List<Clothes> filterList = new List<Clothes>();
            List<Clothes> localCopy = new List<Clothes>();
            FullNameSTR = FullNameFilterTB.Text;
            ShortNameSTR = ShortNameFilterTB.Text;
            RateValue = RateFilterSLDR.Value.ToString();
            CostMinSTR = CostMinFilterTB.Text;
            CostMaxSTR = CostMaxFilterTB.Text;
            ColorSTR = ColorFilterCB.Text;
            CategorySTR = CategoryFilterCB.Text;
            SizeSTR = SizeFilterTB.Text;
            foreach (Clothes x in MainWindow.clothes.ClothesList)
            { 
                filterList.Add(x); 
            }
            if (FullNameSTR != "Полное имя товара")
            {
                CopyLocal(localCopy, filterList);
                foreach (Clothes x in localCopy)
                {
                    if (x.FullName == FullNameSTR)
                    {
                        filterList.Add(x);
                    }
                }
            }
            if (ShortNameSTR != "Краткое имя товара")
            {
                CopyLocal(localCopy, filterList);
                foreach (Clothes x in localCopy)
                {
                    if (x.ShortName == ShortNameSTR)
                    {
                        filterList.Add(x);
                    }
                }
            }
            if (RateValue != "0")
            {
                CopyLocal(localCopy, filterList);
                foreach (Clothes x in localCopy)
                {
                    if (x.Rate == (int)double.Parse(RateValue))
                    {
                        filterList.Add(x);
                    }
                }
            }
            if (CostMinSTR != "Нижняя граница" && CostMaxSTR != "Верхняя граница")
            {
                CopyLocal(localCopy, filterList);
                foreach (Clothes x in localCopy)
                {
                    if (x.Cost > (int)double.Parse(CostMinSTR) && x.Cost < (int)double.Parse(CostMaxSTR))
                    {
                        filterList.Add(x);
                    }
                }
            }
            if (ColorSTR != "Цвет")
            {
                CopyLocal(localCopy, filterList);
                foreach (Clothes x in localCopy)
                {
                    if (x.Color == ColorSTR)
                    {
                        filterList.Add(x);
                    }
                }
            }
            if (CategorySTR != "Категория")
            {
                CopyLocal(localCopy, filterList);
                foreach (Clothes x in localCopy)
                {
                    if (x.Category == CategorySTR)
                    {
                        filterList.Add(x);
                    }
                }
            }
            if (SizeSTR != "Размер")
            {
                CopyLocal(localCopy, filterList);
                foreach (Clothes x in localCopy)
                {
                    if (x.Size == SizeSTR)
                    {
                        filterList.Add(x);
                    }
                }
            }
            if (filterList.Count == 0 && localCopy.Count == 0)
            {
                MessageBox.Show("Ни один из товаров не удовлетворяет заданным характеристикам");
            }
            else
            {
                MainWindow.FilteredClothes.Clear();
                foreach (Clothes x in filterList)
                {
                    MainWindow.FilteredClothes.Add(x);
                }
            }
        }

        void CopyLocal(List<Clothes> LC, List<Clothes> FC)
        {
            if (LC.Count > 0)
            {
                LC.Clear();
            }
            foreach (Clothes x in FC)
            {
                LC.Add(x);
            }
            if (FC.Count > 0)
            {
                FC.Clear();
            }
        }

        private void CancelFilterBTTN_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ClearFilterBTTN_Click(object sender, RoutedEventArgs e)
        {
            FillFields();
        }

        private void FillFields()
        {
            FullNameFilterTB.Text = "Полное имя товара";
            ShortNameFilterTB.Text = "Краткое имя товара";
            RateFilterSLDR.Value = 0;
            CostMinFilterTB.Text = "Нижняя граница";
            CostMaxFilterTB.Text = "Верхняя граница";
            ColorFilterCB.Text = "Цвет";
            CategoryFilterCB.Text = "Категория";
            SizeFilterTB.Text = "Размер";
        }

        private void ShortNameFilterTB_LostFocus(object sender, RoutedEventArgs e)
        {
            if(ShortNameFilterTB.Text == "")
            {
                ShortNameFilterTB.Text = "Краткое имя товара";
            }
        }

        private void FullNameFilterTB_LostFocus(object sender, RoutedEventArgs e)
        {
            if (FullNameFilterTB.Text == "")
            {
                FullNameFilterTB.Text = "Полное имя товара";
            }
        }

        private void CostMinFilterTB_LostFocus(object sender, RoutedEventArgs e)
        {
            if (CostMinFilterTB.Text == "")
            {
                CostMinFilterTB.Text = "Нижняя граница";
            }
        }

        private void CostMaxFilterTB_LostFocus(object sender, RoutedEventArgs e)
        {
            if (CostMaxFilterTB.Text == "")
            {
                CostMaxFilterTB.Text = "Верхняя граница";
            }
        }

        private void SizeFilterTB_LostFocus(object sender, RoutedEventArgs e)
        {
            if (SizeFilterTB.Text == "")
            {
                SizeFilterTB.Text = "Размер";
            }
        }

        private void CostMinFilterTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(!Regex.IsMatch(CostMinFilterTB.Text, "^([0-9]|10|^[1-9]+)$") && CostMinFilterTB.Text != "Нижняя граница")
            {
                CostMinFilterTB.Background = Brushes.PaleVioletRed;
            }
            else
            {
                CostMinFilterTB.Background = Brushes.Transparent;
            }
        }

        private void CostMaxFilterTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!Regex.IsMatch(CostMinFilterTB.Text, "^([0-9]|10|^[1-9]+)$") && CostMaxFilterTB.Text != "Верхняя граница")
            {
                CostMaxFilterTB.Background = Brushes.PaleVioletRed;
            }
            else
            {
                CostMaxFilterTB.Background = Brushes.Transparent;
            }
        }

       
    }
}
