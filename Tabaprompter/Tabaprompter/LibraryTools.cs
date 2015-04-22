using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Tabaprompter
{
    public static class LibraryTools
    {

        internal static List<string> parseTabToFile(Tab currentTab)
        {
            List<string> lines = new List<string>();
            int id = currentTab.ID;

            //lines.Add("id=" + currentTab.ID.ToString());
            lines.Add("id=");
            lines.Add("artist=" + currentTab.artist);
            lines.Add("title=" + currentTab.title);
            lines.Add("tuning=" + currentTab.tuning);
            lines.Add("notes=" + currentTab.notes);
            lines.Add("startDelay=" + currentTab.startDelay.ToString());
            lines.Add("videoUrl=" + currentTab.videoUrl);
            lines.Add("videoEnabled=" + currentTab.videoEnabled);
            lines.Add("sections=");
            Section section;
            for (int i = 0; i < currentTab.sections.Count; i++)
            {
                section = currentTab.sections[i];
                lines.Add("section(" + section.element + ", " + section.startTime + ")=");
                lines.Add(section.text);
                lines.Add("=section");
            }

            int hash = getTabHash(lines);
            lines[0] = Regex.Replace(lines[0], "id=", "id=" + hash.ToString());


            return lines;
        }

        private static int getTabHash(List<string> lines)
        {
            string contents = "";
            for(int i = 0; i < lines.Count; i++)
            {
                contents += Regex.Replace(lines[i], Environment.NewLine, "");
            }
            return contents.GetHashCode();
        }
        internal static Tab parseTabFromFile(string contents)
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
                if (!sections[i].Equals("") && !sections[i].Equals("\r\n"))
                {
                    String[] parts = RegexTools.split(sections[i], "=");
                    List<String> matches = RegexTools.match(pattern, parts[0], RegexOptions.Singleline);
                    Section section = new Section();
                    section.ID = sectionID++;
                    section.element = (Element)Enum.Parse(typeof(Element), matches[0]);
                    section.startTime = int.Parse(matches[1]);
                    section.text = parts[1];

                    section.text = Regex.Replace(section.text, "^\r?\n?", "");
                    section.text = Regex.Replace(section.text, "\r?\n?$", "");
                    sectionList.Add(section);
                }
                
            }
            return sectionList;

            
        }


        private static Tab getHeader(string text)
        {
            string idPattern = "id=([-0-9]*)" + Environment.NewLine;
            string artistPattern = "artist=(.*)" + Environment.NewLine;
            string titlePattern = "title=(.*)" + Environment.NewLine;
            string tuningPattern = "tuning=(.*)" + Environment.NewLine;
            string notesPattern = "notes=(.*)" + Environment.NewLine;
            string startDelayPattern = "startDelay=(\\d*)" + Environment.NewLine;
            string videoUrlPattern = "videoUrl=(.*)" + Environment.NewLine;
            string videoEnabledPattern = "videoEnabled=(\\w+)" + Environment.NewLine;

            string pattern = idPattern + artistPattern + titlePattern + tuningPattern + notesPattern + startDelayPattern + videoUrlPattern + videoEnabledPattern;
            Tab tab = new Tab();

            List<string> matches = RegexTools.match(pattern, text, RegexOptions.Singleline);

            tab.ID = int.Parse(matches[0]);
            tab.artist = matches[1];
            tab.title = matches[2];
            tab.tuning = matches[3];
            tab.notes = matches[4];
            tab.startDelay = int.Parse(matches[5]);
            tab.videoUrl = matches[6];
            tab.videoEnabled = Boolean.Parse(matches[7]);

            return tab;
        }

    }
}
