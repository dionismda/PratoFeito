namespace _Architecture.Application.Interfaces;

public interface IResponse
{
    ResponseEnum Type { get; }
    string Message { get; }
}