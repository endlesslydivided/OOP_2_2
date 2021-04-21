using DIVIDEDSHOP;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WearShop
{
    public class MementoWearList
    {
        public ObservableCollection<Clothes> ClothesList = new ObservableCollection<Clothes>();
        public MementoWearList(ObservableCollection<Clothes> state)
        {
            if (state != null)
            {
                foreach (Clothes x in state)
                {
                    this.ClothesList.Add(x);
                }
            }
            else if (state == null)
                this.ClothesList.Clear();
        }
    }

    public class CaretakerWearList
    {
        public Stack<MementoWearList> History { get; private set; }
        public CaretakerWearList()
        {
            History = new Stack<MementoWearList>();
        }
    }

    public class ClothesCollection
    {
        public ObservableCollection<Clothes> ClothesList { get; set; }
        public void RestoreState(MementoWearList memento)
        {
            ClothesList = memento.ClothesList;
        }
        public MementoWearList SaveState()
        {
            return new MementoWearList(ClothesList);
        }
    }
}
