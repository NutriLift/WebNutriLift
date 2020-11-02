using Dapper;
using Microsoft.Extensions.Configuration;
using NutriLift.Entities;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace NutriLift.Data
{
    public class UserDetailsRepository : IUserDetailsRepository
    {
        private readonly IDBConnection dbConnection;
        private readonly IConfiguration configuration;
        private readonly string connectionString = string.Empty;

        public UserDetailsRepository(IConfiguration configuration, IDBConnection dbConnection)
        {
            this.dbConnection = dbConnection;
            this.configuration = configuration;
            //Get connection string from the appsettings file
            connectionString = this.configuration.GetConnectionString("MainConnection");
        }

        // Example of executing a SP
        public UserDetails VerifyUserLogin(string userName)
        {
            using (var sqlConnection = dbConnection.CreateConnection(connectionString))
            {
                try
                {
                    dbConnection.OpenConnection();
                    var param = new DynamicParameters(); // Building Parameters
                    param.Add("@UserName", userName);
                    //Executing SP and converting the resultset to the UserDetails type
                    var userDetails = sqlConnection.Query<UserDetails>("VerifyUserLogin", param, null,true,0, CommandType.StoredProcedure).FirstOrDefault();
                    return userDetails;
                }              
                finally
                {
                    dbConnection.CloseConnection(); // SQL connection will be closed and disposed
                }
            }
        }

        //Example of executing a SQL query 
        public List<UserDetails> GetAllUsers()
        {
            using (var sqlConnection = dbConnection.CreateConnection(connectionString))
            {
                try
                {
                    var query = @"SELECT [UD_PK] as UserId
                                      ,[UD_IsActive] as IsActive
                                      ,[UD_FirstName] as FirstName
                                      ,[UD_UserName] as UserName
                                      ,[UD_Birthdate] as Birthdate
                                      ,[UD_Gender] as Gender
                                      ,[UD_IsAdmin] as IsAdmin
                                  FROM[dbo].[UserDetails]";
                    dbConnection.OpenConnection();
                    var userList = sqlConnection.Query<UserDetails>(query, null, null, true, 0, CommandType.Text).ToList();
                    return userList;
                }
                finally
                {
                    dbConnection.CloseConnection();
                }
            }
        }
    }
}
