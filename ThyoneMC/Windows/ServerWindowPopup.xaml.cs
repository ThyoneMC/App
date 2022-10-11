using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ThyoneMC.Core;

namespace ThyoneMC.Windows
{
    /// <summary>
    /// Interaction logic for ServerAddWindow.xaml
    /// </summary>
    public partial class ServerWindowPopup : Window
    {
        public enum ServerPopupMode
        {
            Create = 1,
            Add = 2,
            Remove = 3,
            Leave = 4,
        }
        public ServerPopupMode mode;

        CommandLine hamachi = new CommandLine(false, "C:\\Program Files (x86)\\LogMeIn Hamachi\\x64\\hamachi-2.exe", "--cli");

        public ServerWindowPopup(ServerPopupMode mode)
        {
            InitializeComponent();

            this.mode = mode;

            if (mode == ServerPopupMode.Add)
            {
                ServerAddText.Text = "Join Server";
            }
            else if (mode != ServerPopupMode.Create)
            {
                ServerAddInputPassword.IsEnabled = false;
                ServerAddInputPassword.Text = "";
                ServerAddInputPassword.Background = Brushes.Transparent;

                if (mode == ServerPopupMode.Remove)
                {
                    ServerAddText.Text = "Remove Server";
                }
                else if (mode == ServerPopupMode.Leave)
                {
                    ServerAddText.Text = "Leave Server";
                }
            }
        }

        private void ServerAddConfirm_Click(object sender, RoutedEventArgs e)
        {
            string messageReturn = "";

            if (mode == ServerPopupMode.Create)
            {
                messageReturn = hamachi.Execute("create", ServerAddInputName.Text, ServerAddInputPassword.Text);
            }
            else if (mode == ServerPopupMode.Add)
            {
                messageReturn = hamachi.Execute("join", ServerAddInputName.Text, ServerAddInputPassword.Text);
            }
            else if (mode == ServerPopupMode.Remove)
            {
                messageReturn = hamachi.Execute("delete", ServerAddInputName.Text);
            }
            else if (mode == ServerPopupMode.Leave)
            {
                messageReturn = hamachi.Execute("leave", ServerAddInputName.Text);
            }

            string message = (new MyRegex("(?<=,).*")).toString(messageReturn);

            if (!string.IsNullOrEmpty(message))
            {
                System.Windows.MessageBox.Show(message);
            }
            else
            {
                System.Windows.MessageBox.Show(messageReturn);
            }

            this.Close();
        }

        private void ServerAddCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
