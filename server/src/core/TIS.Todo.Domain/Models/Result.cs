namespace TIS.Todo.Domain.Models
{
    public class Result<T>
    {
        public bool IsSuccess { get; set; }

        public T Value { get; set; }

        public string Error { get; set; }

        public static Result<T> Success(T value)
        {
            return new() {IsSuccess = true, Value = value};
        }

        public static Result<T> Failure(string error)
        {
            return new() {IsSuccess = false, Error = error};
        }
    }
}