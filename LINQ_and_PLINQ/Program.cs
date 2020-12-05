using System;
using System.Diagnostics;
using System.Linq;

namespace LINQ_and_PLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите кол-во элементов");
            int N = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            Random rand = new Random();
            string[] arr = Enumerable.Range(0, N).Select(i =>
                Convert.ToString(rand.Next(0, 1000000))).ToArray();
            Stopwatch sw = new Stopwatch();


            //foreach (string i in arr)
            //  Console.WriteLine(i);
            //Console.WriteLine();


            //Выборка чётных чисел
            Console.WriteLine("Выборка чётных чисел");
            sw.Restart();
            string[] result = arr.Where(i =>
                Convert.ToInt32(i.Last().ToString()) % 2 == 0).ToArray();
            sw.Stop();
            for (int i = 0; i < Math.Min(10, result.Length); i++)
                Console.WriteLine(result[i]);
            Console.WriteLine("Время выполнения LINQ - " + sw.ElapsedMilliseconds + "мс");
            sw.Restart();
            result = arr.AsParallel().Where(i =>
                Convert.ToInt32(i.Last().ToString()) % 2 == 0).ToArray();
            sw.Stop();
            Console.WriteLine("Время выполнения PLINQ - " + sw.ElapsedMilliseconds + "мс\n");


            //Выборка нечётных чисел
            Console.WriteLine("Выборка нечётных чисел");
            sw.Restart();
            result = arr.AsParallel().Where(i =>
                Convert.ToInt32(i.Last().ToString()) % 2 == 1).ToArray();
            sw.Stop();
            for (int i = 0; i < Math.Min(10, result.Length); i++)
                Console.WriteLine(result[i]);
            Console.WriteLine("Время выполнения LINQ - " + sw.ElapsedMilliseconds + "мс");
            sw.Restart();
            result = arr.AsParallel().Where(i =>
                 Convert.ToInt32(i.Last().ToString()) % 2 == 1).ToArray();
            sw.Stop();
            Console.WriteLine("Время выполнения PLINQ - " + sw.ElapsedMilliseconds + "мс\n");


            //Выборка чисел, где сумма первой и предпоследней цифры равна 6 
            Console.WriteLine("Выборка чисел, где сумма первой и предпоследней цифры равна 6");
            sw.Restart();
            result = arr.Where(i =>
            {
                if (i.Length <= 3)
                    return false;
                int lastElsement = Convert.ToInt32(i[i.Length - 2].ToString());
                int firstElsement = Convert.ToInt32(i.First().ToString());
                return lastElsement + firstElsement == 6;
            }).ToArray();
            sw.Stop();
            for (int i = 0; i < Math.Min(10, result.Length); i++)
                Console.WriteLine(result[i]);
            Console.WriteLine("Время выполнения LINQ - " + sw.ElapsedMilliseconds + "мс");
            sw.Restart();
            result = arr.AsParallel().Where(i =>
            {
                if (i.Length <= 3)
                    return false;
                int lastElsement = Convert.ToInt32(i[i.Length - 2].ToString());
                int firstElsement = Convert.ToInt32(i.First().ToString());
                return lastElsement + firstElsement == 6;
            }).ToArray();
            sw.Stop();
            Console.WriteLine("Время выполнения PLINQ - " + sw.ElapsedMilliseconds + "мс\n");


            //Выборка чисел, сумма всех чисел равна 13 
            Console.WriteLine("Выборка чисел, сумма всех чисел равна 13");
            sw.Restart();
            result = arr.Where(i =>
                i.Sum(x => Convert.ToInt32(x.ToString())) == 13).ToArray();
            sw.Stop();
            for (int i = 0; i < Math.Min(10, result.Length); i++)
                Console.WriteLine(result[i]);
            Console.WriteLine("Время выполнения LINQ - " + sw.ElapsedMilliseconds + "мс");
            sw.Restart();
            result = arr.AsParallel().Where(i =>
                i.Sum(x => Convert.ToInt32(x.ToString())) == 13).ToArray();
            sw.Stop();
            Console.WriteLine("Время выполнения PLINQ - " + sw.ElapsedMilliseconds + "мс\n");
            Console.ReadKey();
        }
    }
}
