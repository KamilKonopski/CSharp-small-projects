using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace MiniChatSimulator.Services
{
    public class ChatBot
    {
        private readonly Dictionary<string, string> _responses = new()
        {
            { "czesc", "Cześć! Jak się masz?" },
            { "hej", "Hej, co tam?" },
            { "jak sie masz", "Mam się dobrze, dzięki! A Ty?" },
            { "co robisz", "Czekam na Twoje pytanie. 😊" },
            { "do widzenia", "Na razie! 👋" },
            { "jak masz na imie", "Jestem prostym botem, ale możesz mi nadać imię!" },
            { "pomoc", "Możesz powiedzieć 'cześć', 'co robisz', 'jak się masz', itp." },
            { "dziekuje", "Nie ma sprawy! 😄" },
            { "dzień dobry", "Dzień dobry! Jak mogę pomóc?" },
            { "ktora godzina", $"Teraz jest: {DateTime.Now:HH:mm}" },
        };

        public string GetResponse(string input)
        {
            var cleanedInput = Normalize(input);

            foreach (var key in _responses.Keys)
            {
                if (cleanedInput.Contains(key))
                    return _responses[key];
            }

            return "Nie rozumiem. Możesz zapytać inaczej?";
        }

        private string Normalize(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return string.Empty;

            text = text.ToLowerInvariant();

            // Usuń polskie znaki
            text = RemoveDiacritics(text);

            // Usuń znaki interpunkcyjne
            text = Regex.Replace(text, @"[^\w\s]", "");

            return text;
        }

        private string RemoveDiacritics(string text)
        {
            var normalized = text.Normalize(NormalizationForm.FormD);
            var builder = new StringBuilder();

            foreach (var ch in normalized)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(ch);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                    builder.Append(ch);
            }

            return builder.ToString().Normalize(NormalizationForm.FormC);
        }
    }
}