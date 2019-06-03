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
    public class Achievement : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public int SP { get; set; }
        public bool Unlocked { get; set; } = false;
        public int Requirement { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        public Achievement(string name, int sp, int requirement, string description, string image)
        {
            Name = name;
            SP = sp;
            Requirement = requirement;
            Description = description;
            Image = image;
        }

        public override string ToString()
        {
            string s = Name + "\n" + Description;

            if (Unlocked)
            {
                s += "\nReward: " + SP + " SP";
            }

            return s;
        }
    }
}
