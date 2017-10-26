using Xamarin.Forms;
using MVVMSample.Services;
using MVVMSample.ViewModels;
using MVVMSample.Models;

namespace MVVMSample.Views
{
    public partial class PlaylistsPage : ContentPage
    {

        public PlaylistsPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing ()
        {
            base.OnAppearing(); 
        }

        void OnAddPlaylist (object sender, System.EventArgs e)
        {
            (BindingContext as PlaylistsViewModel).AddPlaylist();
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
