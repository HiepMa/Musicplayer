using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using training.Model;
using training.Util;
using Windows.Storage;
using Windows.UI.Popups;

namespace training.ViewModel
{
    class MusicPlayViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string _Song_Url;

        public string Song
        {
            get
            {
                return _Song_Url;
            }
            set
            {
                _Song_Url = value;
                RaisePropertyChanged("Song");
            }
        }

        public MusicPlayViewModel(){
            Messenger.Default.Register<MessengerBus>(this, (message) =>
            {
                this.Song = message.Song;
            });
        }
        private bool CanExecuteMyMethod(object parameter)
        {
            return true;
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
