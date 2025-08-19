using PasswordGenerator.Services;

Console.WriteLine("=== Password Generator ===");
Console.Write("Podaj długość hasła: ");
if (int.TryParse(Console.ReadLine(), out int length))
{
    var generator = new PasswordService();
    string password = generator.Generate(length);
    Console.WriteLine($"Wygenerowane hasło: {password}");
}
else
{
    Console.WriteLine("Nieprawidłowa długość.");
}