using System;
using System.Collections.Generic;
using System.Data;

using System.Data.SQLite;

namespace MedStatistics
{

    struct Params
    {
        public int Type;
        public string Code;
        public string Name;
    }

    class ParamsList
    {

        public int Count { get; private set; }
        public int Type { get; private set; }

        public List<Params> list = new List<Params>();

        public ParamsList(int type)
        {
            Type = type;
        }

        public List<Params> GetNameList()
        {
            SQLiteConnection connection = new SQLiteConnection();
            connection.ConnectionString = "Data Source = " + Program.DataSource;

            SQLiteCommand command = new SQLiteCommand();
            command.CommandText = "SELECT * FROM Params WHERE Type = @type;";
            command.Parameters.Add("@type", DbType.Int32).Value = Type;
            command.Connection = connection;
            SQLiteDataReader dataReader;

            try
            {
                connection.Open();
                dataReader = command.ExecuteReader();
                Count = dataReader.FieldCount;
                Params temp;
                while (dataReader.Read())
                {
                    temp.Type = dataReader.GetInt32(0);
                    temp.Code = dataReader.GetString(1);
                    temp.Name = dataReader.GetString(2);
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

        public string ToParamsString()
        {
            string _params = "";
            foreach (var l in list)
            {
                _params += $", '{l.Code}'";
            }
            return _params;
        }
    }
}
