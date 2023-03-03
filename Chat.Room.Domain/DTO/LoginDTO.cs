using Newtonsoft.Json;

namespace Chat.Room.Domain.DTO
{
    public class LoginDto
    {
        public long id { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string username { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string password { get; set; }
        
        [JsonConstructor]
        public LoginDto(){}
        
        [JsonConstructor]
        public LoginDto(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
    }
}
