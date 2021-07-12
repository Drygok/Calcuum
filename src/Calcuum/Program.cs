using System;
using System.Collections.Generic;

namespace Calcuum
{
    class Program
    {
        private static readonly Dictionary<string, Func<double, double, double>> operations = new Dictionary<string, Func<double, double, double>>()
        {
            {
                "+",
                ((double x, double y) =>
                {
                    return x + y;
                })
            },
            {
                "-",
                ((double x, double y) =>
                {
                    return x - y;
                })
            },
            {
                "*",
                ((double x, double y) =>
                {
                    return x * y;
                })
            },
            {
                "/",
                ((double x, double y) =>
                {
                    return x / y;
                })
            }
        };

        static void Main(string[] args)
        {
            Console.WriteLine("Привет, о дивный новый мир");
            Console.WriteLine("Чтобы использовать возможности калькулятора, Вы можете просто печатать выражение в поле ввода\n");
            Console.WriteLine("Для закрытия приложения введите команду exit");

            string input = "";
            while (input != "exit")
            {
                string[] commands = input.Split(' ');
                if (commands.Length == 3)
                {
                    if (operations.ContainsKey(commands[1]))
                    {
                        try
                        {
                            Console.WriteLine("Результат операции: " + operations[commands[1]].Invoke(Double.Parse(commands[0].Replace('.', ',')), Double.Parse(commands[2].Replace('.', ','))));
                        }
                        catch
                        {
                            Console.WriteLine("Аргументы не опознаны: Пожалуйста, повторите ввод");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Операция не опознана. Допустимые операции:");
                        foreach (string operation in operations.Keys)
                        {
                            Console.Write("\t" + operation);
                        }
                        Console.WriteLine();
                    }
                }
                else
                {
                    if (input != "")
                    {
                        Console.WriteLine("Действие не распознано");
                    }
                }

                Console.WriteLine();
                Console.Write("Введите выражение, разделяя каждый его элемент пробелами (например, \"2 + 2\"): ");
                input = Console.ReadLine();
            }


        }
    }
}
