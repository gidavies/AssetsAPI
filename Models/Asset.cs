using System.ComponentModel.DataAnnotations;

public class Asset
{
  [Key]
  [Required]
  [Display(Name = "assetNumber")]
  public string AssetNumber { get; set; }
 
  [Required]
  [Display(Name = "name")]
  public string Name { get; set; }
 
  [Required]
  [Range(10, 90)]
  [Display(Name = "price")]
  public double? Price { get; set; }
 
  [Required]
  [Display(Name = "service")]
  public string Service { get; set; }
}