using System;
using System.Collections.Generic;
using DevicesLibrary;

namespace Lab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            var devices = new List<Device>();
            int choice;

            do
            {
                Console.WriteLine("\n--- Меню ---");
                Console.WriteLine("1. Добавить устройство");
                Console.WriteLine("2. Показать все устройства");
                Console.WriteLine("0. Выход");
                Console.Write("Ваш выбор: ");

                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Некорректный ввод.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        AddDevice(devices);
                        break;
                    case 2:
                        PrintAll(devices);
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("Некорректный ввод.");
                        break;
                }
            } while (choice != 0);
        }

        static void AddDevice(List<Device> devices)
        {
            Console.Write("Выберите тип:\n1 - Базовое устройство\n2 - Телевизор\n3 - Радиоприёмник\nВаш выбор: ");
            if (!int.TryParse(Console.ReadLine(), out int type))
            {
                Console.WriteLine("Неверный тип.");
                return;
            }

            Console.Write("Бренд: ");
            string brand = Console.ReadLine() ?? "";
            Console.Write("Модель: ");
            string model = Console.ReadLine() ?? "";
            Console.Write("Цена: ");

            if (!decimal.TryParse(Console.ReadLine(), out decimal price))
            {
                Console.WriteLine("Некорректная цена.");
                return;
            }

            switch (type)
            {
                case 1:
                    devices.Add(new Device(brand, model, price));
                    break;
                case 2:
                    Console.Write("Диагональ (дюймы): ");
                    if (!int.TryParse(Console.ReadLine(), out int size)) size = 32;
                    Console.Write("Smart TV (1=да, 0=нет): ");
                    bool smart = Console.ReadLine() == "1";
                    devices.Add(new TV(brand, model, price, size, smart));
                    break;
                case 3:
                    Console.Write("Диапазон (например, FM/AM): ");
                    string range = Console.ReadLine() ?? "FM";
                    Console.Write("Питание от батарей (1=да, 0=нет): ");
                    bool battery = Console.ReadLine() == "1";
                    devices.Add(new Radio(brand, model, price, range, battery));
                    break;
                default:
                    Console.WriteLine("Неверный тип, объект не добавлен.");
                    break;
            }
        }

        static void PrintAll(List<Device> devices)
        {
            if (devices.Count == 0)
            {
                Console.WriteLine("Список пуст.");
                return;
            }

            for (int i = 0; i < devices.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {devices[i]}");
            }
        }
    }
}