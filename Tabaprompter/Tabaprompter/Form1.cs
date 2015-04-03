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
        Panel selectorPanel;
        Panel controlPanel;

        ControlState controlState;
        SavedState savedState;

        string tabFilter;
        string libraryFilter;
        Library library;
        Tab currentTab { get; set; }

        public Form1()
        {

            tabFilter = "Tab files (*.tab)|*.tab|All files (*.*)|*.*";
            libraryFilter = "Tab Library files (*.tlib)|*.tlib|All files (*.*)|*.*";

            InitializeComponent();
            initLibrary();

            


        }
        private void initLibrary()
        {
            library = new Library();
        }
        

        private void Form1_Load(object sender, EventArgs e)
        {



            logPanel = PanelTools.createDefaultPanel("log");
            scrollPanel = PanelTools.createDefaultPanel("scroll");
            markPanel = PanelTools.createDefaultPanel("mark");
            selectorPanel = PanelTools.createDefaultPanel("selector");
            controlPanel = PanelTools.createDefaultPanel("control");


            logPanel = PanelTools.buildLogPanel(logPanel);
            scrollPanel = PanelTools.buildScrollPanel(scrollPanel);
            markPanel = PanelTools.buildMarkPanel(markPanel);

            /*
            selectorPanel = PanelTools.buildSelectorPanel(selectorPanel);
            controlPanel = PanelTools.buildControlPanel(controlPanel);
            */



            displayLogPanel();
            displayScrollPanel();
            //displayMarkPanel();



            /*
            displaySelectorPanel();
            displayControlPanel();
            */







            // Init Selector
            artistComboBox.Text = "Artist";
            artistComboBox.SelectedIndexChanged +=artistComboBox_SelectedIndexChanged;
            titleComboBox.Text = "Title";
            



            setSavedState(SavedState.unsaved);
            setControlState(ControlState.initial);

        }


        private void displayLogPanel()
        {
            updateLogPanel();
            controlsLogDivider.Panel2.Controls.Add(logPanel);
        }
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




        private void displayScrollPanel()
        {
            updateScrollPanel();
            tabVideoDivider.Panel1.Controls.Add(scrollPanel);
        }
        private void updateScrollPanel()
        {
            Panel panel = (Panel)scrollPanel;
            Label l = new Label();
            l.Text = "Scroll Panel!";
            l.AutoSize = true;
            panel.Controls.Add(l);
        }




        private void displayMarkPanel()
        {
            updateMarkPanel();
            tabVideoDivider.Panel1.Controls.Add(markPanel);
        }
        private void updateMarkPanel()
        {
            FlowLayoutPanel flp = (FlowLayoutPanel)markPanel.Controls[0];
            Label l = new Label();
            l.Text = "Mark Panel!";
            l.AutoSize = true;
            flp.Controls.Add(l);
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


                // Video
                webBrowser.Navigate("about:blank");
                addressBarTextBox.Enabled = false;
                addressGoButton.Enabled = false;
                addressStopButton.Enabled = false;
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
                // Check to see if a tab is loaded so it can be exported.
                if(currentTab == null)
                {
                    exportTabToolStripMenuItem.Enabled = false;
                }
                else
                {
                    exportTabToolStripMenuItem.Enabled = true;
                }
                // Files
                saveLibraryToolStripMenuItem.Enabled = true;
                saveLibraryAsToolStripMenuItem.Enabled = true;
                closeLibraryToolStripMenuItem.Enabled = true;


                // Controls
                scrollPlayButton.Enabled = true;
                scrollStopButton.Enabled = true;
                scrollResetButton.Enabled = true;
                markModeButton.Enabled = true;


                // Video
                addressBarTextBox.Enabled = true;
                addressGoButton.Enabled = true;
                addressStopButton.Enabled = true;


                // Selector
                artistComboBox.Enabled = true;
                titleComboBox.Enabled = true;
            }
            else
            {

            }

            newLibraryToolStripMenuItem.Enabled = true;
            openLibraryToolStripMenuItem.Enabled = true;
            importTabToolStripMenuItem.Enabled = true;


        }



        // Open file
        private string selectFile(FileDialog dialog, string filter)
        {
            //OpenFileDialog 
            //openFileDialog1 = new OpenFileDialog();

            //openFileDialog1.InitialDirectory = "c:\\";
            dialog.Filter = tabFilter;
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


        

        private void saveLibraryToolStripMenuItem_Click(object sender, EventArgs e)
        {

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

            FileTools.save(selectFile(new SaveFileDialog(), libraryFilter), new List<string>());
        }

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

        }

        private void openLibraryToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void importTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            // give path to open file method
            string contents = FileTools.open(selectFile(new OpenFileDialog(), tabFilter));

            // parse contents to tab
            // add tab to library
            library.tabs.Add(LibraryTools.parseTabFromFile(contents));

            // Set control state
            setControlState(ControlState.library_loaded);

            // Update comboboxes
            updateComboBoxes(-1);
            
        }

        private void updateComboBoxes(int artist)
        {
            titleComboBox.Items.Clear();

            List<Tab> tabs = new List<Tab>();
            if(artist == -1)
            {
                for(int i = 0; i < library.tabs.Count; i++)
                {
                    if(!doItemsContainThatArtist(library.tabs[i].artist))
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
            for (int i = 0; i < library.tabs.Count; i++)
            {
                if(library.tabs[i].title == cb.SelectedItem)
                {
                    currentTab = library.tabs[i];
                }
            }

            setControlState(ControlState.library_tab_loaded);
            //updateComboBoxes(cb.SelectedIndex);
        }


    }
}
