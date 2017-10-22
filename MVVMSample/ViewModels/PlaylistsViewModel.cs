using System;
using System.Collections.ObjectModel;
using MVVMSample.Models;

namespace MVVMSample.ViewModels
{
    public class PlaylistsViewModel
    {
        public ObservableCollection<Playlist> Playlists { get; private set; } = new ObservableCollection<Playlist>();

        public void AddPlaylist()
        {
            var newPlaylist = "Playlist" + (Playlists.Count + 1);

            Playlists.Add(new Playlist { Title = newPlaylist });
        }
    }
}
