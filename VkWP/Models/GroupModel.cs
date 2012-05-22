using System;
using System.ComponentModel;
using System.Net;
using VkWP.Helpers;

namespace VkWP.Models
{
    public class GroupItem : INotifyPropertyChanged
    {
        private int _gid;
        private string _name;
        private string _screenName;
        private int _isClosed;
        private int _isAdmin;
        private string _photo;
        private string _photoMedium;
        private string _photoBig;

        public int Gid
        {
            get { return _gid; }
            set
            {
                if (_gid != value)
                {
                    _gid = value;
                    NotifyPropertyChanged("Gid");
                }
            }
        }

        public string Name
        {
            get { return TextPreprocessor.Decode(_name); }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    NotifyPropertyChanged("Name");
                }
            }
        }



        public string ScreenName
        {
            get { return _screenName; }
            set
            {
                if (_screenName != value)
                {
                    _screenName = value;
                    NotifyPropertyChanged("ScreenName");
                }
            }
        }



        public int IsClosed
        {
            get { return _isClosed; }
            set
            {
                if (_isClosed != value)
                {
                    _isClosed = value;
                    NotifyPropertyChanged("IsClosed");
                }
            }
        }



        public int IsAdmin
        {
            get { return _isAdmin; }
            set
            {
                if (_isAdmin != value)
                {
                    _isAdmin = value;
                    NotifyPropertyChanged("IsAdmin");
                }
            }
        }



        public string Photo
        {
            get { return _photo; }
            set
            {
                if (_photo != value)
                {
                    _photo = value;
                    NotifyPropertyChanged("Photo");
                }
            }
        }



        public string PhotoMedium
        {
            get { return _photoMedium; }
            set
            {
                if (_photoMedium != value)
                {
                    _photoMedium = value;
                    NotifyPropertyChanged("PhotoMedium");
                }
            }
        }



        public string PhotoBig
        {
            get { return _photoBig; }
            set
            {
                if (_photoBig != value)
                {
                    _photoBig = value;
                    NotifyPropertyChanged("PhotoBig");
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
