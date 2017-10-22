using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Xamarin.Forms;

namespace MVVMSample.Models
{
    public class Playlist : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string Title { get; set; }

        private bool _isFavorite;
        public bool IsFavorite
        {
            get
            {
                return _isFavorite;
            }

            set
            {
                if (_isFavorite == value)
                    return;

                _isFavorite = value;

                OnPropertyChanged ();
                OnPropertyChanged(nameof(Color));
            }
        }

        public Color color
        {
            get
            {
                return IsFavorite ? Color.Pink : Color.Black;             }
        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
