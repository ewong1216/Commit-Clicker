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
    public class Helper : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public int CPS { get; set; } = 0;
        public int BaseCPS { get; set; }
        public int NextCPS { get; set; }
        public int Level { get; set; } = 0;
        public string Name { get; set; }
        public string Description { get; set; }
        public int Cost { get; set; }
        public int BaseCost { get; set; }
        public int ScalingCost { get; set; }
        public double Multiplier { get; set; } = 1.0;

        public void SetCost()
        {
            Cost = BaseCost + Level * (ScalingCost + (Level - 1));
        }
        public void SetMultiplier()
        {
            CPS = (int)(Level * BaseCPS * Multiplier);
            NextCPS = (int)((Level+1) * BaseCPS * Multiplier);
        }
        public void LevelUp()
        {
            Level++;
            SetMultiplier();
            SetCost();
        }
        public Helper(string name, string description, int baseCPS, int baseCost, int scalingCost)
        {
            Name = name;
            Description = description;
            BaseCPS = baseCPS;
            BaseCost = baseCost;
            ScalingCost = scalingCost;
            NextCPS = BaseCPS;
            SetCost();
        }
    }
}