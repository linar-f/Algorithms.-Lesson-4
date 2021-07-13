using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace HashSetAndArray
{
    class Program
    {
        static void Main(string[] args)
        {
            string find = "dfg"; // Инизиализируем переменную которую будем искать
            Char[] letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray(); // Массив символов, из которого формируем строки
            Random number = new Random(); 
            string[] array = new string[10000];
            HashSet<string> HSet = new HashSet<string>();
            for (int i = 0; i < 10000; i++)
            {
                string word = null;
                for (int k = 0; k < 9; k++)
                {
                    word = word + letters[number.Next(25)];  // Создаем строку из символов
                }
                array[i] = word;  // Заполняем массив
                HSet.Add(word); // Заполняем HashSet
                find = array[9999]; // Присваиваем переменной для поиска последний элемент массива
            }
            Stopwatch timer = new Stopwatch();
            timer.Start();
            for (int k = 0; k < 1000; k++)
            {
                for (int i = 0; i < 10000; i++)
                {
                    if (find == array[i])
                    {
                        break;
                    }
                }
            }
            timer.Stop();
            Console.WriteLine($"На поиск строки в массиве затрачено в среднем {timer.ElapsedMilliseconds} микросекунд");
            timer.Reset();
            timer.Start();
            for (int k = 0; k < 1000000; k++)
            { 
                HSet.Contains(find); 
            }
            timer.Stop();
            Console.WriteLine($"На поиск строки в HashSet затрачено в среднем {timer.ElapsedMilliseconds} наноскекунд");
            Console.ReadLine();
        }
    }
}
