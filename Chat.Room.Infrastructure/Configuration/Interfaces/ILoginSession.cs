namespace Chat.Room.Infrastructure.Configuration.Interfaces
{
    public interface ILoginSession
    {
        public string Token { get; }
        public string Username { get; }
    }
}

