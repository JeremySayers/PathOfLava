using PathOfLava;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapTracker
{
    public class TransitionEvent
    {
        public string Name { get; set; } = string.Empty;
        public TransitionType TransitionType { get; set; }
        public int Level { get; set; }
        public DateTime EnterTime { get; set; }
        public string Seed { get; set; } = string.Empty;
    }
}
