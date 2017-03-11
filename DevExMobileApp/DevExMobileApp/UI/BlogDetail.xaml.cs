using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace DevExMobileApp.UI
{
    public partial class BlogDetail : ContentPage
    {
        public string title {get; set;}
        public HtmlWebViewSource description { get; set; }

        public BlogDetail(string Title, string Description)
        {
            title = Title;
            var html = new HtmlWebViewSource()
            {
                Html = Description
            };
            description = html;
            this.BindingContext = this;
            InitializeComponent();
        }
    }
}
