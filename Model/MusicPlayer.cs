using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace training.Model
{
    class MusicPlayerModel
    {
    }
    public class MusicPlay : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string name;
        private string song;
        private string duration;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (name != value)
                {
                    name = value;
                    RaisePropertyChanged("Name");
                }
            }
        }
        public string Song
        {
            get
            {
                return song;
            }
            set
            {
                if (song != value)
                {
                    song = value;
                    RaisePropertyChanged("Song");
                }
            }
        }

        public string Duration
        {
            get
            {
                return duration;
            }
            set
            {
                if (duration != value)
                {
                    duration = value;
                    RaisePropertyChanged("Duration");
                }
            }
        }
        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

    }
}

