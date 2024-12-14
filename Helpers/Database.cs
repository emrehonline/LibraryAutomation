using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;

namespace LibraryAutomation.Helpers
{
    public class Database
    {
        private SqliteConnection GetConnection()
        {
            string connectionString = @"DataSource=denemeDB.db";
            return new SqliteConnection(connectionString);
        }

        private SqliteConnection OpenConnection(SqliteConnection connection)
        {
            if (connection.State != System.Data.ConnectionState.Open)
                connection.Open();

            if (connection.State == System.Data.ConnectionState.Open)
                return connection;
            else
                throw new Exception("Connection Failed");
        }

        private void CloseConnection(SqliteConnection connection)
        {
            if (connection.State == System.Data.ConnectionState.Open)
                connection.Close();
        }

        public bool ExecuteCommand(string query, Dictionary<string, object> parameters = null)
        {
            using (var connection = GetConnection())
            {
                using (SqliteCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    command.Connection = connection;
                    if (parameters != null)
                    {
                        foreach (var parameter in parameters)
                        {
                            command.Parameters.Add(new SqliteParameter(parameter.Key, parameter.Value));
                        }
                    }

                    OpenConnection(connection);

                    int result = command.ExecuteNonQuery();

                    CloseConnection(connection);

                    return result >= 1;
                }
            }
        }

        public bool CheckIfDataExist(string query, Dictionary<string, object> parameters, int limit = 0)
        {
            using (var connection = GetConnection())
            {
                if (limit > 0)
                    query += $" limit {limit}";

                using (var command = new SqliteCommand(query, connection))
                {
                    command.CommandText = query;
                    command.Connection = connection;
                    foreach (var parameter in parameters)
                    {
                        command.Parameters.Add(new SqliteParameter(parameter.Key, parameter.Value));
                    }

                    OpenConnection(connection);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read()) // Don't assume we have any rows.
                        {
                            int ord = reader.GetInt32(0);
                            return ord > 0;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
        }

        public List<object[]> GetList(string tableName, int columnCount = 1)
        {
            using (var connection = GetConnection())
            {
                using (SqliteCommand command = connection.CreateCommand())
                {
                    command.CommandText = $"Select * From {tableName}";
                    command.Connection = connection;

                    OpenConnection(connection);
                    List<object[]> rows = new List<object[]>();
                    using (SqliteDataReader read = command.ExecuteReader())
                    {
                        while (read.Read())
                        {
                            object[] row = new object[columnCount];
                            for (int i = 0; i < columnCount; i++)
                            {
                                row[i] = read.GetValue(i);
                            }

                            rows.Add(row);
                        }
                    }

                    CloseConnection(connection);

                    return rows;
                }
            }
        }

        public List<object[]> GetListByQuery(string query, int columnCount = 1)
        {
            using (var connection = GetConnection())
            {
                using (SqliteCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    command.Connection = connection;

                    OpenConnection(connection);
                    List<object[]> rows = new List<object[]>();
                    using (SqliteDataReader read = command.ExecuteReader())
                    {
                        while (read.Read())
                        {
                            object[] row = new object[columnCount];
                            for (int i = 0; i < columnCount; i++)
                            {
                                row[i] = read.GetValue(i);
                            }

                            rows.Add(row);
                        }
                    }

                    CloseConnection(connection);

                    return rows;
                }
            }
        }
    }
}
