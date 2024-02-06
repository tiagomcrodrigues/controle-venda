using Flunt.Notifications;

namespace ControleVenda.CrossCutting.Common.Models
{
    public class Result<T> : IResult<T>
    {
        public Result(T data)
        {
            Data = data;
        }

        public Result(IEnumerable<Notification> errors)
        {
            Errors = errors;
        }

        public Result(Notification notification)
        {
            Errors = new List<Notification>() { notification };
        }

        public Result(Exception exception)
        {
            Exception = exception;
        }

        public bool Success => !Errors.Any() && Exception == null;

        public T Data { get; private set; }

        public IEnumerable<Notification> Errors { get; private set; } = new List<Notification>();

        public Exception? Exception { get; private set; }


    }
}
