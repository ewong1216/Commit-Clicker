using System;
using System.Collections.Generic;
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
        public int CommitsIncrement { get; set; }
        public int CommitsPerSecond { get; set; }
        public int Specialpoints { get; set; }

        public List<Helper> Helpers { get; set; } = new List<Helper>();

        public Data()
        {
            Helpers.Add(new Helper { Name = "AutoClicker", Description = "Takes some clicks off your fingers", CPS = .1, Level = 0 });
            Helpers.Add(new Helper { Name = "Monkeys", Description = "Train monkeys to click for you!", CPS = 3, Level = 0});
            Helpers.Add(new Helper { Name = "Ethernet", Description = "Connects your device through ethernet to speed up commits", CPS = 10, Level = 0 });
        }
    }
}
