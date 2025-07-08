using System;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Witam w kalkulatorze C#");

            while (true)
            {
                Console.WriteLine("\nWybierz operację (1-5): ");
                Console.WriteLine("1. Dodawanie");
                Console.WriteLine("2. Odejmowanie");
                Console.WriteLine("3. Mnożenie");
                Console.WriteLine("4. Dzielenie");
                Console.WriteLine("5. Wyjście");

                string? choiceNumber = Console.ReadLine();

                if (!int.TryParse(choiceNumber, out int operation))
                {
                    Console.WriteLine("Nieprawidłowy wybór. Spróbuj ponownie.");
                    continue;
                }

                if (operation == 5)
                {
                    Console.WriteLine("Zamykam kalkulator...");
                    break;
                }

                Console.Write("Podaj pierwszą liczbę: ");
                if (!int.TryParse(Console.ReadLine(), out int firstNumber))
                {
                    Console.WriteLine();
                    Console.WriteLine("Nieprawidłowa liczba.");
                    continue;
                }

                Console.Write("Podaj drugą liczbę: ");
                if (!int.TryParse(Console.ReadLine(), out int secondNumber))
                {
                    Console.WriteLine();
                    Console.WriteLine("Nieprawidłowa liczba.");
                    continue;
                }

                int result;

                switch (operation)
                {
                    case 1:
                        result = firstNumber + secondNumber;
                        break;
                    case 2:
                        result = firstNumber - secondNumber;
                        break;
                    case 3:
                        result = firstNumber * secondNumber;
                        break;
                    case 4:
                        if (secondNumber == 0)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Nie można dzielić przez zero.");
                            continue;
                        }
                        result = firstNumber / secondNumber;
                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("Nieznana operacja.");
                        continue;
                }

                Console.WriteLine($"\nWynik: {result}\n");
            }
        }
    }
}