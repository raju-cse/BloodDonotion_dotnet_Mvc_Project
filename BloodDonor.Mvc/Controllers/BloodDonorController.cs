using BloodDonor.Mvc.Data;
using Microsoft.AspNetCore.Mvc;

using BloodDonor.Mvc.Models;
using BloodDonor.Mvc.Services.Interfaces; // ✅ required
using Microsoft.AspNetCore.Mvc;

namespace BloodDonor.Mvc.Controllers;

public class BloodDonorController : Controller
{
    private readonly BloodDonorDbContext _context;
    private readonly IFileServices _fileServices;
    private readonly IBloodDonorService _bloodDonorService;

    public BloodDonorController(BloodDonorDbContext context, IFileServices fileServices, IBloodDonorService bloodDonorService)
    {
        _context = context;
        _fileServices = fileServices;
        _bloodDonorService = bloodDonorService;
    }
    
    // GET
    public IActionResult Index(string bloodGroup, string address, bool? isEligible)
    {
        
        IQueryable<BloodDonorEntity> query = _context.BloodDonors;

        if (!string.IsNullOrEmpty(bloodGroup))
            query = query.Where(d => d.BloodGroup.ToString() == bloodGroup);
        if (!string.IsNullOrEmpty(address))
            query = query.Where(d => d.Address != null && d.Address.Contains(address));

        var donors = query.Select(d => new BloodDonorListViewModel
        {
            Id = d.Id,
            FullName = d.FullName,
            ContactNumber = d.ContactNumber,
            Age = DateTime.Now.Year - d.DateOfBirth.Year,
            Email = d.Email,
            BloodGroup = d.BloodGroup.ToString(),
            Address = d.Address,
            LastDonationDate = d.LastDonationDate.HasValue ? $"{ (DateTime.Today - d.LastDonationDate.Value).Days} days ago" : "Never",
            ProfilePicture = d.ProfilePicture,
            IsEligible = (d.Weight > 45 && d.Weight <200) &&  (!d.LastDonationDate.HasValue || (DateTime.Now - d.LastDonationDate.Value).TotalDays >= 90)
        }).ToList();
        ;
        if (isEligible.HasValue)
        {
            donors = donors.Where(x => x.IsEligible == isEligible.Value).ToList();
        }
        {
            
        }
        return View(donors);
    }


    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(BloodDonorCreateViewModel donor)
    {
        if(!ModelState.IsValid)
            return View(donor);
        var donorEntity = new BloodDonorEntity
        {

            FullName = donor.FullName,
            ContactNumber = donor.ContactNumber,
            DateOfBirth = donor.DateOfBirth,
            Email = donor.Email,
            BloodGroup = donor.BloodGroup,
            Weight = donor.Weight,
            Address = donor.Address,
            LastDonationDate = donor.LastDonationDate,
            ProfilePicture = await _fileServices.SaveFileAsync(donor.ProfilePicture)


        };
        

        _context.BloodDonors.Add(donorEntity);
        _context.SaveChanges();
        return RedirectToAction("Index");
        
    }
    
    public async Task<IActionResult> DetailsAsync(int id)
    {
        var donor = await _bloodDonorService.GetByIdAsync(id);  
        if(donor == null)
        {
            return NotFound();
        }
        var donorViewModel = new BloodDonorListViewModel
        {
            Id = donor.Id,
            FullName = donor.FullName,
            ContactNumber = donor.ContactNumber,
            Age = DateTime.Now.Year - donor.DateOfBirth.Year,
            Email = donor.Email,
            BloodGroup = donor.BloodGroup.ToString(),
            Address = donor.Address,
            LastDonationDate = donor.LastDonationDate.HasValue ? $"{(DateTime.Today - donor.LastDonationDate.Value).Days} days ago" : "Never",
            ProfilePicture = donor.ProfilePicture,
            IsEligible = (donor.Weight > 45 && donor.Weight < 200) && (!donor.LastDonationDate.HasValue || (DateTime.Now - donor.LastDonationDate.Value).TotalDays >= 90)
        };
        return View(donorViewModel);
    }
    
    public IActionResult Edit(int id)
        {
            var donor = _context.BloodDonors.FirstOrDefault(d => d.Id == id);
            if (donor == null)
            {
                return NotFound();
            }
            var donorViewModel = new BloodDonorEditViewModel
            {
                Id = donor.Id,
                FullName = donor.FullName,
                ContactNumber = donor.ContactNumber,
                DateOfBirth = donor.DateOfBirth,
                Email = donor.Email,
                BloodGroup = donor.BloodGroup,
                Address = donor.Address,
                LastDonationDate = donor.LastDonationDate,
                ExistingProfilePicture = donor.ProfilePicture,
            };
            return View(donorViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(BloodDonorEditViewModel donor)
        {
            if (!ModelState.IsValid)
                return View(donor);

            var donorEntity = new BloodDonorEntity
            {
                FullName = donor.FullName,
                ContactNumber = donor.ContactNumber,
                DateOfBirth = donor.DateOfBirth,
                Email = donor.Email,
                BloodGroup = donor.BloodGroup,
                Weight = donor.Weight,
                Address = donor.Address,
                LastDonationDate = donor.LastDonationDate,
                ProfilePicture = await _fileServices.SaveFileAsync(donor.ProfilePicture)
            };
            
            _context.BloodDonors.Add(donorEntity);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        
        public IActionResult Delete(int id)
        {
            var donor = _context.BloodDonors.FirstOrDefault(d => d.Id == id);
            if (donor == null)
            {
                return NotFound();
            }
            var donorViewModel = new BloodDonorListViewModel
            {
                Id = donor.Id,
                FullName = donor.FullName,
                ContactNumber = donor.ContactNumber,
                Age = DateTime.Now.Year - donor.DateOfBirth.Year,
                Email = donor.Email,
                BloodGroup = donor.BloodGroup.ToString(),
                Address = donor.Address,
                LastDonationDate = donor.LastDonationDate.HasValue ? $"{(DateTime.Today - donor.LastDonationDate.Value).Days} days ago" : "Never",
                ProfilePicture = donor.ProfilePicture,
                IsEligible = (donor.Weight > 45 && donor.Weight < 200) && (!donor.LastDonationDate.HasValue || (DateTime.Now - donor.LastDonationDate.Value).TotalDays >= 90)
            };
            return View(donorViewModel);
        }

        [ActionName("DeleteConfirmed")]
        public IActionResult DeleteConfirmed(int id)
        {
            var donor = _context.BloodDonors.FirstOrDefault(d => d.Id == id);
            if (donor == null)
            {
                return NotFound();
            }
            _context.BloodDonors.Remove(donor);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    
}