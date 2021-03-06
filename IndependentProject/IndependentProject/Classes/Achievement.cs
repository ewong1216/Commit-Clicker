﻿using System;
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
        public long Requirement { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string DisplayImage { get; set; } = "/Assets/questionmark.png";
        public string UnlockedImage { get; set; }
        public int Type { get; set; } //Type: 0=AllTimeCommit achievement, 1=HelperLevelAchievement, 2=CPS achievement
        public Data Data { get; set; }
        public Helper Helper { get; set; }

        public Achievement(string name, int sp, long requirement, string description, string image, int type, Data data, Helper helper)
        {
            Name = name;
            SP = sp;
            Requirement = requirement;
            Description = description;
            UnlockedImage = image;
            Type = type;
            Data = data;
            Helper = helper;
        }

        public bool Update()
        {
            if(Type == 0 && Data.AllTimeCommits >= Requirement)
            {
                Achieve();
                return true;
            }
            else if(Type == 1 && Helper.Level >= Requirement)
            {
                Achieve();
                return true;
            }
            else if(Type == 2 && Data.CommitsPerSecond >= Requirement)
            {
                Achieve();
                return true;
            }
            return false;
        }

        private void Achieve()
        {
            Unlocked = true;
            DisplayImage = UnlockedImage;
            Data.Specialpoints += SP;
        }
        public override string ToString()
        {            
            if (Unlocked)
            {
                return Name + "\n" + Description + "\nReward: " + SP + " SP";
            }
            return "???";
        }
    }
}
