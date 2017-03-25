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
            Application.Current.MainPage = new NavigationPage(new MainPage());

            DevExMobileApp.Helpers.Settings.Firstname = Firstname.Text;
            DevExMobileApp.Helpers.Settings.Surname = Surname.Text;
            DevExMobileApp.Helpers.Settings.Email = Email.Text;
            await DisplayAlert("", "Registration Successfull", "Ok");
            await Navigation.PopToRootAsync();

            
        }
    }
}
