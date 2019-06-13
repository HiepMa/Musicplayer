using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace training.ViewModel
{
    class ServiceViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ServiceViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<StudentViewModel>();

            SimpleIoc.Default.Register<PlayListViewModel>();

            SimpleIoc.Default.Register<ListSongViewModel>();

            SimpleIoc.Default.Register<MusicPlayViewModel>();

            SimpleIoc.Default.Register<ListViewModel>();
        }

        public StudentViewModel Student => ServiceLocator.Current.GetInstance<StudentViewModel>();

        public PlayListViewModel PlayList => ServiceLocator.Current.GetInstance<PlayListViewModel>();


        public ListSongViewModel ListSong => ServiceLocator.Current.GetInstance<ListSongViewModel>();

        public MusicPlayViewModel MusicPlay => ServiceLocator.Current.GetInstance<MusicPlayViewModel>();

        public ListViewModel ListPage => ServiceLocator.Current.GetInstance<ListViewModel>();

    }
}
