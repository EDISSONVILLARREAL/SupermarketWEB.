using Microsoft.AspNetCore.Authorization;
using SupermarketWEB.Models;

[Authorize]
public class Category
{
    public int Id { get; set; } // Será la llave primaria
    public string Name { get; set; }
    public string? Description { get; set; }
    // Otras propiedades de la clase Category

    public ICollection<Product>? Products { get; set; } = default!; // Propiedad de navegación
}