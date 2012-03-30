using System;
using System.Collections.Generic;
using System.ComponentModel;
using VkWP.Helpers;

namespace VkWP.Models
{
    public class FeedItemList
    {
        public List<FeedItem> Items { get; set; }
        public List<ProfileItem> Profiles { get; set; }
        public List<GroupItem> Groups { get; set; }
        public FeedItemList Response { get; set; }
    }

    public class FeedItem : INotifyPropertyChanged
    {
        private string _type;
        private int _sourceId;
        private int _postId;
        private string _text;
        private int _date;
        private DateTime _postDate;
        private ProfileItem _author;
        private List<AttachmentItem> _attachments;

        public string Type
        {
            get
            {
                return _type;
            }
            set
            {
                if (this._type != value)
                {
                    this._type = value;
                    this.RaisePropertyChanged("Type");
                }
            }
        }

        public int SourceId
        {
            get
            {
                return _sourceId;
            }
            set
            {
                if (this._sourceId != value)
                {
                    this._sourceId = value;
                    this.RaisePropertyChanged("SourceId");
                }
            }
        }

        public int PostId
        {
            get
            {
                return _postId;
            }
            set
            {
                if (this._postId != value)
                {
                    this._postId = value;
                    this.RaisePropertyChanged("PostId");
                }
            }
        }

        public string Text
        {
            get
            {
                return HtmlDecoder.Decode(_text);
            }
            set
            {
                if (this._text != value)
                {
                    this._text = value;
                    this.RaisePropertyChanged("Text");
                }
            }
        }

        public ProfileItem Author
        {
            get
            {
                if (this._author == null)
                {
                    this._author = new ProfileItem();
                }
                return _author;
            }
            set
            {
                if (_author != value)
                {
                    _author = value;
                    RaisePropertyChanged("Author");
                }
            }
        }

        public int Date
        {
            get { return _date; }
            set
            {
                if (_date != value)
                {
                    _date = value;
                    RaisePropertyChanged("Date");
                }
            }
        }

        public DateTime PostDate
        {
            get { return _postDate; }
            set
            {
                if (_postDate != value)
                {
                    _postDate = value;
                    RaisePropertyChanged("PostDate");
                }
            }
        }

        public List<AttachmentItem> Attachments
        {
            get { return _attachments; }
            set
            {
                if (_attachments != value)
                {
                    _attachments = value;
                    RaisePropertyChanged("Attachments");
                }
            }
        }

        #region INPC
        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
