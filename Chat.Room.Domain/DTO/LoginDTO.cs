using Newtonsoft.Json;

namespace Chat.Room.Domain.DTO
{
    public class LoginDTO
    {
        public long id { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string username { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string password { get; set; }

        [JsonConstructor]
        public LoginDTO(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
    }
}
