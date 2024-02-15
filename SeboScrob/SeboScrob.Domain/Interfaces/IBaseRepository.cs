using SeboScrob.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SeboScrob.Domain.Interfaces
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<T> Get(string id, CancellationToken cancellationToken, string tabela);
        Task<List<T>> GetAll(CancellationToken cancellationToken, string tabela);
    }
}
