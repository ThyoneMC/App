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
            ServerWindowPopup serverPopup = new ServerWindowPopup(ServerWindowPopup.ServerPopupMode.Create);

            serverPopup.Show();
        }

        private void ServerAdd_Click(object sender, RoutedEventArgs e)
        {
            ServerWindowPopup serverPopup = new ServerWindowPopup(ServerWindowPopup.ServerPopupMode.Add);

            serverPopup.Show();
        }

        private void ServerRemove_Click(object sender, RoutedEventArgs e)
        {
            ServerWindowPopup serverPopup = new ServerWindowPopup(ServerWindowPopup.ServerPopupMode.Remove);

            serverPopup.Show();
        }

        private void ServerLeave_Click(object sender, RoutedEventArgs e)
        {
            ServerWindowPopup serverPopup = new ServerWindowPopup(ServerWindowPopup.ServerPopupMode.Leave);

            serverPopup.Show();
        }
    }
}
