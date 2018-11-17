using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

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

        private readonly int _type;
        public int Count { get; private set; }

        public List<Params> List = new List<Params>();

        public ParamsList(int type)
        {
            _type = type;
            Count = 0;
        }

        public List<Params> GetNameList()
        {
            SQLiteConnection connection = new SQLiteConnection();
            connection.ConnectionString = "Data Source = " + Program.DataSource;

            SQLiteCommand command = new SQLiteCommand();
            command.CommandText = "SELECT * FROM Params WHERE Type = @type;";
            command.Parameters.Add("@type", DbType.Int32).Value = _type;
            command.Connection = connection;
            SQLiteDataReader dataReader;

            try
            {
                connection.Open();
                dataReader = command.ExecuteReader();
                Params temp;
                while (dataReader.Read())
                {
                    temp.Type = dataReader.GetInt32(0);
                    temp.Code = dataReader.GetString(1);
                    temp.Name = dataReader.GetString(2);
                    List.Add(temp);
                    Count++;
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

            return List;
        }

        public string ToParamsString()
        {
            string _params = "";
            foreach (var l in List)
            {
                _params += $", '{l.Code}'";
            }
            return _params;
        }
    }
}
