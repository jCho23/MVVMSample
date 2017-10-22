using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using MVVMSample.ViewModels;
using Xamarin.Forms;

namespace MVVMSample.Models
{
    public class Playlist : BaseViewModel
    {
        ////No longer needed, since we added BaseViewModel
        //public event PropertyChangedEventHandler PropertyChanged;

        public string Title { get; set; }

        private bool _isFavorite;
        public bool IsFavorite
        {
            get { return _isFavorite; }
            set
            {
                SetValue(ref _isFavorite, value);
                ////Moved to BaseViewModel
                //if (_isFavorite == value)
                //    return;

                //_isFavorite = value;
                //OnPropertyChanged();
                OnPropertyChanged(nameof(Color));
            }
        }

        public Color Color
        {
            get { return IsFavorite ? Color.HotPink : Color.Black; }
        }

        ////Moved to BaseViewModel
        //private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}
    }
}

