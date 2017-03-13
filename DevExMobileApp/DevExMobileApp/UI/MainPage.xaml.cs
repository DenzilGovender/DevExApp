using Plugin.DeviceInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using DevExMobileApp.Models;

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

            await Navigation.PopAsync();

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
            //var blogsPage = new BlogsPage();
            //NavigationPage.SetBackButtonTitle(blogsPage, "Dashboard");
            //await Navigation.PushAsync(blogsPage, true);

            var rewardsPage = new RewardsPage();
            NavigationPage.SetBackButtonTitle(rewardsPage, "Dashboard");
            await Navigation.PushAsync(rewardsPage, true);
        }
        async private void AttendanceClicked(object sender, EventArgs e)
        {
            

            if (DevExMobileApp.Helpers.Settings.RegisteredDate != string.Empty && DateTime.Now.Month == Convert.ToDateTime(DevExMobileApp.Helpers.Settings.RegisteredDate).Month)
            {
                await DisplayAlert("", "You have already confirmed your attendance", "OK");
            }

            else
            {
                var scanPage = new ZXingScannerPage();

                var options = new MobileBarcodeScanningOptions
                {
                    TryHarder = true,
                    PossibleFormats = new List<ZXing.BarcodeFormat>
                    {
                        ZXing.BarcodeFormat.QR_CODE
                    }
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
                        await DisplayAlert("Confirmation", "You have succesfully confirmed your attendance", "OK");

                        var person = new Person
                        {
                            Name = DevExMobileApp.Helpers.Settings.Firstname,
                            Surname = DevExMobileApp.Helpers.Settings.Surname,
                            Email = DevExMobileApp.Helpers.Settings.Email
                        };

                        string baseurl = "https://emailservicefunction.azurewebsites.net/api/HttpTriggerCSharp1?code=QY8syIpPCGfmGrQDmWiXHgeScIosi9m994RZ1YMVUaXsdcTr/yoFaw==";
                        var client = new HttpClient();
                        var jsonObject = JsonConvert.SerializeObject(person);
                        var content = new StringContent(jsonObject.ToString(), Encoding.UTF8, "application/json");
                        var message = await client.PostAsync(baseurl, content);
                        DevExMobileApp.Helpers.Settings.RegisteredDate = DateTime.Now.ToString();

                    });
                };
            }

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
