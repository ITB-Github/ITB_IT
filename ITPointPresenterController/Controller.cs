using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IT_TeamPointMainScreenInteractor;

namespace ITPointPresenterController
{
    internal class Controller : ITControl_IController, PreviewIController, OverviewIController
    {
        private InputBoundary _iInput;
        public void AttachInput(InputBoundary iInput)
        {
            _iInput = iInput;
        }

        public void ChooseScreen(int Id)
        {

            _iInput.ChooseScreen(Id);
            throw new NotImplementedException();
        }

        public void GetConnected()
        {
            //throw new NotImplementedException();
            _iInput.RequestConnectionState();
        }

        public void GetScreenPreview()
        {
            //throw new NotImplementedException();
            _iInput.RequestScreenPreview();
        }

        public void GetTeam()
        {
            _iInput.RequestTeam();
            //throw new NotImplementedException();
        }

        public void OpenInfomationDialog()
        {
            throw new NotImplementedException();
        }

        public void OpenOverviewWindow()
        {
            
            //throw new NotImplementedException();
            _iInput.RequestOpenOverviewWindow();
        }

        public void OpenPowerpointFile(int id)
        {
            throw new NotImplementedException();
        }

        public void RefreshConnection()
        {
            throw new NotImplementedException();
        }

        public void SetScreenFullScreen()
        {
            _iInput.RequestScreens();
            //throw new NotImplementedException();
        }
    }
}
