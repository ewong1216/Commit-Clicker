using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyChanged;

namespace IndependentProject.Classes
{
    [ImplementPropertyChanged]
    public class Upgrade : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string Image { get; set; }
        public long Cost { get; set; }
        public double Multiplier { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Helper Helper { get; set; }

        public Upgrade(string image, long cost, double multiplier, string name, string description, Helper helper)
        {
            Image = image;
            Cost = cost;
            Multiplier = multiplier;
            Name = name;
            Description = description;
            Helper = helper;
        }

        public override string ToString()
        {
            string s = Name + "\n" + Description + "\nCost: " + Cost;
            return s;
        }
    }
}
