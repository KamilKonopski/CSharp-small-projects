using MiniChatSimulator.Services;

Console.WriteLine("=== Mini Chat Simulator ===");
Console.WriteLine("Napisz 'exit' aby zakończyć.\n");

var bot = new ChatBot();

while (true)
{
    Console.Write("Ty: ");
    string input = Console.ReadLine()?.Trim().ToLower() ?? "";

    if (input == "exit") break;

    string response = bot.GetResponse(input);
    Console.WriteLine($"Bot: {response}\n");
}