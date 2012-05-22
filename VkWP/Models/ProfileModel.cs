using System.Collections.Generic;
using System.ComponentModel;
using System;
using System.Net;
using VkWP.Helpers;

namespace VkWP.Models
{
    public class ProfileItemList
    {
        public List<ProfileItem> Response { get; set; }
    }
    /// <summary>
    /// Класс для создания групп
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class FriendGroup<T> : IEnumerable<T>
    {
        public FriendGroup(string name, IEnumerable<T> items)
        {
            this.Title = name;
            this.Items = new List<T>(items);
        }

        public override bool Equals(object obj)
        {
            FriendGroup<T> that = obj as FriendGroup<T>;

            return (that != null) && (this.Title.Equals(that.Title));
        }

        public string Title
        {
            get;
            set;
        }

        public IList<T> Items
        {
            get;
            set;
        }

        #region IEnumerable<T> Members

        public IEnumerator<T> GetEnumerator()
        {
            return this.Items.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.Items.GetEnumerator();
        }

        #endregion
    }

    public class ProfileItem : INotifyPropertyChanged
    {
        private int _uid;
        private string _lastName;
        private string _firstName;
        private string _photo;
        private string _photoMedium;
        private bool _online;
        /// <summary>
        /// Key for user's online status
        /// </summary>
        private const int ONLINE = 1;

        public int Uid
        {
            get { return _uid; }
            set
            {
                if (_uid != value)
                {
                    _uid = value;
                    RaisePropertyChanged("Uid");
                }
            }
        }
        /// <summary>
        /// Sets user's online status
        /// </summary>
        public int Online
        {
            set { _online = (value == ONLINE); }
        }
        /// <summary>
        /// Gets text representation of user's online status
        /// </summary>
        public string OnlineStatus
        {
            get { return _online ? "В сети" : string.Empty; }
        }

        public string LastName
        {
            get { return TextPreprocessor.Decode(_lastName); }
            set
            {
                if (_lastName != value)
                {
                    _lastName = value;
                    RaisePropertyChanged("LastName");
                }
            }
        }
        /// <summary>
        /// Gets first letter of FirstName
        /// </summary>
        public string FirstLetter
        {
            get
            {
                string result = string.Empty;
                if (_firstName != result)
                {
                    result = _firstName[0].ToString();
                }
                return TextPreprocessor.Decode(result);
            }
        }

        public string FirstName
        {
            get { return TextPreprocessor.Decode(_firstName); }
            set
            {
                if (_firstName != value)
                {
                    _firstName = value;
                    RaisePropertyChanged("FirstName");
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
                    if (value.IndexOf(".gif") == -1)
                    {
                        _photo = value;

                    }
                    else
                    {
                        _photo = "Images/nophoto.jpg";//Вставляем заглушку при отсутсвии фотографии, т.к. BitmapImage  не поддерживает gif
                    }
                    RaisePropertyChanged("Photo");
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
                    if (value.IndexOf(".gif") == -1)
                    {
                        _photoMedium = value;

                    }
                    else
                    {
                        _photoMedium = "Images/nophoto.jpg";//Вставляем заглушку при отсутсвии фотографии, т.к. BitmapImage  не поддерживает gif
                    }
                    RaisePropertyChanged("PhotoMedium");
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

    public class StatusResponse
    {
        public string Text { get; set; }
        public StatusResponse Response { get; set; }
    }
}

