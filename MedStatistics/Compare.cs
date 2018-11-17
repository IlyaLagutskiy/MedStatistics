using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MedStatistics
{
    public partial class Compare : Form
    {

        private readonly int _type;
        private int _count;

        private ParamsList _paramsList;
        private Intervals _intervals;

        public Compare(int type)
        {
            InitializeComponent();
            _type = type;
        }

        private void Compare_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            _intervals = new Intervals(_type);
            List<Intervals.IntervalStruct> intervalsList = _intervals.GetIntervals();
            int i = 0;
            dataGridView1.Rows.Clear();
            foreach (var l in intervalsList)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells["Number"].Value = i + 1;
                dataGridView1.Rows[i].Cells["Year"].Value = l.Year;
                dataGridView1.Rows[i].Cells["Period"].Value = l.Period;
                dataGridView1.Rows[i].Cells["Check"].Value = false;
                i++;
            }

            dataGridView2.Rows.Add(2);
            dataGridView2.Rows[0].Cells["N"].Value = "";
            dataGridView2.Rows[0].Cells["Code"].Value = "Year";
            dataGridView2.Rows[0].Cells["PName"].Value = "Год";
            dataGridView2.Rows[1].Cells["N"].Value = "";
            dataGridView2.Rows[1].Cells["Code"].Value = "Period";
            dataGridView2.Rows[1].Cells["PName"].Value = "Период";

            _paramsList = new ParamsList(_type);
            List<Params> paramsList = _paramsList.GetNameList();
            i = 2;
            foreach (var l in paramsList)
            {
                dataGridView2.Rows.Add();
                dataGridView2.Rows[i].Cells["N"].Value = i- 1;
                dataGridView2.Rows[i].Cells["Code"].Value = l.Code;
                dataGridView2.Rows[i].Cells["PName"].Value = l.Name;
                i++;
            }

        }

        private void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridView1.IsCurrentCellDirty)
            {
                dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
                return;
            }
            DataGridViewCell cell = dataGridView1.CurrentCell;
            if (cell.RowIndex != -1 
                && cell.OwningColumn.Name == "Check")
            {
                if (cell.Value.ToString() == "true")
                {
                    if (_count >= 2)
                    {
                        dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[0];
                        ((DataGridViewCheckBoxCell)cell).Value = false;
                        MessageBox.Show(@"Нельзя выбрать более двух записей для сравнения!");
                        return;
                    }
                    _count++;
                    LoadCompareData(_count, cell.RowIndex);
                }
                else
                {
                    DeleteCompareData(_count);
                    _count--;
                }
                if (_count == 2)
                {
                    CompareData();
                }
            }
        }

        private void LoadCompareData(int index, int rowIndex)
        {
            string indexS = index == 1 ? "Data1" : "Data2";
            DataList dataList = new DataList(_type, _paramsList);
            dataList.Period = dataGridView1.Rows[rowIndex].Cells["Period"].Value.ToString();
            dataList.Year = int.Parse(dataGridView1.Rows[rowIndex].Cells["Year"].Value.ToString());
            dataList.ReadData();
            for (int i = 0; i < _paramsList.Count; i++)
            {
                dataGridView2.Rows[i + 2].Cells[indexS].Value = dataList.Data[i];
            }

            dataGridView2.Rows[0].Cells[indexS].Value = dataList.Year;
            dataGridView2.Rows[1].Cells[indexS].Value = dataList.Period;
        }

        private void DeleteCompareData(int index)
        {
            string indexS = index == 1 ? "Data1" : "Data2";
            for (int i = 0; i < dataGridView2.RowCount; i++)
            {
                if(index == 2)
                dataGridView2.Rows[i].Cells["Data1"].Value = dataGridView2.Rows[i].Cells["Data2"].Value;
                dataGridView2.Rows[i].Cells[indexS].Value = "";
                dataGridView2.Rows[i].Cells["Change"].Value = "";
                dataGridView2.Rows[i].Cells["Percent"].Value = "";
            }
        }

        private void CompareData()
        {
            for (int i = 2; i < dataGridView2.RowCount; i++)
            {
                double data1 = double.Parse(dataGridView2.Rows[i].Cells["Data1"].Value.ToString());
                double data2 = double.Parse(dataGridView2.Rows[i].Cells["Data2"].Value.ToString());
                dataGridView2.Rows[i].Cells["Change"].Value = data2 - data1;
                dataGridView2.Rows[i].Cells["Percent"].Value = $"{(data2 - data1) / data1 * 100:N2}%";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[i].Cells["Check"].Value = "false";
            }
            DeleteCompareData(2);
            DeleteCompareData(1);
            _count = 0;
        }
    }
}
