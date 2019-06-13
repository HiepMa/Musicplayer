using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using training.Model;
using training.Util;
using Windows.Storage;

namespace training.ViewModel
{
    class ListViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Song> ListSong { get; set; }
        private Uri image = new Uri("ms-appx:///Assets/icon/play.png");
        private bool Open_close;

        public bool Open_Close
        {
            get { return Open_close; }
            set
            {
                if( Open_close != value)
                {
                    Open_close = value;
                    RaisePropertyChanged("Open_Close");
                }
            }
        }

        public ListViewModel()
        {
            /*            Transfer = new RelayCommand(
                            param => this.chang_vis(),
                            param => this.CanExecuteMyMethod(param));*/
            /*            Add_Song = new RelayCommand(
                            param => this.Show_PickerAsync(param),
                            param => this.CanExecuteMyMethod(param));*/
            Messenger.Default.Register<MessengerBus>(this, (message) =>
            {
                this.Open_Close = message.Trans;
            });
        }
        public ICommand Add_Song
        {
            get;
            private set;
        }
        public ICommand Transfer
        {
            get;
            private set;
        }

        public Uri image_url
        {
            get { return image; }
            set
            {
                if (image != value)
                {
                    image = value;
                    RaisePropertyChanged("image_url");
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
