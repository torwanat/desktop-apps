using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
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
#pragma warning disable CS0618

namespace Port_Scanner
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        TcpListener server;
        int start;
        int end;
        Thread thread;

        private void btStart_Click(object sender, RoutedEventArgs e)
        {
            if(!int.TryParse(tbRangeStart.Text, out start))
            {
                MessageBox.Show("Invalid start value!", "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if(!int.TryParse(tbRangeEnd.Text, out end) || end > 65535)
            {
                MessageBox.Show("Invalid end value!", "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (start > end)
            {
                MessageBox.Show("Invalid port range!", "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if(btStart.Content.ToString() == "Start")
            {
                lvPorts.Items.Add("Start a new scan...");
                thread = new Thread(ScanPorts);
                thread.Start();
                btStart.Content = "Pause";
                btStop.IsEnabled = true;
            }else if(btStart.Content.ToString() == "Pause")
            {
                thread.Suspend();
                btStop.IsEnabled = false;
                btStart.Content = "Resume";
            }else if(btStart.Content.ToString() == "Resume")
            {
                thread.Resume();
                btStop.IsEnabled = true;
                btStart.Content = "Pause";
            }
        }

        void ScanPorts()
        {
            for (int i = start; i <= end; i++)
            {
                lbCurrentlyScanning.Dispatcher.BeginInvoke(new Action(delegate()
                {
                    lbCurrentlyScanning.Content = i;
                }));
                try
                {
                    server = new TcpListener(IPAddress.Loopback, i);
                    server.Start();
                    server.Stop();
                }
                catch
                {
                    lvPorts.Dispatcher.BeginInvoke(new Action(delegate() 
                    { 
                        lvPorts.Items.Add("Port: " + i + " is busy"); 
                    }));
                }
            }
            lvPorts.Dispatcher.BeginInvoke(new Action(delegate ()
            {
                lvPorts.Items.Add("Scan Completed");
                btStart.Content = "Start";
                btStop.IsEnabled = false;
            }));
        }

        private void btStop_Click(object sender, RoutedEventArgs e)
        {
            if(thread != null && thread.IsAlive)
            {
                thread.Abort();
            }
            btStop.IsEnabled = false;
            btStart.Content = "Start";
            lbCurrentlyScanning.Content = "";
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if(thread != null && thread.IsAlive)
            {
                thread.Abort();
            }

            base.OnClosing(e);
        }
    }

}
