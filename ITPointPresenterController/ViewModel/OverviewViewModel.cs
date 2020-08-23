using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace ITPointPresenterController
{

    
    public delegate void PlayVideo();
    public delegate void PauseVideo();
    public delegate void StopVideo();
    public delegate void ReplayVideo();

    public class VideoCmd
    {
        public PlayVideo PlayVideoCmd;
        public PauseVideo PauseVideoCmd;
        public StopVideo StopVideoCmd;
        public ReplayVideo ReplayVideoCmd;
    }

    public class OverviewViewModel: ViewModelBase
    {

        Visibility _WindowVisibility;
        public Visibility WindowVisibility
        {
            get
            {
                return _WindowVisibility;
            } 
            set
            {
                _WindowVisibility = value;
                RaisePropertyChanged("WindowVisibility");
            }
        }
        ImageSource _Landing;
        public ImageSource Landing {
            get 
            {
                return _Landing;
            } 
            set
            {
                _Landing = value;
                RaisePropertyChanged("Landing");
        
            }
        }

        Uri _Uri;
        public Uri Uri
        {
            get
            {
                return _Uri;
            }
            set
            {
                _Uri = value;
                RaisePropertyChanged("Uri");
            }
        }

        Visibility _MediaVisibility;
        public Visibility MediaVisibility
        {
            get
            {
                return _MediaVisibility;
            }
            set
            {
                _MediaVisibility = value;
                RaisePropertyChanged("MediaVisibility");
            }
        }

        public int _Top;
        public int Top
        {
            get
            {
                return _Top;
            }
            set
            {
                _Top = value;
                RaisePropertyChanged("Top");
            }
        }

        public int _Left;
        public int Left
        {
            get
            {
                return _Left;
            }
            set
            {
                _Left = value;
                RaisePropertyChanged("Left");
            }
        }

        WindowState _WindowState;
        public WindowState WindowState
        {
            get
            {
                return _WindowState;
            }
            set
            {
                _WindowState = value;
                RaisePropertyChanged("WindowState");
            }
        }


        public OverviewViewModel()
        {
            Top = 0;
            Left = 0;
            WindowState = WindowState.Normal;
            WindowVisibility = Visibility.Visible;
            MediaVisibility = Visibility.Collapsed;
            Uri = null;
            Landing = null;
        }

        public OverviewViewModel(VideoCmd videoCmd)
        {
            Top = 0;
            Left = 0;
            WindowState = WindowState.Normal;
            WindowVisibility = Visibility.Collapsed;
            MediaVisibility = Visibility.Collapsed;
            Uri = null;
            Landing = null;
            //
            PlayVideoCommand = videoCmd.PlayVideoCmd;
            PauseVideoCommand = videoCmd.PauseVideoCmd;
            StopVideoCommand = videoCmd.StopVideoCmd;
            ReplayVideoCommand = videoCmd.ReplayVideoCmd;


        }

        private PlayVideo PlayVideoCommand;
        private PauseVideo PauseVideoCommand;
        private StopVideo StopVideoCommand;
        private ReplayVideo ReplayVideoCommand;

        public void PlayVideo()
        {
            PlayVideoCommand();
        }

        public void PauseVideo()
        {
            PauseVideoCommand();
        }
        public void StopVideo()
        {
            StopVideoCommand();
        }
        public void ReplayVideo()
        {
            ReplayVideoCommand();
        }

        OverviewIController _iCtrl;
        public void AttachController(OverviewIController iCtrl)
        {
            _iCtrl = iCtrl;
        }
        


        
    }
}
