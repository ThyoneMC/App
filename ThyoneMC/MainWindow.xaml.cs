using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using ThyoneMC.Core;

namespace ThyoneMC
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CommandLine hamachi = new CommandLine(false, "C:\\Program Files (x86)\\LogMeIn Hamachi\\x64\\hamachi-2.exe", "--cli");

        public MainWindow()
        {
            hamachi.Execute("logon");

            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void AppMinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void AppCloseButton_Click(object sender, RoutedEventArgs e)
        {
            hamachi.Execute("logout");

            Application.Current.Shutdown();
        } 
    }
}
