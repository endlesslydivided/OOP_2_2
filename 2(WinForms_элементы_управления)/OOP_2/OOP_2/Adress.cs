using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_2
{
    public class Adress
    {
        public Adress(string city, string index, string street, int house, int apartment)
        {
            this.city = city;
            this.index = index;
            this.street = street;
            this.house = house;
            this.apartment = apartment;
        }
        public Adress()
        {
            this.city = "";
            this.index = "";
            this.street = "";
            this.house = 0;
            this.apartment = 0;
        }
        public string city;
        public string index;
        public string street;
        public int house;
        public int apartment;
        public override string ToString()
        {
            return ($"Город:{city}\n Индекс:{index}\n Улица:{street}\n Дом:{house}\n Квартира:{apartment}");
        }

    }
}
