using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_TeamPointMainScreenInteractor
{
    public interface OutputBoundary
    {
        void ReceiveScreenPreview(ScreenOutData screenOut);
        void ReceiveConnectionState(ConnectionOutData conn);
        void ReceiveTeamOut(List<TeamOutData> teams);
        void ReceiveScreens(List<ScreenOutData> screenOuts);
        void ReceivePowerpoints(List<PowerpointOutData> pptOuts);
        void ReceiveMusics(List<MusicOutData> musicOuts);
        void ReceiveVideos(List<VideoOutData> videoOuts);
        void OpenOverviewWindow();
        void OpenEndRoundWindow();
        void ReceiveLauncher(LauncherOutData launcher);
    }
}
