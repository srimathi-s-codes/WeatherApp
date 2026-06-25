using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WeatherApp.Pages
{
    public class AdminLoginModel : PageModel
    {
        [BindProperty]
        public string Username { get; set; } = string.Empty;
        
        [BindProperty]
        public string Password { get; set; } = string.Empty;
        
        public bool LoginFailed { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (Username == "admin" && Password == "admin123")
            {
                HttpContext.Session.SetString("IsAdminLoggedIn", "true");
                return RedirectToPage("/Admin");
            }
            
            LoginFailed = true;
            return Page();
        }
    }
}