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
using training.DB.engine;
using training.Model;
using training.Other;
using Windows.UI.Popups;

namespace training.ViewModel
{
    public class StudentViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _randomText;
        public string RandomText
        {
            get
            {
                return _randomText;
            }
            set
            {
                _randomText = value;
                RaisePropertyChanged("RandomText");
            }
        }
        public ICommand Button_Click
        {
            get;
            private set;

        }
        public StudentViewModel() {
            LoadStudents();
            Button_Click = new RelayCommand(
                param => this.SetTextAsync(param),
                param => this.CanExecuteMyMethod(param));
        }
        public ObservableCollection<Student> Students
        {
            get;
            set;
        }

        public void LoadStudents()
        {
            ObservableCollection<Student> students = new ObservableCollection<Student>();

            students.Add(new Student { FirstName = "Mark", LastName = "Allain" });
            students.Add(new Student { FirstName = "Allen", LastName = "Brown" });
            students.Add(new Student { FirstName = "Linda", LastName = "Hamerski" });

            Students = students;
        }

        public async Task SetTextAsync(object obj)
        {
            //SqliteDatabase db = (SqliteDatabase) DatabaseService.Instance().DB;

            //db.Song.Insert(new SongEntity { Name = "A", Path = "B" });

            //var result = db.Song.Where(p => p.Name == "A");
            //foreach (var song in result)
            //{
            //    var dialog = new MessageDialog($"Name={song.Name}, Path={song.Path}");
            //    await dialog.ShowAsync();
            //    Console.WriteLine($"Name={song.Name}, Price={song.Path}");
            //}
            ISongDao songDao = DatabaseService.Instance().DB.SongDao;
            songDao.Insert(new DB.model.Song { Name = "A", Path = "XXX" });
            songDao.Insert(new DB.model.Song { Name = "B", Path = "XXX" });
            songDao.Insert(new DB.model.Song { Name = "C", Path = "XXX" });

            Debug.WriteLine(songDao.getAll());
            Debug.WriteLine(songDao.getAll());
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
