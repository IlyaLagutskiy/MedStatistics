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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Record record = new Record(1);
            record.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RecordsList recordsList = new RecordsList(1);
            recordsList.ShowDialog();
        }
    }
}
