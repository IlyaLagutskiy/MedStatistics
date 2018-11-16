using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MedStatistics
{
    public partial class Record : Form
    {
        private readonly bool _isCreating;
        private readonly int _type;
        private ParamsList _paramsList;
        private DataList _dataList;
        private Intervals.IntervalStruct _interval;

        public Record(int type)
        {
            InitializeComponent();
            _isCreating = true;
            _type = type;
        }

        public Record(int type, int year, string period)
        {
            InitializeComponent();
            _type = type;
            _isCreating = false;
            _interval.Period = period;
            _interval.Year = year;
        }

        private void Note_Load(object sender, EventArgs e)
        {
            _paramsList = new ParamsList(_type);
            List<Params> list = _paramsList.GetNameList();
            for (int i = 0; i < list.Count; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells["Number"].Value = i + 1;
                dataGridView1.Rows[i].Cells["Code"].Value = list[i].Code;
                dataGridView1.Rows[i].Cells["PName"].Value = list[i].Name;
            }
            if (_isCreating)
            {
                comboBox1.SelectedIndex = 0;
                comboBox2.SelectedIndex = 0;
            }
            else
            {
                comboBox1.SelectedText = _interval.Period;
                comboBox2.SelectedText = _interval.Year.ToString();
                comboBox1.Enabled = false;
                comboBox2.Enabled = false;
                _dataList = new DataList(_type, _paramsList);
                _dataList.Year = _interval.Year;
                _dataList.Period = _interval.Period;
                _dataList.ReadData();
                for (int i = 0; i < list.Count; i++)
                {
                    dataGridView1.Rows[i].Cells["Data"].Value = _dataList.Data[i];
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<double> data = new List<double>();
            try
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    double temp;
                    temp = double.Parse(dataGridView1.Rows[i].Cells["Data"].Value.ToString());
                    data.Add(temp);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            string period = comboBox1.Text;
            int year = int.Parse(comboBox2.Text);

            DataList dataList = new DataList(_type, _paramsList);
            dataList.Year = year;
            dataList.Period = period;
            dataList.Data = data;
            if (_isCreating)
            {
                dataList.WriteData();
            }
            else
            {
                dataList.CorrectData();
            }

            MessageBox.Show(@"Сохранено");

        }
    }
}
