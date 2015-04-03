using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tabaprompter
{
    public class Library
    {
        // ID
        public int ID { get; set; }
        public List<Tab> tabs { get; set; }
        
        public Library()
        {
            tabs = new List<Tab>();
        }
    }
}
