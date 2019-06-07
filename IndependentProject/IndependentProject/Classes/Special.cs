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
    public class Special : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string Description { get; set; }
        public string Image { get; set; }
        public double Multiplier { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }

        public Special(string name, string description, string image, int cost)
        {
            Name = name;
            Description = description;
            Image = image;
            Cost = cost;
            Multiplier = 1.0;
        }
        public void Purchase()
        {
            Multiplier += 0.05;
            Cost += 10;
        }
        public override string ToString()
        {
            string s = Name + "\n" + Description + "\nCost: " + Cost + "SP" + "\nCurrent Multiplier: " + Multiplier*100 + "%";
            return s;
        }
    }
}
