using Plugin.DeviceInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using ZXing.Mobile;
using ZXing.Net.Mobile.Forms;

namespace DevExMobileApp.UI
{
    public partial class MainPage : ContentPage
    {

        public MainPage(string URL)
        {
            InitializeComponent();
            //var platform = CrossDeviceInfo.Current.Platform;
            Browser.Source = URL;
            gridDashboard.RowSpacing = 5;
            DevexHeading.FontFamily = Device.OnPlatform("MarkerFelt-Thin", "Roboto", "Verdana");
            DevexHeading.TextColor = Color.White;
           
            Image btn = new Image
            {
                Aspect = Aspect.Fill,
               
                Source = "button.jpg"

            };
            Agenda.Image = (FileImageSource) btn.Source;
           
        }

        async private void AgendaClicked(object sender, EventArgs e)
        {
            var agendaPage = new AgendaPage();
            NavigationPage.SetBackButtonTitle(agendaPage, "Dashboard");
            await Navigation.PushAsync(agendaPage, true);
        }

        async private void SubmitClicked(object sender, EventArgs e)
        {
            var submitPage = new SubmitTopicPage();
            NavigationPage.SetBackButtonTitle(submitPage, "Dashboard");
            await Navigation.PushAsync(submitPage, true);
        }

        async private void BlogsClicked(object sender, EventArgs e)
        {
            var blogsPage = new BlogsPage();
            NavigationPage.SetBackButtonTitle(blogsPage, "Dashboard");
            await Navigation.PushAsync(blogsPage, true);
        }
        async private void AttendanceClicked(object sender, EventArgs e)
        {
            var scanPage = new ZXingScannerPage();

            var options = new MobileBarcodeScanningOptions
            {
                AutoRotate = false,
      
                TryHarder = true,
                PossibleFormats = new List<ZXing.BarcodeFormat>
                    {
                        ZXing.BarcodeFormat.QR_CODE
                    }
            };

            //add options and customize page
            scanPage = new ZXingScannerPage(options)
            {
                DefaultOverlayTopText = "Align the barcode within the frame",
                DefaultOverlayBottomText = string.Empty
            };

           
            await Navigation.PushAsync(scanPage);

            scanPage.OnScanResult += (result) =>
            {
                // Stop scanning
                scanPage.IsScanning = false;

                // Pop the page and show the result
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await Navigation.PopAsync();
                    await DisplayAlert("You have succesfully confirmed your attendance", result.Text, "OK");
                });
            };

        }



        void webOnNavigating(object sender, WebNavigatingEventArgs e)
        {
            loader.IsVisible = true;
            loader.IsRunning = true;
            Browser.IsVisible = false;
        }

        void webOnEndNavigating(object sender, WebNavigatedEventArgs e)
        {
            loader.IsVisible = false;
            loader.IsRunning = false;
            Browser.IsVisible = false;

        }
    }
}
