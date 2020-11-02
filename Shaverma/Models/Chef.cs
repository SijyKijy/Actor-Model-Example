using Shaverma.Actors;
using System;
using System.Threading.Tasks;

namespace Shaverma.Models
{
    public class Chef : AbstractWorker<Order>, IChef
    {
        public string Name { get; }
        public Status Status { get; private set; }

        public Chef(string name)
        {
            Name = name;
            Status = Status.Free;
        }

        protected override async Task HandleJob(Order msg)
        {
            Status = Status.Busy;
            Console.WriteLine($"Шеф {Name} принял заказ {msg.Name}");

            foreach (var shaverma in msg.Shavermas)
                await Cook(shaverma);

            Console.WriteLine($"Шеф {Name} выполнил заказ {msg.Name}");
            Status = Status.Free;
        }

        protected override Task HandleError(Job<Order> job, Exception ex)
        {
            Console.WriteLine($"Ой-ой, шеф {Name} не смог принять {job.Assignment.Name} по причине: {ex}");

            return Task.CompletedTask;
        }

        public async Task Cook(IShaverma shaverma)
        {
            Console.WriteLine($"Шеф {Name} начинает готовить {shaverma.Name}");
            await Task.Delay(1000);
            Console.WriteLine($"Шеф {Name} приготовил {shaverma.Name}");
        }

        public override string ToString() => Name;
    }
}
