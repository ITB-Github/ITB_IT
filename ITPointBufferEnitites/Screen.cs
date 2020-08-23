using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITPointBufferEnitites
{
    public struct Screen
    {
        [JsonProperty("Id")]
        public int Id { get; set; }
        [JsonProperty("ScreenShot")]
        public string ScreenShot { get; set; }
    }
}
