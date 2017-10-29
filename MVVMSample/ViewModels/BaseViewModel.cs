using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace MVVMSample.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        protected Page page;
        public BaseViewModel(Page page)
        {
            this.page = page;
        }

        public BaseViewModel()
        {

        }

        string title = string.Empty;

        // Gets or sets the "Title" property
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        string subTitle = string.Empty;

        // Gets or sets the "Subtitle" property
        public string Subtitle
        {
            get { return subTitle; }
            set { SetProperty(ref subTitle, value); }
        }

        string icon;
        /// <summary>
        /// Gets or sets the "Icon" of the viewmodel
        /// </summary>
        public string Icon
        {
            get { return icon; }
            set { SetProperty(ref icon, value); }
        }

        bool isBusy;
        /// <summary>
        /// Gets or sets if the view is busy.
        /// </summary>
        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                SetProperty(ref isBusy, value);
                SetProperty(ref isBusyRev, !isBusy, nameof(IsBusyRev));
            }
        }

        private bool isBusyRev;
        /// <summary>
        /// Gets or sets the reverse of  isbusy. Handy for hiding views during busy times.
        /// </summary>
        public bool IsBusyRev
        {
            get { return isBusyRev; }
            set { SetProperty(ref isBusyRev, value); }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void SetProperty<T>(ref T backingField, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingField, value))
                return;

            backingField = value;

            OnPropertyChanged(propertyName);
        }
    }
}
