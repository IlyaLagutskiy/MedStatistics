using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MedStatistics
{
    public partial class RecordsList : Form
    {
        public RecordsList(int type)
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            button3.Enabled = checkBox1.Checked;
        }
    }
}
