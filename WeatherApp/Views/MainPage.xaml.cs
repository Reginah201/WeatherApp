using WeatherApp.Services;

namespace WeatherApp
{
    public partial class MainPage : ContentPage
    {
        private readonly Services.WeatherService _weatherService;
        private readonly IGeolocation _geolocation;
        public MainPage()
        {
            InitializeComponent();
            _weatherService = new Services.WeatherService("f7864df7a8367f5fcd8f590f59b6c0da");  
            _geolocation = Geolocation.Default;

            this.Appearing += async (s, e) => await RefreshWeather();
        }

        private async Task RefreshWeather()
        {
            try
            {
                var location = await _geolocation.GetLocationAsync(new GeolocationRequest
                {
                    DesiredAccuracy = GeolocationAccuracy.Medium,
                    Timeout = TimeSpan.FromSeconds(5)
                });

                if (location != null)
                {
                    var weatherData = await _weatherService.GetWeatherDataAsync(
                        location.Latitude,
                        location.Longitude);

                    MainThread.BeginInvokeOnMainThread(() =>
                    {
                        CityLabel.Text = weatherData.CityName;
                        TemperatureLabel.Text = $"{weatherData.Main.Temperature:F1}°C";
                        DescriptionLabel.Text = weatherData.Weather.FirstOrDefault()?.Description ?? "No description available";
                        FeelsLikeLabel.Text = $"Feels like: {weatherData.Main.FeelsLike:F1}°C";
                    });
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }

            private async void OnRefreshClicked(object sender, EventArgs e)
            {
                await RefreshWeather();
            }
        }

}
