using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ServicesDeskUCAB.Pages
{
    public class ConsultarModel : PageModel
    {
        private readonly ILogger<ConsultarModel> _logger;

        public ConsultarModel(ILogger<ConsultarModel> logger)
        {
            _logger = logger;
        }
        public void OnGet()
        {
        }
    }
}
