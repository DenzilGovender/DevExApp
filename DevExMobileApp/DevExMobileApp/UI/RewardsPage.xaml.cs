using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Xamarin.Database;

using Xamarin.Forms;
using DevExMobileApp.Models;
using Firebase.Xamarin.Database.Query;

namespace DevExMobileApp.UI
{
    public partial class RewardsPage : ContentPage, INotifyPropertyChanged
    {
        Reward reward = new Reward();
        List<Shop> shopItems = new List<Shop>();
        String name = DevExMobileApp.Helpers.Settings.Firstname + " " + DevExMobileApp.Helpers.Settings.Surname;
        public RewardsPage()
        {
          

            InitializeComponent();
            GetRewards();
            GetShop();
             BindingContext = this;
            


        }

    private async void GetRewards()
    {
            try
            {
                activityIndicator.IsRunning = true;
                activityIndicator.IsVisible = true;
                var firebase = new FirebaseClient("https://devex-6d4d1.firebaseio.com");
                Reward = await firebase.Child("Rewards").Child(DevExMobileApp.Helpers.Settings.UserID).OnceSingleAsync<Reward>();
            }
            catch
            {

            }
      }

        private async void GetShop()
        {
            try
            {
                activityIndicator.IsRunning = true;
                activityIndicator.IsVisible = true;
                var firebase = new FirebaseClient("https://devex-6d4d1.firebaseio.com");
                ShopItems = await firebase.Child("KudosShop").OnceSingleAsync<List<Shop>>();
            }
            catch
            {

            }
        }

        public event PropertyChangedEventHandler PropertyChanged;


    public void RaisePropertyChanged(string propName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
    }

    public Reward Reward
        {
        get { return reward; }
        set
        {
            activityIndicator.IsRunning = false;
           // activityIndicator.IsVisible = false;
            reward = value;
            RaisePropertyChanged("Reward");

        }
    }

        public List<Shop> ShopItems
        {
            get { return shopItems; }
            set
            {
                activityIndicator.IsRunning = false;
                // activityIndicator.IsVisible = false;
                shopItems = value;
                listView.ItemsSource = ShopItems;
                RaisePropertyChanged("ShopItems");

            }
        }

        public String Name
        {
            get { return name; }
            set
            {
                name = value;
                RaisePropertyChanged("Name");

            }
        }

        void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
       => ((ListView)sender).SelectedItem = null;

        async void  Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var shop = ((ListView)sender).SelectedItem as Shop;
            if (shop == null)
                return;

            var answer = await DisplayAlert("Confirm", "Are you sure you want to purchase this item?", "Yes", "No");
            if (answer)
            {
               
            }

        }
    }
}
