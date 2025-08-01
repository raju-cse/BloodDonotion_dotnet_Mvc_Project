using BloodDonor.Mvc.Services.Interfaces;

namespace BloodDonor.Mvc.Services.Implementations;

public class FileServices : IFileServices
{
    private readonly IWebHostEnvironment _env;

    public FileServices(IWebHostEnvironment env)
    {
        _env = env;
    }
    public override async Task<string> SaveFileAsync(IFormFile? file)
    {
        if(file != null && file.Length > 0)
        {
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            var folderPath = Path.Combine(_env.WebRootPath, "profiles");
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            var fullPath = Path.Combine(folderPath, fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                await file.CopyToAsync(stream);                    
            }
            return Path.Combine("profiles", fileName);
        }
        return String.Empty;
    }
    
}