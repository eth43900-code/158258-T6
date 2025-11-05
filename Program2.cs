using System;

namespace LabExercise2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("输出0到10的数字（使用while循环）:");
            int i = 0;
            while (i <= 10)
            {
                Console.Write(i);
                if (i < 10) Console.Write(",");
                i++;
            }
            Console.WriteLine();
        }
    }
}