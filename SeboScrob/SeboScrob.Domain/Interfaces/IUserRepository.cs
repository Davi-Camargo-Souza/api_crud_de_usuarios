using SeboScrob.Domain.Entities;

namespace SeboScrob.Domain.Interfaces
{
    public interface IUserRepository : IBaseRepository<UserEntity>
    {
        Task<UserEntity> GetByEmail (string email, CancellationToken cancellationToken);
        Task<UserEntity> GetByCPF (string cpf, CancellationToken cancellationToken);
    }
}
