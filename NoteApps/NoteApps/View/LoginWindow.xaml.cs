using NoteApps.ViewModel;
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

namespace NoteApps.View
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow 
    {
        //đã check hết
        public LoginWindow()
        {
            InitializeComponent();
            LoginVM vm = new LoginVM();
            containerGrid.DataContext = vm;
            vm.HasLogIn += Vm_HasLogIn;
        }

        private void Vm_HasLogIn(object sender, EventArgs e)
        {
            this.Close();
        }

        private void haveAccountButton_Click(object sender, RoutedEventArgs e)
        {
            RegisterStackPannel.Visibility = Visibility.Collapsed;
            loginStackPannel.Visibility = Visibility.Visible;
        }

        private void noAccountButton_Click(object sender, RoutedEventArgs e)
        {
            RegisterStackPannel.Visibility = Visibility.Visible;
            loginStackPannel.Visibility = Visibility.Collapsed;
        }
    }
}
