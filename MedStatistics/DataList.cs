using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

namespace MedStatistics
{
    class DataList
    {
        public int Year { get; set; }
        public string Period { get; set; }
        public List<double> Data { get; set; }

        private readonly int _type;
        private readonly ParamsList _paramsList;

        public DataList(int type, ParamsList paramsList)
        {
            _type = type;
            _paramsList = paramsList;
        }

        public void WriteData()
        {
            SQLiteConnection connection = new SQLiteConnection();
            connection.ConnectionString = "Data Source = " + Program.DataSource;

            SQLiteCommand command = new SQLiteCommand();
            command.CommandText = $"INSERT INTO {Tables.ConvertTable(_type)} " +
                                  $"('Year', 'Period' {_paramsList.ToParamsString()}) " +
                                  $"VALUES ('{Year}', '{Period}'{DataToString()});";
 //           command.Parameters.Add(new SQLiteParameter("@table", Tables.ConvertTable(_type)));
 //           command.Parameters.Add(new SQLiteParameter("@params", _paramsList.ToParamsString()));
 //           command.Parameters.Add(new SQLiteParameter("@year", Year));
 //           command.Parameters.Add(new SQLiteParameter("@period", Period));
 //           command.Parameters.Add(new SQLiteParameter("@data", DataToString()));
            command.Connection = connection;

            try
            {
                connection.Open();

                command.ExecuteNonQuery();

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
        }

        public void CorrectData()
        {
            SQLiteConnection connection = new SQLiteConnection();
            connection.ConnectionString = "Data Source = " + Program.DataSource;

            SQLiteCommand command = new SQLiteCommand();
            command.CommandText = $"UPDATE {Tables.ConvertTable(_type)} " +
                                  $"SET {CorrectStatement()} " +
                                  $"WHERE Year = '{Year}' AND Period = '{Period}';";
            //           command.Parameters.Add(new SQLiteParameter("@table", Tables.ConvertTable(_type)));
            //           command.Parameters.Add(new SQLiteParameter("@params", _paramsList.ToParamsString()));
            //           command.Parameters.Add(new SQLiteParameter("@year", Year));
            //           command.Parameters.Add(new SQLiteParameter("@period", Period));
            //           command.Parameters.Add(new SQLiteParameter("@data", DataToString()));
            command.Connection = connection;

            try
            {
                connection.Open();

                command.ExecuteNonQuery();

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
        }

        public string DataToString()
        {
            string data = "";
            foreach (var d in Data)
            {
                data += $", {d}";
            }

            return data;
        }

        public string CorrectStatement()
        {
            string statement = "";
            for (int i = 0; i < Data.Count; i++)
            {
                statement += $"'{_paramsList.list[i].Code}' = {Data[i]}, ";
            }

            return statement.Remove(statement.Length - 2, 1);
        }

    }
}
