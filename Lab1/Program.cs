using System;

class Program
{
    static void Main()
    {
        // Генерируем случайный массив с целыми числами ы
        double[] array = GenerateRandomArray(10, -10.0, 10.0, 2);
      
        // Выводим изначальный массив
        Console.WriteLine("Изначальный массив:");
        foreach (var element in array)
        {
            Console.Write(element + " ");
        }
        Console.WriteLine();

        // Находим номер минимального элемента
        int nummin = FindIndexOfMinElement(array);
        Console.WriteLine("Номер минимального элемента: " +nummin );

        // Находим сумму элементов между первым и вторым отрицательными
        double summas = CalculateSumBetweenNegatives(array);
        Console.WriteLine("Сумма элементов между первым и вторым отрицательными: "+summas);

        // Преобразовываем массив
        Array.Sort(array, (a, b) => Math.Abs(a) <= 1 ? -1 : 1);

        // Выводим преобразованный массив
        Console.WriteLine("Преобразованный массив:");
        foreach (var element in array)
        {
            Console.Write(element + " ");
        }
    }

    // Метод для генерации случайного массива
    static double[] GenerateRandomArray(int length, double min, double max, int decimalPlaces)
    {
        Random random = new Random();
        double[] array = new double[length];

        for (int i = 0; i < length; i++)
        {
            double value = min + (max - min) * random.NextDouble();
            array[i] = Math.Round(value, decimalPlaces);
        }

        return array;
    }

    // Метод для поиска номера минимального элемента
    static int FindIndexOfMinElement(double[] array)
    {
        double min = array[0];
        int nummin = 0;

        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] < min)
            {
                min = array[i];
                nummin = i;
            }
        }

        return nummin+1;
    }

    // Метод для вычисления суммы элементов между первым и вторым отрицательными
    static double CalculateSumBetweenNegatives(double[] array)
    {
        double sum = 0;
        int firstNegativeIndex = -1;

        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] < 0)
            {
                if (firstNegativeIndex == -1)
                {
                    firstNegativeIndex = i;
                }
                else
                {
                    for (int j = firstNegativeIndex + 1; j < i; j++)
                    {
                        sum += array[j];
                    }
                    break;
                }
            }
        }

        return sum;
    }
}
