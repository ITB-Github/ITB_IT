using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_TeamPointMainScreenInteractor
{
    public class IT_Control_InteractorMain 
    {
        private ITControl_Interactor interactor;
        public IT_Control_InteractorMain(HardDriveGateway iHD, ScreenBoundary iScreen, PointDataGateway iPointData, OutputBoundary iOut)
        {
            interactor = new ITControl_Interactor(
                                                 iOut,
                                                 iPointData,
                                                 iHD,
                                                 iScreen
                                              );
        }

        public InputBoundary GetInputBoundary()
        {
            return interactor as InputBoundary;
        }
    }
}
