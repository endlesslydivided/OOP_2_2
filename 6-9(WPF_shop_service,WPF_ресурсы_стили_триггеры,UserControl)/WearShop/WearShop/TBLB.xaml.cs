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
    /// Логика взаимодействия для TBLB.xaml
    /// </summary>
    public partial class TBLB : UserControl
    {
        public TBLB()
        {
            InitializeComponent();

            
        }


         static TBLB()
        {
            LabelTextProperty =
       DependencyProperty.Register(
           "LabelText",
           typeof(string),
           typeof(TBLB),
           new PropertyMetadata(string.Empty));
            
            LabelFontProperty =
            DependencyProperty.Register(
            "Font",
             typeof(string),
            typeof(TBLB),
            new FrameworkPropertyMetadata(
                               "Calibri",
                               FrameworkPropertyMetadataOptions.AffectsMeasure |
                               FrameworkPropertyMetadataOptions.AffectsRender |
                               FrameworkPropertyMetadataOptions.AffectsArrange,
                               new PropertyChangedCallback(OnFontChanged)
                               ));

            TextProperty =
           DependencyProperty.Register(
                           "Text",
                           typeof(string),
                           typeof(TBLB),
                           new FrameworkPropertyMetadata(
                               "",
                               FrameworkPropertyMetadataOptions.AffectsMeasure |
                               FrameworkPropertyMetadataOptions.AffectsRender |
                               FrameworkPropertyMetadataOptions.AffectsArrange,
                               new PropertyChangedCallback(OnTextChanged),
                               new CoerceValueCallback(TextControl)
                               ),
                           new ValidateValueCallback(TextIsRight));
            TextChangedEvent = EventManager.RegisterRoutedEvent("TextChanged", RoutingStrategy.Bubble,
        typeof(RoutedPropertyChangedEventHandler<string>), typeof(TBLB));
        }
         

        public static readonly DependencyProperty LabelTextProperty;

        public static readonly DependencyProperty LabelFontProperty;

        public static readonly DependencyProperty TextProperty;

        public static readonly RoutedEvent TextChangedEvent;
        public event RoutedPropertyChangedEventHandler<string> TextChanged
        {
            add { this.AddHandler(routedEvent: TextChangedEvent, value); }
            remove { this.RemoveHandler(TextChangedEvent, value); }
        }

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

        public string Font
        {
            get { return (string)GetValue(LabelFontProperty); }
            set { SetValue(LabelFontProperty, value); }
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

        private static void OnTextChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            ((TBLB)sender).LabelText = (string)e.NewValue;
        }

        private static void OnFontChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            ((TBLB)sender).Font = (string)e.NewValue;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}

