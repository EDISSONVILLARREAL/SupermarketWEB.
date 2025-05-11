using System.ComponentModel.DataAnnotations;

namespace SupermarketWEB.Models
{

    public class PayMode
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string? Descripcion
        {
            get; set;
        }
    }
}