using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MedStatistics
{
    public partial class RecordsList : Form
    {
        private readonly int _type;

        public RecordsList(int type)
        {
            InitializeComponent();
            _type = type;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            button3.Enabled = checkBox1.Checked;
        }

        private void RecordsList_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            Intervals intervals = new Intervals(_type);
            List<Intervals.IntervalStruct> list = intervals.GetIntervals();
            int i = 0;
            dataGridView1.Rows.Clear();
            foreach (var l in list)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells["Number"].Value = i + 1;
                dataGridView1.Rows[i].Cells["Year"].Value = l.Year;
                dataGridView1.Rows[i].Cells["Period"].Value = l.Period;
                i++;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (dataGridView1.CurrentRow != null)
            {
                int year = int.Parse(dataGridView1.CurrentRow.Cells["Year"].Value.ToString());
                string period = dataGridView1.CurrentRow.Cells["Period"].Value.ToString();
                Record record = new Record(_type, year, period);
                record.ShowDialog();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataList dataList = new DataList(_type);
            dataList.Year = int.Parse(dataGridView1.CurrentRow.Cells["Year"].Value.ToString());
            dataList.Period = dataGridView1.CurrentRow.Cells["Period"].Value.ToString();
            dataList.DeleteData();
            MessageBox.Show(@"Данные удалены");
            checkBox1.Checked = false;
            LoadData();
        }
    }
}
