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

namespace ThyoneMC.Windows
{
    /// <summary>
    /// Interaction logic for ServerAddWindow.xaml
    /// </summary>
    public partial class ServerAddWindow : Window
    {
        public ServerAddWindow()
        {
            InitializeComponent();
        }

        private void ServerConfirm_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(ServerInputName.Text);
            Console.WriteLine(ServerInputPassword.Text);

            this.Close();
        }

        private void ServerCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
