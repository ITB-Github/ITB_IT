using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITPointPresenterController
{
    public class MusicViewModel
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string Path { get; set; }
        public byte[] Stream { get; set; }
        public MusicViewModel()
        {
            Id = -1;
            FileName = "(No Name)";
            Path = "(Unknown Paht)";
            Stream = null;
        }
    }
}
