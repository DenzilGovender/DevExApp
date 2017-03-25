using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Xamarin.Database;
using Firebase.Xamarin.Database.Query;

using Xamarin.Forms;
using DevExMobileApp.Models;

namespace DevExMobileApp.UI
{
    public partial class AgendaPage : ContentPage
    {
        public AgendaPage()
        {
            InitializeComponent();
             GetAgenda();
        }

        private async void GetAgenda()
        {
            try
            {
                
                var firebase = new FirebaseClient("https://devex-6d4d1.firebaseio.com");
                var agenda = await firebase.Child("Agenda").OnceSingleAsync<Agenda>();
            }
            catch
            {

            }
        }
    }
}
