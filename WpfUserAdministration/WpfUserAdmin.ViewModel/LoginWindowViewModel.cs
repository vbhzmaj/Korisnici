using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfUserAdmin.Model;

namespace WpfUserAdmin.ViewModel
{
    public class LoginWindowViewModel : INotifyPropertyChanged

    {
        private User currentUser;
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
        public LoginWindowViewModel()
        {

        }
        public bool CheckLog(string username, string pass)
        {
            CurrentUser = WpfUserAdmin.Model.User.FindLogUser(username, pass);
            if (CurrentUser == null)
            {
                return false;
            }

            else
            {
                return true;
            }


        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }
    }
}
