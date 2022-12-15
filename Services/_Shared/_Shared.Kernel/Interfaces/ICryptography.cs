namespace _Shared.Kernel.Interfaces;

public interface ICryptography
{
    string Encrypt(string plainText, string? passPhrase = null);
    string Decrypt(string encryptText, string? passPhrase = null);
}