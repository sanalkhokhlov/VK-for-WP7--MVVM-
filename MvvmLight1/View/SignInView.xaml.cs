using System;
using Microsoft.Phone.Controls;
using VkWP.Client;

namespace MvvmLight1.View
{
    /// <summary>
    /// Description for SignInView.
    /// </summary>
    public partial class SignInView : PhoneApplicationPage
    {
        /// <summary>
        /// Initializes a new instance of the SignInView class.
        /// </summary>
        public SignInView()
        {
            InitializeComponent();
        }

        private void WebBrowserNavigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            if (webBrowser.Source.AbsolutePath == "/blank.html")
            {
                var accessInfo = new AccessInfoBag
                {
                    Token = webBrowser.Source.Fragment.Substring(14, 63),
                    Uid = webBrowser.Source.Fragment.Substring(103)
                };
                AccessInfoStore.Save(accessInfo);
                App.GlobalVkClient.Start(accessInfo);
                NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
            }
        }
    }
}