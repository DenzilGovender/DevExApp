using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Xamarin.Database;
using Firebase.Xamarin.Database.Query;

using Xamarin.Forms;
using DevExMobileApp.Models;
using System.ComponentModel;

namespace DevExMobileApp.UI
{
    public partial class AgendaPage : ContentPage, INotifyPropertyChanged
    {
        Agenda agenda = new Agenda();
        public AgendaPage()
        {
            InitializeComponent();
            activityIndicator.HorizontalOptions = LayoutOptions.CenterAndExpand;
            activityIndicator.Color = Color.Black;
            activityIndicator.IsVisible = false;
            GetAgenda();
            BindingContext = this;

        }

        private async void GetAgenda()
        {

            activityIndicator.IsRunning = true;
            activityIndicator.IsVisible = true;
            var firebase = new FirebaseClient("https://devex-6d4d1.firebaseio.com");
            Agenda = await firebase.Child("Agenda").OnceSingleAsync<Agenda>();
           


        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        public Agenda Agenda
        {
            get { return agenda; }
            set
            {
                activityIndicator.IsRunning = false;
                activityIndicator.IsVisible = false;
                agenda = value;
                RaisePropertyChanged("Agenda");

            }
        }
    }
}
