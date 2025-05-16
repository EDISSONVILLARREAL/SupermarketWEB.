using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SupermarketWEB.Models
{
    [Authorize]
    public class Provider
    {
        [Key] // Asegúrate de tener este atributo
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Para autoincremento
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [EmailAddress]
        public string ContactEmail { get; set; }

        [Required]
        [Phone]
        public string ContactPhone { get; set; }

        [Required]
        public string Address { get; set; }

        public ICollection<Product>? Products { get; set; }
    }
}