using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfUserAdmin.Model;

namespace WpfUserAdmin.ViewModel
{
    public class AddEditWindowViewModel : INotifyPropertyChanged
    {
        #region fields

        private User currentUser;
        private string windowTitle;
        private ICommand saveCommand;
        private Mediator mediator;

        #endregion

        #region properties

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

        public string WindowTitle
        {
            get { return windowTitle; }
            set
            {
                if (windowTitle == value)
                {
                    return;
                }
                windowTitle = value;
                OnPropertyChanged(new PropertyChangedEventArgs("WindowTitle"));
            }
        }

        public ICommand SaveCommand
        {
            get { return saveCommand; }
            set
            {
                if (saveCommand == value)
                {
                    return;
                }
                saveCommand = value;
                OnPropertyChanged(new PropertyChangedEventArgs("SaveCommand"));
            }
        }

        #endregion

        #region constructors and methods
        public AddEditWindowViewModel(User user, Mediator mediator)
        {
            this.mediator = mediator;

            SaveCommand = new RelayCommand(SaveExecute, CanSave);

            CurrentUser = user;
            WindowTitle = "Editing user";

        }

        public AddEditWindowViewModel(Mediator mediator)
        {
            this.mediator = mediator;

            SaveCommand = new RelayCommand(SaveExecute, CanSave);

            CurrentUser = new User();
            WindowTitle = "Adding new user";

        }

        void SaveExecute(object obj)
        {

            if (CurrentUser != null && !CurrentUser.HasErrors)
             {
                int result = CurrentUser.Save();
                if (result == 0) { OnSave(new SavedEventArgs("User not saved. Try to modify your input.")); }
                if (result == 1) { OnSave(new SavedEventArgs("New user saved. (If input conversion fails, IsAdmin is false by default.)")); }
                if (result == 2) { OnSave(new SavedEventArgs("User data saved. (If input conversion fails, IsAdmin value is not updated.")); }
                
                if (result > 0) { mediator.Notify("UserChange", CurrentUser); }
                
            }
            else
            {
                OnSave(new SavedEventArgs("Check your input."));
            }
        }

        bool CanSave(object obj)
        {
            return true;
        }

        #endregion

        #region events

        public delegate void SavedEventHandler(object sender, SavedEventArgs e);

        public class SavedEventArgs : EventArgs
        {
            private string message;

            public string Message
            {
                get { return message; }
                set
                {
                    if (message == value)
                    {
                        return;
                    }
                    message = value;
                }
            }

            public SavedEventArgs(string message)
            {
                this.message = message;
            }
        }


        public event SavedEventHandler Saved;

        public void OnSave(SavedEventArgs e)
        {
            if (Saved != null)
            {
                Saved(this, e);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }

        #endregion
    }
}
