namespace BloodDonor.Mvc.Services.Interfaces;

public abstract class IFileServices
{
    public abstract Task<string> SaveFileAsync(IFormFile file);

}