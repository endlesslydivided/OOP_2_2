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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WearShop
{
    /// <summary>
    /// Выполните шаги 1a или 1b, а затем 2, чтобы использовать этот пользовательский элемент управления в файле XAML.
    ///
    /// Шаг 1a. Использование пользовательского элемента управления в файле XAML, существующем в текущем проекте.
    /// Добавьте атрибут XmlNamespace в корневой элемент файла разметки, где он 
    /// будет использоваться:
    ///
    ///     xmlns:MyNamespace="clr-namespace:WearShop"
    ///
    ///
    /// Шаг 1б. Использование пользовательского элемента управления в файле XAML, существующем в другом проекте.
    /// Добавьте атрибут XmlNamespace в корневой элемент файла разметки, где он 
    /// будет использоваться:
    ///
    ///     xmlns:MyNamespace="clr-namespace:WearShop;assembly=WearShop"
    ///
    /// Потребуется также добавить ссылку из проекта, в котором находится файл XAML,
    /// на данный проект и пересобрать во избежание ошибок компиляции:
    ///
    ///     Щелкните правой кнопкой мыши нужный проект в обозревателе решений и выберите
    ///     "Добавить ссылку"->"Проекты"->[Поиск и выбор проекта]
    ///
    ///
    /// Шаг 2)
    /// Теперь можно использовать элемент управления в файле XAML.
    ///
    ///     <MyNamespace:CustomControl1/>
    ///
    /// </summary>
    public class TBLabel : Control
    {
        static TBLabel()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TBLabel), new FrameworkPropertyMetadata(typeof(TBLabel)));
        }

        public static readonly DependencyProperty LabelTextProperty =
          DependencyProperty.Register(
              "LabelText",
              typeof(string),
              typeof(LabelTextBox),
              new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty TextProperty =
           DependencyProperty.Register(
                           "Text",
                           typeof(string),
                           typeof(LabelTextBox),
                           new FrameworkPropertyMetadata(
                               "",
                               FrameworkPropertyMetadataOptions.AffectsMeasure |
                               FrameworkPropertyMetadataOptions.AffectsRender |
                               FrameworkPropertyMetadataOptions.AffectsArrange,
                               new PropertyChangedCallback(OnTextChanged),
                               new CoerceValueCallback(TextControl)
                               ),
                           new ValidateValueCallback(TextIsRight));



        public string LabelText
        {
            get
            {
                return (string)GetValue(LabelTextProperty);
            }
            set
            {
                SetValue(LabelTextProperty, value);
            }
        }


        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        private static object TextControl(DependencyObject d, object value)
        {
            if (((string)value).Length > 255)
            {
                return ((string)value).Substring(0, 255);
            }
            else return (string)value;
        }

        private static bool TextIsRight(object value)
        {
            if (Regex.IsMatch((string)value, "([0-9]*[A-Z]*[a-z]*)*"))
            {
                return true;
            }
            return false;
        }

        private static void OnTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

        }
    }
}
