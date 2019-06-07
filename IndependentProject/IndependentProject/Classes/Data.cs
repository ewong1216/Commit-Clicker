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
        public int Specialpoints { get; set; } = 99999;
        public int AllTimeCommits { get; set; } = 0;

        public ObservableCollection<Helper> Helpers { get; set; } = new ObservableCollection<Helper>();
        public ObservableCollection<Upgrade> Upgrades = new ObservableCollection<Upgrade>();
        public ObservableCollection<Upgrade> PastUpgrades = new ObservableCollection<Upgrade>();
        public ObservableCollection<Achievement> Achievements = new ObservableCollection<Achievement>();
        public ObservableCollection<Special> Specials { get; set; } = new ObservableCollection<Special>();
        
        public Data()
        {
            AddHelpers();
            AddUpgrades();
            AddAchievements();
            AddSpecials();
        }
        public void CheckAchievements()
        {
            foreach(Achievement a in Achievements)
            {
                if (!a.Unlocked)
                {
                    a.Update();
                }
            }
        }
        private void AddHelpers()
        {
            Helpers.Add(new Helper("AutoClicker", "Takes some clicks off your fingers", 1, 10, 1));
            Helpers.Add(new Helper("Monkeys", "Train monkeys to click for you!", 15, 100, 10));
            Helpers.Add(new Helper("Ethernet", "Connects your device through ethernet to speed up commits", 100, 500, 30));
        }
        private void AddUpgrades()
        {
            Upgrades.Add(new Upgrade("/Assets/mouse.png", 100, 0.1, "Faster Clicks", "Increases Auto Clicker CPS by 10%", Helpers.ElementAt(0)));
            Upgrades.Add(new Upgrade("/Assets/mouse.png", 300, 0.25, "Even Faster Clicks", "Increases Auto Clicker CPS by 25%", Helpers.ElementAt(0)));
            Upgrades.Add(new Upgrade("/Assets/mouse.png", 1000, 0.5, "Super Fast Clicks", "Increases Auto Clicker CPS by 50%", Helpers.ElementAt(0)));
            Upgrades.Add(new Upgrade("/Assets/mouse.png", 5000, 1.0, "Lightning Fast Clicks", "Increases Auto Clicker CPS by 100%", Helpers.ElementAt(0)));
        }

        private void AddAchievements()
        {
            Achievements.Add(new Achievement("Commit Beginner",10, 1, "Earn 1 commit all time","/Assets/mouse.png",0,this,null));
            Achievements.Add(new Achievement("Commit Novice",50, 50, "Earn 50 commits all time","/Assets/mouse.png",0,this,null));
            Achievements.Add(new Achievement("AutoClicker Beginner", 10, 1, "Reach AutoClicker Level 1", "/Assets/mouse.png", 1, this, Helpers.ElementAt(0)));
        }

        private void AddSpecials()
        {
            Specials.Add(new Special("Better Bargaining", "Reduces helper hire & level-up cost", "/Assets/mouse.png",100));
            Specials.Add(new Special("Cheaper Upgrades", "Reduces upgrades cost", "/Assets/mouse.png", 150));
        }
    }
}
