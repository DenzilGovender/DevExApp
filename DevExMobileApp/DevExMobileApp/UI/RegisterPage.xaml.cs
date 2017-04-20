using DevExMobileApp.Models;
using Firebase.Xamarin.Database;
using Newtonsoft.Json;
using System;


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
            Application.Current.MainPage = new NavigationPage(new MainPage());

            DevExMobileApp.Helpers.Settings.Firstname = Firstname.Text;
            DevExMobileApp.Helpers.Settings.Surname = Surname.Text;
            DevExMobileApp.Helpers.Settings.Email = Email.Text;
            AddRewardToDataBase();
            
            await Navigation.PopToRootAsync();

            
        }

        private async void AddRewardToDataBase()
        {
            try
            {
                var rewardToPost = new Reward
                {
                    Kudos = 0,
                    NoOfSessionsAttended = 0,
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
                await DisplayAlert("", "Registration Successfull", "Ok");
            }
            catch
            {

            }

        }
    }
}
