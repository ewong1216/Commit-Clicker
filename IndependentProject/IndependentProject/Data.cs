using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndependentProject
{

    public class Data : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public int commits;
        public int commitsIncrement;
        public int commitsPerSecond;
        public int specialpoints;
    }
}
