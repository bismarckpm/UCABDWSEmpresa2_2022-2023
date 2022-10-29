using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace ServicesDeskUCAB.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public Credential Credential { get; set; }

        public void OnGet()
        {
            this.Credential =  new Credential { Username  = "admin@gmail.com" };
            
        }
        public IActionResult OnPost()
        {
            if (this.Credential.Username.Equals("admin@gmail.com") && this.Credential.Password.Equals("123"))
            {
                return RedirectToPage("Index");
            }
            else
            {
                this.Credential.Msg = "Invalid";
                return Page();
            }
        }
    }
    public class Credential
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string Msg { get; set; }

    }
}
