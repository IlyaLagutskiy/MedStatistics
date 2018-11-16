using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;

namespace MedStatistics
{
    class DataList
    {
        public int Year { get; set; }
        public string Period { get; set; }
        public List<double> Data { get; set; }

        private readonly int _type;
        private readonly ParamsList _paramsList;

        public DataList(int type)
        {
            _type = type;
        }

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
                                  $"WHERE Year = @year AND Period = @period;";
            //           command.Parameters.Add(new SQLiteParameter("@table", Tables.ConvertTable(_type)));
            //           command.Parameters.Add(new SQLiteParameter("@params", _paramsList.ToParamsString()));
            command.Parameters.Add("@year", DbType.Int32).Value = Year;
            command.Parameters.Add("@period", DbType.String).Value = Period;
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

        public void ReadData()
        {
            SQLiteConnection connection = new SQLiteConnection();
            connection.ConnectionString = "Data Source = " + Program.DataSource;

            SQLiteCommand command = new SQLiteCommand();
            command.CommandText = $"SELECT * FROM {Tables.ConvertTable(_type)} WHERE Year = @year AND Period = @period;";
            command.Parameters.Add("@year", DbType.Int32).Value = Year;
            command.Parameters.Add("@period", DbType.String).Value = Period;
            command.Connection = connection;
            SQLiteDataReader dataReader;
            Data = new List<double>();

            try
            {
                connection.Open();
                dataReader = command.ExecuteReader();
                double temp;
                dataReader.Read();
                for (int i = 0; i < _paramsList.Count; ++i)
                {
                    temp = dataReader.GetDouble(i+2);
                    Data.Add(temp);
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
        }

        public void DeleteData()
        {
            SQLiteConnection connection = new SQLiteConnection();
            connection.ConnectionString = "Data Source = " + Program.DataSource;

            SQLiteCommand command = new SQLiteCommand();
            command.CommandText = $"DELETE FROM {Tables.ConvertTable(_type)} WHERE Year = @year AND Period = @period;";
            command.Parameters.Add("@year", DbType.Int32).Value = Year;
            command.Parameters.Add("@period", DbType.String).Value = Period;
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
                statement += $"'{_paramsList.List[i].Code}' = {Data[i]}, ";
            }

            return statement.Remove(statement.Length - 2, 1);
        }

    }
}
