// using BloodDonor.Mvc.Data;
// using BloodDonor.Mvc.Models;
// using BloodDonor.Mvc.Repositories.Interfaces;
//
// namespace BloodDonor.Mvc.Repositories.Implementations;
//
// public class BloodDonorRepository: IBloodDonorRepository
// {
//     private readonly BloodDonorDbContext _context;
//
//     public BloodDonorRepository(BloodDonorDbContext context)
//     {
//         _context = context;
//     }
//
//     public void Add(BloodDonorEntity bloodDonor)
//     {
//         _context.BloodDonors.Add(bloodDonor);
//     }
//
//     public void Delete(BloodDonorEntity bloodDonor)
//     {
//         _context.BloodDonors.Remove(bloodDonor);
//     }
//
//     public Task<IEnumerable<BloodDonorEntity>> Find(Func<BloodDonorEntity, bool> predicate)
//     {
//         throw new System.NotImplementedException();
//     }
//
//     public async Task<BloodDonorEntity?> GetAsync(int id)
//     {
//         return await _context.BloodDonors.FindAsync(id);
//     }
//
//     public void Update(BloodDonorEntity bloodDonor)
//     {
//         _context.BloodDonors.Update(bloodDonor);
//     }
// }

using BloodDonor.Mvc.Data;
using BloodDonor.Mvc.Models;
using BloodDonor.Mvc.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using BloodDonor.Mvc.Services.Interfaces;

namespace BloodDonor.Mvc.Repositories.Implementations;

public class BloodDonorRepository : IBloodDonorRepository
{
    private readonly BloodDonorDbContext _context;

    public BloodDonorRepository(BloodDonorDbContext context)
    {
        _context = context;
    }

    public async Task<List<BloodDonorEntity>> GetAllAsync()
    {
        return await _context.BloodDonors.ToListAsync();
    }

    public async Task<BloodDonorEntity?> GetByIdAsync(int id)
    {
        return await _context.BloodDonors.FindAsync(id);
    }

    public async Task<IEnumerable<BloodDonorEntity>> FindAsync(Expression<Func<BloodDonorEntity, bool>> predicate)
    {
        return await _context.BloodDonors.Where(predicate).ToListAsync();
    }

    public void Add(BloodDonorEntity bloodDonor)
    {
        _context.BloodDonors.Add(bloodDonor);
    }

    public void Update(BloodDonorEntity bloodDonor)
    {
        _context.BloodDonors.Update(bloodDonor);
    }

    public void Delete(BloodDonorEntity bloodDonor)
    {
        _context.BloodDonors.Remove(bloodDonor);
    }
}
