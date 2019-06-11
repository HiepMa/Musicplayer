using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using training.DB.model;
using training.Other;
using Windows.Storage;
using Windows.UI.Popups;

namespace training.ViewModel
{
    class PlayListViewModel : INotifyPropertyChanged
    {
        // ms-appx:///Assets/Video/demo.webm
        public event PropertyChangedEventHandler PropertyChanged;
        private string _Song_Url;
        private int _id;
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
                    Change_Song();
                }
            }
        }

        public ICommand Add_Song
        {
            get;
            private set;
        }

        public ObservableCollection<Song> ListSong { get; set; }

        public void MusicPlayList()
        {
            ObservableCollection<Song> song = new ObservableCollection<Song>();

            song.Add(new Song { Id = 1, Name="New Song", Path="ms-appx:///Assets/Video/demo.mp4" });
            song.Add(new Song { Id = 2, Name = "Yes I Do", Path = "ms-appx:///Assets/Video/demo.webm" });

            ListSong = song;
        }

        public PlayListViewModel()
        {
            MusicPlayList();
            Song = ListSong[0].Path;
            Add_Song = new RelayCommand(
                param => this.Show_PickerAsync(param),
                param => this.CanExecuteMyMethod(param));
        }

        public void Change_Song()
        {
            Song = ListSong[_id].Path;
        }

        public async Task setPermissionFileAsync(Uri filepath)
        {
            Windows.Storage.StorageFolder installedLocation = Windows.ApplicationModel.Package.Current.InstalledLocation;
            StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(filepath);
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
            ObservableCollection<Song> song = new ObservableCollection<Song>();
            if (file != null)
            {
                // Application now has read/write access to the picked file
                string[] namedetail = file.Name.Split('.');
                ListSong.Add(new Song {Id = 10, Name = namedetail[0], Path = file.Path});
                Windows.Storage.FileProperties.BasicProperties basicProperties = await file.GetBasicPropertiesAsync();
                
                string fileSize = string.Format("{0:n0}", basicProperties.Size);
                Debug.WriteLine(fileSize);
            }
            /*            var file = await picker.PickMultipleFilesAsync();*/
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
