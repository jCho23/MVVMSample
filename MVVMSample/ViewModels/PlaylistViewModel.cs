using System;

using Xamarin.Forms;

namespace MVVMSample.ViewModels
{
    public class PlaylistViewModel : BaseViewModel
    {
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
    }
}