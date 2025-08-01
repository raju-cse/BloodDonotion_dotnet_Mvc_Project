// using System.Linq.Expressions;
// using BloodDonor.Mvc.Models;
// using BloodDonor.Mvc.Services.Interfaces;
//
// namespace BloodDonor.Mvc.Repositories.Interfaces;
//
// public class IBloodDonorRepository
// {
//     Task<IFileServices<BloodDonorEntity>> GetAllAsync();
//     public Task<BloodDonorEntity?> GetByIdAsync(int id);
//     Task<IEnumerable<BloodDonorEntity>> FindAsync(Expression<Func<BloodDonorEntity, bool>> predicate);
//     void Add(BloodDonorEntity bloodDonor);
//     void Update(BloodDonorEntity bloodDonor);
//     void Delete(BloodDonorEntity bloodDonor);
// }

using System.Linq.Expressions;
using BloodDonor.Mvc.Models;
using BloodDonor.Mvc.Services.Interfaces;

namespace BloodDonor.Mvc.Repositories.Interfaces
{
    public interface IBloodDonorRepository
    {
        Task<List<BloodDonorEntity>> GetAllAsync();
        Task<BloodDonorEntity?> GetByIdAsync(int id);
        Task<IEnumerable<BloodDonorEntity>> FindAsync(Expression<Func<BloodDonorEntity, bool>> predicate);
        void Add(BloodDonorEntity bloodDonor);
        void Update(BloodDonorEntity bloodDonor);
        void Delete(BloodDonorEntity bloodDonor);
    }
}
