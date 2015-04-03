using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tabaprompter
{
    public class Tab
    {
        public int ID { get; set; }
        public string artist { get; set; }
        public string title { get; set; }
        public string tuning { get; set; }
        public string notes { get; set; }
        public int scrollDelay { get; set; }
        public int startDelay { get; set; }

        public List<Section> sections { get; set; }

        public List<string> getSectionText()
        {
            List<string> list = new List<string>();
            for(int i = 0; i < sections.Count; i++)
            {
                list.Add(sections[i].text);
            }
            return list;
        }

        public List<string> getSongInfo()
        {
            List<string> list = new List<string>();
            list.Add(artist);
            list.Add(title);
            list.Add(tuning);
            list.Add(notes);

            return list;
        }
    }
}
