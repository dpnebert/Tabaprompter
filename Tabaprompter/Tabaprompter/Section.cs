using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tabaprompter
{
    public class Section
    {
        public int ID { get; set; }
        public int startTime { get; set; }
        public Element element { get; set; }
        public string text { get; set; }
    }
}
