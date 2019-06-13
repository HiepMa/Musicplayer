using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using training.Model;
using training.Util;

namespace training.ViewModel
{
    class AddPlsyListViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _NamePlayList;
        public string NamePlayList
        {
            get
            {
                return _NamePlayList;
            }
            set
            { 
                _NamePlayList = value;
                RaisePropertyChanged("NamePlayList");
            }
        }

        public AddPlsyListViewModel()
        {
            Accept = new RelayCommand(
                param => this.process(),
                param => this.CanExecuteMyMethod(param));
        }
        public ICommand Accept
        {
            get;
            private set;
        }

        public void process()
        {
            try
            {
                Messenger.Default.Send<MessengerBus>(new MessengerBus() { NamePlayList = this.NamePlayList });
                
            }
            catch(Exception e)
            {
                //TODO
            }
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
