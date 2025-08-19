namespace QuizApp.Models
{
    public class Question
    {
        public required string Text { get; set; }
        public required List<string> Options { get; set; }
        public int CorrectIndex { get; set; }
    }
}