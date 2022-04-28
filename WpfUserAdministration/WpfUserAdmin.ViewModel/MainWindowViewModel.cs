using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using WpfUserAdmin.Model;

namespace WpfUserAdmin.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        #region Fields

        private User currentUser;
        private UserCollection userList;
        private ListCollectionView userListView;
        private string filteringText;
        private Mediator mediator;

        #endregion

        #region Properties

        public User CurrentUser
        {
            get { return currentUser; }
            set
            {
                if (currentUser == value)
                {
                    return;
                }
                currentUser = value;
                OnPropertyChanged(new PropertyChangedEventArgs("CurrentUser"));
            }
        }

        public UserCollection UserList
        {
            get { return userList; }
            set
            {
                if (userList == value)
                {
                    return;
                }
                userList = value;
                OnPropertyChanged(new PropertyChangedEventArgs("UserList"));
            }
        }

        public ListCollectionView UserListView
        {
            get { return userListView; }
            set
            {
                if (userListView == value)
                {
                    return;
                }
                userListView = value;
                OnPropertyChanged(new PropertyChangedEventArgs("UserListView"));
            }
        }

        public string FilteringText
        {
            get { return filteringText; }
            set
            {
                if (filteringText == value)
                {
                    return;
                }
                filteringText = value;
                OnPropertyChanged(new PropertyChangedEventArgs("FilteringText"));
            }

        }

        #endregion

        #region Constructors and methods
        public MainWindowViewModel(Mediator mediator)
        {

            this.mediator = mediator;

            this.PropertyChanged += MainWindowViewModel_PropertyChanged;

            UserList = UserCollection.GetAllUsers();

            UserListView = new ListCollectionView(UserList);

            UserListView.Filter = UserFilter;

            CurrentUser = new User();

            mediator.Register("UserChange", UserChanged);
        }

        private void UserChanged(object obj)
        {
            User user = (User)obj;

            int index = UserList.IndexOf(user);

            if (index != -1)
            {
                UserList.RemoveAt(index);
                UserList.Insert(index, user);
            }
            else
            {
                UserList.Add(user);
            }
        }

        private void MainWindowViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("FilteringText"))
            {
                UserListView.Refresh();
            }
        }

        private bool UserFilter(object obj)
        {
            if (FilteringText == null) return true;
            if (FilteringText.Equals("")) return true;

            User user = obj as User;
            return user.UserName.ToLower().StartsWith(FilteringText.ToLower());
        }

        void SaveEditedExecute(object obj)
        {
            CurrentUser.UpdateUser();

        }

        bool CanSaveEdited(object obj)
        {

            if (CurrentUser == null) return false;

            return true;
        }

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }
    }
}
