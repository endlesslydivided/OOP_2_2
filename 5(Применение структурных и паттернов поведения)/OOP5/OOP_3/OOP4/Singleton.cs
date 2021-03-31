using OOP_2;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_3.OOP4
{
    class SingletonForm1
    {
        private static SingletonForm1 form1Information;

        public Color BackgroundColor { get; private set ; } 
        public Font WindowFont { get; private set; } 
        public Size WindowSize { get; private set; } 

        protected SingletonForm1(Color color, Font font, Size size)
        {
        this.BackgroundColor = color;
        this.WindowFont = font;
        this.WindowSize = size;
        }

        public static SingletonForm1 getInstance(Color color,Font font, Size size)
        {
            if (form1Information == null)
                form1Information = new SingletonForm1(color, font, size);
            return form1Information;
        }

        public override string ToString()
        {
            return "Цвет фона: " + this.BackgroundColor.Name + "\nШрифт: " + this.WindowFont.Name + "\nРазмер окна: " + this.WindowSize.Width + "x"+ this.WindowSize.Height;
        }
    }
}
