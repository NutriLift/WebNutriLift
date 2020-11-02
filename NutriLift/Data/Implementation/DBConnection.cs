using System.Data;
using System.Data.SqlClient;

namespace NutriLift.Data
{
    public class DBConnection : IDBConnection
    {
        public IDbConnection Connection { get; private set; }

        public IDbConnection CreateConnection(string connectionString)
        {
            if (Connection == null)
            {
                Connection = new SqlConnection(connectionString);
            }

            return Connection;
        }

        public void OpenConnection()
        {
            if (Connection.State == ConnectionState.Broken)
                Connection.Close();
            if (Connection.State == ConnectionState.Closed)
                Connection.Open();
        }

        public void CloseConnection()
        {
            if (Connection != null && Connection.State == ConnectionState.Open)
            {
                Connection.Close();
                Connection.Dispose();
            }
        }
    }
}
