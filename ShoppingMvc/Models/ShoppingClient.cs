using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace ShoppingMvc.Models
{
    public class ShoppingClient
    {
        string Baseurl = "http://localhost:50494/";
        public HttpClient GetClient()
        {
            var Client = new HttpClient();
            Client.BaseAddress = new Uri(Baseurl);
            Client.DefaultRequestHeaders.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return Client;
        }
    }
}