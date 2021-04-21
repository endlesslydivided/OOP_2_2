using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace WearShop
{
    public partial class BlockButton : FrameworkElement
    {
        public static readonly DependencyProperty TextProperty;
        public static  readonly DependencyProperty BackgroundProperty;
        public static  readonly DependencyProperty ForegroundProperty;

        public BlockButton()
        {
            Text = "Button";
            Background = "Transparent";
            Foreground = "Transparent";
        }

        static BlockButton()
        {
            TextProperty = DependencyProperty.Register(
                            "Text",
                            typeof(string),
                            typeof(BlockButton),
                            new FrameworkPropertyMetadata(
                                string.Empty,
                                FrameworkPropertyMetadataOptions.AffectsMeasure |
                                FrameworkPropertyMetadataOptions.AffectsRender,
                                new PropertyChangedCallback(OnTextChanged),
                                new CoerceValueCallback(TextControl)
                                ),
                            new ValidateValueCallback(TextIsRight));
            BackgroundProperty = DependencyProperty.Register(
                            "Background",
                            typeof(string),
                            typeof(BlockButton),
                            new FrameworkPropertyMetadata(
                                Color.FromRgb(0, 0, 0),
                                FrameworkPropertyMetadataOptions.AffectsMeasure |
                                FrameworkPropertyMetadataOptions.AffectsRender
                                ));
            ForegroundProperty = DependencyProperty.Register(
                            "Foreground",
                            typeof(string),
                            typeof(BlockButton),
                            new FrameworkPropertyMetadata(
                                Color.FromRgb(255, 255, 255),
                                FrameworkPropertyMetadataOptions.AffectsMeasure |
                                FrameworkPropertyMetadataOptions.AffectsRender
                                ));
        }

        private static void OnTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

        }

        

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        public  string Background
        {
            get { return (string)GetValue(BackgroundProperty); }
            set { SetValue(BackgroundProperty, value); }
        }
        public  string Foreground
        {
            get { return (string)GetValue(ForegroundProperty); }
            set { SetValue(ForegroundProperty, value); }
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
    }
}
