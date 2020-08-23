using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IT_TeamPointMainScreenInteractor;

namespace FileOpenerAPI
{
    internal class FileOpenerService : IT_TeamPointMainScreenInteractor.FileOpenerAPI
    {
        public void OpenFile(string filePath)
        {
            //throw new NotImplementedException();
            try
            {
                Process proccess = new Process();

                ProcessStartInfo startInfo = new ProcessStartInfo(filePath);

                proccess.StartInfo = startInfo;
                proccess.Start();
            }
            catch
            {

            }
        }
    }
}
