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
        OutputBoundary _iOuput;
        HardDriveGateway _hd;
        ScreenBoundary _iScreen;
        PointDataGateway _iPoint;

        public ITControl_Interactor(    OutputBoundary iOutput, 
                                        PointDataGateway iPoint, 
                                        HardDriveGateway hd,
                                        ScreenBoundary iScreen)
        {
            _iOuput = iOutput;
            _iPoint = iPoint;
            _hd = hd;
            _iScreen = iScreen;

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

        
    }
}
