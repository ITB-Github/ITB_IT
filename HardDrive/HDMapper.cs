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
            return _hdAccess.GetImageToDisplay();
            //throw new NotImplementedException();
        }

        public string LoadMusicFiles()
        {
            return _hdAccess.LoadMusicFiles();
            //throw new NotImplementedException();
        }

        public string LoadPowerpointFiles()
        {
            return _hdAccess.LoadPowerpointFiles();
            //throw new NotImplementedException();
        }

        public string LoadVideoFiles()
        {
            return _hdAccess.LoadVideoFiles();
            //throw new NotImplementedException();
        }
    }
}
