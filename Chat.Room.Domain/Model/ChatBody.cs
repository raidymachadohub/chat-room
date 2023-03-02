namespace Chat.Room.Domain.Model
{
    public class ChatBody
    {
        public string Message { get; set; }

        public ChatBody(string message)
        {
            Message = message;
        }
    }
}

