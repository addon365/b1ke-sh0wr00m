using addon365.Database.Entity.User;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using Threenine.Data;
using System.Linq;
using addon365.Database.Service;
using System.Net.Http;
using Newtonsoft.Json;
using addon365.IService;

namespace addon365.WebClient.Service.WebService
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;
        public UserService()
        {
            _httpClient = WebDataClient.Client;
        }

        public User Validate(string userId, string password)
        {

            IList<KeyValuePair<string, string>> postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("UserId", userId));
            postData.Add(new KeyValuePair<string, string>("Password", password));
          
                using (var content = new FormUrlEncodedContent(postData))
                {
                    
                    //content.Headers.Add("Content-Type", "application/x-www-form-urlencoded");

                    HttpResponseMessage response = _httpClient.PostAsync("user/authenticate", content).Result;

                   
                    User user = null;
                    if (response.StatusCode==System.Net.HttpStatusCode.OK)
                    { 
                        var json = response.Content.ReadAsStringAsync().ConfigureAwait(true)
                                        .GetAwaiter()
                                        .GetResult();

                        user = JsonConvert.DeserializeObject<User>(json);

 
                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                    var json = response.Content.ReadAsStringAsync().ConfigureAwait(true)
                                      .GetAwaiter()
                                      .GetResult();

                    throw JsonConvert.DeserializeObject<Exception>(json);
                    }


                return user;
                }
            


            
        }
        public User InsertUser(User user)
        {
            
            return user;
        }
        public IEnumerable<User> GetUsers()
        {
            return null;
        }

       
    }
}
