using System.Data;

namespace NutriLift.Data
{
    public interface IDBConnection
    {
        IDbConnection Connection { get; }
        void CloseConnection();
        IDbConnection CreateConnection(string connectionString);
        void OpenConnection();
    }
}
