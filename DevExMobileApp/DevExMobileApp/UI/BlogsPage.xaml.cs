using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

using Xamarin.Forms;
using System.Net.Http;

namespace DevExMobileApp.UI
{
    public partial class BlogsPage : ContentPage
    {
        public BlogsPage()
        {
            
            InitializeComponent();
            blogsView.ItemsSource = GetBlogs();

            blogsView.ItemTapped += async (sender, args) =>
            {
                var Item = args.Item as BlogPost;
                await Navigation.PushAsync(new BlogDetail(Item.Title,Item.Content));
            };

        }

       

        public List<BlogPost> GetBlogs()
        {
            const string baseurl = "https://public-api.wordpress.com/rest/v1.1/sites/devex.azurewebsites.net/posts";
            var client = new HttpClient();
            var jsonData = client.GetStringAsync(baseurl).Result;
            JToken token = JObject.Parse(jsonData);

            var postCount = (int)token.SelectToken("found");
            var postArray = token.SelectToken("posts");

            var posts = JsonConvert.DeserializeObject<List<BlogPost>>(postArray.ToString());

            return posts;
        }
    
    }
}
