using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace tp.Models;

public class Event
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Title { get; set; }

    [Required]
    [StringLength(500)]
    public string Description { get; set; }

    [Required]
    [DisplayName("Date de l'évènement")]
    [DataType(DataType.DateTime)]
    public DateTime EventDate { get; set; }

    [Required]
    [Range(10, 200)]
    [DisplayName("Nombre de participants")]
    public int MaxParticipants { get; set; }

    [Required]
    [StringLength(100)]
    public string Location { get; set; }

    [DisplayName("Date de création")]
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}