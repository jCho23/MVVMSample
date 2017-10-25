namespace MVVMSample.Models
{
    ////This is a domain class
    public class Playlist
    {
        //No longer needed, since we added BaseViewModel
        //public event PropertyChangedEventHandler PropertyChanged;

        public string Title { get; set; }

        public bool IsFavorite { get; set; }
    }
}

