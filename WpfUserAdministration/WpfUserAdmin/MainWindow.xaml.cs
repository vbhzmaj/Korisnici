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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfUserAdmin.ViewModel;
using WpfUserAdmin.Model;

namespace WpfUserAdmin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(User user)
        {
            InitializeComponent();
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel(Mediator.Instance);
            this.DataContext = mainWindowViewModel;
            mainWindowViewModel.CurrentUser = user;
        }

        private void BttnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddEditWindow newAddWindow = new AddEditWindow();
            newAddWindow.DataContext = new AddEditWindowViewModel(Mediator.Instance);
            newAddWindow.ShowDialog();
        }

        private void BttnEdit_Click(object sender, RoutedEventArgs e)
        {
            MainWindowViewModel viewModel = (MainWindowViewModel)DataContext;
            AddEditWindow newEditWindow = new AddEditWindow();
            newEditWindow.DataContext = new AddEditWindowViewModel(viewModel.CurrentUser.Clone(), Mediator.Instance );
            newEditWindow.ShowDialog();


        }
    }
}
