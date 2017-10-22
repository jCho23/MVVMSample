﻿using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MVVMSample.Views
{
    public partial class PlaylistDetailPage : ContentPage
    {

        private Playlist _playlist;

        public PlaylistDetailPage(Playlist playlist)
        {
            _playlist = playlist;

            InitializeComponent();

            title.Text = playlist.Title;
        }
    }
}