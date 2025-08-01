using BloodDonor.Mvc.Models;

namespace BloodDonor.Mvc.Services.Interfaces;

public interface IBloodDonorService
{
    Task<IEnumerable<BloodDonorEntity>> GetAsync();
    public Task<BloodDonorEntity?> GetByIdAsync(int id);
    Task AddAsync(BloodDonorEntity bloodDonor);
    Task UpdateAsync(BloodDonorEntity bloodDonor);
    Task DeleteAsync(BloodDonorEntity bloodDonor);


}