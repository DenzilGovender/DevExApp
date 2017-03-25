using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace DevExMobileApp
{
    public class App : Application
    {
        public App()
        {
            //DevExMobileApp.Helpers.Settings.Firstname = string.Empty;
            //DevExMobileApp.Helpers.Settings.Surname = string.Empty;
            //DevExMobileApp.Helpers.Settings.Email = string.Empty;
            //DevExMobileApp.Helpers.Settings.RegisteredDate = string.Empty;
            //MainPage = new NavigationPage(new DevExMobileApp.UI.MainPage("https://devex.azurewebsites.net"));

            if (IsRegistered())
            {
                MainPage = new NavigationPage(new DevExMobileApp.UI.MainPage());
            }
            else
            {

                MainPage = new NavigationPage(new DevExMobileApp.UI.RegisterPage());

            }

        }

        private bool IsRegistered()
        {
            if (DevExMobileApp.Helpers.Settings.Firstname != string.Empty)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
