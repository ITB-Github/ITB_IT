using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_TeamPointMainScreenInteractor
{
    public interface InputBoundary
    {
        void RequestConnectionState();
        void RequestScreenPreview();
        void RequestTeam();
        void RequestScreens();
        void ChooseScreen(int id);
        void RequestOpenOverviewWindow();
        void RequestResources();
        void RequestOpenPowerpoint(PowerpointInData ppt);
    }
}
