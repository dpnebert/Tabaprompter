using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tabaprompter
{
    public partial class Form1 : Form
    {
        Library library;
        public Form1()
        {
            InitializeComponent();

            library = new Library();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void importTabToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
