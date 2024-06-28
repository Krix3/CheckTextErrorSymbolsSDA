using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите текст:");
        string input = Console.ReadLine();

        Console.WriteLine("Введите недопустимые слова через запятую:");
        string[] forbiddenWords = Console.ReadLine().Split(',');

        string result = ReplaceForbiddenWords(input, forbiddenWords, out int replacementsCount);

        Console.WriteLine("Результат работы:");
        Console.WriteLine(result);
        Console.WriteLine($"Статистика: {replacementsCount} замен(ы).");
    }

    static string ReplaceForbiddenWords(string text, string[] forbiddenWords, out int replacementsCount)
    {
        replacementsCount = 0;
        foreach (string word in forbiddenWords)
        {
            string trimmedWord = word.Trim();
            if (string.IsNullOrEmpty(trimmedWord)) continue;

            string pattern = @"\b" + Regex.Escape(trimmedWord) + @"\b";
            text = Regex.Replace(text, pattern, match =>
            {
                replacementsCount++;
                return new string('*', match.Length);
            }, RegexOptions.IgnoreCase);
        }
        return text;
    }
}