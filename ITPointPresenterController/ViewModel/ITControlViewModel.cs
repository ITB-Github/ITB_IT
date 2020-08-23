using FontAwesome.WPF.Converters;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
//using FontAwesome;


namespace ITPointPresenterController
{
    public class ITControlViewModel: ViewModelBase
    {

        ITControl_IController _iCtrl;
        public void AttachController(ITControl_IController iCtrl)
        {
            _iCtrl = iCtrl;
        }

        ObservableCollection<PowerpointViewModel> _ppts;
        public ObservableCollection<PowerpointViewModel> PPTs
        {
            get
            {
                return _ppts;
            }
            set
            {
                _ppts = value;
                RaisePropertyChanged("PPTs");
            }
        }

        ObservableCollection<MusicViewModel> _Musics;
        public ObservableCollection<MusicViewModel> Musics
        {
            get
            {
                return _Musics;
            }
            set
            {
                _Musics = value;
                RaisePropertyChanged("Musics");
            }
        }


        ObservableCollection<VideoViewModel> _Videos;
        public ObservableCollection<VideoViewModel> Videos
        {
            get
            {
                return _Videos;
            }
            set
            {
                _Videos = value;
                RaisePropertyChanged("Videos");
            }
        }

        public void LoadResources()
        {
            //throw new NotImplementedException();
            _iCtrl.LoadResources();
        }

        public bool _isCOnnected;
        public bool IsConnected
        {
            get
            {
                return _isCOnnected;
            }
            set
            {
                _isCOnnected = value;
                RaisePropertyChanged("IsConnected");
            }
        }


        ImageSource _Image;
        public ImageSource ScreenPreview
        {
            get
            {
                return _Image;
            }
            set
            {
                _Image = value;
                RaisePropertyChanged("ScreenPreview");
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



        PowerpointViewModel pptvmChosen;
        public PowerpointViewModel PPTvmChosen
        {
            get => pptvmChosen;
            set
            {
                pptvmChosen = value;
                RaisePropertyChanged("PowerpointChosen");
            }
        }




        public ITControlViewModel()
        {
            PPTs = new ObservableCollection<PowerpointViewModel>();
            PPTs.Add(new PowerpointViewModel());
            //
            Musics = new ObservableCollection<MusicViewModel>();
            Musics.Add(new MusicViewModel());
            //
            Videos = new ObservableCollection<VideoViewModel>();
            Videos.Add(new VideoViewModel());
            //
            Teams = new ObservableCollection<TeamViewModel>();
            Teams.Add(new TeamViewModel());
            //
            IsConnected = false;
            ScreenPreview = null;


        }


        public void GetScreenPreview()
        {
            if (_iCtrl == null)
                return;
            _iCtrl.GetScreenPreview();
        }

        public void GetConntected()
        {
            if (_iCtrl == null)
                return;
            _iCtrl.GetConnected();
        }

        public void GetTeam()
        {
            if (_iCtrl == null)
                return;
            _iCtrl.GetTeam();
        }

        public void SetScreenFullScreen()
        {
            if (_iCtrl == null)
                return;
            _iCtrl.SetScreenFullScreen();
        }

        public void OpenOverview()
        {
            if (_iCtrl == null)
                return;
            _iCtrl.OpenOverviewWindow();
        }


        public void OpenPowerpoint()
        {
            if (_iCtrl == null)
                return;
            _iCtrl.OpenPowerpointFile(PPTvmChosen);
        }

    }
}
