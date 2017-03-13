using DevExMobileApp.Models;
using Firebase.Xamarin.Auth;
using Firebase.Xamarin.Database;
using Firebase.Xamarin.Database.Query;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace DevExMobileApp.UI
{
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private async void SubmitClicked(Object sender, EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new MainPage("https://devex.azurewebsites.net"));

            DevExMobileApp.Helpers.Settings.Firstname = Firstname.Text;
            DevExMobileApp.Helpers.Settings.Surname = Surname.Text;
            DevExMobileApp.Helpers.Settings.Email = Email.Text;
            await DisplayAlert("", "Registration Successfull", "Ok");
            await Navigation.PopToRootAsync();

            var reward = new Reward
            {
                Kudos = 5,
                NoOfSessionsAttended = 10,
                NoOfSessionsPresented = 20,
                Rewardee = new Person
                {
                    Email = "email",
                    Name = "sadas",
                    Surname = "asdsa"
                }
            };

            var jsonObject = JsonConvert.SerializeObject(reward);

            var firebase = new FirebaseClient("https://devex-6d4d1.firebaseio.com");
            var item = await firebase
              .Child("Rewards")
              //.WithAuth(auth.FirebaseToken) // <-- Add Auth token if required. Auth instructions further down in readme.
              .PostAsync(reward);
        }
    }
}
