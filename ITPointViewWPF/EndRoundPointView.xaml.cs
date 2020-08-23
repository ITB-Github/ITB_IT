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
using ITPointPresenterController;

namespace ITPointViewWPF
{
    /// <summary>
    /// Interaction logic for EndRoundPointView.xaml
    /// </summary>
    public partial class EndRoundPointView : Window
    {
        public EndRoundPointView()
        {
            InitializeComponent();
            DataContext = new EndRoundPointViewModel();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Visibility = Visibility.Collapsed;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.MouseDown += EndRoundPointView_MouseDown;
            this.MouseDoubleClick += EndRoundPointView_MouseDoubleClick;
        }

        private void EndRoundPointView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (WindowState == WindowState.Normal)
                this.WindowState = WindowState.Maximized;
            else
                this.WindowState = WindowState.Normal;
            //throw new NotImplementedException();
        }

        private void EndRoundPointView_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ChangedButton == MouseButton.Left)
            {
                DragMove();
                return;
            }    
            //throw new NotImplementedException();

            if(e.ChangedButton == MouseButton.Right)
            {
                ContextMenu cm = this.FindResource("mnuContext") as ContextMenu;
                cm.IsOpen = true;
                return;
            }    
        }

        private void mnuClose_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lsv.SelectedIndex = -1;
        }
    }
}
