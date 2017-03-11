using System;
using System.Collections.Generic;
using System.Linq;
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
            await DisplayAlert("Confirmation", "Request submitted successfully", "Ok");
        }
    }
}
