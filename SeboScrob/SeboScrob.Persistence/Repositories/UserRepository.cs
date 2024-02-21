using Dapper;
using SeboScrob.Domain.Entities;
using SeboScrob.Domain.Interfaces;
using SeboScrob.Persistence.Context;
               
namespace SeboScrob.Persistence.Repositories
{ 
    public class UserRepository : BaseRepository<UserEntity>, IUserRepository
    {
        private readonly DapperContext _dapperContext;
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context, DapperContext dapperContext) : base (context, dapperContext)
        {
            _dapperContext = dapperContext;
            _context = context;
        }            

        public async Task<UserEntity> GetByCPF(string cpf, CancellationToken cancellationToken)
        {
            using (var connection = _dapperContext.CreateConnection())
            {
                connection.Open();
                var sql = $"SELECT * FROM Users WHERE cpf = {cpf}";
                var result = await connection.QuerySingleOrDefaultAsync(sql, cancellationToken);
                connection.Close();
                return result;
            }

        }

        public async Task<UserEntity> GetByEmail(string email, CancellationToken cancellationToken)
        {
            using (var connection = _dapperContext.CreateConnection())
            {
                connection.Open();
                var sql = $"SELECT * FROM Users WHERE email = '{email}'";
                var result = await connection.QueryFirstOrDefaultAsync<UserEntity>(sql, cancellationToken);
                connection.Close ();
                return result;
            }
        }

    }
}
