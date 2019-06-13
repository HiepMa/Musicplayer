using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using training.DB;
using training.Model;
using training.Util;
using Windows.Storage;

namespace training.ViewModel
{
    class ListSongViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string _Song_Url;
        private int _id = 0;
        DatabaseService _db = DatabaseService.Instance();
        public ObservableCollection<Song> ListSong { get; set; }
        public ICommand Transfer
        {
            get;
            private set;
        }

        public ICommand Add_Song
        {
            get;
            private set;
        }

        public ICommand Play_Song
        {
            get;
            private set;
        }

        public ICommand Delete_Song
        {
            get;
            private set;
        }

        public ListSongViewModel()
        {
            loadListSong();
/*            MusicPlayList();*/
            Change_Song();
            Add_Song = new RelayCommand(
                param => this.Show_PickerAsync(param),
                param => this.CanExecuteMyMethod(param));
            Play_Song = new RelayCommand(
                param => this.Change_Song(),
                param => this.CanExecuteMyMethod(param));
            Delete_Song = new RelayCommand(
                param => this.delete(),
                param => this.CanExecuteMyMethod(param));
            Transfer = new RelayCommand(
                param => this.open(),
                param => this.CanExecuteMyMethod(param));
        }

        public void Add_DB()
        {
            Song s1 = new Song { Name = "That Girl", Path = "ms-appx:///Assets/Video/thatgirl.mp4" };
            Song s2 = new Song { Name = "Faded", Path = "ms-appx:///Assets/Video/faded.mp4" };
            Song s3 = new Song { Name = "Bạc Phận", Path = "ms-appx:///Assets/Video/bacphan.mp3" };
            Song s4 = new Song { Name = "Yes I Do", Path = "ms-appx:///Assets/Video/demo.mp4" };
            Playlist p1 = new Playlist { Name = "US-UK" };
            Playlist p2 = new Playlist { Name = "VN" };
            Playlist p3 = new Playlist { Name = "All" };
            _db.InsertSong(s1);
            _db.InsertSong(s2);
            _db.InsertSong(s3);
            _db.InsertSong(s4);
            _db.InsertPlaylist(p1);
            _db.InsertPlaylist(p2);
            _db.InsertPlaylist(p3);
/*            DatabaseService.Instance().DB.SongDao.Insert(s1);
            DatabaseService.Instance().DB.SongDao.Insert(s2);
            DatabaseService.Instance().DB.SongDao.Insert(s3);
            DatabaseService.Instance().DB.SongDao.Insert(s4);
            DatabaseService.Instance().DB.PlaylistDao.Insert(p1);
            DatabaseService.Instance().DB.PlaylistDao.Insert(p2);
            DatabaseService.Instance().DB.PlaylistDao.Insert(p3);*/
            DatabaseService.Instance().DB.PlaylistDao.addSong(s1, p1);
            DatabaseService.Instance().DB.PlaylistDao.addSong(s2, p1);
            DatabaseService.Instance().DB.PlaylistDao.addSong(s3, p2);
            DatabaseService.Instance().DB.PlaylistDao.addSong(s4, p2);
            DatabaseService.Instance().DB.PlaylistDao.getSong(p1.Id).ForEach(delegate (Song sx) {
                Debug.WriteLine($"Song: {sx.Name} - {sx.Path}");
            });
        }

        public void open()
        {
            try
            {
                Messenger.Default.Send<MessengerBus>(new MessengerBus() { Trans = true });
            }
            catch (Exception e)
            {
                //TODO
            }
        }

        public void loadListSong()
        {
/*            Add_DB();*/
            List<Song> List_song = DatabaseService.Instance().DB.SongDao.getAll();
            ObservableCollection<Song> Lsong = new ObservableCollection<Song>();
/*            for (int i=0;i < List_song.Count() ;i++)
            {
                Song newsong = new Song { Id = List_song[i].Id, Name = List_song[i].Name, Path = List_song[i].Path };
                Lsong.Add(newsong);
            }*/
            foreach (var s in List_song)
            {
                Lsong.Add(s);
            }
            ListSong = Lsong;
        }
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

        public void delete()
        {
            DatabaseService.Instance().DB.SongDao.Delete(ListSong[SelectTaskListIndex].Id);
            ListSong.Remove(ListSong[_id]);
/*            Debug.WriteLine(ListSong[_id].Id);*/
            /*            loadListSong();*/
        }

        public async Task Show_PickerAsync(object obj)
        {
            var picker = new Windows.Storage.Pickers.FileOpenPicker();
            picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.PicturesLibrary;
            picker.FileTypeFilter.Add(".mp3");
            picker.FileTypeFilter.Add(".mp4");
            picker.FileTypeFilter.Add(".webm");

            Windows.Storage.StorageFile file = await picker.PickSingleFileAsync();
            if (file != null)
            {
                // Application now has read/write access to the picked file
                string[] namedetail = file.Name.Split('.');
                Song addsong = new Song { Name = namedetail[0], Path = file.Path };
                Windows.Storage.FileProperties.BasicProperties basicProperties = await file.GetBasicPropertiesAsync();

                string fileSize = string.Format("{0:n0}", basicProperties.Size);
                Debug.WriteLine(fileSize);
                ListSong.Add(addsong);
                DatabaseService.Instance().DB.SongDao.Insert(addsong);
/*                DatabaseService.Instance().DB.PlaylistDao.addSong(addsong,);*/

/*                Messenger.Default.Send<MessengerBus>(new MessengerBus() { NameSong = namedetail[0], Path = file.Path });*/
            }
            /*            var file = await picker.PickMultipleFilesAsync();*/
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

        public void Change_Song()
        {
            try
            {
                Messenger.Default.Send<MessengerBus>(new MessengerBus() { Song = ListSong[_id].Path });
            }
            catch (Exception e) {
                //TODO
            }
        }

        public async Task setPermissionFileAsync(Uri filepath)
        {
            Windows.Storage.StorageFolder installedLocation = Windows.ApplicationModel.Package.Current.InstalledLocation;
            StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(filepath);
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
