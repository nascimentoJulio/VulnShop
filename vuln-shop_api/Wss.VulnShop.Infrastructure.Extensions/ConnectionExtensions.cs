using Dapper;
using Npgsql;
using System.Text;

namespace Wss.VulnShop.Infrastructure.Extensions
{
    public static class ConnectionExtensions
    {
        public static async Task<IEnumerable<T>> QueryPaginatedAsync<T>(this NpgsqlConnection conn, string query, int limit, int page) 
        {
           StringBuilder finalQuery = new StringBuilder(query);
            finalQuery.AppendLine(@"limit @Limit
                                    offset @Page");
            return await conn.QueryAsync<T>(finalQuery.ToString(), new { Page = limit * (page - 1), Limit = limit });
        }
    }
}