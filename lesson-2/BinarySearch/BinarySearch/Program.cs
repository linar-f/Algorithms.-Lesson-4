using System;

namespace BinarySearch
{
    class Program
    {
        public static (int, int) BinarySearch(int[] inputArray, int searchValue)
        {
            //Как мы выяснили на занятии, асимптотическая сложность данного метода логарифм от N по основанию 2.
            int count = 0;
            int min = 0;
            int max = inputArray.Length - 1;
            while (min <= max)
            {
                count = count + 1;
                int mid = (min + max) / 2;
                if (searchValue == inputArray[mid])
                {
                    return (mid, count);
                }
                else if (searchValue < inputArray[mid])
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }

            }
            return (-1, count);
        }

        static void Main(string[] args)
        {
            int[] array = { 1, 5, 7, 18, 20, 23, 24, 25, 29, 35, 45, 55, 77, 98, 99, 100, 199 };
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine($"{i}) {array[i]}");
            }
            Console.WriteLine("Введите искомое число:");
            int findNumber = Convert.ToInt32(Console.ReadLine());
            (int index, int numberStep) = BinarySearch(array, findNumber);
            if (index != -1)
            {
                Console.WriteLine($"Индекс искомого элемента {index}. Количество итераций: {numberStep}.");
            }
            else
            {
                Console.WriteLine($"Программа вернула {index} - элемент с данным значением не найден.");
            }    
            
        }
    }
}
