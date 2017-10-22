using System;
using System.Collections.Generic;
using MVVMSample.Models;
using MVVMSample.ViewModels;
using Xamarin.Forms;

namespace MVVMSample.Views
{
    public partial class PlaylistDetailPage : ContentPage
    {
        private PlaylistViewModel _playlist;

        public PlaylistDetailPage(PlaylistViewModel playlist)
        {
            _playlist = playlist;

            InitializeComponent();

            title.Text = _playlist.Title;
        }
    }
}