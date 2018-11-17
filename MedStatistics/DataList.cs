using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Globalization;
using System.Windows.Forms;

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

        public bool WriteData()
        {
            if (CheckData())
            {
                // ReSharper disable once LocalizableElement
                MessageBox.Show("Данная запись уже существует!\nЗначения не сохранены!");
                return false;
            }

            SQLiteConnection connection = new SQLiteConnection();
            connection.ConnectionString = "Data Source = " + Program.DataSource;

            SQLiteCommand command = new SQLiteCommand();
            command.CommandText = $"INSERT INTO {Tables.ConvertTable(_type)} " +
                                  $"('Year', 'Period' {_paramsList.ToParamsString()}) " +
                                  $"VALUES ('{Year}', '{Period}'{DataToString()});";
            command.Connection = connection;

            bool result = true;

            try
            {
                connection.Open();

                command.ExecuteNonQuery();

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                result = false;
            }
            finally
            {
                connection.Dispose();
            }

            return result;
        }

        public bool CorrectData()
        {

            SQLiteConnection connection = new SQLiteConnection();
            connection.ConnectionString = "Data Source = " + Program.DataSource;

            SQLiteCommand command = new SQLiteCommand();
            command.CommandText = $"UPDATE {Tables.ConvertTable(_type)} " +
                                  $"SET {CorrectStatement()} " +
                                  "WHERE Year = @year AND Period = @period;";
            command.Parameters.Add("@year", DbType.Int32).Value = Year;
            command.Parameters.Add("@period", DbType.String).Value = Period;
            command.Connection = connection;

            bool result = true;

            try
            {
                connection.Open();

                command.ExecuteNonQuery();

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                result = false;
            }
            finally
            {
                connection.Dispose();
            }

            return result;
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
                    temp = dataReader.GetDouble(i + 2);
                    Data.Add(temp);
                }
                dataReader.Close();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Dispose();
            }
        }

        public bool DeleteData()
        {
            SQLiteConnection connection = new SQLiteConnection();
            connection.ConnectionString = "Data Source = " + Program.DataSource;

            SQLiteCommand command = new SQLiteCommand();
            command.CommandText = $"DELETE FROM {Tables.ConvertTable(_type)} WHERE Year = @year AND Period = @period;";
            command.Parameters.Add("@year", DbType.Int32).Value = Year;
            command.Parameters.Add("@period", DbType.String).Value = Period;
            command.Connection = connection;

            bool result = true;

            try
            {
                connection.Open();

                command.ExecuteNonQuery();

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                result = false;
            }
            finally
            {
                connection.Dispose();
            }

            return result;
        }

        public bool CheckData()
        {
            SQLiteConnection connection = new SQLiteConnection();
            connection.ConnectionString = "Data Source = " + Program.DataSource;

            SQLiteCommand command = new SQLiteCommand();
            command.CommandText = $"SELECT COUNT(*) FROM {Tables.ConvertTable(_type)} WHERE Year = @year AND Period = @period;";
            command.Parameters.Add("@year", DbType.Int32).Value = Year;
            command.Parameters.Add("@period", DbType.String).Value = Period;
            command.Connection = connection;

            bool result = false;

            try
            {
                connection.Open();

                result = Convert.ToInt32(command.ExecuteScalar()) != 0;

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Dispose();
            }

            return result;
        }

        public string DataToString()
        {
            string data = "";
            foreach (var d in Data)
            {
                data += $", {d.ToString(CultureInfo.InvariantCulture)}";
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
