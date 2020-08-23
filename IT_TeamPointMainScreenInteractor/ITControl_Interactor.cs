using ITPointBufferEnitites;
using ITPointEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;


namespace IT_TeamPointMainScreenInteractor
{
    internal class ITControl_Interactor : InputBoundary
    {
        FileOpenerAPI _fileAPI;
        OutputBoundary _iOuput;
        HardDriveGateway _hd;
        ScreenBoundary _iScreen;
        PointDataGateway _iPoint;

        public ITControl_Interactor(    OutputBoundary iOutput, 
                                        PointDataGateway iPoint, 
                                        HardDriveGateway hd,
                                        ScreenBoundary iScreen,
                                        FileOpenerAPI fileAPI)
        {
            _iOuput = iOutput;
            _iPoint = iPoint;
            _hd = hd;
            _iScreen = iScreen;
            _fileAPI = fileAPI;

        }
        /// <summary>
        /// Property - Dai Dien
        /// </summary>
        /// 

       
        Screen _ScreenPreview
        {
            set
            {
                sendScreenOut(produceScreenOutData(value));
            }
        }

        bool _IsConnected
        {
            set
            {
                sendConnectionOut(produceConnectionOut(value));
            }
        }

        List<Team> _teams;
        List<Team> _Teams
        {
            get
            {
                return _teams;
            }
            set
            {
                _teams = value;
                sendTeamOut(produceTeanOut(_teams));
            }
        }

        List<Screen> _screens;

        List<Screen> _Screens
        {
            get
            {
                return _screens;
            }
            set
            {
                _screens = value;
                sendScreensOut(produceScreensOut(_screens));
            }
        }

        Screen _screenChosen;
        Screen _ScreenChosen
        {
            get
            {
                return _screenChosen;
            }
            set
            {
                _screenChosen = value;
            }
        }

        List<Powerpoint> _Powerpoints;
        public List<Powerpoint> Powerpoints
        {
            get
            {
                return _Powerpoints;
            }
            set
            {
                _Powerpoints = value;
                sendPPTlist(producePowerpointOut(_Powerpoints));
            }
        }


        List<Music> _Musics;
        public List<Music> Musics
        {
            get
            {
                return _Musics;
            }
            set
            {
                _Musics = value;
                //
                sendMusicOuts(produceMusicOutList(_Musics));


            }
        }

        List<Video> _Videos;
        public List<Video> Videos
        {
            get
            {
                return _Videos;
            }
            set
            {
                _Videos = value;
                sendVideoOutList(produceVideoOutList(_Videos));
            }
        }





        /// <summary>
        /// 
        /// </summary>

        public void RequestConnectionState()
        {
            //throw new NotImplementedException();
            _IsConnected = _iPoint.IsConnected();
        }

        public void RequestScreenPreview()
        {
            //throw new NotImplementedException();
            _ScreenPreview = produceScreenPreviewFromJson(_iScreen.GetScreenPreview());
        }

        public void RequestTeam()
        {
            //throw new NotImplementedException()
            _Teams = produceTeamFromJson(_iPoint.GetTeamsInJson());
        }

        public void RequestScreens()
        {
            //throw new NotImplementedException();
            _Screens = produceScreensListFromJson(_iScreen.GetScreenInfo());
        }


        public void ChooseScreen(int id)
        {
            _screenChosen = _Screens.FirstOrDefault(x => x.Id == id);
        }

        public void RequestOpenOverviewWindow()
        {
            _iOuput.OpenOverviewWindow();
            //throw new NotImplementedException();
        }

        public void RequestResources()
        {
            Powerpoints = producePowerpointListFromJson(_hd.LoadPowerpointFiles());
            Musics = produceMusicListFromJson(_hd.LoadMusicFiles());
            Videos = produceVideoListFromJson(_hd.LoadVideoFiles());
            //throw new NotImplementedException();
        }


        /// <summary>
        /// Ham Private
        /// </summary>
        /// 

        Screen produceScreenPreviewFromJson(string json)
        {
            return Converter.DeserializeJson<Screen>(json);
        }

