using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using training.Other;

namespace training.ViewModel
{
    class ListSongViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string nag;
        public ICommand Transfer
        {
            get;
            private set;
        }

        public string Visility_2
        {
            get
            {
                return nag;
            }
            set
            {
                if (nag != value)
                {
                    nag = value;
                    RaisePropertyChanged("Visility_2");
                }
            }
        }

        public ListSongViewModel()
        {
            Transfer = new RelayCommand(
                param => this.change_vis(),
                param => this.CanExecuteMyMethod(param));
        }

        public void change_vis()
        {
            Visility_2 = "Collapsed";
/*            public void Change_Display()
            {
                if (Tab_index == 0)
                {
                    Visility = "Visible";
                }
                else
                {
                    Visility = "Collapsed";
                }
            }*/
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
