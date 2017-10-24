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
        public ObservableCollection<PlaylistViewModel> Playlists { get; private set; } = new ObservableCollection<PlaylistViewModel>();

        private PlaylistViewModel _selectedPlaylist;
        public PlaylistViewModel SelectedPlaylist
        {
            get
            {
                return _selectedPlaylist;
            }

            set
            {
                SetValue(ref _selectedPlaylist, value);
                ////Moved to BaseViewModel
                //if (_selectedPlaylist == value)
                //    return;

                //_selectedPlaylist = value;

                //OnPropertyChanged(); 
            }
        }

		////The follwings are Read-Only Properties 
        ////These properties are handling the events 
        public ICommand AddPlaylistCommand { get; private set; }
        public ICommand SelectPlaylistCommand { get; private set; }

        private readonly IPageService _pageService;
        public PlaylistsViewModel(IPageService pageService)
        {
            _pageService = pageService;

            ////Here, we are wrapping the AddPlaylist Method using Command
            AddPlaylistCommand = new Command(AddPlaylist);
            ////We are using a generic version of the Command class
            SelectPlaylistCommand = new Command<PlaylistViewModel>(async vm => SelectPlaylist(vm));

        }

        private void AddPlaylist()
        {
            var newPlaylist = "Playlist" + (Playlists.Count + 1);

            Playlists.Add(new PlaylistViewModel { Title = newPlaylist });
        }

        public async Task SelectPlaylist(PlaylistViewModel playlist)
        {
            if (playlist == null)
                return;

            playlist.IsFavorite = !playlist.IsFavorite;

            SelectedPlaylist = null;

            await _pageService.PushAsync(new PlaylistDetailPage(playlist));
        }
    }
}
