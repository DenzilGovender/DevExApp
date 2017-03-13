using DevExMobileApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace DevExMobileApp.UI
{
    public partial class SubmitTopicPage : ContentPage
    {
        public SubmitTopicPage()
        {
            InitializeComponent();
          
        }

        private async void SubmitClicked(Object sender, EventArgs e)
        {
            try
            {


                var topic = new Topic
                {
                    TopicName = Topic_Field.Text,
                    IsPresented = presenterPicker.Items[presenterPicker.SelectedIndex].ToString(),
                    SubmittedBy = new Person
                    {
                        Name = DevExMobileApp.Helpers.Settings.Firstname,
                        Surname = DevExMobileApp.Helpers.Settings.Surname,
                        Email = DevExMobileApp.Helpers.Settings.Email
                    }
                };




                string baseurl = "https://emailservicefunction.azurewebsites.net/api/SubmitTopicFunction?code=9CnxKy3YC81iRvWzQCLK/fYNFfXY9sRNp2Gijnpl5lMhpTisEY7IbA==";
                var client = new HttpClient();
                var jsonObject = JsonConvert.SerializeObject(topic);
                var content = new StringContent(jsonObject.ToString(), Encoding.UTF8, "application/json");
                var message = await client.PostAsync(baseurl, content);
            }
            catch
            {
                await DisplayAlert("", "There was an issue sending your request", "Ok");
                return;
            }
            await DisplayAlert("", "Request submitted successfully", "Ok");
        }

        private void SendMail()
        {
            
        }
    }
}
