namespace _Shared.Kernel.Services;

public class CipherCryptographyService : ICipherCryptographyService
{
    private readonly CryptographySetting? _appJwtSetting;

    public CipherCryptographyService(IOptions<CryptographySetting>? appJwtSetting)
    {
        _appJwtSetting = appJwtSetting?.Value;
    }

    public string Encrypt(string plainText, string? passPhrase = null)
    {
        passPhrase ??= _appJwtSetting?.EncryptionKey;

        var btkey = Encoding.ASCII.GetBytes(passPhrase);
        RijndaelManaged aes128 = new()
        {
            Mode = CipherMode.ECB,
            Padding = PaddingMode.Zeros
        };
        var encryptor = aes128.CreateEncryptor(btkey, null);
        MemoryStream msEncrypt = new();
        using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
        using (var swEncrypt = new StreamWriter(csEncrypt))
        {
            swEncrypt.Write(plainText);
        }

        return Convert.ToBase64String(msEncrypt.ToArray());
    }

    public string Decrypt(string encryptText, string? passPhrase = null)
    {
        passPhrase ??= _appJwtSetting?.EncryptionKey;

        var cipher = Convert.FromBase64String(encryptText);
        var btkey = Encoding.ASCII.GetBytes(passPhrase);

        RijndaelManaged aes128 = new()
        {
            Mode = CipherMode.ECB,
            Padding = PaddingMode.Zeros
        };

        var decryptor = aes128.CreateDecryptor(btkey, null);
        MemoryStream ms = new(cipher);
        CryptoStream cs = new(ms, decryptor, CryptoStreamMode.Read);
        var plain = new byte[cipher.Length];
        var decryptCount = 0;

        while (true)
        {
            var count = cs.Read(plain, 0, plain.Length);

            if (count == 0)
                break;

            decryptCount += count;
        }

        ms.Close();
        cs.Close();
        return Encoding.UTF8.GetString(plain, 0, decryptCount).Replace("\0", "");
    }

    public byte[] GenerateSha256(string inputString)
    {
        using HashAlgorithm algorithm = SHA256.Create();

        return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
    }

    public string GenerateSha256String(string inputString)
    {
        StringBuilder sb = new();

        foreach (var b in GenerateSha256(inputString))
            sb.Append(b.ToString("X2"));

        return sb.ToString();
    }
}
