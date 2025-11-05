using System;

namespace LabExercise3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("输出0到10的数字（使用do-while循环）:");
            int i = 0;
            do
            {
                Console.Write(i);
                if (i < 10) Console.Write(",");
                i++;
            } while (i <= 10);
            Console.WriteLine();
        }
    }
}
