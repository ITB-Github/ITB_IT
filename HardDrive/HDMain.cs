using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IT_TeamPointMainScreenInteractor;
namespace HardDrive
{
    public class HDMain
    {
        HDMapper _hdMapper;
        public HDMain()
        {
            _hdMapper = new HDMapper();

        }
        public HardDriveGateway GetHardDriveGateway()
        {
            return _hdMapper as HardDriveGateway;
        }
    }
}
