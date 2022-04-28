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
    /// Interaction logic for AddEditWindow.xaml
    /// </summary>
    public partial class AddEditWindow : Window
    {
        public AddEditWindow()
        {
            InitializeComponent();
        }
        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            AddEditWindowViewModel viewModel = (AddEditWindowViewModel)DataContext;
            viewModel.Saved += ViewModel_Saved;
        }

        private void ViewModel_Saved(object sender, AddEditWindowViewModel.SavedEventArgs e)
        {
            MessageBox.Show(e.Message);
        }

        private void BttnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
