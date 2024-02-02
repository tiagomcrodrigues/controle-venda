namespace ControleVenda.CrossCutting.Common.Models
{
    public class Result<T> : IResult<T>
    {
        public Result(T data)
        {
            Data = data;
        }

        public Result(IDictionary<string, string> errors)
        {
            Errors = errors;
        }

        public Result(Exception exception)
        {
            Exception = exception;
        }

        public bool Success => !Errors.Any()  && Exception == null;

        public T Data { get; private set; }

        public IDictionary<string, string> Errors { get; private set; } = new Dictionary<string, string>();

        public Exception? Exception { get; private set; }

        
    }
}
