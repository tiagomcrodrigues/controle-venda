namespace ControleVenda.CrossCutting.Common.Models
{
    public interface IResult<T>
    {
        bool Success { get; }
        T Data { get; }
        IDictionary<string, string> Errors { get; }
        Exception? Exception { get; }
    }
}
