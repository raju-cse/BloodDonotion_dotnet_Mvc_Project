using BloodDonor.Mvc.Models;
using BloodDonor.Mvc.Repositories.Interfaces;
using BloodDonor.Mvc.Services.Interfaces;

namespace BloodDonor.Mvc.Services.Implementations;

public class BloodDonorService : IBloodDonorService
{
    private readonly IBloodDonorRepository  _bloodDonorRepository;

    public BloodDonorService(IBloodDonorRepository bloodDonorRepository)
    {
        _bloodDonorRepository = bloodDonorRepository;
    }

    public Task<IEnumerable<BloodDonorEntity>> GetAsync()
    {
        throw new NotImplementedException();
    }

    public Task<BloodDonorEntity?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task AddAsync(BloodDonorEntity bloodDonor)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsyns(BloodDonorEntity bloodDonor)
    {
        throw new NotImplementedException();
    }

    public async Task<BloodDonorEntity?> GetAllAsync(int id)
    {
        return await _bloodDonorRepository.GetByIdAsync(id);
    }

    public Task UpdateAsync(BloodDonorEntity bloodDonor)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(BloodDonorEntity bloodDonor)
    {
        throw new NotImplementedException();
    }
}