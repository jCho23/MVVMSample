using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using MVVMSample.Models;
using MVVMSample.ViewModels;
using MVVMSample.Services;

namespace MVVMSample.Views
{
    public partial class PlaylistsPage : ContentPage
    {

        public PlaylistsPage()
        {
            ViewModel = new PlaylistsViewModel(new PageService());
            InitializeComponent();
        }

        protected override void OnAppearing ()
        {
            base.OnAppearing(); 
        }

        ////Implemented ICommand, no longer need event handler
        //void OnAddPlaylist(object sender, System.EventArgs e)
        //{
            //(BindingContext as PlaylistsViewModel).AddPlaylist();
            ////Moved to ViewModel
            //var newPlaylist = "Playlist" + (_playlists.Count + 1);

            //_playlists.Add(new Playlist {Title = newPlaylist})

        void OnPlaylistSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            ViewModel.SelectPlaylistCommand.Execute(e.SelectedItem);
            ////Moved to ViewModel
            //if (e.SelectedItem == null)
            //    return;

            //var playlist = e.SelectedItem as Playlist;
            //playlist.IsFavorite = !playlist.IsFavorite;

            //playlistsListView.SelectedItem = null;
        }

        private PlaylistsViewModel ViewModel
        {
            get
            {
                return BindingContext as PlaylistsViewModel;
            }

            set
            {
                BindingContext = value;  
            }
        }
    }
}
