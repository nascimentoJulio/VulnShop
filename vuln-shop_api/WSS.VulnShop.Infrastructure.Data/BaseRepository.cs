using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Collections.Generic;
using System.Data.SqlClient;
using WSS.VulnShop.Domain.Entities;
using WSS.VulnShop.Domain.Repository;

namespace WSS.VulnShop.Infrastructure.Data
{
    public class BaseRepository<T> : IBaseRepository<T>
    {
        internal readonly NpgsqlConnection _conn;
        private readonly string _table;
        public BaseRepository(IConfiguration configuration, string table)
        {
            var dataSourceBuilder = new NpgsqlDataSourceBuilder(configuration.GetConnectionString("POSTGRES"));
            var dataSource = dataSourceBuilder.Build();

            _conn = dataSource.OpenConnection();
            _table = table;
        }
        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetById(int id)
        {
            return await _conn.QueryFirstOrDefaultAsync<T>(@$"SELECT 
                                                 *
                                               FROM {_table}
                                               WHERE id = @Id
            ", new { Id = id});
        }

        public async Task<IEnumerable<T>> GetPaginated(int limit, int page)
        {
            return await _conn.QueryAsync<T>(@$"SELECT 
                                                 *
                                               FROM {_table}
                                               limit @Limit
                                               offset @Page", new {Limit = limit, Page = limit *(page - 1)});
        }

        public Task<int> Insert(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
