using Newtonsoft.Json;
using System.Collections.Generic;

namespace AddEmployeesPlugin
{
    
    public class UsersJson
    {
        [JsonProperty("users")]
        public User[] Data { get; set; }
    }

    public class User
    {

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("maidenName")]
        public string MaidenName { get; set; }



        [JsonProperty("phone")]
        public string Phone { get; set; }


    }


}