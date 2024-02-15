using Dapper;
using SeboScrob.Domain.Entities;
using SeboScrob.Domain.Interfaces;
using SeboScrob.Persistence.Context;

namespace SeboScrob.Persistence.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _context;
        private readonly DapperContext _dapperContext;

        public BaseRepository(AppDbContext context, DapperContext dapperContext)
        {
            _context = context;
            _dapperContext = dapperContext;
        }
        public async void Create(T entity)
        {
            entity.DateCreated = DateTime.UtcNow;
            _context.Add(entity);
        }

        // o método delete não vai deletar o registro 100%.
        public void Delete (T entity)
        {
            entity.DateDisabled = DateTime.UtcNow;
            entity.Ativo = false;
            _context.Update(entity);
        }

        public async Task<T> Get(string id, CancellationToken cancellationToken, string tabela)
        {
            using (var connection = _dapperContext.CreateConnection())
            {
                connection.Open();
                id = $"\"{id}\"";
                string sql = $"SELECT * FROM {tabela} WHERE id = {id}";
                var result = await connection.QueryFirstOrDefaultAsync<T>(sql, cancellationToken);
                connection.Close();
                return result;
            }
        }

        public async Task<List<T>> GetAll(CancellationToken cancellationToken, string tabela)
        {
            using (var connection = _dapperContext.CreateConnection())
            {
                connection.Open();
                string sql = $"SELECT * FROM {tabela}";
                var result = await connection.QueryAsync<List<T>>(sql, cancellationToken);
                connection.Close();
                return (List<T>)result;
            }
        }

        public void Update(T entity)
        {
            entity.DateUpdated = DateTime.UtcNow;
            _context.Update(entity);
        }
    }
}
