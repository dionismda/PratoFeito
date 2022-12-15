namespace _Shared.Kernel.Interfaces.Services;

public interface ICipherCryptographyService : ICryptography
{
    byte[] GenerateSha256(string inputString);
    string GenerateSha256String(string inputString);
}
