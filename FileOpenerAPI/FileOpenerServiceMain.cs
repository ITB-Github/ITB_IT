using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileOpenerAPI
{
    public class FileOpenerServiceMain
    {
        FileOpenerService service;
        public FileOpenerServiceMain()
        {
            service = new FileOpenerService();
        }
        public IT_TeamPointMainScreenInteractor.FileOpenerAPI GetFileOpenerAPI()
        {
            return service as IT_TeamPointMainScreenInteractor.FileOpenerAPI;
        }
    }
}
