
namespace MVVMSample.Models
{
    ////This is a domain class
    public class Playlist
    {
        ////No longer needed, since we added BaseViewModel
        //public event PropertyChangedEventHandler PropertyChanged;

        public string Title { get; set; }

        public bool IsFavorite { get; set; }

        ////Moved to PlaylistViewModel
        ////Everything related to the UI is in the PlaylistViewModel  
        //{
        //    get { return _isFavorite; }
        //    set
        //    {
        //        SetValue(ref _isFavorite, value);
        //        ////Moved to BaseViewModel
        //        //if (_isFavorite == value)
        //        //    return;

        //        //_isFavorite = value;
        //        //OnPropertyChanged();
        //        OnPropertyChanged(nameof(Color));
        //    }
        //}

        //public Color Color
        //{
        //    get { return IsFavorite ? Color.HotPink : Color.Black; }
        //}

        ////Moved to BaseViewModel
        //private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}
    }
}

