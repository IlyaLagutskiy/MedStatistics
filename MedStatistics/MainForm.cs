using System;
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

        private void button3_Click(object sender, EventArgs e)
        {
            Compare compare = new Compare(1);
            compare.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Record record = new Record(2);
            record.ShowDialog();
        }


        private void button5_Click(object sender, EventArgs e)
        {
            RecordsList recordsList = new RecordsList(2);
            recordsList.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Compare compare = new Compare(2);
            compare.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Record record = new Record(3);
            record.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            RecordsList recordsList = new RecordsList(3);
            recordsList.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Compare compare = new Compare(3);
            compare.ShowDialog();
        }
    }
}
