using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ITPointPresenterController;

namespace ITPointViewWPF
{
    public class ViewMain
    {
        MainWindow _MainWindow;
        PreviewView _PreviewView;
        OverviewView _OverviewView;
        EndRoundPointView _EndRoundPointView;
        public ViewMain()
        {
            _MainWindow = new MainWindow();
            _PreviewView = new PreviewView();
            _OverviewView = new OverviewView();
            _EndRoundPointView = new EndRoundPointView();
        }

        public OverviewViewModel GetOverviewViewModel()
        {
            return _OverviewView.DataContext as OverviewViewModel;
        }

        public PreviewViewModel GetPreviewViewModel()
        {
            return _PreviewView.DataContext as PreviewViewModel;
        }

        public ITControlViewModel GetITControlViewModel()
        {
            return _MainWindow.DataContext as ITControlViewModel;
        }

        public EndRoundPointViewModel GetRoundPointViewModel()
        {
            return _EndRoundPointView.DataContext as EndRoundPointViewModel;
        }

        public Window GetMainWindow()
        {
            return _MainWindow as Window;
        }

    }
}
