namespace _Shared.Application.Interfaces;

public interface IResponse
{
    ResponseTypeEnum Type { get; }
    string Message { get; }
}
