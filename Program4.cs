using System;

namespace LabExercise4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("0到100之间能被3和4整除的数:");
            int count = 0;
            for (int i = 0; i <= 100; i++)
            {
                if (i % 3 == 0 && i % 4 == 0)
                {
                    Console.Write(i);
                    count++;
                    if (i < 100) Console.Write(",");
                }
            }
            Console.WriteLine($"\n总共找到 {count} 个符合条件的数字");
        }
    }
}
