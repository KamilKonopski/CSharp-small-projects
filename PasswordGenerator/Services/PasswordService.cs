namespace PasswordGenerator.Services
{
    public class PasswordService
    {
        private readonly Random _random = new();

        private const string _chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*";

        public string Generate(int length)
        {
            return new string(Enumerable.Range(0, length)
                .Select(_ => _chars[_random.Next(_chars.Length)]).ToArray());
        }
    }
}