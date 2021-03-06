﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IT_TeamPointMainScreenInteractor;

namespace ITPointPresenterController
{
    internal class Controller : ITControl_IController, PreviewIController, OverviewIController, EndRoundPointIController
    {
        private InputBoundary _iInput;
        public void AttachInput(InputBoundary iInput)
        {
            _iInput = iInput;
        }

        public void ChooseScreen(int Id)
        {

            _iInput.ChooseScreen(Id);
            //throw new NotImplementedException();
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

        public void LoadResources()
        {
            _iInput.RequestResources();
            //throw new NotImplementedException();
        }

        public void OpenEndRoundWindow()
        {
            _iInput.RequestOpenEndRoundWindow();
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

        public void OpenPowerpointFile(PowerpointViewModel pptvm)
        {
            _iInput.RequestOpenPowerpoint(new PowerpointInData()
            {
                Id = pptvm.Id,
                FileName = pptvm.FileName,
                Path = pptvm.Path
            });
            //throw new NotImplementedException();
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
