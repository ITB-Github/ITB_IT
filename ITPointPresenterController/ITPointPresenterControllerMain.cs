using IT_TeamPointMainScreenInteractor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITPointPresenterController
{
    public class ITPointPresenterControllerMain
    {
        Controller _iCtrl;
        Presenter _presenter;
        public ITPointPresenterControllerMain(
            ITControlViewModel itvm, 
            PreviewViewModel prvm, 
            OverviewViewModel ovm, 
            EndRoundPointViewModel evm)
        {
            _presenter = new Presenter(itvm, prvm, ovm, evm);
            _iCtrl = new Controller();

            itvm.AttachController(_iCtrl);
            prvm.AttachController(_iCtrl);
            ovm.AttachController(_iCtrl);
            evm.AttachController(_iCtrl);
        }

        public OutputBoundary GetOutputBoundary()
        {
            return _presenter as OutputBoundary;
        }

        public void AttachInputBoundary(InputBoundary input)
        {
            _iCtrl.AttachInput(input);
        }
    }
}
