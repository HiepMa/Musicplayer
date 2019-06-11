using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace training.ViewModel
{
    class NagationViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private int _id;
        private string nag;
        public int Tab_index
        {
            get
            {
                return _id;
            }
            set
            {
                if (_id != value)
                {
                    _id = value;
                    RaisePropertyChanged("Tab_index");
                }
            }
        }

        public string Visility_2
        {
            get
            {
                return nag;
            }
            set
            {
                if(nag != value)
                {
                    nag = value;
                    RaisePropertyChanged("Visility_2");
                }
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
