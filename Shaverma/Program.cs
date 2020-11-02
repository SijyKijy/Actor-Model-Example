using Shaverma.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shaverma
{
    class Program
    {
        private static Random _random;
        private static List<IShaverma> _allShavermas;
        private static int _Counter;

        static Program()
        {
            _random = new Random((int)DateTime.Now.Ticks);
            _allShavermas = new List<IShaverma>() { new SmallShaverma(), new StandartShaverma(), new BigShaverma() };
        }

        static void Main()
        {
            Chef ramzi = new Chef("Рамзи");
            Chef oliver = new Chef("Оливер");

            while (true)
            {
                var key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Q)
                    ramzi.Post(GenerateOrder());

                if (key.Key == ConsoleKey.W)
                    oliver.Post(GenerateOrder());
            }
        }

        private static Order GenerateOrder()
        {
            StringBuilder orderString = new StringBuilder();
            var shavermas = new List<IShaverma>(_random.Next(0, 10));

            for (int i = 0; i < shavermas.Capacity; i++)
                shavermas.Add(_allShavermas[_random.Next(0, _allShavermas.Count)]);

            foreach (var shaverma in shavermas)
                orderString.AppendLine($"Название: {shaverma.Name} Цена: {shaverma.Price};");

            var order = new Order($"№{_Counter}", shavermas);
            Console.WriteLine();
            Console.WriteLine($"Заказ создан (Цена: {order.Price}) Товары: {orderString}");
            _Counter++;
            return order;
        }
    }
}