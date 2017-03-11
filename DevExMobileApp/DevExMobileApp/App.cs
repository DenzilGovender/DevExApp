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
            // The root page of your application
            //var content = new ContentPage
            //{
            //    Title = "DevEx",
            //    Content = new StackLayout
            //    {
                
            //Children = {
            //            new WebView {
            //            Source = "https://devex.azurewebsites.net",
            //            WidthRequest = 1000,
            //            HeightRequest = 1000
            //            }
            //        }
            //    }
            //};

            MainPage = new NavigationPage(new DevExMobileApp.UI.MainPage("https://devex.azurewebsites.net"));
            
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
