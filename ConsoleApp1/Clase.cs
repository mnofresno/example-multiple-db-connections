using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Clase
    {
        private async Task<SqlConnection> GetConnection()
        {
            var connection = new SqlConnection("Data Source=.;Initial Catalog=AdventureWorks;Integrated Security=True;MultipleActiveResultSets=true;");

            await connection.OpenAsync();

            return connection;
        }

        public async Task<List<SqlDataReader>> ExecuteAsync()
        {
            var tasksList = new List<Task<SqlDataReader>>();
            var transactions = new List<SqlTransaction>();
            var connections = new List<SqlConnection>();

            for (int i = 0; i < 10; i++)
            {
                var connection = await GetConnection();
                var command = connection.CreateCommand();
                var transaction = connection.BeginTransaction();
                var dr = ExecuteSP(connection, transaction, null);
                tasksList.Add(dr);
                transactions.Add(transaction);
                connections.Add(connection);
            }

            
            await Task.WhenAll(tasksList);
            transactions.ForEach(x => x.Commit());
            connections.ForEach(x => x.Close());



            var result = new List<SqlDataReader>();

            foreach (var drTask in tasksList)
            {
                var dr = await drTask;

                result.Add(dr);
            }

            return result;
        }

        private async Task<SqlDataReader> ExecuteSP(SqlConnection connection, SqlTransaction transaction, SqlCommand command1 = null)
        {
            command1 = connection.CreateCommand();

            command1.CommandType = System.Data.CommandType.StoredProcedure;
            command1.CommandText = "delayCustom";
            command1.Transaction = transaction;
            var dr1 = await command1.ExecuteReaderAsync(System.Data.CommandBehavior.Default);
            return dr1;
        }
    }
}
