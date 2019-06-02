using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyChanged;

namespace IndependentProject
{
    [ImplementPropertyChanged]
    public class Data : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public int Commits { get; set; }
        public int CommitsClickIncrement { get; set; }
        public int CommitsPerSecond { get; set; }
        public int Specialpoints { get; set; }

        public ObservableCollection<Helper> Helpers { get; set; } = new ObservableCollection<Helper>();

        public Data()
        {
            Helpers.Add(new Helper("AutoClicker","Takes some clicks off your fingers",1,10,1));
            Helpers.Add(new Helper("Monkeys","Train monkeys to click for you!",3,100,10));
            Helpers.Add(new Helper("Ethernet","Connects your device through ethernet to speed up commits",10,500,30));
        }
    }
}
