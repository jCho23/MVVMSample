using System;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

using Xamarin.Forms;

using MVVMSample.Views;
using MVVMSample.Models;
using MVVMSample.Services;
using MVVMSample.Interfaces;

namespace MVVMSample.ViewModels
{
    public class PlaylistsViewModel : BaseViewModel
    {
		private PlaylistViewModel _selectedPlaylist;
		private readonly IPageService _pageService;

		public ObservableCollection<PlaylistViewModel> Playlists { get; private set; } = new ObservableCollection<PlaylistViewModel>();
		public PlaylistViewModel SelectedPlaylist
        {
            get
            {
                return _selectedPlaylist;
            }

            set
            {
                SetValue(ref _selectedPlaylist, value);
            }
        }

        /* The followings are Read-Only Properties 
        These properties are handling the events */ 
        public ICommand AddPlaylistCommand { get; private set; }
        public ICommand SelectPlaylistCommand { get; private set; }

        public PlaylistsViewModel(IPageService pageService)
        {
            _pageService = pageService;

            //Here, we are wrapping the AddPlaylist Method using Command
            AddPlaylistCommand = new Command(AddPlaylist);

            /* We are using a generic version of the Command class to account for the Asynchronous Method
            Thus, we need to declare an Asynchronous Lambda expression and manually call the target method */  
            SelectPlaylistCommand = new Command<PlaylistViewModel>(async vm => await SelectPlaylist(vm));
        }
    
        private void AddPlaylist()
        {
            var newPlaylist = "Playlist" + (Playlists.Count + 1);

            Playlists.Add(new PlaylistViewModel { Title = newPlaylist });
        }

        public SelectPlaylist(PlaylistViewModel playlist)
        {
            if (playlist == null)
                return;

            playlist.IsFavorite = !playlist.IsFavorite;

            SelectedPlaylist = null;

            //await _pageService.PushAsync(new PlaylistDetailPage(playlist));
        }
    }
}