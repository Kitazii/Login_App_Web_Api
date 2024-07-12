using Microsoft.Maui.Maps;
using Map = Microsoft.Maui.Controls.Maps.Map;
namespace LoginApp.Maui.Views;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();

        var location = new Location(55.796391, -4.863235);
        var mapSpan = new MapSpan(location, 0.01, 0.01);
        var map = new Map(mapSpan)
        {
            MapType = MapType.Street,
            IsShowingUser = false,
            IsZoomEnabled = true,
            IsTrafficEnabled = true,
            IsScrollEnabled = true
        };

        // Set the map as the content of the ContentPage
        Content = map;
    }
}