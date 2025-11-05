using System;

namespace LabExercise7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("简单计算器程序（带异常处理）");

            while (true)
            {
                try
                {
                    Console.WriteLine("\n请输入第一个数字 (输入 'q' 退出):");
                    string input1 = Console.ReadLine();
                    if (input1.ToLower() == "q") break;

                    Console.WriteLine("请输入运算符 (+, -, *, /):");
                    string opInput = Console.ReadLine();
                    if (opInput.ToLower() == "q") break;

                    Console.WriteLine("请输入第二个数字:");
                    string input2 = Console.ReadLine();
                    if (input2.ToLower() == "q") break;

                    // 预防性检查 - 使用if/else
                    if (string.IsNullOrEmpty(input1) || string.IsNullOrEmpty(input2) || string.IsNullOrEmpty(opInput))
                    {
                        Console.WriteLine("输入不能为空!");
                        continue;
                    }

                    // 转换输入
                    double a = double.Parse(input1);
                    double b = double.Parse(input2);
                    char c = char.Parse(opInput);

                    double result = 0;
                    bool validOperation = true;

                    // 执行计算
                    switch (c)
                    {
                        case '+':
                            result = a + b;
                            break;
                        case '-':
                            result = a - b;
                            break;
                        case '*':
                            result = a * b;
                            break;
                        case '/':
                            // 检查除零错误
                            if (b == 0)
                            {
                                throw new DivideByZeroException("错误: 除数不能为零!");
                            }
                            result = a / b;
                            break;
                        default:
                            validOperation = false;
                            Console.WriteLine("无效的运算符! 请使用 +, -, *, /");
                            break;
                    }

                    if (validOperation)
                    {
                        Console.WriteLine($"{a} {c} {b} = {Math.Round(result, 2)}");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("错误: 请输入有效的数字格式!");
                }
                catch (DivideByZeroException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (OverflowException)
                {
                    Console.WriteLine("错误: 数字太大或太小!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"发生未知错误: {ex.Message}");
                }
                finally
                {
                    // 清理资源或执行必要的操作
                    Console.WriteLine("--- 计算完成 ---");
                }
            }

            Console.WriteLine("感谢使用计算器!");
        }
    }
}