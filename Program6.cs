using System;
using System.Collections.Generic;

namespace LabExercise6
{
    // Car类定义
    public class Car
    {
        // 数据成员
        private string make;
        private string model;
        private string colour;
        private readonly string registrationNumber; // 只读字段

        // 构造函数
        public Car(string make, string model, string colour, string registrationNumber)
        {
            this.make = make;
            this.model = model;
            this.colour = colour;
            this.registrationNumber = registrationNumber;
        }

        // 只读属性 - 注册号
        public string RegistrationNumber
        {
            get { return registrationNumber; }
        }

        // Make属性 - 只有在有值时才允许设置
        public string Make
        {
            get { return make; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    make = value;
                else
                    Console.WriteLine("Make不能为空值!");
            }
        }

        // Model属性
        public string Model
        {
            get { return model; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    model = value;
                else
                    Console.WriteLine("Model不能为空值!");
            }
        }

        // Colour属性
        public string Colour
        {
            get { return colour; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    colour = value;
                else
                    Console.WriteLine("Colour不能为空值!");
            }
        }

        // 输出汽车信息的方法
        public string GetCarInfo()
        {
            return $"品牌:{make}, 型号:{model}, 颜色:{colour}, 注册号:{registrationNumber}";
        }

        // 显示简要信息（用于列表显示）
        public string GetShortInfo()
        {
            return $"{make} {model} ({colour}) - 注册号: {registrationNumber}";
        }
    }

    class Program
    {
        static List<Car> cars = new List<Car>();

        static void InitializeCars()
        {
            // 创建5辆汽车
            cars.Add(new Car("Toyota", "Camry", "Red", "TOY123"));
            cars.Add(new Car("Honda", "Civic", "Blue", "HON456"));
            cars.Add(new Car("Ford", "Mustang", "Black", "FOR789"));
            cars.Add(new Car("BMW", "X5", "White", "BMW012"));
            cars.Add(new Car("Tesla", "Model 3", "Silver", "TES345"));
        }

        static void DisplayAllCars()
        {
            Console.WriteLine("\n=== 所有汽车信息 ===");
            for (int i = 0; i < cars.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {cars[i].GetShortInfo()}");
            }
            Console.WriteLine("====================\n");
        }

        static void ModifyCar()
        {
            Console.WriteLine("\n选择要修改的汽车 (输入1-5):");
            for (int i = 0; i < cars.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {cars[i].GetShortInfo()}");
            }

            if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= 5)
            {
                Car selectedCar = cars[choice - 1];

                Console.WriteLine($"\n修改汽车: {selectedCar.GetShortInfo()}");
                Console.WriteLine("输入新的品牌 (或按Enter跳过):");
                string newMake = Console.ReadLine();
                if (!string.IsNullOrEmpty(newMake))
                {
                    selectedCar.Make = newMake;
                }

                Console.WriteLine("输入新的型号 (或按Enter跳过):");
                string newModel = Console.ReadLine();
                if (!string.IsNullOrEmpty(newModel))
                {
                    selectedCar.Model = newModel;
                }

                Console.WriteLine("输入新的颜色 (或按Enter跳过):");
                string newColour = Console.ReadLine();
                if (!string.IsNullOrEmpty(newColour))
                {
                    selectedCar.Colour = newColour;
                }

                Console.WriteLine("修改完成!");
                Console.WriteLine($"更新后的信息: {selectedCar.GetShortInfo()}");
            }
            else
            {
                Console.WriteLine("无效的选择!");
            }
        }

        static void SearchCar()
        {
            Console.WriteLine("\n搜索汽车:");
            Console.WriteLine("1. 按品牌搜索");
            Console.WriteLine("2. 按颜色搜索");
            Console.Write("请选择搜索方式: ");

            if (int.TryParse(Console.ReadLine(), out int searchType))
            {
                string searchTerm;
                List<Car> results = new List<Car>();

                switch (searchType)
                {
                    case 1:
                        Console.Write("输入品牌名称: ");
                        searchTerm = Console.ReadLine();
                        results = cars.FindAll(c => c.Make.ToLower().Contains(searchTerm.ToLower()));
                        break;
                    case 2:
                        Console.Write("输入颜色: ");
                        searchTerm = Console.ReadLine();
                        results = cars.FindAll(c => c.Colour.ToLower().Contains(searchTerm.ToLower()));
                        break;
                    default:
                        Console.WriteLine("无效的选择!");
                        return;
                }

                if (results.Count > 0)
                {
                    Console.WriteLine($"\n找到 {results.Count} 辆匹配的汽车:");
                    foreach (var car in results)
                    {
                        Console.WriteLine($"- {car.GetShortInfo()}");
                    }
                }
                else
                {
                    Console.WriteLine("没有找到匹配的汽车!");
                }
            }
        }

        static void DisplayMenu()
        {
            Console.WriteLine("\n=== 汽车管理系统 ===");
            Console.WriteLine("1. 查看所有汽车");
            Console.WriteLine("2. 修改汽车信息");
            Console.WriteLine("3. 搜索汽车");
            Console.WriteLine("4. 退出");
            Console.Write("请选择操作 (1-4): ");
        }

        static void Main(string[] args)
        {
            InitializeCars();

            Console.WriteLine("欢迎使用汽车管理系统!");

            while (true)
            {
                DisplayMenu();
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        DisplayAllCars();
                        break;
                    case "2":
                        ModifyCar();
                        break;
                    case "3":
                        SearchCar();
                        break;
                    case "4":
                        Console.WriteLine("感谢使用汽车管理系统，再见!");
                        return;
                    default:
                        Console.WriteLine("无效的选择，请输入1-4之间的数字!");
                        break;
                }
            }
        }
    }
}