using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using MVVMSample.Interfaces;
using MVVMSample.Models;
using MVVMSample.Services;
using MVVMSample.Views;
using Xamarin.Forms;

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

        public ICommand AddPlaylistCommand { get; private set; }
        private readonly IPageService _pageService;
        public PlaylistsViewModel(IPageService pageService)
        {
            _pageService = pageService;

            AddPlaylistCommand = new Command(AddPlaylist);
        }

        public void AddPlaylist()
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
