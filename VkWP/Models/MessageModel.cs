using System;
using System.ComponentModel;

namespace VkWP.Models
{
    public class MessageItem : INotifyPropertyChanged
    {
        private int _mid;
        public int Mid
        {
            get { return _mid; }
            set
            {
                if (_mid != value)
                {
                    _mid = value;
                    NotifyPropertyChanged("Mid");
                }
            }
        }

        private int _uid;
        public int Uid
        {
            get { return _uid; }
            set
            {
                if (_uid != value)
                {
                    _uid = value;
                    NotifyPropertyChanged("Uid");
                }
            }
        }

        private int _date;
        public int Date
        {
            get { return _date; }
            set
            {
                if (_date != value)
                {
                    _date = value;
                    NotifyPropertyChanged("Date");
                }
            }
        }

        private int _readState;
        public int ReadState
        {
            get { return _readState; }
            set
            {
                if (_readState != value)
                {
                    _readState = value;
                    NotifyPropertyChanged("ReadState");
                }
            }
        }

        private int _out;
        public int Out
        {
            get { return _out; }
            set
            {
                if (_out != value)
                {
                    _out = value;
                    NotifyPropertyChanged("Out");
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
                    NotifyPropertyChanged("Title");
                }
            }
        }

        private string _body;
        public string Body
        {
            get { return _body; }
            set
            {
                if (_body != value)
                {
                    _body = value;
                    NotifyPropertyChanged("Body");
                }
            }
        }

        private int _chatId;
        public int ChatId
        {
            get { return _chatId; }
            set
            {
                if (_chatId != value)
                {
                    _chatId = value;
                    NotifyPropertyChanged("ChatId");
                }
            }
        }

        private ProfileItem _author;
        public ProfileItem Author
        {
            get { return _author; }
            set
            {
                if (_author != value)
                {
                    _author = value;
                    NotifyPropertyChanged("Author");
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
