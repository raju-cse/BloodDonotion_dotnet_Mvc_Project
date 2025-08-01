using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
    

namespace BloodDonor.Mvc.Models
{
    public class BloodDonorEntity
    {
        [Key]
        public int Id { get; set; }
        public required string FullName { get; set; }
        [Phone]
        public required string ContactNumber { get; set; }
        public required DateTime DateOfBirth { get; set; }
        [EmailAddress]
        public required string Email { get; set; }
        public required BloodGroup BloodGroup { get; set; }
        [Range(50, 150)]
        [Display(Name = " Weight(kg) ")]
        public float Weight { get; set; }
        public string? Address { get; set; }
        public DateTime? LastDonationDate { get; set; }
        public string? ProfilePicture { get; set; }
        
        public Collection<Donation> Donations { get; set; } = new Collection<Donation>();
    }

  

   
    
    
}
