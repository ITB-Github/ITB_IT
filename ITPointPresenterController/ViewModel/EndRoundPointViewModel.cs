using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace ITPointPresenterController
{
    public class EndRoundPointViewModel:ViewModelBase
    {
        EndRoundPointIController _iCtrl;
        public void AttachController(EndRoundPointIController iCtrl)
        {
            _iCtrl = iCtrl;
        }

        ImageSource _Landing;
        public ImageSource Landing
        {
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

        private int _Top;
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

        private int _Left;
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

        Visibility _Visibility;
        public Visibility Visibility
        {
            get
            {
                return _Visibility;
            }
            set
            {
                _Visibility = value;
                RaisePropertyChanged("Visibility");
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

        ObservableCollection<TeamViewModel> _Teams;
        public ObservableCollection<TeamViewModel> Teams
        {
            get
            {
                return _Teams;
            }
            set
            {
                _Teams = value;
                RaisePropertyChanged("Teams");
            }
        }
        
        public int NumberOfItemInRow
        {
            get
            {
                if (Teams == null || Teams.Count < 1)
                    return 0;
                return Teams.Count;
            }
            set
            {

            }
        }




        public EndRoundPointViewModel()
        {
            Top = 0;
            Left = 0;
            Visibility = Visibility.Collapsed;
            WindowState = WindowState.Normal;
        }

    }
}
