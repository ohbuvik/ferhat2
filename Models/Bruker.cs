using System.ComponentModel.DataAnnotations;

public class Bruker
{
    public int Id { get; set; }

    [Required]
    public string? Navn { get; set; }

    [Display(Name = "Kontaktinfo")]
    public string? KontaktInfo { get; set; }

    [Display(Name = "Antall spill gjennomført")]
    [Range(0, int.MaxValue, ErrorMessage = "Antall spill må være 0 eller høyere.")]
    public int AntallSpill { get; set; }
}

