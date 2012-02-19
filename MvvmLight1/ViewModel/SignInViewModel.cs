using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace MvvmLight1.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm/getstarted
    /// </para>
    /// </summary>
    public class SignInViewModel : ViewModelBase
    {
        private Uri _authUri;

        public Uri AuthUri
        {
            get { return _authUri; }
            set
            {
                if (this._authUri != value)
                {
                    this._authUri = value;
                    this.RaisePropertyChanged("AuthUri");
                }
            }
        }

        private bool _loading = true;

        public bool Loading
        {
            get { return _loading; }
            set
            {
                if (_loading != value)
                {
                    _loading = value;
                    RaisePropertyChanged("Loading");
                }
            }
        }

        private ICommand _webBrowserNavigatingCommand;

        public ICommand WebBrowserNavigatingCommand
        {
            get
            {
                return this._webBrowserNavigatingCommand;
            }
        }

        private ICommand _webBrowserNavigatedCommand;

        public ICommand WebBrowserNavigatedCommand
        {
            get
            {
                return this._webBrowserNavigatedCommand;
            }
        }

        private ICommand _singInPageOnNavigatedToCommand;

        public ICommand SingInPageOnNavigatedToCommand
        {
            get
            {
                return this._singInPageOnNavigatedToCommand;
            }
            set
            {
                if (_singInPageOnNavigatedToCommand != value)
                {
                    _singInPageOnNavigatedToCommand = value;
                    RaisePropertyChanged("SingInPageOnNavigatedToCommand");
                }
            }
        }

        private void WebBrowserNavigatingAction()
        {
            Loading = true;
        }

        private void WebBrowserNavigatedAction(Uri msg)
        {
            Loading = false;
            Debug.WriteLine("from ViewModel: "+msg.AbsoluteUri);
        }

        private void SingInPageOnNavigatedToAction()
        {
            if (App.GlobalVkClient.Active)
            {
                var rootFrame = ((App)Application.Current).RootFrame;
                rootFrame.RemoveBackEntry();
                rootFrame.GoBack();
            }
        }

        /// <summary>
        /// Initializes a new instance of the SignInViewModel class.
        /// </summary>
        public SignInViewModel()
        {
            AuthUri = new Uri(App.GlobalVkClient.GetAuthUrl());
            this._webBrowserNavigatingCommand = new RelayCommand(this.WebBrowserNavigatingAction);
            this._webBrowserNavigatedCommand = new RelayCommand<Uri>(this.WebBrowserNavigatedAction);
            this._singInPageOnNavigatedToCommand = new RelayCommand(this.SingInPageOnNavigatedToAction);
        }
    }
}