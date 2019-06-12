using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IndependentProject.Classes;
using PropertyChanged;
using Windows.UI.Xaml.Controls;

namespace IndependentProject
{
    [ImplementPropertyChanged]
    public class Data : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public long Commits { get; set; }
        public int CommitsClickIncrement { get; set; }
        public int CommitsPerSecond { get; set; }
        public int Specialpoints { get; set; }
        public long AllTimeCommits { get; set; }
        public int Clicks { get; set; }
        public double MusicVolume { get; set; } = 0.5;
        public double SoundVolume { get; set; } = 0.5;
        public int AchievementsUnlocked { get; set; }
        public long Seconds { get; set; }

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
        public void SetTotalCPS()
        {
            CommitsPerSecond = 0;
            foreach(Helper h in Helpers)
            {
                CommitsPerSecond += h.CPS;
            }
        }
        public string TimePlayed()
        {
            return new TimeSpan(Seconds).ToString();
        }
        public string AchievementsPercentage()
        {
            double d = (double)AchievementsUnlocked / Achievements.Count();
            return AchievementsUnlocked + "/" + Achievements.Count + " (" + (int) (d * 100) + "%)";
        }
        public string UpgradesPercentage()
        {
            double d = (double)PastUpgrades.Count / (Upgrades.Count + PastUpgrades.Count);
            return PastUpgrades.Count + "/" + (Upgrades.Count + PastUpgrades.Count) + " (" + (int) (d*100) + "%)";
        }
        private void AddHelpers()
        {
            Helpers.Add(new Helper("Auto Clicker", "Takes some clicks off your fingers", 1, 10, 1, 1));
            Helpers.Add(new Helper("Monkeys", "Train monkeys to click for you!", 15, 800, 100, 50));
            Helpers.Add(new Helper("Ethernet", "Connects your device through ethernet to speed up commits", 500, 50000, 12000, 10000));
            Helpers.Add(new Helper("Office Building", "Concentrates monkeys into buildings instead of being spread out", 13000, 25000000, 600000, 40000));
            Helpers.Add(new Helper("Satellites", "Take control of innocent people's devices for comitting purposes", 900000, 1000000000, 5000000, 20000));
        }
        private void AddUpgrades()
        {
            Upgrades.Add(new Upgrade("/Assets/mouse.png", 50, 0.1, "Faster Clicks", "Increases Auto Clicker CPS by 10%", Helpers.ElementAt(0)));
            Upgrades.Add(new Upgrade("/Assets/mouse.png", 200, 0.25, "Even Faster Clicks", "Increases Auto Clicker CPS by 25%", Helpers.ElementAt(0)));
            Upgrades.Add(new Upgrade("/Assets/mouse.png", 800, 0.5, "Super Fast Clicks", "Increases Auto Clicker CPS by 50%", Helpers.ElementAt(0)));
            Upgrades.Add(new Upgrade("/Assets/mouse.png", 1500, 1.0, "Lightning Fast Clicks", "Increases Auto Clicker CPS by 100%", Helpers.ElementAt(0)));

            Upgrades.Add(new Upgrade("/Assets/monkey.jpg", 3000, 0.1, "Monkey See, Monkey Do", "Increases Monkey CPS by 10%", Helpers.ElementAt(1)));
            Upgrades.Add(new Upgrade("/Assets/monkey.jpg", 10000, 0.25, "Nutritious Food", "Increases Monkey CPS by 25%", Helpers.ElementAt(1)));
            Upgrades.Add(new Upgrade("/Assets/monkey.jpg", 50000, 0.5, "Acrobat Training", "Increases Monkey CPS by 50%", Helpers.ElementAt(1)));
            Upgrades.Add(new Upgrade("/Assets/monkey.jpg", 75000, 1.0, "Genetic Modification", "Increases Monkey CPS by 100%", Helpers.ElementAt(1)));

            Upgrades.Add(new Upgrade("/Assets/cable.png", 1000000, 0.1, "Better Installation", "Increases Ethernet CPS by 10%", Helpers.ElementAt(2)));
            Upgrades.Add(new Upgrade("/Assets/cable.png", 7000000, 0.25, "More Connected Devices", "Increases Ethernet CPS by 25%", Helpers.ElementAt(2)));
            Upgrades.Add(new Upgrade("/Assets/cable.png", 25000000, 0.5, "Server Control", "Increases Ethernet CPS by 50%", Helpers.ElementAt(2)));
            Upgrades.Add(new Upgrade("/Assets/cable.png", 60000000, 1.0, "Market Monopoly", "Increases Ethernet CPS by 100%", Helpers.ElementAt(2)));

            Upgrades.Add(new Upgrade("/Assets/office.jpg", 200000000, 0.1, "Clean Bathrooms", "Increases Office Building CPS by 10%", Helpers.ElementAt(3)));
            Upgrades.Add(new Upgrade("/Assets/office.jpg", 800000000, 0.25, "Air Conditioning", "Increases Office Building CPS by 25%", Helpers.ElementAt(3)));
            Upgrades.Add(new Upgrade("/Assets/office.jpg", 1000000000, 0.5, "Basement Expansion", "Increases Office Building CPS by 50%", Helpers.ElementAt(3)));
            Upgrades.Add(new Upgrade("/Assets/office.jpg", 9000000000, 1.0, "Skyscrapers", "Increases Office Building CPS by 100%", Helpers.ElementAt(3)));

            Upgrades.Add(new Upgrade("/Assets/satellite.jpg", 8000000000, 0.1, "Cheaper Materials", "Increases Satellite CPS by 10%", Helpers.ElementAt(4)));
            Upgrades.Add(new Upgrade("/Assets/satellite.jpg", 15000000000, 0.25, "Improved Solar Panels", "Increases Satellite CPS by 25%", Helpers.ElementAt(4)));
            Upgrades.Add(new Upgrade("/Assets/satellite.jpg", 60000000000, 0.5, "Space Tech Revolution", "Increases Satellite CPS by 50%", Helpers.ElementAt(4)));
            Upgrades.Add(new Upgrade("/Assets/satellite.jpg", 100000000000, 1.0, "Intergalactic Dyson Spheres", "Increases Satellite CPS by 100%", Helpers.ElementAt(4)));
        }

