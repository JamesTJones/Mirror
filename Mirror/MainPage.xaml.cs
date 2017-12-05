using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using static Mirror.mapproxy;
using Windows.Devices.Geolocation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Mirror
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();   
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {



            RootObject myWeather = await OpenMapProxy.GetWeather(20, 30);
            string icon = String.Format("http://openweathermap.org/img/w/{0}.png", myWeather.weather[0].icon);
            ResultImage.Source = new BitmapImage(new Uri(icon, UriKind.Absolute));
            ResultTextBlock.Text = myWeather.name + " " + myWeather.main.temp + " " + myWeather.weather[0].description;
            DateTime now = DateTime.Now;
            TimeBlock.Text = Convert.ToString(now);


        }
    }
}
