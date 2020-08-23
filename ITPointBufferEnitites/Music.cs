using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITPointBufferEnitites
{
    public class Music
    {
        [JsonProperty("Id")]
        public int Id { get; set; }
        [JsonProperty("FileName")]
        public string FileName { get; set; }
        [JsonProperty("Path")]
        public string Path { get; set; }
    }
}
