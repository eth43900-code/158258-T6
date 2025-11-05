using System;

namespace LabExercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("输出0到10的数字（使用for循环）:");
            for (int i = 0; i <= 10; i++)
            {
                Console.Write(i);
                if (i < 10) Console.Write(",");
            }
            Console.WriteLine();
        }
    }
}