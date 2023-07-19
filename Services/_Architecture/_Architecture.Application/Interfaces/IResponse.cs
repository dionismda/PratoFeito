namespace _Architecture.Application.Interfaces;

public interface IResponse<out TObject>
{
    ResponseEnum Type { get; }
    string Message { get; }
    TObject Result { get; }
}