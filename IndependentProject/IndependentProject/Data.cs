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
        public int commits { get; set; }
        public int commitsIncrement { get; set; }
        public int commitsPerSecond { get; set; }
        public int specialpoints { get; set; }
    }
}
