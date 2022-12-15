namespace _Shared.Kernel.Interfaces;

public interface IResponse
{
    ResponseTypeEnum Type { get; }
    string Message { get; }
}
