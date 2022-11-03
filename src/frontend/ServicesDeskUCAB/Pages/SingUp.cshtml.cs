using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;

namespace ServicesDeskUCAB.Pages.Shared
{
    public class RegistrarUsuarioModel : PageModel
    {
        [BindProperty]
        public Usuario Usuario { get; set; }
        public void OnGet()
        {
            this.Usuario = new Usuario {  };
        }
        public async Task<IActionResult> OnPostAsync()
        {
            var json = JsonSerializer.Serialize(this.Usuario);
            StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            Console.WriteLine(this.Usuario);
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44392/");
            HttpResponseMessage response;
            response = await client.PostAsync("api/Usuario/CrearCliente", httpContent);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return RedirectToPage("Login");
            }
            else
            {
                return Page();
            }

        }
    }

    public class Usuario
    {
        [Required]
        public int cedula { get; set; }
        [Required]
        [MaxLength(50)]
        [MinLength(3)]
        public string primer_nombre { get; set; } = string.Empty;
        [MaxLength(50)]
        [MinLength(3)]
        public string segundo_nombre { get; set; } = string.Empty;
        [Required]
        [MaxLength(50)]
        [MinLength(3)]
        public string primer_apellido { get; set; } = string.Empty;
        [MaxLength(50)]
        [MinLength(3)]
        public string segundo_apellido { get; set; } = string.Empty;
        [Required]
        public DateTime fecha_nacimiento { get; set; }

        public char gender { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string correo { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; } = string.Empty;
    }
}


