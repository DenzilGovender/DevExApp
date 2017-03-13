using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace DevExMobileApp.UI
{
    public partial class RewardsPage : ContentPage
    {
        public RewardsPage()
        {
            InitializeComponent();
            progress.ProgressTo(0.5, 800, Easing.SinOut);
        }
    }
}
