using System;
using System.ComponentModel;

namespace VkWP.Models
{
    public class AttachmentItem : INotifyPropertyChanged
    {
        private string _type;

        public string Type
        {
            get { return _type; }
            set
            {
                if (_type != value)
                {
                    _type = value;
                    NotifyPropertyChanged("Type");
                }
            }
        }

        private PhotoItem _photo;

        public PhotoItem Photo
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

        private Link _link;

        public Link Link
        {
            get { return _link; }
            set
            {
                if (_link != value)
                {
                    _link = value;
                    NotifyPropertyChanged("Link");
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
