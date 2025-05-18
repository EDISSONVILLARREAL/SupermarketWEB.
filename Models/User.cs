using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class User
{
    [Key] // Esto define que Id es la clave primaria
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Auto-incremental
    public int Id { get; set; }

   
    public string? Name { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }
}