        private void AddAchievements()
        {
            Achievements.Add(new Achievement("Commit Discovery", 5, 1, "Earn 1 commit all time", "/Assets/commitgraph.png", 0, this, null));
            Achievements.Add(new Achievement("Commit Gatherer", 10, 100, "Earn 100 commits all time", "/Assets/commitgraph.png", 0, this, null));
            Achievements.Add(new Achievement("Commit Collector", 30, 10000, "Earn 10,000 commits all time", "/Assets/commitgraph.png", 0, this, null));
            Achievements.Add(new Achievement("Commit Hoarder", 50, 1000000, "Earn 1M commits all time", "/Assets/commitgraph.png", 0, this, null));
            Achievements.Add(new Achievement("Commit Connisseur", 100, 100000000, "Earn 100M commits all time", "/Assets/commitgraph.png", 0, this, null));
            Achievements.Add(new Achievement("Commit Investigator", 200, 10000000000, "Earn 10B commits all time", "/Assets/commitgraph.png", 0, this, null));
            Achievements.Add(new Achievement("Commit Researcher", 400, 1000000000000, "Earn 1T commits all time", "/Assets/commitgraph.png", 0, this, null));

            Achievements.Add(new Achievement("Quick Committer", 5, 10, "Reach 10 CPS", "/Assets/upload.png", 2, this, null));
            Achievements.Add(new Achievement("Swift Committer", 10, 100, "Reach 100 CPS", "/Assets/upload.png", 2, this, null));
            Achievements.Add(new Achievement("Rapid Committer", 30, 1000, "Reach 1,000 CPS", "/Assets/upload.png", 2, this, null));
            Achievements.Add(new Achievement("Hyper Committer", 50, 10000, "Reach 10,000 CPS", "/Assets/upload.png", 2, this, null));
            Achievements.Add(new Achievement("Crazy Committer", 70, 100000, "Reach 100,000 CPS", "/Assets/upload.png", 2, this, null));
            Achievements.Add(new Achievement("Insane Committer", 100, 1000000, "Reach 1M CPS", "/Assets/upload.png", 2, this, null));
            Achievements.Add(new Achievement("Surpersonic Committer", 200, 10000000, "Reach 10M CPS", "/Assets/upload.png", 2, this, null));
            Achievements.Add(new Achievement("Lightspeed Committer", 400, 100000000, "Reach 100M CPS", "/Assets/upload.png", 2, this, null));

            Achievements.Add(new Achievement("Auto Clicker Beginner", 5, 1, "Reach Auto Clicker Level 1", "/Assets/mouse.png", 1, this, Helpers.ElementAt(0)));
            Achievements.Add(new Achievement("Auto Clicker Novice", 10, 10, "Reach Auto Clicker Level 10", "/Assets/mouse.png", 1, this, Helpers.ElementAt(0)));
            Achievements.Add(new Achievement("Auto Clicker Trainee", 20, 25, "Reach Auto Clicker Level 25", "/Assets/mouse.png", 1, this, Helpers.ElementAt(0)));
            Achievements.Add(new Achievement("Auto Clicker Master", 50, 100, "Reach Auto Clicker Level 100", "/Assets/mouse.png", 1, this, Helpers.ElementAt(0)));
            Achievements.Add(new Achievement("Auto Clicker Legend", 100, 500, "Reach Auto Clicker Level 500", "/Assets/mouse.png", 1, this, Helpers.ElementAt(0)));
            Achievements.Add(new Achievement("Auto Clicker God", 200, 1000, "Reach Auto Clicker Level 1000", "/Assets/mouse.png", 1, this, Helpers.ElementAt(0)));

            Achievements.Add(new Achievement("Monkey Beginner", 5, 1, "Reach Monkey Level 1", "/Assets/monkey.jpg", 1, this, Helpers.ElementAt(1)));
            Achievements.Add(new Achievement("Monkey Novice", 10, 10, "Reach Monkey Level 10", "/Assets/monkey.jpg", 1, this, Helpers.ElementAt(1)));
            Achievements.Add(new Achievement("Monkey Trainee", 20, 25, "Reach Monkey Level 25", "/Assets/monkey.jpg", 1, this, Helpers.ElementAt(1)));
            Achievements.Add(new Achievement("Monkey Master", 50, 100, "Reach Monkey Level 100", "/Assets/monkey.jpg", 1, this, Helpers.ElementAt(1)));
            Achievements.Add(new Achievement("Monkey Legend", 100, 500, "Reach Monkey Level 500", "/Assets/monkey.jpg", 1, this, Helpers.ElementAt(1)));
            Achievements.Add(new Achievement("Monkey God", 200, 1000, "Reach Monkey Level 1000", "/Assets/monkey.jpg", 1, this, Helpers.ElementAt(1)));

            Achievements.Add(new Achievement("Ethernet Beginner", 5, 1, "Reach Ethernet Level 1", "/Assets/cable.png", 1, this, Helpers.ElementAt(2)));
            Achievements.Add(new Achievement("Ethernet Novice", 10, 10, "Reach Ethernet Level 10", "/Assets/cable.png", 1, this, Helpers.ElementAt(2)));
            Achievements.Add(new Achievement("Ethernet Trainee", 20, 25, "Reach Ethernet Level 25", "/Assets/cable.png", 1, this, Helpers.ElementAt(2)));
            Achievements.Add(new Achievement("Ethernet Master", 50, 100, "Reach Ethernet Level 100", "/Assets/cable.png", 1, this, Helpers.ElementAt(2)));
            Achievements.Add(new Achievement("Ethernet Legend", 100, 500, "Reach Ethernet Level 500", "/Assets/cable.png", 1, this, Helpers.ElementAt(2)));
            Achievements.Add(new Achievement("Ethernet God", 200, 1000, "Reach Ethernet Level 1000", "/Assets/cable.png", 1, this, Helpers.ElementAt(2)));

            Achievements.Add(new Achievement("Office Building Beginner", 10, 1, "Reach Office Building Level 1", "/Assets/office.jpg", 1, this, Helpers.ElementAt(3)));
            Achievements.Add(new Achievement("Office Building Novice", 20, 10, "Reach Office Building Level 10", "/Assets/office.jpg", 1, this, Helpers.ElementAt(3)));
            Achievements.Add(new Achievement("Office Building Trainee", 50, 25, "Reach Office Building Level 25", "/Assets/office.jpg", 1, this, Helpers.ElementAt(3)));
            Achievements.Add(new Achievement("Office Building Master", 70, 100, "Reach Office Building Level 100", "/Assets/office.jpg", 1, this, Helpers.ElementAt(3)));
            Achievements.Add(new Achievement("Office Building Legend", 120, 500, "Reach Office Building Level 500", "/Assets/office.jpg", 1, this, Helpers.ElementAt(3)));
            Achievements.Add(new Achievement("Office Building God", 280, 1000, "Reach Office Building Level 1000", "/Assets/office.jpg", 1, this, Helpers.ElementAt(3)));

            Achievements.Add(new Achievement("Satellite Beginner", 20, 1, "Reach Satellite Level 1", "/Assets/satellite.jpg", 1, this, Helpers.ElementAt(4)));
            Achievements.Add(new Achievement("Satellite Novice", 50, 10, "Reach Satellite Level 10", "/Assets/satellite.jpg", 1, this, Helpers.ElementAt(4)));
            Achievements.Add(new Achievement("Satellite Trainee", 80, 25, "Reach Satellite Level 25", "/Assets/satellite.jpg", 1, this, Helpers.ElementAt(4)));
            Achievements.Add(new Achievement("Satellite Master", 150, 100, "Reach Satellite Level 100", "/Assets/satellite.jpg", 1, this, Helpers.ElementAt(4)));
            Achievements.Add(new Achievement("Satellite Legend", 200, 500, "Reach Satellite Level 500", "/Assets/satellite.jpg", 1, this, Helpers.ElementAt(4)));
            Achievements.Add(new Achievement("Satellite God", 400, 1000, "Reach Satellite Level 1000", "/Assets/satellite.jpg", 1, this, Helpers.ElementAt(4)));
        }

        private void AddSpecials()
        {
            Specials.Add(new Special("Better Bargaining Skills", "Reduces helper hire & level-up cost", "/Assets/bargaining.jpg",200));
            Specials.Add(new Special("Cheaper Upgrades", "Reduces upgrades cost", "/Assets/money.jpg", 200));
            Specials.Add(new Special("Time Hacking", "Increases CPS of all Helpers", "/Assets/clocks.jpg", 200));
        }
    }
}
