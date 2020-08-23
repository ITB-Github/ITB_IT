using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_TeamPointMainScreenInteractor
{
    public interface HardDriveGateway
    {
        string LoadPowerpointFiles();
        string LoadMusicFiles();
        string LoadVideoFiles();
        byte[] GetImageToDisplay();
    }
}
