using System;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

using Xamarin.Forms;

using MVVMSample.Views;
using MVVMSample.Models;

namespace MVVMSample.ViewModels
{
    public class PlaylistsViewModel : BaseViewModel
    {
		private PlaylistViewModel _selectedPlaylist;

        public EventHandler<PlaylistEventArgs> PlayListSelected;
        public class PlaylistEventArgs:EventArgs{
            public Playlist selectedPlayList { get; set; }
        }

		public ObservableCollection<PlaylistViewModel> Playlists { get; private set; } = new ObservableCollection<PlaylistViewModel>();
		public PlaylistViewModel SelectedPlaylist
        {
            get
            {
                return _selectedPlaylist;
            }

            set
            {
                SetProperty(ref _selectedPlaylist, value);
            }
        }

        /* The followings are Read-Only Properties 
        These properties are handling the events */ 
        public ICommand AddPlaylistCommand { get; private set; }
        public ICommand SelectPlaylistCommand { get; private set; }

        public PlaylistsViewModel()
        {
            //Here, we are wrapping the AddPlaylist Method using Command
            AddPlaylistCommand = new Command(AddPlaylist);

            /* We are using a generic version of the Command class to account for the Asynchronous Method
            Thus, we need to declare an Asynchronous Lambda expression and manually call the target method */  
            //SelectPlaylistCommand = new Command<Playlist>(async (pl) => SelectPlaylist(pl));
        }
    
        private void AddPlaylist()
        {
            var newPlaylist = "Playlist" + (Playlists.Count + 1);

            Playlists.Add(new PlaylistViewModel { Title = newPlaylist });
        }

        public void SelectPlaylist(Playlist playlist)
        {
            if (playlist == null)
                return;

            playlist.IsFavorite = !playlist.IsFavorite;

            //SelectedPlaylist = null;

            PlayListSelected?.Invoke(this, new PlaylistEventArgs { selectedPlayList = playlist });

            //await _pageService.PushAsync(new PlaylistDetailPage(playlist));
        }
    }
}