using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

public class BlogPost
{
    [JsonProperty("ID")]
    public int Id { get; set; }

    [JsonProperty("date")]
    public DateTime DateCreated { get; set; }

    [JsonProperty("title")]
    public string Title { get; set; }

    [JsonProperty("URL")]
    public string Url { get; set; }

    [JsonProperty("content")]
    public string Content { get; set; }

    [JsonProperty("excerpt")]
    public string Excerpt { get; set; }

    [JsonProperty("author")]
    public Dictionary<string, object> AuthorDetails { get; set; }

    public List<string> Author
    {
        get
        {
            return AuthorDetails.Select(x => x.Key).ToList();
        }
    }
}
