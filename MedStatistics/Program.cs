﻿using System;
using System.Windows.Forms;

namespace MedStatistics
{
    static class Program
    {
        public static string DataSource = "MedStatistics.db";
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
