using System;
using System.Threading.Tasks;
using MVVMSample.ViewModels;
using Xamarin.Forms;

namespace MVVMSample.Views
{
    public abstract class BaseContentPage<T> : ContentPage where T : BaseViewModel, new()
    {
        T viewModel;

        protected BaseContentPage()
        {
            this.ViewModel = Activator.CreateInstance<T>();
        }

        /// <summary>
        /// Gets or sets the view model.
        /// </summary>
        /// <value>The view model.</value>
        public T ViewModel
        {
            get { return this.viewModel; }
            set
            {
                viewModel = value;
                BindingContext = viewModel;
                this.SetBinding(TitleProperty, nameof(ViewModel.Title));
 
            }
        }

        //public abstract void SubscribeEventHandlers();
        public virtual void SubscribeEventHandlers()
        {
            
        }

        //public abstract void UnsubscribeEventHandlers();
        public virtual void UnsubscribeEventHandlers()
        {

        }


        protected override void OnAppearing()
        {
            base.OnAppearing();
            SubscribeEventHandlers();
        }


        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            UnsubscribeEventHandlers();
        }
    }
}