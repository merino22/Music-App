namespace AssistantManager.Core.Models
{
    public class Result<T>
    {
        public Result(string message)
        {
            ErrorMessage = message;
            Success = false;
        }

        public Result(T value)
        {
            Value = value;
            Success = true;
        }

        public bool Success { get; set; }

        public string ErrorMessage { get; set; }

        public T Value { get; set; }
    }
}
