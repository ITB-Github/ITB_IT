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

using ITPointPresenterController;
namespace ITPointViewWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new ITControlViewModel();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if((bool)btnChkPreview.IsChecked)
            {
                ITControlViewModel itvm = DataContext as ITControlViewModel;
                itvm.GetScreenPreview();
                btnChkPreview.IsChecked = false;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ITControlViewModel itvm = DataContext as ITControlViewModel;
            itvm.GetConntected();
            itvm.GetTeam();
            itvm.LoadResources();
        }

        private void btnSetScreen_Click(object sender, RoutedEventArgs e)
        {
            ITControlViewModel itvm = DataContext as ITControlViewModel;
            itvm.SetScreenFullScreen();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void mnuOverview_Click(object sender, RoutedEventArgs e)
        {
            ITControlViewModel itvm = DataContext as ITControlViewModel;
            itvm.OpenOverview();
        }

        private void chkOpenPPT_Checked(object sender, RoutedEventArgs e)
        {
            if(chkOpenPPT.IsChecked == false)
            {
                return;
            }    
            
            if(dgPowerpoint.SelectedItem==null)
            {
                MessageBox.Show("Please choose Powerpoint File To Open");
                return;
            }

            ITControlViewModel itvm = DataContext as ITControlViewModel;
            itvm.OpenPowerpoint();

        }
    }
}
