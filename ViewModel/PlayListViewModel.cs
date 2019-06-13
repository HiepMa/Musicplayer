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
using training.DB;
using training.Model;
using training.Util;
using Windows.Storage;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;

namespace training.ViewModel
{
    class PlayListViewModel : INotifyPropertyChanged
    {
        // ms-appx:///Assets/Video/demo.webm
        public event PropertyChangedEventHandler PropertyChanged;
        private int _id = 0;
        DatabaseService _db = DatabaseService.Instance();
        public ObservableCollection<Playlist> PLayListSong { get; set; }

        public string name { get; set; }

        public ICommand Delete_Playlist
        {
            get;
            private set;
        }

        public ICommand Add_PlayList
        {
            get;
            private set;
        }
        public PlayListViewModel()
        {
            LoadPlayList();
            Delete_Playlist = new RelayCommand(
                param => this.delete(),
                param => this.CanExecuteMyMethod(param));
            Add_PlayList = new RelayCommand(
                param => this.Show_PickerAsync(param),
                param => this.CanExecuteMyMethod(param));
            
        }
        public void LoadPlayList()
        {
            List<Playlist> Play_List = DatabaseService.Instance().DB.PlaylistDao.getAll();
            ObservableCollection <Playlist> play = new ObservableCollection<Playlist>();
            foreach (var s in Play_List)
            {
                play.Add(s);
            }
            PLayListSong = play;
        }

        public void delete()
        {
            DatabaseService.Instance().DB.PlaylistDao.Delete(PLayListSong[SelectTaskListIndex].Id);
            PLayListSong.Remove(PLayListSong[_id]);
        }

        public int SelectTaskListIndex
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
                    RaisePropertyChanged("SelectTaskListIndex");
                    /*                    Change_Song();*/
                }
            }
        }
        public async Task Show_PickerAsync(object obj)
        {
            var addplsylist = new training.View.AddplayList();
            addplsylist.ShowAsync();
            Messenger.Default.Register<MessengerBus>(this, (message) =>
            {
                this.name = message.NamePlayList;
                Playlist p = new Playlist { Name = name };
                DatabaseService.Instance().DB.PlaylistDao.Insert(p);
                PLayListSong.Add(p);
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
