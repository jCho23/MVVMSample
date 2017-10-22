using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace MVVMSample.Views
{
    public partial class PlaylistsPage : ContentPage
    {
        private ObservableCollection<Playlist> _playlists = new ObservableColllection<Playlist> ();

        public PlaylistsPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing ()
        {
            playlistsListView.ItemsSource = _playlists;
            base.OnAppearing(); 
        }








        void Handle_Clicked(object sender, System.EventArgs e)
        {
            throw new NotImplementedException();
        }

        void OnPlaylistSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
