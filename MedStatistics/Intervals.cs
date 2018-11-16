using System;
using System.Collections.Generic;
using System.Data.SQLite;


namespace MedStatistics
{
    class Intervals
    {
        public struct IntervalStruct
        {
            public int Year;
            public string Period;
        }

        private readonly int _type;

        public Intervals(int type)
        {
            _type = type;
        }

        public List<IntervalStruct> GetIntervals()
        {
            SQLiteConnection connection = new SQLiteConnection();
            connection.ConnectionString = "Data Source = " + Program.DataSource;

            SQLiteCommand command = new SQLiteCommand();
            command.CommandText = $"SELECT Year, Period FROM {Tables.ConvertTable(_type)};";
            command.Connection = connection;
            SQLiteDataReader dataReader;
            List<IntervalStruct> list = new List<IntervalStruct>();

            try
            {
                connection.Open();
                dataReader = command.ExecuteReader();
                IntervalStruct temp;
                while (dataReader.Read())
                {
                    temp.Year = dataReader.GetInt32(0);
                    temp.Period = dataReader.GetString(1);
                    list.Add(temp);
                }

                dataReader.Close();
                connection.Close();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Dispose();
            }

            return list;
        }
}
}
