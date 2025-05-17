using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SupermarketWEB.Data;
using System.ComponentModel.DataAnnotations;

namespace SupermarketWEB.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly SupermarketContext _context;

        public RegisterModel(SupermarketContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Register Registro { get; set; }

        public void OnGet() { }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            if (_context.Users.Any(u => u.Email == Registro.Email))
            {
                ModelState.AddModelError(string.Empty, "Este correo ya está registrado.");
                return Page();
            }

            var nuevoUsuario = new User
            {
                Name = Registro.Name,
                Email = Registro.Email,
                Password = Registro.Password
            };

            _context.Users.Add(nuevoUsuario);
            _context.SaveChanges();

            return RedirectToPage("/Account/Login");
        }
    }

    public class Register
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El correo es obligatorio")]
        [EmailAddress(ErrorMessage = "Correo inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria")]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Debe tener al menos 8 caracteres")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirme la contraseña")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Las contraseñas no coinciden")]
        public string ConfirmPassword { get; set; }
    }
}