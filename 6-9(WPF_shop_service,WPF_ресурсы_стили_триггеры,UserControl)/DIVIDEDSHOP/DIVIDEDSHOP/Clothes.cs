using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DIVIDEDSHOP
{
    public class Clothes
    {
        public string shortName;
        public string fullName;
        public string description;
        public string imageAdress;
        public string category;
        public int rate;
        public int cost;
        public string color;
        public string size;

        public Clothes(string shortName,string fullName, string description, string imageAdress, string category,int rate, int cost, string color, string size)
        {
            this.shortName = shortName;
            this.fullName = fullName;
            this.description = description;
            this.imageAdress = imageAdress;
            this.category = category;
            this.rate = rate;
            this.cost = cost;
            this.color = color;
            this.size = size;
        }

        public Clothes()
        {
            this.shortName = "Краткое название";
            this.fullName = "Полное название";
            this.description = "Описание";
            this.imageAdress = "";
            this.category = "Одежда";
            this.rate = 0;
            this.cost = 0;
            this.color = "Чёрный";
            this.size = "0";
        }
        public string ShortName
        {
            get { return shortName; }
            set
            {
                shortName = value;
                OnPropertyChanged("ShortName");
            }
        }
        public string FullName
        {
            get { return fullName; }
            set
            {
                fullName = value;
                OnPropertyChanged("FullName");
            }
        }
        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                OnPropertyChanged("Description");
            }
        }
        public string ImageAdress
        {
            get { return imageAdress; }
            set
            {
                imageAdress = value;
                OnPropertyChanged("ImageAdress");
            }
        }
        public string Category
        {
            get { return category; }
            set
            {
                category = value;
                OnPropertyChanged("Category");
            }
        }
        public int Rate
        {
            get { return rate; }
            set
            {
                rate = value;
                OnPropertyChanged("Rate");
            }
        }
        public int Cost
        {
            get { return cost; }
            set
            {
                cost = value;
                OnPropertyChanged("Cost");
            }
        }
        public string Color
        {
            get { return color; }
            set
            {
                color = value;
                OnPropertyChanged("Color");
            }
        }
        public string Size
        {
            get { return size; }
            set
            {
                size = value;
                OnPropertyChanged("Size");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }

    public class ApplicationViewModel : INotifyPropertyChanged
    {
        private Clothes selectedClothes;

        public ObservableCollection<Clothes> clothes { get; set; }
        public Clothes SelectedClothes
        {
            get { return selectedClothes; }
            set
            {
                selectedClothes = value;
                OnPropertyChanged("SelectedPhone");
            }
        }

        public ApplicationViewModel()
        {
            clothes = new ObservableCollection<Clothes>
            {
                new Clothes("Джемпер чёрный","Джемпер чёрный мужской тёплый","Данный чёрный шерстяной джемпер согреет вас зимними вечерами.Качественные материалы были использованы при изготавлении данной модели.",
                "D:/ALEX/STUDY/4SEM_2COURSE/ООТП/Лабораторные работы/6-7(WPF_shop_service)/DIVIDEDSHOP/DIVIDEDSHOP/Pictures/джемпер.jfif","Одежда",5,50,"Чёрный","35")
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
