using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace MedStatistics
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new GroupBox();
            this.button3 = new Button();
            this.button2 = new Button();
            this.button1 = new Button();
            this.groupBox2 = new GroupBox();
            this.button6 = new Button();
            this.button5 = new Button();
            this.button4 = new Button();
            this.groupBox3 = new GroupBox();
            this.button9 = new Button();
            this.button8 = new Button();
            this.button7 = new Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new Point(16, 14);
            this.groupBox1.Margin = new Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new Padding(4);
            this.groupBox1.Size = new Size(240, 368);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Административные процедуры";
            // 
            // button3
            // 
            this.button3.Location = new Point(7, 126);
            this.button3.Name = "button3";
            this.button3.Size = new Size(226, 23);
            this.button3.TabIndex = 0;
            this.button3.Text = "Сравнить записи";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new Point(7, 79);
            this.button2.Name = "button2";
            this.button2.Size = new Size(226, 23);
            this.button2.TabIndex = 0;
            this.button2.Text = "Просмотреть записи";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new Point(7, 33);
            this.button1.Name = "button1";
            this.button1.Size = new Size(226, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Создать запись";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new EventHandler(this.button1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button6);
            this.groupBox2.Controls.Add(this.button5);
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Location = new Point(264, 14);
            this.groupBox2.Margin = new Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new Padding(4);
            this.groupBox2.Size = new Size(240, 368);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Заболеваемость";
            // 
            // button6
            // 
            this.button6.Location = new Point(7, 126);
            this.button6.Name = "button6";
            this.button6.Size = new Size(226, 23);
            this.button6.TabIndex = 1;
            this.button6.Text = "Сравнить записи";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.Location = new Point(7, 79);
            this.button5.Name = "button5";
            this.button5.Size = new Size(226, 23);
            this.button5.TabIndex = 1;
            this.button5.Text = "Просмотреть записи";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Location = new Point(7, 33);
            this.button4.Name = "button4";
            this.button4.Size = new Size(226, 23);
            this.button4.TabIndex = 1;
            this.button4.Text = "Создать запись";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new EventHandler(this.button4_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button9);
            this.groupBox3.Controls.Add(this.button8);
            this.groupBox3.Controls.Add(this.button7);
            this.groupBox3.Location = new Point(512, 14);
            this.groupBox3.Margin = new Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new Padding(4);
            this.groupBox3.Size = new Size(240, 368);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Показатели";
            // 
            // button9
            // 
            this.button9.Location = new Point(7, 126);
            this.button9.Name = "button9";
            this.button9.Size = new Size(226, 23);
            this.button9.TabIndex = 2;
            this.button9.Text = "Сравнить записи";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new EventHandler(this.button9_Click);
            // 
            // button8
            // 
            this.button8.Location = new Point(7, 79);
            this.button8.Name = "button8";
            this.button8.Size = new Size(226, 23);
            this.button8.TabIndex = 2;
            this.button8.Text = "Просмотреть записи";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new EventHandler(this.button8_Click);
            // 
            // button7
            // 
            this.button7.Location = new Point(7, 33);
            this.button7.Name = "button7";
            this.button7.Size = new Size(226, 23);
            this.button7.TabIndex = 2;
            this.button7.Text = "Создать запись";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new EventHandler(this.button7_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new SizeF(8F, 16F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(765, 395);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new Padding(4);
            this.Name = "MainForm";
            this.Text = "МедСтатистика";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBox1;
        private Button button3;
        private Button button2;
        private Button button1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private Button button6;
        private Button button5;
        private Button button4;
        private Button button9;
        private Button button8;
        private Button button7;
    }
}

