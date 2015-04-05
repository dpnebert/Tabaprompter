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
        Color myRgbColor = Color.FromArgb(0, 255, 0);
        //Colors colors = 
        int markBgRBColor = 0;
        Boolean playing;
        Thread scrollThread { get; set; }

        public int ms { get; set; }

        System.Windows.Forms.Timer timer;

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
            scrollThread = new Thread(new ThreadStart(this.scroll));
            //initTimer();   
            playing = false;
            librarySavePath = "";

            tabFilter = "Tab files (*.tab)|*.tab|All files (*.*)|*.*";
            libraryFilter = "Tab Library files (*.tlib)|*.tlib|All files (*.*)|*.*";

            InitializeComponent();

        }

        delegate void scrollCallBack();

        private void scroll()
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.scrollPanel.InvokeRequired)
            {
                scrollCallBack d = new scrollCallBack(scroll);
                this.Invoke(d, new object[] { });
            }
            else
            {
                playing = true;

                startTimer();
                int mms = getMs();
                while(playing)
                {
                    mms = getMs();
                    scrollPanel.Controls[0].Location = new Point(scrollPanel.Controls[0].Location.X + ms);

                }

            }
        }

      


        private System.Windows.Forms.Timer initTimer()
        {
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 1;
            timer.Tick += tick;
            ms = 0;
            return timer;
        }



        private void tick(object sender, EventArgs e)
        {
            Thread.Sleep(100);
            ms++;
        }


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
            //displayScrollPanel();
            //displayMarkPanel();



            /*
            displaySelectorPanel();
            displayControlPanel();
            */

            // Init Selector
            artistComboBox.Text = "Artist";
            artistComboBox.SelectedIndexChanged +=artistComboBox_SelectedIndexChanged;
            titleComboBox.Text = "Title";


            initLibrary();


            enableVideo = enableVideoCheckBox.Checked;

        }
        private void loadTab(Tab tab)
        {
            log("Loading: " + tab.getSongArtistTitle(" - "));
            createScrollPanelBanner(tab.getSongInfo());

            setControlState(ControlState.library_tab_loaded);

            enableVideo = currentTab.videoEnabled;
            updateVideoUrl(currentTab.videoUrl);

        }


        // Putting panels in place
        private void displayLogPanel()
        {
            controlsLogDivider.Panel2.Controls.Add(logPanel);
            //updateLogPanel();
        }
        private void displayScrollPanel()
        {

            tabVideoDivider.Panel1.Controls.Clear();
            //updateScrollPanel(text);
            tabVideoDivider.Panel1.Controls.Add(scrollPanel);
        }
        private void displayMarkPanel()
        {
            tabVideoDivider.Panel1.Controls.Clear();

            tabVideoDivider.Panel1.Controls.Add(markPanel);
            updateMarkPanel();
        }
        void markLabel_Click(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            label.BackColor = Color.LightGreen;
            label1.Text = ms.ToString();
            //MessageBox.Show("mark click");
            label1.Click += label1_Click;
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
            label.AutoSize = true;
            label.Location = new Point((panel.Width / 2) - (label.Width / 2), (panel.Height / 2) - (label.Height / 2));
            //label.Location = new Point(50, 50);
            panel.Controls.Add(label);
            tabVideoDivider.Panel1.Controls.Clear();
                
            tabVideoDivider.Panel1.Controls.Add(scrollPanel);
        }


        // Creating panels
        private void updateLogPanel()
        {

            FlowLayoutPanel flp = (FlowLayoutPanel)logPanel.Controls[0];
            //logPanel.AutoScrollPosition = new Point(logPanel.AutoScrollPosition.X, logPanel.Height);
        }
        private void updateScrollPanel(List<string> text)
        {

            string content = "";
            for (int i = 0; i < text.Count; i++)
            {
                content += text[i];
            }
            Panel panel = (Panel)scrollPanel;
            panel.Controls.Clear();

            Label label = new Label();
            label.Text = content;
            label.AutoSize = true;
            panel.Controls.Add(label);
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
            for (int i = 0; i < lines.Count; i++)
            {
                Label markLabel = new Label();
                markLabel.Text = lines[i];
                markLabel.BackColor = getMarkTimeLabelColor();
                markLabel.AutoSize = true;
                markLabel.BorderStyle = BorderStyle.Fixed3D;
                markLabel.Click += markLabel_Click;
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
                artistComboBox.Enabled = false;
                titleComboBox.Enabled = false;

                
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
                    exportTabToolStripMenuItem.Enabled = false;
                }
                else
                {
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

                log("Control State: Play mode");
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
            enableVideoControls(enableVideo);

            
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
            saveLibrary(filename);


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

            exportTab(path);

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
            
            string temp = createTempDir("tabaprompter\\");

            // open opendialog and get filename
            string path = selectFile(new OpenFileDialog(), libraryFilter);
            ZipTools.unzip(path, temp);
            string[] files = Directory.GetFiles(temp);
            for (int i = 0; i < files.Length; i++)
            {
                importTab(files[i]);
            }

                // remove temp dir
                removeTempDir(temp);
            
        }
        private void importTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = selectFile(new OpenFileDialog(), tabFilter);
            importTab(path);
            

            // Update comboboxes
            updateComboBoxes(-1);
            
        }
        private void closeLibraryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            initLibrary();
            setControlState(ControlState.initial);
        }
                 
        
        ////////////////////////////// Controls
        private void scrollPlayButton_Click(object sender, EventArgs e)
        {
            scrollThread.Start();
            //startTimer();

            
        }
        private int getMs()
        {
            return ms;
        }
        private void startTimer()
        {
            //Object o = (Thread)timerThread;

            timer = initTimer();
            timer.Start();
        }
        private void stopTimer()
        {
            timer.Stop();
        }
        private void scrollStopButton_Click(object sender, EventArgs e)
        {
            //scrollThread.Abort();
            //scrollThread.Join();
            stopTimer();
        }
        private void scrollResetButton_Click(object sender, EventArgs e)
        {

        }
        private void markModeButton_Click(object sender, EventArgs e)
        {
            if(controlState == ControlState.library_tab_loaded_mark_mode)
            {
                createScrollPanelBanner(currentTab.getSongInfo());
                setControlState(ControlState.library_tab_loaded_play_mode);
                stopTimer();
            }
            else
            {
                displayMarkPanel();
                setControlState(ControlState.library_tab_loaded_mark_mode);
                startTimer();
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
        

    }





    


}
