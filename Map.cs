using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathOfLava
{
    public class Map
    {
        public string Name { get; set; } = string.Empty;
        public string Level { get; set; } = string.Empty;
        public TimeSpan? TotalTime { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
    }
}
