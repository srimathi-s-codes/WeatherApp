using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WeatherApp.Models;
using WeatherApp.Services;

namespace WeatherApp.Pages
{
    public class AdminModel : PageModel
    {
        private readonly ContactService _contactService;
        
        public AdminModel(ContactService contactService)
        {
            _contactService = contactService;
        }
        
        public List<ContactMessage> Messages { get; set; } = new();

        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("IsAdminLoggedIn") != "true")
            {
                return RedirectToPage("/AdminLogin");
            }
            
            Messages = _contactService.GetAllMessages();
            return Page();
        }
        
        public IActionResult OnPostLogout()
        {
            HttpContext.Session.Remove("IsAdminLoggedIn");
            return RedirectToPage("/AdminLogin");
        }
    }
}