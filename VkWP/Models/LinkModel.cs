using System;
using System.ComponentModel;

namespace VkWP.Models
{
    public class Link : INotifyPropertyChanged
    {
        private string _url;

        public string Url
        {
            get { return _url; }
            set
            {
                if (_url != value)
                {
                    _url = value;
                    NotifyPropertyChanged("Url");
                }
            }
        }

        private string _title;

        public string Title
        {
            get { return _title; }
            set
            {
                if (_title != value)
                {
                    _title = value;
                    var uri = new Uri(_url);
                    var requested = uri.Scheme + Uri.SchemeDelimiter + uri.Host + "/";
                    _title = requested;
                    NotifyPropertyChanged("Title");
                }
            }
        }

        private string _description;

        public string Description
        {
            get { return _description; }
            set
            {
                if (_description != value)
                {
                    _description = value;
                    NotifyPropertyChanged("Description");
                }
            }
        }

        private string _imageSrc;

        public string ImageSrc
        {
            get { return _imageSrc; }
            set
            {
                if (_imageSrc != value)
                {
                    _imageSrc = value;
                    NotifyPropertyChanged("ImageSrc");
                }
            }
        }


        #region INPC
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
        #endregion
    }
}
