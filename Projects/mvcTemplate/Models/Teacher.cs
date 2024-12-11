using System.ComponentModel.DataAnnotations;

namespace mvc.Models;

public class Teacher
{
    [Required(ErrorMessage = "L'identifiant est obligatoire")]
    [Display(Name = "Identifiant")]
    public int Id { get; set; }

    [StringLength(20, MinimumLength = 5)]
    public string Lastname { get; set; }
    [Required]
    public string Firstname { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }

    [Required]
    [Range(18, 100)]
    public int Age { get; set; }
}