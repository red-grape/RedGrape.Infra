namespace RedGrape.Infra.Core.Utils
{
    public interface IRedGrapeEncryptor
    {
        string EncryptString(string text);
        string DecryptString(string cipherText);
    }
}
