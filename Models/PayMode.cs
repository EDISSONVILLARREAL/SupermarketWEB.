using System.ComponentModel.DataAnnotations;

namespace SupermarketWEB.Models
{
    namespace SupermarketWEB.Models
    {
        public class PayMode
        {
            public int Id { get; set; }

            [Required]
            [Display(Name = "Efectivo")]
            public bool Efectivo { get; set; }

            [Required]
            [Display(Name = "Tarjeta")]
            public bool Tarjeta { get; set; }

            [Required]
            [Display(Name = "Transferencia")]
            public bool Transferencia { get; set; }
        }
    }
}