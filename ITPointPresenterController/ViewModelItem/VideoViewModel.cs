using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITPointPresenterController
{
    public class VideoViewModel
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string Path { get; set; }
        public VideoViewModel()
        {
            Id = -1;
            FileName = "(NoName)";
            Path = "(Unknown Path)";
        }
    }
}
