using System;
using System.Collections.Generic;
using MVVMSample.Models;
using MVVMSample.ViewModels;
using Xamarin.Forms;

namespace MVVMSample.Views
{
    public partial class PlaylistDetailPage : ContentPage
    {
        private PlaylistViewModel PlaylistVM;

        public PlaylistDetailPage(Playlist selectedPlaylist, PlaylistViewModel vm)
        {
            InitializeComponent();
            PlaylistVM = vm;
            title.Text = selectedPlaylist.Title;
        }
    }
}