using QuizApp.Data;

Console.WriteLine("=== Quiz App ===\n");

var questions = QuizData.GetQuestions();
int score = 0;

for (int i = 0; i < questions.Count; i++)
{
    var q = questions[i];
    Console.WriteLine($"{i + 1}. {q.Text}");
    for (int j = 0; j < q.Options.Count; j++)
        Console.WriteLine($"{j + 1}) {q.Options[j]}");

    Console.Write("Twoja odpowiedź (1-4): ");
    if (int.TryParse(Console.ReadLine(), out int answer) && answer == q.CorrectIndex + 1)
    {
        Console.WriteLine("✅ Dobrze!\n");
        score++;
    }
    else
    {
        Console.WriteLine($"❌ Źle. Poprawna odpowiedź: {q.Options[q.CorrectIndex]}\n");
    }
}

Console.WriteLine($"Twój wynik: {score} / {questions.Count}");