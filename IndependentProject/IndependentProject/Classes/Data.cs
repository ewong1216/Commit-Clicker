using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IndependentProject.Classes;
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
        public ObservableCollection<Upgrade> Upgrades = new ObservableCollection<Upgrade>();
        public ObservableCollection<Upgrade> PastUpgrades = new ObservableCollection<Upgrade>();

        public Data()
        {
            AddHelpers();
            AddUpgrades();
        }
        private void AddHelpers()
        {
            Helpers.Add(new Helper("AutoClicker", "Takes some clicks off your fingers", 1, 10, 1));
            Helpers.Add(new Helper("Monkeys", "Train monkeys to click for you!", 3, 100, 10));
            Helpers.Add(new Helper("Ethernet", "Connects your device through ethernet to speed up commits", 10, 500, 30));
        }
        private void AddUpgrades()
        {
            Upgrades.Add(new Upgrade("/Assets/mouse.png", 100, 0.1, "Faster Clicks", "Increases Auto Clicker CPS by 10%", Helpers.ElementAt(0)));
            Upgrades.Add(new Upgrade("/Assets/mouse.png", 300, 0.25, "Even Faster Clicks", "Increases Auto Clicker CPS by 25%", Helpers.ElementAt(0)));
            Upgrades.Add(new Upgrade("/Assets/mouse.png", 1000, 0.5, "Super Fast Clicks", "Increases Auto Clicker CPS by 50%", Helpers.ElementAt(0)));
            Upgrades.Add(new Upgrade("/Assets/mouse.png", 5000, 1.0, "Lightning Fast Clicks", "Increases Auto Clicker CPS by 100%", Helpers.ElementAt(0)));
        }
    }
}
