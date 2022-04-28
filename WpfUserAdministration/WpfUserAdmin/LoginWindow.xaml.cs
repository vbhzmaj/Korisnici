using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfUserAdmin.ViewModel;

namespace WpfUserAdmin
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }
        
        private void BttnLogin_Click(object sender, RoutedEventArgs e)
        {
            LoginWindowViewModel viewModelLog = (LoginWindowViewModel)DataContext;
            
            Boolean checkInput;

            checkInput = viewModelLog.CheckLog(TextBoxAddUsername.Text.ToString(),
                                  Typepass.Password.ToString());

            if (checkInput)
            {
                MainWindow newMainWindow = new MainWindow(viewModelLog.CurrentUser);
                newMainWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Login failed. Please try again.");
            }
        }

        private void BttnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
