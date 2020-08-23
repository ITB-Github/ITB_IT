using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITPointBufferEnitites
{
    public struct ScreenInstruction
    {
        [JsonProperty("Top")]
        public int Top { get; set; }
        [JsonProperty("Left")]
        public int Left { get; set; }
        [JsonProperty("IsMaximized")]
        public bool IsMaximized { get; set; }
        [JsonProperty("IsShown")]
        public bool IsShown { get; set; }
    }
}
