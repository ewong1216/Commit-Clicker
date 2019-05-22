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

        public double CPS { get; set; }
        public int Level { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}