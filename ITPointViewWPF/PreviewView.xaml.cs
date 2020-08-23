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
    /// Interaction logic for PreviewView.xaml
    /// </summary>
    public partial class PreviewView : Window
    {
        public PreviewView()
        {
            InitializeComponent();
            this.DataContext = new PreviewViewModel();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Visibility = Visibility.Collapsed;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            {
                this.Visibility = Visibility.Collapsed;
                PreviewViewModel prvm = DataContext as PreviewViewModel;
                prvm.ChooseScreen();

            }
        }
    }
}
