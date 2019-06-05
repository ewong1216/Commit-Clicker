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

        public int Cost { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        public Special()
        {

        }


    }
}
