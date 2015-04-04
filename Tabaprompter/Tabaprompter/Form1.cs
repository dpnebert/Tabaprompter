using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tabaprompter
{
    public partial class Form1 : Form
    {
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
            librarySavePath = "";

            tabFilter = "Tab files (*.tab)|*.tab|All files (*.*)|*.*";
            libraryFilter = "Tab Library files (*.tlib)|*.tlib|All files (*.*)|*.*";

            InitializeComponent();

        }
        private void initLibrary()
        {
            library = new Library();
            clearComboBoxes();
            setControlState(ControlState.initial);
            setSavedState(SavedState.unsaved);
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

            createScrollPanelBanner(tab.getSongInfo());

            setControlState(ControlState.library_tab_loaded);

            enableVideo = currentTab.videoEnabled;
            updateVideoUrl(currentTab.videoUrl);

        }


        // Putting panels in place
        private void displayLogPanel()
        {
            controlsLogDivider.Panel2.Controls.Add(logPanel);
            updateLogPanel();
        }
        private void displayScrollPanel()
        {
            //updateScrollPanel(text);
            tabVideoDivider.Panel1.Controls.Add(scrollPanel);
        }
        private void displayMarkPanel()
        {
            updateMarkPanel();
            tabVideoDivider.Panel1.Controls.Add(markPanel);
        }
        void markLabel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("mark click");

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
            tabVideoDivider.Panel1.Controls.Add(scrollPanel);
        }


        // Creating panels
        private void updateLogPanel()
        {

            FlowLayoutPanel flp = (FlowLayoutPanel)logPanel.Controls[0];
            Label l = new Label();
            l.Text = "Log Panel!";
            l.AutoSize = true;
            flp.Controls.Add(l);
            logPanel.AutoScroll = true;
            logPanel.AutoScrollPosition = new Point(logPanel.AutoScrollPosition.X, logPanel.Height);
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

            Panel panel = (Panel)markPanel;
            panel.Controls.Clear();

            FlowLayoutPanel flp = new FlowLayoutPanel();
            flp.AutoSize = true;
            flp.WrapContents = false;
            flp.FlowDirection = FlowDirection.TopDown;
            List<string> lines = currentTab.getSectionText();
            for (int i = 0; i < lines.Count; i++)
            {
                Label markLabel = new Label();
                markLabel.Text = lines[i];
                markLabel.AutoSize = true;
                markLabel.BorderStyle = BorderStyle.Fixed3D;
                markLabel.Click += markLabel_Click;
                flp.Controls.Add(markLabel);
            }
            panel.Controls.Add(flp);
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

            // parse contents to tab
            // add tab to library
            library.tabs.Add(LibraryTools.parseTabFromFile(contents));

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

            // get parsed lines from the load tab
            List<String> lines = LibraryTools.parseTabToFile(currentTab);


            // pass path and parsed lines to save util func.
            FileTools.save(path, lines);

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

        }
        private void scrollStopButton_Click(object sender, EventArgs e)
        {

        }
        private void scrollResetButton_Click(object sender, EventArgs e)
        {

        }
        private void markModeButton_Click(object sender, EventArgs e)
        {
            if(controlState == ControlState.library_tab_loaded_mark_mode)
            {
                createScrollPanelBanner(currentTab.getSectionText());
                setControlState(ControlState.library_tab_loaded_play_mode);
            }
            else
            {
                displayMarkPanel();
                setControlState(ControlState.library_tab_loaded_mark_mode);
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
