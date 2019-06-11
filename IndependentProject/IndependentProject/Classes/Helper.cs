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
        public int IncrementCost { get; set; }
        public int ScalingCost { get; set; }
        public double UpgradesMultiplier { get; set; } = 1.0;

        public void SetCost(double costMultiplier)
        {
            Cost = (int) ((BaseCost + Level * IncrementCost + Level * Level * ScalingCost) * costMultiplier);
        }
        public void SetCPS(double specialCPSMultiplier)
        {
            CPS = (int)(Level * BaseCPS * UpgradesMultiplier * specialCPSMultiplier);
            NextCPS = (int)((Level+1) * BaseCPS * UpgradesMultiplier * specialCPSMultiplier);
        }
        public void LevelUp(double costMultiplier, double specialCPSMultiplier)
        {
            Level++;
            SetCPS(specialCPSMultiplier);
            SetCost(costMultiplier);
        }

        public Helper(string name, string description, int baseCPS, int baseCost, int incrementCost, int scalingCost)
        {
            Name = name;
            Description = description;
            BaseCPS = baseCPS;
            BaseCost = baseCost;
            IncrementCost = incrementCost;
            ScalingCost = scalingCost;
            NextCPS = BaseCPS;
            SetCost(1.0);
        }
    }
}