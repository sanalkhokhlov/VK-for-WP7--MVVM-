using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using VkWP.Models;
using System.Collections.Generic;


namespace MvvmLight1.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm/getstarted
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private int _postId;
        private int _sourceId;
        private bool _loading = false;
        private FeedItem _selectedFeed;
        private ProfileItem _userProfile;
        private ObservableCollection<FeedItem> _feedDataSource;
        public ObservableCollection<ProfileItem> _friendsDataSource=new ObservableCollection<ProfileItem>();
        private ICommand _loadDataCommand;
        private string _status;



        /// <summary>
        /// вызов методов загрузки профиля,новостей,друзей. Надо сделать последовательный вызов, чтобы второй не начинался покуда первый не отработает, хз как
        /// </summary>
        private void LoadDataAction()
        {
            LoadFriends();
            LoadMainViewInfo();
            //LoadNotification();
        }

        /// <summary>
        /// загрузка профиля, новостей
        /// </summary>
        private void LoadMainViewInfo()
        {
            if (!App.GlobalVkClient.Active)
            {
                Login();
                return;
            }
            Loading = true;
            App.GlobalVkClient.GetMainViewInfo(
                (response) =>
                {
                    if (response.Response == null) return;
                    UserProfile = response.Response.User[0];
                    Status = response.Response.Status.Text;
                    response.Response.News.Items.ForEach((feed) =>
                    {
                        switch (feed.Type)
                        {
                            case "post":
                                {
                                    if (feed.Text.Length > 100) feed.Text = feed.Text.Substring(0, 100) + "...";
                                    break;
                                }
                            default:
                                {
                                    break;
                                }
                        }
                        feed.PostDate = new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds(Convert.ToDouble(feed.Date)).ToLocalTime();
                        foreach (var profile in response.Response.News.Profiles.Where(profile => profile.Uid == feed.SourceId))
                        {
                            feed.Author.FirstName = profile.FirstName;
                            feed.Author.LastName = profile.LastName;
                            feed.Author.Photo = profile.Photo;
                            feed.Author.Uid = profile.Uid;
                        }
                        foreach (var group in response.Response.News.Groups.Where(group => group.Gid == Math.Abs(feed.SourceId)))
                        {
                            feed.Author.FirstName = group.Name;
                            feed.Author.Photo = group.Photo;
                            feed.Author.Uid = group.Gid;
                        }
                        DataSource.Add(feed);
                    });
                    Loading = false;
                },
                    (error) => Debug.WriteLine(error.Message));
        }

        /// <summary>
        /// загрузка уведомлений, не распарсено
        /// </summary>
        private void LoadNotification()
        {
            if (!App.GlobalVkClient.Active)
            {
                Login();
                return;
            }
            Loading = true;
            App.GlobalVkClient.GetNotifications(
                (response) =>
                {
                    if (response == null) return;
                    var temp = response;
                },
                    error => Debug.WriteLine(error.Message));
        }


        /// <summary>
        /// загрузка друзей
        /// </summary>
        private void LoadFriends()
        {
            if (!App.GlobalVkClient.Active)
            {
                Login();
                return;
            }
            Loading = true;
            App.GlobalVkClient.GetFriends(
                (response) =>
                {
                    if (response == null) return;
                    response.Response.ForEach(user => _friendsDataSource.Add(user));
                    Loading = false;
                    RaisePropertyChanged("FriendsDataSource");//Оповещаем View о том что данные изменены и их нужно перегрузить
                },
                    (error) => Debug.WriteLine(error.Message));
        }

        /// <summary>
        /// перекидывает на авторизацию
        /// </summary>
        private void Login()
        {
            var rootFrame = ((App)Application.Current).RootFrame;
            rootFrame.Navigate(new Uri("/View/SignInView.xaml", UriKind.Relative));
        }

        /// <summary>
        /// свойство отвечает за показ ProgressBar
        /// </summary>
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

        /// <summary>
        /// статус юзера вконтакте
        /// </summary>
        public string Status
        {
            get { return _status; }
            set
            {
                _status = value;
                RaisePropertyChanged("Status");
            }
        }

        /// <summary>
        /// профиль юзера
        /// </summary>
        public ProfileItem UserProfile
        {
            get { return _userProfile; }
            set
            {
                if (this._userProfile != value)
                {
                    this._userProfile = value;
                    this.RaisePropertyChanged("UserProfile");
                }
            }
        }

        /// <summary>
        /// команда, связана с представлением через Binding
        /// </summary>
        public ICommand LoadDataCommand
        {
            get
            {
                return this._loadDataCommand;
            }
        }

        /// <summary>
        /// коллекция новостей, связана с представлением через Binding
        /// </summary>
        public ObservableCollection<FeedItem> DataSource
        {
            get
            {
                if (this._feedDataSource == null)
                {
                    this._feedDataSource = new ObservableCollection<FeedItem>();
                }
                return this._feedDataSource;
            }
        }

        /// <summary>
        /// коллекция друзей, связана с представлением через Binding
        /// </summary>
        public List<FriendGroup<ProfileItem>> FriendsDataSource
        {
            get
            {
                var col = this._friendsDataSource;
                if (col == null) 
                {
                    col = new ObservableCollection<ProfileItem>();//На случай если к свойству обращаются до завершения запроса к API (почти всегда собственно)
                }
                var groupedFriends = from profileitem in col
                                     group profileitem by profileitem.FirstLetter into c
                                     orderby c.Key
                                     select new FriendGroup<ProfileItem>(c.Key, c);//Группируем друзей по первой букве их имени
                return groupedFriends.ToList();
            }
        }

        /// <summary>
        /// эти херни еще не использовал, пригодятся при навигации на новость
        /// </summary>
        public int SelectedPostId
        {
            get
            {
                if (this.SelectedFeed != null)
                {
                    return this.SelectedFeed.PostId;
                }
                return 0;
            }
            set
            {
                this._postId = value;
            }
        }

        public int SelectedSourceId
        {
            get
            {
                if (this.SelectedFeed != null)
                {
                    return this.SelectedFeed.SourceId;
                }
                return 0;
            }
            set
            {
                this._sourceId = value;
            }
        }

        public FeedItem SelectedFeed
        {
            get
            {
                return this._selectedFeed;
            }
            set
            {
                if (this._selectedFeed != value)
                {
                    this._selectedFeed = value;
                    if (this._selectedFeed != null)
                    {
                        this._postId = this._selectedFeed.PostId;
                        this._sourceId = this._selectedFeed.SourceId;
                    }
                    this.RaisePropertyChanged("SelectedPostId");
                    this.RaisePropertyChanged("SelectedSourceId");
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            if (IsInDesignMode)
            {

            }
            else
            {
                //инициализируем команду и назначаем Action
                this._loadDataCommand = new RelayCommand(this.LoadDataAction);
            }
        }

    }
}