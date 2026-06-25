using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WeatherApp.Models;
using WeatherApp.Services;

namespace WeatherApp.Pages;

public class IndexModel : PageModel
{
    private readonly IWeatherService _weatherService;

    public IndexModel(IWeatherService weatherService)
    {
        _weatherService = weatherService;
    }

    [BindProperty]
    public string City { get; set; } = string.Empty;
    
    public WeatherData? WeatherData { get; set; }
    public string ErrorMessage { get; set; } = string.Empty;
    public bool IsCelsius { get; set; } = true;

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (string.IsNullOrWhiteSpace(City))
        {
            ErrorMessage = "Please enter a city name.";
            return Page();
        }

        WeatherData = await _weatherService.GetWeatherAsync(City);
        
        if (WeatherData == null)
        {
            ErrorMessage = "City not found. Please try again.";
        }

        return Page();
    }

    public IActionResult OnPostToggleUnit()
    {
        IsCelsius = !IsCelsius;
        return RedirectToPage();
    }
}
