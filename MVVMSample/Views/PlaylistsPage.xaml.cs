using Xamarin.Forms;
using MVVMSample.Services;
using MVVMSample.ViewModels;

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

        void OnAddPlaylist (object sender, System.EventArgs e)
        {
            (BindingContext as PlaylistsViewModel).AddPlaylist();
        }



        void OnPlaylistSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            ViewModel.SelectPlaylistCommand.Execute(e.SelectedItem);
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
