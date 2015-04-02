using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Tabaprompter
{
    public static class LibraryTools
    {

        internal static Tab parseTab(string contents)
        {
            //String[] parts = contents.Split(new string[] { "sections=" }, StringSplitOptions.None);
            String[] parts = RegexTools.split(contents, "sections=");
            Tab tab = getHeader(parts[0]);

            tab.sections = getSections(parts[1]);
            return tab;

        }

        private static List<Section> getSections(string text)
        {
            List<Section> sectionList = new List<Section>();
            int sectionID = 100;
            string pattern = "section\\((\\w+), (\\d+)\\)";

            String[] sections = RegexTools.split(text, "=section");

            for(int i = 0; i < sections.Length; i++)
            {
                if(!sections[i].Equals(""))
                {
                    String[] parts = RegexTools.split(sections[i], "=");
                    List<String> matches = RegexTools.match(pattern, parts[0], RegexOptions.Singleline);
                    Section section = new Section();
                    section.ID = sectionID++;
                    section.element = (Element)Enum.Parse(typeof(Element), matches[0]);
                    section.startTime = int.Parse(matches[1]);
                    section.text = parts[1];
                    sectionList.Add(section);
                }
                
            }
            return sectionList;

            
        }

        private static Tab getHeader(string text)
        {
            string idPattern = "id=(\\d*)" + Environment.NewLine;
            string artistPattern = "artist=(.*)" + Environment.NewLine;
            string titlePattern = "title=(.*)" + Environment.NewLine;
            string tuningPattern = "tuning=(.*)" + Environment.NewLine;
            string notesPattern = "notes=(.*)" + Environment.NewLine;
            string scrollDelayPattern = "scrollDelay=(\\d*)" + Environment.NewLine;
            string startDelayPattern = "startDelay=(\\d*)" + Environment.NewLine;

            string pattern = idPattern + artistPattern + titlePattern + tuningPattern + notesPattern + scrollDelayPattern + startDelayPattern;
            Tab tab = new Tab();

            List<string> matches = RegexTools.match(pattern, text, RegexOptions.Singleline);

            tab.ID = int.Parse(matches[0]);
            tab.artist = matches[1];
            tab.title = matches[2];
            tab.tuning = matches[3];
            tab.notes = matches[4];
            tab.scrollDelay = int.Parse(matches[5]);
            tab.startDelay = int.Parse(matches[6]);

            return tab;
        }
    }
}
