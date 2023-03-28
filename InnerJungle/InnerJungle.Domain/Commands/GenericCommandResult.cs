using InnerJungle.Domain.Commands.Contracts;

namespace InnerJungle.Domain.Commands
{
    public class GenericCommandResult : ICommandResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public Object Data { get; set; }

        public GenericCommandResult(bool success, string message, Object data)
        {
            Success = success;
            Message = message;
            Data = data;
        }

        public GenericCommandResult()
        {

        }
    }
}
