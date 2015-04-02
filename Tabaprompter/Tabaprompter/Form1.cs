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

        string tabFilter;
        Library library;


        public Form1()
        {

            tabFilter = "Tab files (*.tab)|*.tab|All files (*.*)|*.*";

            InitializeComponent();
            initLibrary();

            


        }
        private void initLibrary()
        {
            library = new Library();
            library.tabs = new List<Tab>();
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


        












        
        



        private void setControlState(ControlState cS)
        {
            
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
            else if (controlState == ControlState.unsaved_library_loaded)
            {

                // Files
                saveLibraryAsToolStripMenuItem.Enabled = true;
                saveLibraryToolStripMenuItem.Enabled = true;
                exportTabToolStripMenuItem.Enabled = true;
                closeLibraryToolStripMenuItem.Enabled = true;


                // Selector
                artistComboBox.Enabled = true;
                titleComboBox.Enabled = true;
            }
            else if (controlState == ControlState.saved_library_loaded)
            {

                // Files
                saveLibraryAsToolStripMenuItem.Enabled = true;
                saveLibraryToolStripMenuItem.Enabled = true;
                exportTabToolStripMenuItem.Enabled = true;
                closeLibraryToolStripMenuItem.Enabled = true;


                // Selector
                artistComboBox.Enabled = true;
                titleComboBox.Enabled = true;
            }
            else if (controlState == ControlState.unsaved_library_tab_loaded)
            {
                // Files
                saveLibraryAsToolStripMenuItem.Enabled = true;
                saveLibraryToolStripMenuItem.Enabled = true;
                exportTabToolStripMenuItem.Enabled = true;
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
            else if (controlState == ControlState.saved_library_tab_loaded)
            {
                // Files
                saveLibraryAsToolStripMenuItem.Enabled = true;
                saveLibraryToolStripMenuItem.Enabled = true;
                exportTabToolStripMenuItem.Enabled = true;
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
        private void openFile(string filter)
        {
            
        }


        

        private void saveLibraryToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void saveLibraryAsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exportTabToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void newLibraryToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void openLibraryToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void importTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            //openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = tabFilter;
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            String contents;
            // string path : Open Dialog box
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                // give path to open file method
                contents = FileTools.open(openFileDialog1.FileName);

                // parse contents to tab
                // add tab to library
                library.tabs.Add(LibraryTools.parseTab(contents));

                // Set control state
                setControlState(ControlState.library_loaded);
            }

            
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


    }
}
