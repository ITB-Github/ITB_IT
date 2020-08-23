using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITPointPresenterController
{
    public interface ITControl_IController
    {
        void RefreshConnection();
        void GetScreenPreview();
        void SetScreenFullScreen();
        void OpenInfomationDialog();
        void GetConnected();
        void OpenPowerpointFile(PowerpointViewModel pptvm);
        void GetTeam();
        void OpenOverviewWindow();
        void LoadResources();
        
    }
}
