using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tabaprompter
{
    public partial class Form1 : Form
    {

        public decimal scrollDelayMultiplier { get; set; }

        // Section Label Colors
        public Color verseLabelColor { get; set; }
        public Color chorusLabelColor { get; set; }
        public Color bridgeLabelColor { get; set; }
        public Color hookLabelColor { get; set; }
        public Color refrainLabelColor { get; set; }
        public Color introLabelColor { get; set; }



        // temp
        public int markCount { get; set; }
        public int scrollCount { get; set; }



        Color myRgbColor = Color.FromArgb(0, 255, 0);
        //Colors colors = 
        int markBgRBColor = 0;
        //Boolean playing;
        private System.Timers.Timer timer;
        public int ms { get; set; }

        Panel logPanel;
        Panel scrollPanel;
        Panel markPanel;
        
        /*
        Panel selectorPanel;
        Panel controlPanel;
        */

        ControlState controlState;
        SavedState savedState;

        string tabFilter;
        string libraryFilter;
        Library library;
        Tab currentTab { get; set; }

        string librarySavePath { get; set; }

        Boolean enableVideo;

        public Form1()
        {

            scrollDelayMultiplier = 15.6M;


            librarySavePath = "";
            this.DoubleBuffered = true;
            tabFilter = "Tab files (*.tab)|*.tab|All files (*.*)|*.*";
            libraryFilter = "Tab Library files (*.tlib)|*.tlib|All files (*.*)|*.*";

            InitializeComponent();

            timer = new System.Timers.Timer();
            timer.Interval = 1;
            timer.Elapsed += timer_Elapsed;



            introLabelColor = Color.FromArgb(255, 69, 69, 69);
            verseLabelColor = Color.FromArgb(255, 0, 128, 128);
            chorusLabelColor = Color.FromArgb(255, 128, 0, 128);
            bridgeLabelColor = Color.FromArgb(255, 128, 128, 0);
            hookLabelColor = Color.FromArgb(255, 200, 200, 50);
            refrainLabelColor = Color.FromArgb(255, 50, 200, 200);
        }



        private Color getSectionLabelColor(Element element)
        {
            if(element == Element.bridge)
            {
                return bridgeLabelColor;
            }
            else if(element == Element.chorus)
            {
                return chorusLabelColor;
            }
            else if(element == Element.hook)
            {
                return hookLabelColor;
            }
            else if(element == Element.refrain)
            {
                return refrainLabelColor;
            }
            else if(element == Element.verse)
            {
                return verseLabelColor;
            }
            return Color.Firebrick;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

            logPanel = PanelTools.createDefaultPanel("log");
            scrollPanel = PanelTools.createDefaultPanel("scroll");
            markPanel = PanelTools.createDefaultPanel("mark");

            /*
            selectorPanel = PanelTools.createDefaultPanel("selector");
            controlPanel = PanelTools.createDefaultPanel("control");
            */

            logPanel = PanelTools.buildLogPanel(logPanel);
            scrollPanel = PanelTools.buildScrollPanel(scrollPanel);
            markPanel = PanelTools.buildMarkPanel(markPanel);

            /*
            selectorPanel = PanelTools.buildSelectorPanel(selectorPanel);
            controlPanel = PanelTools.buildControlPanel(controlPanel);
            */



            displayLogPanel();
            List<string> list = new List<string>();
            list.Add("Welcome to Tabaprompter!");
            createScrollPanelBanner(list);
            //displayMarkPanel();



            /*
            displaySelectorPanel();
            displayControlPanel();
            */

            // Init Selector
            //artistComboBox.Text = "Artist";
            artistComboBox.SelectedIndexChanged += artistComboBox_SelectedIndexChanged;
            //titleComboBox.Text = "Title";


            initLibrary();


            enableVideo = enableVideoCheckBox.Checked;

            scrollDelayMultiplierNumericUpDown.Value = scrollDelayMultiplier;
        }



        int current = 0;
        int totalHeight = 0;// scrollPanel.Height / 2;
        delegate void SetTextCallback();
        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {

            SetLabel();
            SetText();
            ms++;

        }
        public void SetLabel()
        {
            if (this.scrollPanel.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetLabel);
                try
                {
                    this.Invoke(d, new object[] { });
                }
                catch(Exception e)
                {
                    timer.Stop();
                }
                
            }
            else
            {
                if(controlState ==  ControlState.library_tab_loaded_play_mode)
                {
                    int time = 0;

                    if (scrollPanel.Controls[current].Height + totalHeight <= ms && current < scrollPanel.Controls.Count - 1)
                    {
                        totalHeight += scrollPanel.Controls[current].Height;
                        current++;
                    }
                    if(current != scrollPanel.Controls.Count - 1)
                    {
                        int h = scrollPanel.Controls[current].Height;
                        time = currentTab.sections[current + 1].startTime - currentTab.sections[current].startTime;

                        
                    
                
                        if(time == 0)
                        {
                            time = currentTab.sections[1].startTime - currentTab.sections[0].startTime;
                        }


                        double delay = (Double)(time / h) * (Double)scrollDelayMultiplier;
                        timer.Interval = (int)delay;
                        label2.Text = delay.ToString();
                    }


                    int height = scrollPanel.Height;
                    int middle = height / 2;

                    Label control;

                    for (int i = 0; i < scrollPanel.Controls.Count; i++)
                    {
                        control = (Label)scrollPanel.Controls[i];
                        if(control.Location.Y <= height && control.Location.Y > 0)
                        {

                            double x = control.Location.Y;

                            double a = -100 / (Math.Pow(height - middle, 2));

                            double y = a * Math.Pow(x - middle, 2) + 100;

                            double comp = y;


                            if (i == 0)
                            {

                                label3.Text = comp.ToString();
                            }
                            double opacity = (255 * y) / 100;

                            control.BackColor = Color.FromArgb((int)opacity, control.BackColor);
                        }
                       
                        control.Location = new Point(control.Location.X, control.Location.Y - 1);
                    }
                }
            }
        }




        public void SetText()
        {
            if (this.flowLayoutPanel1.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { });
            }
            else
            {
                label1.Text = ms.ToString();
            }
        }


        /*
        private void tick(object sender, EventArgs e)
        {
            ms++;
        }
        */

        private void initLibrary()
        {
            log("Initializing...");
            library = new Library();
            clearComboBoxes();
            setControlState(ControlState.initial);
            setSavedState(SavedState.unsaved);
        }
        
        private void log(string text)
        {
            Label label = createLogLabel(text);
            FlowLayoutPanel flp = (FlowLayoutPanel)logPanel.Controls[0];
            flp.Controls.Add(label);
            flp.ScrollControlIntoView(label);
        }
        
        private Label createLogLabel(string text)
        {
            Label label = new Label();
            label.Text = text;
            label.AutoSize = true;
            return label;
        }
        private void logList(List<string> list)
        {
            for(int i = 0; i < list.Count; i++)
            {
                log(list[i]);
            }
        }
        
        private void setSavePath(string path)
        {
            librarySavePath = path;
            setSavedState(SavedState.saved);
        }
        private void loadTab(Tab tab)
        {
            log("Loading: " + tab.getSongArtistTitle(" - "));
            createScrollPanelBanner(tab.getSongInfo());

            setControlState(ControlState.library_tab_loaded);

            enableVideo = currentTab.videoEnabled;
            updateVideoUrl(currentTab.videoUrl);



            startDelayTextBox.Text = tab.startDelay.ToString();
        }


        // Putting panels in place
        private void displayLogPanel()
        {
            controlsLogDivider.Panel2.Controls.Add(logPanel);
            //updateLogPanel();
        }
        private void displayScrollPanel()
        {

            offsetStartTime = currentTab.startDelay;
            //tabVideoDivider.Panel1.Controls.Clear();
            scrollPanel.Controls.Clear();

            scrollPanel.Paint += scrollPanel_Paint;
            tabVideoDivider.Panel1.Controls.Add(scrollPanel);
            updateScrollPanel(currentTab.sections);
            
        }
        private void displayMarkPanel()
        {
            setControlState(ControlState.library_tab_loaded_mark_mode);
            tabVideoDivider.Panel1.Controls.Clear();

            tabVideoDivider.Panel1.Controls.Add(markPanel);
            updateMarkPanel();
        }
        void markLabel_Click(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            int clicked = int.Parse(label.Name);
            for (int i = 0; i < currentTab.sections.Count; i++)
            {
                if(clicked == currentTab.sections[i].ID)
                {
                    currentTab.sections[i].startTime = ms;
                    if (i == currentTab.sections.Count - 1)
                    {

                        markMode();
                    }
                }
            }
                label.BackColor = Color.LightGreen;
            //label1.Text = ms.ToString();
            //MessageBox.Show("mark click");
            //label1.Click += label1_Click;


        }

        void label1_Click(object sender, EventArgs e)
        {
            label1.Text = ms.ToString();
        }
        private void markTimeLabelColorReset()
        {
            myRgbColor = Color.FromArgb(255, 0, 255);
        }
        private Color getMarkTimeLabelColor()
        {
            if (markBgRBColor < 248)
            {
                markBgRBColor += 8;
            }
            else
            {
                markBgRBColor = 0;
            }
            
            
            return Color.FromArgb(255, markBgRBColor, 255);
        }
        private void createScrollPanelBanner(List<string> list)
        {
            string text = "";
            for (int i = 0; i < list.Count; i++)
            {
                text += list[i] + "\r\n";
            }

            Panel panel = (Panel)scrollPanel;
            panel.Controls.Clear();
            Label label = new Label();
            label.Text = text;

            //label.SendToBack();

            label.AutoSize = true;
            label.Location = new Point((panel.Width / 2) - (label.Width / 2), (panel.Height / 2) - (label.Height / 2));
            //label.Location = new Point(50, 50);
            panel.Controls.Add(label);
            tabVideoDivider.Panel1.Controls.Clear();
                
            tabVideoDivider.Panel1.Controls.Add(scrollPanel);
        }


        // Creating panels


        public int offsetStartTime { get; set; }
        public int offsetScrollTime { get; set; }

        private void updateLogPanel()
        {

            FlowLayoutPanel flp = (FlowLayoutPanel)logPanel.Controls[0];
            //logPanel.AutoScrollPosition = new Point(logPanel.AutoScrollPosition.X, logPanel.Height);
        }

        private void scrollPanel_Paint(object sender, PaintEventArgs e)
        {
            /*
            Pen blackpen = new Pen(Color.Black, 1);
            Graphics g = e.Graphics;
            
            g.DrawLine(blackpen, 0, scrollPanel.Height / 2, scrollPanel.Width, scrollPanel.Height / 2);
            g.Dispose();
             */
        }
        
        private void updateScrollPanel(List<Section> sections)
        {
            Panel panel = (Panel)scrollPanel;

            panel.Controls.Clear();
            Label label;
            List<Label> labels = new List<Label>();
            int widestLabel = 0;
            int labelX = 0;
            List<int> offsets = new List<int>();
            for (int i = 0; i < sections.Count; i++)
            {
                label = new Label();

                label.BackColor = getSectionLabelColor(currentTab.sections[i].element);
                if (currentTab.sections[i].element == Element.MARK)
                {
                    label.Visible = false;
                }

                label.BorderStyle = BorderStyle.Fixed3D;

                label.Padding = new Padding(10, 10, 10, 10);

                //offsets.Add(halfParentHeight + offsetStartTime + )
                //label.Location = new Point(labelWidthOffset, newY);
                label.Text = sections[i].text;
                label.Font = new Font("Consolas", 11);
                label.AutoSize = true;
                //newY += label.Height;
                label.Click += label_Click;
                if (label.Width > widestLabel)
                {
                    widestLabel = label.Width;
                }
                //labels.Add(label);
                panel.Controls.Add(label);


            }


            int height = scrollPanel.Height;
            int middle = height / 2;

            labelX = 50;
            int last = offsetStartTime + middle;
            for (int i = 0; i < panel.Controls.Count; i++)
            {
                panel.Controls[i].Location = new Point(labelX, last);

                last += panel.Controls[i].Height;
            }




            //     new Point((panel.Width / 2) - (label.Width / 2), (panel.Height / 2) - (label.Height / 2));
            //int labelWidthOffset = (panel.Width / 2) - (widestLabel / 2);
            


            //for (int i = 0; i < sections.Count; i++)
            //{
            //   panel.Controls[i].Location = new Point(labelWidthOffset, panel.Controls[i].Location.Y);
            //    //label = new Label();
            //    //label.Location = new Point(30, sections[i].startTime);
            //    //label.Text = sections[i].text;
            //    //label.AutoSize = true;
            //    //panel.Controls.Add(label);
            //}
            


            //panel.Controls[0].Location = new Point(100, 200);
            //panel.Controls[1].Location = new Point(200, 200);
            
        }

        void label_Click(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            label3.Text = label.Height.ToString();
        }
        private void updateMarkPanel()
        {
            markTimeLabelColorReset();
            Panel panel = (Panel)markPanel;
            panel.Controls.Clear();

            FlowLayoutPanel flp = new FlowLayoutPanel();
            flp.MouseEnter += giveMarkPanelFocusToScroll;
            flp.AutoSize = true;
            flp.WrapContents = false;
            flp.FlowDirection = FlowDirection.TopDown;
            List<string> lines = currentTab.getSectionText();

            Label markLabel = new Label();
            markLabel.Name = currentTab.sections[0].ID.ToString();
            markLabel.BackColor = Color.LightGreen;
            markLabel.AutoSize = true;
            markLabel.BorderStyle = BorderStyle.Fixed3D;
            //markLabel.Click += markLabel_Click;
            currentTab.sections[0].startTime = 0;
            markLabel.Text = lines[0];

            flp.Controls.Add(markLabel);



            for (int i = 1; i < lines.Count; i++)
            {
                markLabel = new Label();
                markLabel.Name = currentTab.sections[i].ID.ToString();
                markLabel.BackColor = getMarkTimeLabelColor();
                markLabel.AutoSize = true;
                markLabel.BorderStyle = BorderStyle.Fixed3D;
                markLabel.Click += markLabel_Click;

                if (currentTab.sections[i].element == Element.MARK)
                {
                    markLabel.Text = "MARK";
                }
                else
                {
                    markLabel.Text = lines[i];
                }

                flp.Controls.Add(markLabel);
            }
            panel.Controls.Add(flp);
            tabVideoDivider.Panel1.Controls.Clear();
            tabVideoDivider.Panel1.Controls.Add(panel);
                
        }

        private void giveMarkPanelFocusToScroll(object sender, EventArgs e)
        {
            markPanel.Controls[0].Focus();
        }
        

        /*
        private void displaySelectorPanel()
        {
            updateSelectorPanel();
            selectorsControlsDivider.Panel1.Controls.Add(selectorPanel);
        }
        private void updateSelectorPanel()
        {
            FlowLayoutPanel flp = (FlowLayoutPanel)selectorPanel.Controls[0];
            Label l = new Label();
            l.Text = "Selector Panel!";
            l.AutoSize = true;
            flp.Controls.Add(l);
        }




        private void displayControlPanel()
        {
            updateControlPanel();
            controlsLogDivider.Panel1.Controls.Add(controlPanel);
        }
        private void updateControlPanel()
        {
            FlowLayoutPanel flp = (FlowLayoutPanel)controlPanel.Controls[0];
            Label l = new Label();
            l.Text = "Control Panel!";
            l.AutoSize = true;
            flp.Controls.Add(l);
        }
        */


        // States
        private void setSavedState(SavedState sS)
        {
            savedState = sS;
        }
        private void setControlState(ControlState cS)
        {
            if(library.tabs.Count == 0)
            {
                //setSav
            }
            controlState = cS;
            if (controlState == ControlState.initial)
            {
                log("Control State: Initial");
                // Files
                closeLibraryToolStripMenuItem.Enabled = false;
                saveLibraryAsToolStripMenuItem.Enabled = false;
                saveLibraryToolStripMenuItem.Enabled = false;
                exportTabToolStripMenuItem.Enabled = false;
                closeLibraryToolStripMenuItem.Enabled = false;

                // Controls
                scrollPlayButton.Enabled = false;
                scrollStopButton.Enabled = false;
                scrollResetButton.Enabled = false;
                markModeButton.Enabled = false;


                // Selector
                //artistComboBox.Enabled = false;
                //titleComboBox.Enabled = false;

                
                // Set web browser to a blank page
                blankWebBrowser();
            }
            else if (controlState == ControlState.library_loaded)
            {

                label1.Text = ms.ToString();


                log("Control State: Library loaded");
                // Also check to see if it has been saved.
                // Can't have the Save button enabled if it
                // wasn't saved to begin with
                if(savedState == SavedState.unsaved)
                {
                    saveLibraryToolStripMenuItem.Enabled = false;
                }
                else
                {
                    saveLibraryToolStripMenuItem.Enabled = true;
                }

                // Files
                saveLibraryAsToolStripMenuItem.Enabled = true;
                closeLibraryToolStripMenuItem.Enabled = true;

                // A tab needs to be loaded (selected) to enable this item
                exportTabToolStripMenuItem.Enabled = false;


                // Selector
                artistComboBox.Enabled = true;
                titleComboBox.Enabled = true;
            }
            else if (controlState == ControlState.library_tab_loaded)
            {

                log("Control State: Tab loaded");
                // Also check to see if it has been saved.
                // Can't have the Save button enabled if it
                // wasn't saved to begin with
                if (savedState == SavedState.unsaved)
                {
                    saveLibraryToolStripMenuItem.Enabled = false;
                }
                else
                {
                    saveLibraryToolStripMenuItem.Enabled = true;
                }



                // Check to see if a tab is loaded so it can be exported.
                if (currentTab == null)
                {
                    // I don't want to hear the music start while testing
                    //
                    // When finished, replace false with true
                    //
                    enableVideo = false;//enableVideo = true;


                    exportTabToolStripMenuItem.Enabled = false;
                }
                else
                {
                    // Video 
                    enableVideo = currentTab.videoEnabled;
                    
                    //enableVideoControls(enableVideo);
                    exportTabToolStripMenuItem.Enabled = true;
                }
                // Files
                saveLibraryAsToolStripMenuItem.Enabled = true;
                closeLibraryToolStripMenuItem.Enabled = true;


                // Controls
                scrollPlayButton.Enabled = true;
                scrollStopButton.Enabled = true;
                scrollResetButton.Enabled = true;
                markModeButton.Enabled = true;

                

                // Selector
                artistComboBox.Enabled = true;
                titleComboBox.Enabled = true;


            }
            else if (controlState == ControlState.library_tab_loaded_play_mode)
            {

                log("Control State: Play");
                // Also check to see if it has been saved.
                // Can't have the Save button enabled if it
                // wasn't saved to begin with
                if (savedState == SavedState.unsaved)
                {
                    saveLibraryToolStripMenuItem.Enabled = false;
                }
                else
                {
                    saveLibraryToolStripMenuItem.Enabled = true;
                }



                // Check to see if a tab is loaded so it can be exported.
                if (currentTab == null)
                {
                    exportTabToolStripMenuItem.Enabled = false;
                }
                else
                {
                    exportTabToolStripMenuItem.Enabled = true;

                    enableVideoCheckBox.Enabled = enableVideo;

                }
                // Files
                saveLibraryAsToolStripMenuItem.Enabled = true;
                closeLibraryToolStripMenuItem.Enabled = true;


                // Controls
                scrollPlayButton.Enabled = true;
                scrollStopButton.Enabled = true;
                scrollResetButton.Enabled = true;
                markModeButton.Text = "Mark";
                markModeButton.Enabled = true;



                // Selector
                artistComboBox.Enabled = true;
                titleComboBox.Enabled = true;

                // mark panel call get sections text // updateScrollPanel(currentTab.getSectionText());

                //displayScrollPanel(currentTab.getSectionText());




                //displayScrollPanel();

            }
            else if (controlState == ControlState.library_tab_loaded_stop_mode)
            {

                log("Control State: Stop");
                // Also check to see if it has been saved.
                // Can't have the Save button enabled if it
                // wasn't saved to begin with
                if (savedState == SavedState.unsaved)
                {
                    saveLibraryToolStripMenuItem.Enabled = false;
                }
                else
                {
                    saveLibraryToolStripMenuItem.Enabled = true;
                }



                // Check to see if a tab is loaded so it can be exported.
                if (currentTab == null)
                {
                    exportTabToolStripMenuItem.Enabled = false;
                }
                else
                {
                    exportTabToolStripMenuItem.Enabled = true;

                    enableVideoCheckBox.Enabled = enableVideo;

                }
                // Files
                saveLibraryAsToolStripMenuItem.Enabled = true;
                closeLibraryToolStripMenuItem.Enabled = true;


                // Controls
                scrollPlayButton.Enabled = true;
                scrollStopButton.Enabled = true;
                scrollResetButton.Enabled = true;
                markModeButton.Text = "Mark";
                markModeButton.Enabled = true;



                // Selector
                artistComboBox.Enabled = true;
                titleComboBox.Enabled = true;

                // mark panel call get sections text // updateScrollPanel(currentTab.getSectionText());

                //displayScrollPanel(currentTab.getSectionText());




                //displayScrollPanel();

            }
            else if (controlState == ControlState.library_tab_loaded_mark_mode)
            {

                log("Control State: Mark mode");

                saveLibraryToolStripMenuItem.Enabled = false;
                exportTabToolStripMenuItem.Enabled = false;
               
              
                // Files
                saveLibraryAsToolStripMenuItem.Enabled = false;
                closeLibraryToolStripMenuItem.Enabled = false;


                // Controls
                scrollPlayButton.Enabled = false;
                scrollStopButton.Enabled = false;
                scrollResetButton.Enabled = false;
                markModeButton.Enabled = true;
                markModeButton.Text = "Stop";


                // Selector
                artistComboBox.Enabled = false;
                titleComboBox.Enabled = false;
                // updateScrollPanel(currentTab.getSectionText());
                //updateMarkPanel();
                //displayMarkPanel();

            }
            else
            {

            }

            newLibraryToolStripMenuItem.Enabled = true;
            openLibraryToolStripMenuItem.Enabled = true;
            importTabToolStripMenuItem.Enabled = true;


            /*
            // Video 
            if(currentTab != null)
            {
                enableVideo = currentTab.videoEnabled;
            }
            else
            {
                // I don't want to hear the music start while testing
                //
                // When finished, replace false with true
                //
                enableVideo = false;//enableVideo = true;
            }
            //enableVideoControls(enableVideo);
            */
            
        }
        


        // FILES
        private string createTempDir(string dirName)
        {
            // Convert tabs to files in temp location
            string temp = Path.GetTempPath() + dirName;

            if (File.Exists(temp))
            {
                File.Delete(temp);
            }
            Directory.CreateDirectory(temp);
            return temp;
        }
        private void removeTempDir(string dirName)
        {
            // remove temp location
            if (Directory.Exists(dirName))
            {
                string[] files = Directory.GetFiles(dirName);
                for (int i = 0; i < files.Length; i++)
                {
                    File.Delete(files[i]);
                }
                Directory.Delete(dirName);
            }
        }
        private string selectFile(FileDialog dialog, string filter)
        {
            //OpenFileDialog 
            //openFileDialog1 = new OpenFileDialog();

            //openFileDialog1.InitialDirectory = "c:\\";
            dialog.Filter = filter;
            dialog.FilterIndex = 1;
            dialog.RestoreDirectory = true;

            // string path : Open Dialog box
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                return dialog.FileName;

            }
            return "";
        }


        // Open file
        private void importTab(string path)
        {
            // give path to open file method
            string contents = FileTools.open(path);

            Tab tab = LibraryTools.parseTabFromFile(contents);

            // parse contents to tab
            // add tab to library
            library.tabs.Add(tab);

            log("Tab imported: " + tab.getSongArtistTitle(" - "));

            // Set control state
            setControlState(ControlState.library_loaded);

            // Update comboboxes
            updateComboBoxes(-1);

        }
        

        // Save File
        private void saveLibraryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveLibrary(librarySavePath);

        }
        private void saveLibraryAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // export tabs to temp folder, zip them up and ask where to save it
            //
            //
            //
            //
            //
            //
            //

            // ask for filename to save as
            string filename = selectFile(new SaveFileDialog(), libraryFilter);
            if (!bEmptyString(filename))
            {
                saveLibrary(filename);
            }

        }
        private void saveLibrary(string path)
        {


            string temp = createTempDir("tabaprompter\\");
            List<string> lines;
            for (int i = 0; i < library.tabs.Count; i++)
            {
                lines = LibraryTools.parseTabToFile(library.tabs[i]);
                FileTools.save(temp + library.tabs[i].ID.ToString(), lines);
            }


            // zip files and save
            ZipTools.zip(path, temp);

            // remove temp dir
            removeTempDir(temp);


            //FileTools.save(, new List<string>());
            setSavePath(path);

            log("Library saved");

            //setSavedState(SavedState.saved);
            setControlState(ControlState.library_loaded);
        }
        

        // ComboBoxes
        private void clearComboBoxes()
        {
            artistComboBox.Items.Clear();
            titleComboBox.Items.Clear();
            artistComboBox.Text = "Artist";
            titleComboBox.Text = "Title";
        }
        private void updateComboBoxes(int artist)
        {
            titleComboBox.Items.Clear();

            List<Tab> tabs = new List<Tab>();
            if (artist == -1)
            {
                for (int i = 0; i < library.tabs.Count; i++)
                {
                    if (!doItemsContainThatArtist(library.tabs[i].artist))
                    {
                        artistComboBox.Items.Add(library.tabs[i].artist);
                    }
                    titleComboBox.Items.Add(library.tabs[i].title);
                }
            }
            else
            {
                string artistName = artistComboBox.Items[artist].ToString();
                for (int i = 0; i < library.tabs.Count; i++)
                {
                    if (artistName.Equals(library.tabs[i].artist))
                    {
                        titleComboBox.Items.Add(library.tabs[i].title);
                    }

                }
            }

        }
        private Boolean doItemsContainThatArtist(string text)
        {
            Boolean found = false;
            string tabString = "";
            string boxString = "";

            tabString = text;
            for (int j = 0; j < artistComboBox.Items.Count; j++)
            {
                boxString = artistComboBox.Items[j].ToString();
                if (tabString.Equals(boxString))
                {
                    found = true;
                }
            }
            return found;
        }
               
        
        // Menu Items
        private void exportTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // get path with open dialog
            string path = selectFile(new SaveFileDialog(), tabFilter);
            if (!bEmptyString(path))
            {
                exportTab(path);
            }
        }

        private void exportTab(string path)
        {
            // get parsed lines from the load tab
            List<String> lines = LibraryTools.parseTabToFile(currentTab);


            // pass path and parsed lines to save util func.
            FileTools.save(path, lines);
            log("Tab exported: " + currentTab.getSongArtistTitle(" - "));
        }
        private void newLibraryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            initLibrary();
        }
        private void openLibraryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

            // open opendialog and get filename
            string path = selectFile(new OpenFileDialog(), libraryFilter);
            if (!bEmptyString(path))
            {
                string temp = createTempDir("tabaprompter\\");
                ZipTools.unzip(path, temp);
                string[] files = Directory.GetFiles(temp);
                for (int i = 0; i < files.Length; i++)
                {
                    importTab(files[i]);
                }

                // remove temp dir
                removeTempDir(temp);
            }
            
            
        }
        private Boolean bEmptyString(string path)
        {
            if(path.Equals(""))
            {
                return true;
            }
            return false;
        }
        private void importTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = selectFile(new OpenFileDialog(), tabFilter);

            if(!bEmptyString(path))
            {
                importTab(path);


                // Update comboboxes
                updateComboBoxes(-1);
            }
            
            
        }
        private void closeLibraryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //clearComboBoxes();
            currentTab = null;
            initLibrary();
            //setControlState(ControlState.initial);
        }
                 
        
        ////////////////////////////// Controls
        private void scrollPlayButton_Click(object sender, EventArgs e)
        {
            //startTimer(); // is the thread starting the timer or should i do it here?
            //scrollThread.Start();
            //initTimer();
            //timer.Start();

            play();



            //displayScrollPanel();
            //scrollTimer.Start();
        }
        private void play()
        {

            if (controlState == ControlState.library_tab_loaded)
            {
                displayScrollPanel();
            }
            //else if (controlState == ControlState.library_tab_loaded_stop_mode)
            //{

            //}

            setControlState(ControlState.library_tab_loaded_play_mode);
                //offsetStartTime = currentTab.startDelay;
                //tabVideoDivider.Panel1.Controls.Clear();
                //scrollPanel.Controls.Clear();

                //scrollPanel.Paint += scrollPanel_Paint;
                //tabVideoDivider.Panel1.Controls.Add(scrollPanel);
                //updateScrollPanel(currentTab.sections);
            //}

            timer.Start();

        }
        private void scrollStopButton_Click(object sender, EventArgs e)
        {

            setControlState(ControlState.library_tab_loaded_stop_mode);
            timer.Stop();
        }

        
        private void scrollResetButton_Click(object sender, EventArgs e)
        {
            ms = 0;
            displayScrollPanel();
        }
        private void markModeButton_Click(object sender, EventArgs e)
        {

            markMode();
            
            
        }

        private void markMode()
        {
            if (controlState == ControlState.library_tab_loaded_mark_mode)
            {
                setControlState(ControlState.library_tab_loaded);
                createScrollPanelBanner(currentTab.getSongInfo());
                timer.Stop();
                //stopTimer();
            }
            else
            {
                setControlState(ControlState.library_tab_loaded);
                displayMarkPanel();
                timer.Start();
                //startTimer();
            }
        }



        // Selectors!!!!!!!!!!!!!!!!!!!!!!!!!
        private void artistComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            updateComboBoxes(cb.SelectedIndex);
        }
        private void titleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            for (int i = 0; i < library.tabs.Count; i++)//add flag to stop looking when found
            {
                if(library.tabs[i].title == cb.SelectedItem)
                {
                    currentTab = library.tabs[i];
                }
            }
            loadTab(currentTab);
            //displayScrollPanel();

            //updateComboBoxes(cb.SelectedIndex);
        }

       
        // VIDEO OPTIONS
        private void enableVideoCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            enableVideo = enableVideoCheckBox.Checked;
            enableVideoControls(enableVideo);
            blankWebBrowser();
        }
        private void enableVideoControls(Boolean enable)
        {
            addressBarTextBox.Enabled = enable;
            addressGoButton.Enabled = enable;
            addressStopButton.Enabled = enable;

            if (currentTab != null)
            {
                currentTab.videoEnabled = enable;
                enableVideoCheckBox.Checked = enable;

                if (enableVideoCheckBox.Checked)
                {
                    WebBrowserNavigate();
                }
                else
                {

                }
            }

            // Update controls by sending the current state
            //setControlState(controlState);
        }
        private void updateVideoUrl(string p)
        {
            addressBarTextBox.Text = p;
        }
        private void WebBrowserNavigate()
        {
            webBrowser.Navigate(addressBarTextBox.Text);
        }
        private void blankWebBrowser()
        {
            webBrowser.Stop();
            webBrowser.Navigate("about:blank");
        }
        
        private void addressGoButton_Click(object sender, EventArgs e)
        {
            WebBrowserNavigate();
        }
        private void addressStopButton_Click(object sender, EventArgs e)
        {
            webBrowser.Stop();
        }


        /*
        private void scrollTimer_Tick(object sender, EventArgs e)
        {
            Label label;
            for (int i = 0; i < scrollPanel.Controls.Count; i++)
            {
                label = (Label)scrollPanel.Controls[i];
                label.Location = new Point(label.Location.X, label.Location.Y - 1);
            }
            label2.Text = scrollCount.ToString();
            scrollCount++;
        }
        */



        private void startDelayTextBox_TextChanged(object sender, EventArgs e)
        {
            currentTab.startDelay = int.Parse(startDelayTextBox.Text);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            FlowLayoutPanel flp = (FlowLayoutPanel)((Label)sender).Parent;
        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void scrollDelayMultiplierNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            scrollDelayMultiplier = scrollDelayMultiplierNumericUpDown.Value;
        }

        
        

    }





    


}
