# Weather Razor App

A modern, responsive weather application built with ASP.NET Core Razor Pages and Bootstrap 5.

## Features

- 🌤️ Real-time weather data from OpenWeatherMap API
- 🎨 Dynamic backgrounds that change with weather conditions
- 📱 Fully responsive design for mobile and desktop
- ⚡ Loading animations and smooth transitions
- 🌡️ Temperature, humidity, wind speed, and pressure display
- 🔍 City search functionality with error handling

## Setup Instructions

### 1. Prerequisites
- .NET 8.0 SDK or later
- Visual Studio Code or Visual Studio
- OpenWeatherMap API key (free at https://openweathermap.org/api)

### 2. Getting Started

1. **Clone or download the project**
   ```bash
   cd WeatherApp
   ```

2. **Get your OpenWeatherMap API Key**
   - Visit https://openweathermap.org/api
   - Sign up for a free account
   - Generate an API key

3. **Configure the API Key**
   - Open `appsettings.json`
   - Replace `YOUR_API_KEY_HERE` with your actual API key:
   ```json
   {
     "OpenWeatherMap": {
       "ApiKey": "your_actual_api_key_here"
     }
   }
   ```

4. **Restore packages and run**
   ```bash
   dotnet restore
   dotnet run
   ```

5. **Open in browser**
   - Navigate to `https://localhost:5001` or `http://localhost:5000`
   - Or use the URL shown in the terminal

### 3. Using Visual Studio Code

1. Open the WeatherApp folder in VS Code
2. Install the C# extension if not already installed
3. Press `F5` to run with debugging, or `Ctrl+F5` to run without debugging

## Project Structure

```
WeatherApp/
├── Models/
│   └── WeatherData.cs          # Weather data models
├── Services/
│   └── WeatherService.cs       # OpenWeatherMap API service
├── Pages/
│   ├── Index.cshtml            # Home page with weather search
│   ├── Index.cshtml.cs         # Home page logic
│   ├── About.cshtml            # About page
│   ├── About.cshtml.cs         # About page logic
│   ├── Contact.cshtml          # Contact form page
│   ├── Contact.cshtml.cs       # Contact form logic
│   └── Shared/
│       └── _Layout.cshtml      # Shared layout with navigation
├── wwwroot/
│   └── css/
│       └── site.css            # Custom weather-themed styles
├── appsettings.json            # Configuration including API key
└── Program.cs                  # Application startup
```

## Technologies Used

- **ASP.NET Core 8.0** - Web framework
- **Razor Pages** - Server-side rendering
- **Bootstrap 5** - CSS framework
- **Font Awesome** - Icons
- **OpenWeatherMap API** - Weather data
- **Custom CSS** - Weather-themed styling

## API Integration

The app uses the OpenWeatherMap Current Weather API:
- Endpoint: `https://api.openweathermap.org/data/2.5/weather`
- Parameters: city name, API key, units (metric)
- Response: JSON with weather data including temperature, humidity, wind, pressure

## Features Breakdown

### Home Page
- City search with real-time weather data
- Dynamic backgrounds based on weather conditions
- Weather icons from OpenWeatherMap
- Responsive weather cards with detailed information
- Loading spinner during API calls
- Error handling for invalid cities

### About Page
- Information about the application
- Technology stack details
- Gradient background design

### Contact Page
- Contact form with validation
- Success message on form submission
- Modern form styling

## Customization

### Adding New Weather Backgrounds
Edit the CSS classes in `site.css`:
```css
.weather-container.your-weather-type {
  background: linear-gradient(135deg, #color1 0%, #color2 100%);
}
```

### Modifying Weather Data Display
Update the `WeatherData` model in `Models/WeatherData.cs` and corresponding views.

## Troubleshooting

1. **API Key Issues**
   - Ensure your API key is valid and active
   - Check that you've replaced the placeholder in `appsettings.json`

2. **Build Errors**
   - Run `dotnet restore` to restore NuGet packages
   - Ensure .NET 8.0 SDK is installed

3. **Port Issues**
   - Check `Properties/launchSettings.json` for port configuration
   - Use `dotnet run --urls="http://localhost:5000"` to specify a port

## License

This project is for educational purposes. Weather data provided by OpenWeatherMap.