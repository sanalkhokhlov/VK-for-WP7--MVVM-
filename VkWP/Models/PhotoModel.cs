using System;
using System.ComponentModel;

namespace VkWP.Models
{
    public class PhotoItem : INotifyPropertyChanged
    {
        private int _pid;

        public int Pid
        {
            get { return _pid; }
            set
            {
                if (_pid != value)
                {
                    _pid = value;
                    NotifyPropertyChanged("Pid");
                }
            }
        }

        private int _aid;

        public int Aid
        {
            get { return _aid; }
            set
            {
                if (_aid != value)
                {
                    _aid = value;
                    NotifyPropertyChanged("Aid");
                }
            }
        }

        private int _ownerId;

        public int OwnerId
        {
            get { return _ownerId; }
            set
            {
                if (_ownerId != value)
                {
                    _ownerId = value;
                    NotifyPropertyChanged("OwnerId");
                }
            }
        }

        private string _src;

        public string Src
        {
            get { return _src; }
            set
            {
                if (_src != value)
                {
                    _src = value;
                    NotifyPropertyChanged("Src");
                }
            }
        }

        private string _srcSmall;

        public string SrcSmall
        {
            get { return _srcSmall; }
            set
            {
                if (_srcSmall != value)
                {
                    _srcSmall = value;
                    NotifyPropertyChanged("SrcSmall");
                }
            }
        }

        private string _srcBig;

        public string SrcBig
        {
            get { return _srcBig; }
            set
            {
                if (_srcBig != value)
                {
                    _srcBig = value;
                    NotifyPropertyChanged("SrcBig");
                }
            }
        }

        private DateTime _created;

        public DateTime Created
        {
            get { return _created; }
            set
            {
                if (_created != value)
                {
                    _created = value;
                    NotifyPropertyChanged("Created");
                }
            }
        }

        private string _likes;

        public string Likes
        {
            get { return _likes; }
            set
            {
                if (_likes != value)
                {
                    _likes = value;
                    NotifyPropertyChanged("Likes");
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
