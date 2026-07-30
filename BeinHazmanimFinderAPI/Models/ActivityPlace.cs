using System.ComponentModel.DataAnnotations;

namespace BeinHazmanimFinderAPI.Models;

public class ActivityPlace
{
    [Required]
    public int Id { get; set; }

    [Required]
    [StringLength(70)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [StringLength(35)]
    [RegularExpression("^Restaurant|Water Park|Nature Trail|Museum|Historical Site|Adventure Park|Boat Trip|Visitor Center|Children Activity$")]
    public string Category { get; set; } = string.Empty;

    [Required]
    [StringLength(40)]
    public string City { get; set; } = string.Empty;

    [Required]
    [StringLength(50)]
    public string Area { get; set; } = string.Empty;

    [Required]
    [StringLength(30)]
    [RegularExpression("^Families|Children|Youth|Adults|Men|Women$")]
    public string TargetAudience {  get; set; } = string.Empty;

    [Required]
    [Range(0, 1000)]
    public decimal PricePerPerson { get; set; }

    [Required]
    [Range(0, 18)]
    public int MinimumAge { get; set; }

    [Required]
    public DateTime AvailableDate { get; set; }

    [Required]
    public bool IsAccessible { get; set; } = false;

    [Required]
    public bool RequiresKashrut { get; set; }=false;

    [StringLength(50)]
    public string? KashrutAuthority { get; set; }
}
