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
using Firebase.Xamarin.Auth;
using Firebase.Xamarin.Database;
using Firebase.Xamarin.Database.Query;


namespace DevExMobileApp.UI
{
    public partial class MainPage : ContentPage
    {
        private const string AcceptedInvite = "DevEx Accept Invite";
        private const string AddPoints = "DevEx Add Points";

        public MainPage()
        {
            InitializeComponent();
            gridDashboard.RowSpacing = 5;
            DevexHeading.FontFamily = Device.OnPlatform("MarkerFelt-Thin", "Roboto", "Verdana");
            DevexHeading.TextColor = Color.White;
           
            
           
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

                        if (result.Text == AcceptedInvite)
                        {

                            await AcceptInvite();
                        }
                        else
                        {
                            await AddAttendancePoints(result.Text);
                        }
                                
                    });
                };
            

        }

        private async Task AcceptInvite()
        {
            if (DevExMobileApp.Helpers.Settings.RegisteredDate != string.Empty && DateTime.Now.Month == Convert.ToDateTime(DevExMobileApp.Helpers.Settings.RegisteredDate).Month)
            {
                await DisplayAlert("", "You have already confirmed your attendance", "OK");
            }
            else
            {
                try
                {
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
                    await DisplayAlert("", "You have succesfully confirmed your attendance", "OK");
                }
                catch
                {
                    await DisplayAlert("", "There was an issue confirming your attendance, Please try again later", "OK");
                }
            }
        }

        private async Task AddAttendancePoints(string points)
        {
            try
            {
                if (DevExMobileApp.Helpers.Settings.ScannedKudosDate != string.Empty && DateTime.Now.Month == Convert.ToDateTime(DevExMobileApp.Helpers.Settings.ScannedKudosDate).Month)
                {
                    await DisplayAlert("", "You have already scanned this code", "OK");
                    return;
                }
                // check to see if person already scanned for points
                int ConvertedPoints = Convert.ToInt32(points.Substring(points.Length - 2));

                //Get record from firebase for user
                var firebase = new FirebaseClient("https://devex-6d4d1.firebaseio.com");

                var reward = await firebase.Child("Rewards").Child(DevExMobileApp.Helpers.Settings.UserID).OnceSingleAsync<Reward>();

                if (reward == null)
                {
                    AddRewardToDataBase(ConvertedPoints);
                }
                else
                {
                    reward.Kudos = reward.Kudos + ConvertedPoints;
                    EditRewardsInDataBase(reward);
                }
                DevExMobileApp.Helpers.Settings.ScannedKudosDate = DateTime.Now.ToString();
                await DisplayAlert("", "Kudos Increased", "OK");
            }
            catch
            {
                await DisplayAlert("", "There was an issue, Please try again later", "OK");
            }

        }

        private async void AddRewardToDataBase(int Points)
        {
            var rewardToPost = new Reward
            {
                Kudos = Points,
                NoOfSessionsAttended = 1,
                NoOfSessionsPresented = 0,
                Rewardee = new Person
                {
                    Name = DevExMobileApp.Helpers.Settings.Firstname,
                    Surname = DevExMobileApp.Helpers.Settings.Surname,
                    Email = DevExMobileApp.Helpers.Settings.Email
                }
            };

            var jsonObject = JsonConvert.SerializeObject(rewardToPost);
            var firebase = new FirebaseClient("https://devex-6d4d1.firebaseio.com");

            var item = await firebase
              .Child("Rewards")
              .PostAsync(rewardToPost);
            DevExMobileApp.Helpers.Settings.UserID = item.Key;

        }


        private async void EditRewardsInDataBase(Reward reward)
        {
            reward.NoOfSessionsAttended++;
            var jsonObject = JsonConvert.SerializeObject(reward);
            var firebase = new FirebaseClient("https://devex-6d4d1.firebaseio.com");
            await firebase.Child("Rewards").Child(DevExMobileApp.Helpers.Settings.UserID).PutAsync(reward);

        }


    }
}
