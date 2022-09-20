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
using ThyoneMC.Windows;

namespace ThyoneMC.MVVM.View
{
    /// <summary>
    /// Interaction logic for ServersView.xaml
    /// </summary>
    public partial class ServersView : UserControl
    {
        public ServersView()
        {
            InitializeComponent();
        }

        private void ServerCreate_Click(object sender, RoutedEventArgs e)
        {
            ServerAddWindow addPopup = new ServerAddWindow();

            addPopup.Show();

            this.IsEnabled = false;
        }

        private void ServerAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ServerRemove_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
