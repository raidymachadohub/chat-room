using Chat.Room.Shared.FlowControl.Enum;

namespace Chat.Room.Shared.FlowControl.Model
{
    public class Error
    {
        public string Message { get; set; }
        public ErrorType ErrorType { get; set; }

        public Error(ErrorType errorType, string message)
        {
            ErrorType = errorType;
            Message = message;
        }
        public Error(){}
        
    }
}

