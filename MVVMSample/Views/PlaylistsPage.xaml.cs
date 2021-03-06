﻿using Xamarin.Forms;

using MVVMSample.Models;
using MVVMSample.ViewModels;
using System.Collections.ObjectModel;

namespace MVVMSample.Views
{
    public partial class PlaylistsPage : ContentPage
    {
        private ObservableCollection<Playlist> _playlists = new ObservableCollection<Playlist>();
        PlaylistsViewModel ViewModel;

        public PlaylistsPage(PlaylistsViewModel vm)
        {
            BindingContext = ViewModel = vm;
            Title = ViewModel.Title;
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            playlistsListView.ItemsSource = _playlists;

            base.OnAppearing();
        }

        void OnAddPlaylist(object sender, System.EventArgs e)
        {
            var newPlaylist = "Playlist " + (_playlists.Count + 1);

            _playlists.Add(new Playlist { Title = newPlaylist });

            this.Title = $"{_playlists.Count} Playlists";
        }

        async void OnPlaylistSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var playlist = e.SelectedItem as Playlist;
            playlist.IsFavorite = !playlist.IsFavorite;

            playlistsListView.SelectedItem = null;

            await Navigation.PushAsync (new PlaylistDetailPage(playlist, new PlaylistViewModel()));
        }
    }
}