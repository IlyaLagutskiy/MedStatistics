using System.ComponentModel;
using System.Windows.Forms;

namespace MedStatistics
{
    partial class Compare
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Year = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Period = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Check = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.N = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Change = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Percent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Number,
            this.Year,
            this.Period,
            this.Check});
            this.dataGridView1.Location = new System.Drawing.Point(17, 16);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(5);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(323, 383);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CurrentCellDirtyStateChanged += new System.EventHandler(this.dataGridView1_CurrentCellDirtyStateChanged);
            // 
            // Number
            // 
            this.Number.HeaderText = "№";
            this.Number.Name = "Number";
            this.Number.ReadOnly = true;
            this.Number.Width = 25;
            // 
            // Year
            // 
            this.Year.HeaderText = "Год";
            this.Year.Name = "Year";
            this.Year.ReadOnly = true;
            this.Year.Width = 50;
            // 
            // Period
            // 
            this.Period.HeaderText = "Период";
            this.Period.Name = "Period";
            this.Period.ReadOnly = true;
            // 
            // Check
            // 
            this.Check.FalseValue = "false";
            this.Check.HeaderText = "Сравнить";
            this.Check.Name = "Check";
            this.Check.TrueValue = "true";
            this.Check.Width = 75;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(17, 407);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(157, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Очистить выделение";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.N,
            this.Code,
            this.PName,
            this.Data1,
            this.Data2,
            this.Change,
            this.Percent});
            this.dataGridView2.Location = new System.Drawing.Point(349, 16);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.Size = new System.Drawing.Size(927, 383);
            this.dataGridView2.TabIndex = 3;
            // 
            // N
            // 
            this.N.HeaderText = "№";
            this.N.Name = "N";
            this.N.ReadOnly = true;
            this.N.Width = 30;
            // 
            // Code
            // 
            this.Code.HeaderText = "Code";
            this.Code.Name = "Code";
            this.Code.ReadOnly = true;
            this.Code.Visible = false;
            // 
            // PName
            // 
            this.PName.HeaderText = "Наименование";
            this.PName.Name = "PName";
            this.PName.ReadOnly = true;
            this.PName.Width = 500;
            // 
            // Data1
            // 
            this.Data1.HeaderText = "Значение 1";
            this.Data1.Name = "Data1";
            this.Data1.ReadOnly = true;
            this.Data1.Width = 75;
            // 
            // Data2
            // 
            this.Data2.HeaderText = "Значение 2";
            this.Data2.Name = "Data2";
            this.Data2.ReadOnly = true;
            this.Data2.Width = 75;
            // 
            // Change
            // 
            this.Change.HeaderText = "Изменение";
            this.Change.Name = "Change";
            this.Change.ReadOnly = true;
            // 
            // Percent
            // 
            this.Percent.HeaderText = "Процент";
            this.Percent.Name = "Percent";
            this.Percent.ReadOnly = true;
            this.Percent.Width = 80;
            // 
            // Compare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1302, 446);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Compare";
            this.Text = "Сравнение записей";
            this.Load += new System.EventHandler(this.Compare_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dataGridView1;
        private Button button1;
        private DataGridView dataGridView2;
        private DataGridViewTextBoxColumn Number;
        private DataGridViewTextBoxColumn Year;
        private DataGridViewTextBoxColumn Period;
        private DataGridViewCheckBoxColumn Check;
        private DataGridViewTextBoxColumn N;
        private DataGridViewTextBoxColumn Code;
        private DataGridViewTextBoxColumn PName;
        private DataGridViewTextBoxColumn Data1;
        private DataGridViewTextBoxColumn Data2;
        private DataGridViewTextBoxColumn Change;
        private DataGridViewTextBoxColumn Percent;
    }
}