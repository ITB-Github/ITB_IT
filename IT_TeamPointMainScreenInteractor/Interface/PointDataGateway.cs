using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_TeamPointMainScreenInteractor
{
    public interface PointDataGateway
    {
        string GetTeamsInJson();
        bool IsConnected();
    }
}
