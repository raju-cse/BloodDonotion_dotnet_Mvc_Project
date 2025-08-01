using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BloodDonor.Mvc.Models;

public class Donation
{

    [Key]
    public int Id { get; set; }
    public required DateTime DonationDate { get; set; }

    [ForeignKey("BloodDonor")]
    public required int BloodDonorId { get; set; }

}