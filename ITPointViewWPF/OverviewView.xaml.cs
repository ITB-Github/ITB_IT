using ITPointPresenterController;
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

namespace ITPointViewWPF
{
    /// <summary>
    /// Interaction logic for OverviewView.xaml
    /// </summary>
    public partial class OverviewView : Window
    {
        public OverviewView()
        {
            InitializeComponent();

            //VideoCmd videoCmd = new VideoCmd();
            //videoCmd.PlayVideoCmd = this.PlayVideo;
            //videoCmd.PauseVideoCmd = this.PauseVideo;
            //videoCmd.StopVideoCmd = this.StopVideo;
            //videoCmd.ReplayVideoCmd = this.ReplayVideo;

           this.DataContext = new OverviewViewModel();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.MouseDown += OverviewView_MouseDown;
            this.MouseDoubleClick += OverviewView_MouseDoubleClick;
        }

        private void OverviewView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
                this.WindowState = WindowState.Maximized;
            else
                this.WindowState = WindowState.Normal;
            //throw new NotImplementedException();
        }

        void PlayVideo()
        {
            try
            {
                video.Play();
            }
            catch
            {

            }

        }
        void PauseVideo()
        {
            try
            {
                video.Pause();
            }
            catch
            {

            }
        }

        void ReplayVideo()
        {
            try
            {
                video.Stop();
                video.Play();
            }
            catch
            {

            }
        }

        void StopVideo()
        {
            try
            {
                video.Stop();
                //video.Play();
            }
            catch
            {

            }
        }

        private void OverviewView_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ChangedButton == MouseButton.Left)
            {
                DragMove();
                return;
            }
            if (e.ChangedButton == MouseButton.Right)
            {
                ctxMenu.IsOpen = true;
                return;
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Visibility = Visibility.Collapsed;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }
    }
}
