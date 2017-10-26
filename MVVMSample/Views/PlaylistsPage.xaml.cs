using Xamarin.Forms;

using MVVMSample.ViewModels;
using MVVMSample.Models;

namespace MVVMSample.Views
{
    public partial class PlaylistsPage : ContentPage
    {

        public PlaylistsPage()
        {
            BindingContext = new PlaylistViewModel();
            InitializeComponent();
        }

        protected override void OnAppearing ()
        {
            base.OnAppearing(); 
        }

        void OnAddPlaylist (object sender, System.EventArgs e)
        {
            var newPlaylist = "Playlist " + (_playlists.Count + 1);
            _playlists.Add(new Playlist { Title = newPlaylist });
            this.Title = $"{_playlists.Count} Playlists";
        }



        void OnPlaylistSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var playlist = e.SelectedItem as Playlist;
            playlist.IsFavorite = !playlist.IsFavorite;

            playlistsListView.SelectedItem = null;
        }
    }
}