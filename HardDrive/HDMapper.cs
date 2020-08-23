using IT_TeamPointMainScreenInteractor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardDrive
{
    internal class HDMapper : HardDriveGateway
    {
        HDAccess _hdAccess;
        public HDMapper()
        {
            _hdAccess = new HDAccess();
        }
        public byte[] GetImageToDisplay()
        {
            throw new NotImplementedException();
        }

        public string LoadMusicFiles()
        {
            throw new NotImplementedException();
        }

        public string LoadPowerpointFiles()
        {
            throw new NotImplementedException();
        }

        public string LoadVideoFiles()
        {
            throw new NotImplementedException();
        }
    }
}
