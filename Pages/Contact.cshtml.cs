using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WeatherApp.Models;
using WeatherApp.Services;

namespace WeatherApp.Pages
{
    public class ContactModel : PageModel
    {
        private readonly ContactService _contactService;
        
        public ContactModel(ContactService contactService)
        {
            _contactService = contactService;
        }
        
        [BindProperty]
        public string Name { get; set; } = string.Empty;
        
        [BindProperty]
        public string Email { get; set; } = string.Empty;
        
        [BindProperty]
        public string Message { get; set; } = string.Empty;
        
        public bool MessageSent { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var contactMessage = new ContactMessage
                {
                    Name = Name,
                    Email = Email,
                    Message = Message
                };
                
                _contactService.SaveMessage(contactMessage);
                MessageSent = true;
                
                // Clear form
                Name = string.Empty;
                Email = string.Empty;
                Message = string.Empty;
            }
            
            return Page();
        }
    }
}