        ScreenOutData produceScreenOutData(Screen screen)
        {
            return new ScreenOutData()
            {
                Id = screen.Id,
                ScreenShot = Converter.FromBase64ToBytes(screen.ScreenShot)
            };
        }
        void sendScreenOut(ScreenOutData screenOut)
        {
            _iOuput.ReceiveScreenPreview(screenOut);
        }

        //
        ConnectionOutData produceConnectionOut(bool isConnected)
        {
            return new ConnectionOutData() { IsConnected = isConnected };
        }
        void sendConnectionOut(ConnectionOutData conn)
        {
            _iOuput.ReceiveConnectionState(conn);
        }
        //
        List<Team> produceTeamFromJson(string json)
        {
            return Utils.Converter.DeserializeJsonToList<Team>(json);
        }

        List<TeamOutData> produceTeanOut(List<Team> teams)
        {
            List<TeamOutData> list = new List<TeamOutData>();
            foreach(var team in teams)
            {
                list.Add(new TeamOutData()
                {
                    Id = team.Id,
                    TeamName = team.TeamName,
                    Point = team.Point
                });
            }
            return list;
        }

        void sendTeamOut(List<TeamOutData> list)
        {
            _iOuput.ReceiveTeamOut(list);
        }
        //

        List<Screen> produceScreensListFromJson(string json)
        {
            return Utils.Converter.DeserializeJsonToList<Screen>(json);
        }

        //
        List<ScreenOutData> produceScreensOut(List<Screen> screens)
        {
            List<ScreenOutData> screenOuts = new List<ScreenOutData>();
            foreach(var screen in screens)
            {
                screenOuts.Add(new ScreenOutData() { 
                    Id = screen.Id,
                    ScreenShot = Utils.Converter.FromBase64ToBytes(screen.ScreenShot)
                });
            }
            return screenOuts;
        }

        void sendScreensOut(List<ScreenOutData>  screenOuts)
        {
            _iOuput.ReceiveScreens(screenOuts);
        }
        //

        List<Powerpoint> producePowerpointListFromJson(string json)
        {
            return Utils.Converter.DeserializeJson<List<Powerpoint>>(json);
        }

        List<PowerpointOutData> producePowerpointOut(List<Powerpoint> list)
        {
            List<PowerpointOutData> listPPT = new List<PowerpointOutData>();
            foreach(var ppt in list)
            {
                listPPT.Add(new PowerpointOutData() { 
                    Id = ppt.Id,
                    FileName = ppt.FileName,
                    Path = ppt.Path
                });
            }
            return listPPT;
        }

        void sendPPTlist(List<PowerpointOutData> list)
        {
            _iOuput.ReceivePowerpoints(list);
        }


        //

        List<Music> produceMusicListFromJson(string json)
        {
            return Utils.Converter.DeserializeJsonToList<Music>(json);
        }

        List<MusicOutData> produceMusicOutList(List<Music> list)
        {
            List<MusicOutData> musicOuts = new List<MusicOutData>();
            list.ForEach(x => musicOuts.Add(new MusicOutData()
            {
                Id = x.Id,
                FileName = x.FileName,
                Path = x.Path
            }));
            return musicOuts;
        }
        void sendMusicOuts(List<MusicOutData> list)
        {
            _iOuput.ReceiveMusics(list);
        }
        //

        List<Video> produceVideoListFromJson(string json)
        {
            return Utils.Converter.DeserializeJsonToList<Video>(json);
        }

        List<VideoOutData> produceVideoOutList(List<Video> videos)
        {
            List<VideoOutData> list = new List<VideoOutData>();
            videos.ForEach(x => list.Add(new VideoOutData()
            {
                Id = x.Id,
                FileName = x.FileName,
                Path = x.Path
            }));
            return list;
        }
        void sendVideoOutList(List<VideoOutData> list)
        {
            _iOuput.ReceiveVideos(list);
        }

        public void RequestOpenPowerpoint(PowerpointInData ppt)
        {
            _fileAPI.OpenFile(ppt.Path);
            //throw new NotImplementedException();
        }
    }
}
