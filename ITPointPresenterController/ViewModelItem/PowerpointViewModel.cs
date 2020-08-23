using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITPointPresenterController
{
    public class PowerpointViewModel
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string Path { get; set; }
        public PowerpointViewModel()
        {
            Id = -1;
            FileName = "(NoName)";
            Path = "(Unknown Path)";
        }
    }
}
