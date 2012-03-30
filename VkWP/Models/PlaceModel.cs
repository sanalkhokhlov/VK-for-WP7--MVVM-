using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace VkWP.Models
{
    public class PlaceItemList
    {
        public List<PlaceItem> Response { get; set; }
    }

    public class PlaceItem : INotifyPropertyChanged
    {
        private string _pid;
        private double _latitude;
        private double _longitude;
        private string _title;
        private string _address;
        private int _type;
        private string _icon;
        private string _created;
        private string _updated;
        private int _checkins;
        private int _country;
        private int _city;

        public string Pid
        {
            get { return _pid; }
            set
            {
                if (this._pid != value)
                {
                    this._pid = value;
                    this.RaisePropertyChanged("Pid");
                }
            }
        }

        public double Latitude
        {
            get { return _latitude; }
            set
            {
                if (this._latitude != value)
                {
                    this._latitude = value;
                    this.RaisePropertyChanged("Latitude");
                }
            }
        }

        public double Longitude
        {
            get { return _longitude; }
            set
            {
                if (this._longitude != value)
                {
                    this._longitude = value;
                    this.RaisePropertyChanged("Longitude");
                }
            }
        }

        public string Title
        {
            get { return _title; }
            set
            {
                if (this._title != value)
                {
                    this._title = value;
                    this.RaisePropertyChanged("Title");
                }
            }
        }

        public string Address
        {
            get { return _address; }
            set
            {
                if (this._address != value)
                {
                    this._address = value;
                    this.RaisePropertyChanged("Address");
                }
            }
        }

        public int Type
        {
            get { return _type; }
            set
            {
                if (this._type != value)
                {
                    this._type = value;
                    this.RaisePropertyChanged("Type");
                }
            }
        }

        public string Icon
        {
            get { return _icon; }
            set
            {
                if (this._icon != value)
                {
                    this._icon = value;
                    this.RaisePropertyChanged("Icon");
                }
            }
        }

        public string Created
        {
            get { return _created; }
            set
            {
                if (this._created != value)
                {
                    this._created = value;
                    this.RaisePropertyChanged("Created");
                }
            }
        }

        public string Updated
        {
            get { return _updated; }
            set
            {
                if (this._updated != value)
                {
                    this._updated = value;
                    this.RaisePropertyChanged("Updated");
                }
            }
        }

        public int Checkins
        {
            get { return _checkins; }
            set
            {
                if (this._checkins != value)
                {
                    this._checkins = value;
                    this.RaisePropertyChanged("Checkins");
                }
            }
        }

        public int Country
        {
            get { return _country; }
            set
            {
                if (this._country != value)
                {
                    this._country = value;
                    this.RaisePropertyChanged("Country");
                }
            }
        }

        public int City
        {
            get { return _city; }
            set
            {
                if (this._city != value)
                {
                    this._city = value;
                    this.RaisePropertyChanged("City");
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
