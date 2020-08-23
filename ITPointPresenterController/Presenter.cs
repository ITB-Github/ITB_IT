using IT_TeamPointMainScreenInteractor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITPointPresenterController
{
    internal class Presenter : OutputBoundary
    {
        ITControlViewModel _itvm;
        PreviewViewModel _prvm;
        OverviewViewModel _ovm;
        public Presenter(ITControlViewModel itvm, PreviewViewModel prvm, OverviewViewModel ovm)
        {
            _itvm = itvm;
            _prvm = prvm;
            _ovm = ovm;
        }

        
        public void OpenOverviewWindow()
        {
            //HideAllWindow();
            _ovm.WindowVisibility = System.Windows.Visibility.Visible;
            //throw new NotImplementedException();
        }

        public void ReceiveConnectionState(ConnectionOutData conn)
        {
            //
            _itvm.IsConnected = conn.IsConnected;
            //throw new NotImplementedException();
        }

        public void ReceiveMusics(List<MusicOutData> musicOuts)
        {
            _itvm.Musics = new System.Collections.ObjectModel.ObservableCollection<MusicViewModel>();
            musicOuts.ForEach(x => _itvm.Musics.Add(new MusicViewModel()
            {
                Id = x.Id,
                FileName = x.FileName,
                Path = x.Path
            }));
            //throw new NotImplementedException();
        }

        public void ReceivePowerpoints(List<PowerpointOutData> pptOuts)
        {
            //throw new NotImplementedException();
            _itvm.PPTs = new System.Collections.ObjectModel.ObservableCollection<PowerpointViewModel>();
            pptOuts.ForEach(x => _itvm.PPTs.Add(new PowerpointViewModel()
            {
                Id = x.Id,
                FileName = x.FileName,
                Path = x.Path
            }));
        }

        public void ReceiveScreenPreview(ScreenOutData screenOut)
        {
            //

            _itvm.ScreenPreview = Converter.ByteToImage(screenOut.ScreenShot);
            //throw new NotImplementedException();
        }

        public void ReceiveScreens(List<ScreenOutData> screenOuts)
        {
            //throw new NotImplementedException();


            _prvm.Screens = new System.Collections.ObjectModel.ObservableCollection<ScreenViewModel>();
            foreach (var screen in screenOuts)
            {
                ScreenViewModel scrvm = new ScreenViewModel(
                    screen.Id,
                    Converter.ByteToImage(screen.ScreenShot));

                _prvm.Screens.Add(scrvm);
            }

            _prvm.Visible = System.Windows.Visibility.Visible;
        }

        public void ReceiveTeamOut(List<TeamOutData> teams)
        {
            //throw new NotImplementedException();
            _itvm.Teams = new System.Collections.ObjectModel.ObservableCollection<TeamViewModel>();
            foreach(var team in teams)
            {
                _itvm.Teams.Add(new TeamViewModel() {
                    Id = team.Id,
                    TeamName = team.TeamName,
                    Point = team.Point,
                    PointSet = team.Point
                    });
            }
        }

        public void ReceiveVideos(List<VideoOutData> videoOuts)
        {
            _itvm.Videos = new System.Collections.ObjectModel.ObservableCollection<VideoViewModel>();
            videoOuts.ForEach(x => _itvm.Videos.Add(new VideoViewModel()
            {
                Id = x.Id,
                FileName = x.FileName,
                Path = x.Path
            }));
            //throw new NotImplementedException();
        }

        void HideAllWindow()
        {
            _ovm.WindowVisibility = System.Windows.Visibility.Collapsed;
        }
    }
}
