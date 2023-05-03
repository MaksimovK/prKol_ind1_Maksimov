using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;

namespace IndividualPract
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (File.Exists("formula.txt"))
            {
                if (new FileInfo("formula.txt").Length == 0)
                {
                    Console.WriteLine("Файл пуст!");
                }
                else
                {
                    string formula = ReadFormulaFromFile("formula.txt");
                    int result = EvaluateFormula(formula);
                    Console.WriteLine($"Результат: {result}");
                }
            }
            else Console.WriteLine("Ошибка! Файла нет!");
        }

        static string ReadFormulaFromFile(string filePath)
        {
            string formula = "";
            using (StreamReader sr = new StreamReader(filePath))
            {
                formula = sr.ReadLine();
            }

            return formula;
        }

        static int EvaluateFormula(string formula)
        {
            Stack<int> numbers = new Stack<int>();
            Stack<char> operators = new Stack<char>();

            foreach (char c in formula)
            {
                if (Char.IsDigit(c))
                {
                    // Если символ является числом, добавляем его в стек чисел
                    numbers.Push(c - '0');
                }
                else if (c == 'm' || c == 'p')
                {
                    // Если символ является оператором, добавляем его в стек операторов
                    operators.Push(c);
                }
                else if (c == ',')
                {
                    // Игнорируем символ ","
                    continue;
                }
                else if (c == ')')
                {
                    // Если символ является закрывающей скобкой, вычисляем результат

                    int b = numbers.Pop();
                    int a = numbers.Pop();
                    char op = operators.Pop();

                    int res = 0;
                    if (op == 'm')
                    {
                        res = (a - b) % 10;
                    }
                    else if (op == 'p')
                    {
                        res = (a + b) % 10;
                    }

                    // Добавляем результат в стек чисел
                    numbers.Push(res);
                }
            }

            return numbers.Pop();
        }
    }
}