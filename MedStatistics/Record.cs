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
    public partial class Record : Form
    {
        private readonly bool _isCreating;
        private readonly int _type;
        private ParamsList _paramsList;

        public Record(bool isCreating, int type)
        {
            InitializeComponent();
            _isCreating = isCreating;
            _type = type;
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

            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool isParsing = true;
            int i = 0;
            List < double > data = new List<double>();
            int count = dataGridView1.RowCount;
            while(isParsing && i<count)
            {
                double temp;
                isParsing = double.TryParse(dataGridView1.Rows[i].Cells["Data"].Value.ToString(), out temp);
                i++;
                data.Add(temp);
            }

            if (i != count)
            {
                MessageBox.Show($"Неверный формат чисел в строке {i+1}");
                return;
            }

            string period = comboBox1.Text;
            int year = int.Parse(comboBox2.Text);

            DataList dataList = new DataList(_type, _paramsList);
            dataList.Year = year;
            dataList.Period = period;
            dataList.Data = data;

            dataList.CorrectData();

        }
    }
}
