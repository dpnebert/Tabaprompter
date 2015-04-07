using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Tabaprompter
{
    public class PanelTools
    {



        internal static FlowLayoutPanel createFlowPanel(FlowDirection flowDir, string name)
        {

            FlowLayoutPanel flp = new FlowLayoutPanel();
            flp.FlowDirection = flowDir;
            flp.Dock = DockStyle.Fill;
            flp.AutoSize = true;
            flp.Name = name;
            flp.WrapContents = false;
            return flp;
        }
        internal static Panel createDefaultPanel(string name)
        {
            Panel panel = new Panel();
            panel.Dock = DockStyle.Fill;
            panel.Name = name;
            panel.AutoSize = true;
            return panel;
        }


        internal static Panel buildLogPanel(Panel panel)
        {
            FlowLayoutPanel flp = createFlowPanel(FlowDirection.TopDown, "log");
            panel.Controls.Add(flp);
            flp.AutoScroll = true;
            panel.BorderStyle = BorderStyle.Fixed3D;
            panel.AutoScroll = true;
            return panel;
        }
        internal static Panel buildScrollPanel(Panel panel)
        {
            //panel.BackColor = System.Drawing.Color.Green;//
            panel.AutoScroll = true;
            return panel;////
        }
        internal static Panel buildMarkPanel(Panel panel)
        {
            panel.BorderStyle = BorderStyle.Fixed3D;//
            panel.AutoScroll = true;
           
            return panel;//
        }

        /*
        internal static Panel buildSelectorPanel(Panel panel)
        {
            FlowLayoutPanel flp = createFlowPanel(FlowDirection.TopDown, "selector");
            panel.Controls.Add(flp);
            panel.BorderStyle = BorderStyle.Fixed3D;

            // Build combo box controls



            return panel;
        }
        internal static Panel buildControlPanel(Panel panel)
        {
            FlowLayoutPanel flp = createFlowPanel(FlowDirection.TopDown, "control");
            panel.Controls.Add(flp);
            return panel;
        }
        */



    }
}
