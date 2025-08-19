using QuizApp.Models;

namespace QuizApp.Data
{
    public static class QuizData
    {
        public static List<Question> GetQuestions() => new()
        {
            new Question
            {
                Text = "Jaki język programowania używany jest w .NET?",
                Options = new() { "Java", "C#", "Python", "JavaScript" },
                CorrectIndex = 1
            },
            new Question
            {
                Text = "Który typ służy do przechowywania liczb całkowitych?",
                Options = new() { "string", "bool", "int", "float" },
                CorrectIndex = 2
            },
            new Question
            {
                Text = "Jakie słowo kluczowe tworzy nowy obiekt?",
                Options = new() { "class", "using", "new", "namespace" },
                CorrectIndex = 2
            }
        };
    }
}