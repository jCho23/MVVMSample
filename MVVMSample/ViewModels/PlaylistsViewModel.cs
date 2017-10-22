using System;
using System.Collections.ObjectModel;
using MVVMSample.Models;

namespace MVVMSample.ViewModels
{
    public class PlaylistsViewModel : BaseViewModel
    {
        public ObservableCollection<Playlist> Playlists { get; private set; } = new ObservableCollection<Playlist>();

        private Playlist _selectedPlaylist;
        public Playlist SelectedPlaylist
        {
            get
            {
                return _selectedPlaylist;
            }

            set
            {
                if (_selectedPlaylist == value)
                    return;

                _selectedPlaylist = value;

                OnPropertyChanged(); 
            }
        }

        public void AddPlaylist()
        {
            var newPlaylist = "Playlist" + (Playlists.Count + 1);

            Playlists.Add(new Playlist { Title = newPlaylist });
        }

        public void SelectPlaylist(Playlist playlist)
        {
            if (playlist == null)
                return;

            playlist.IsFavorite = !playlist.IsFavorite;

            SelectedPlaylist = null;
        }
    }
}
