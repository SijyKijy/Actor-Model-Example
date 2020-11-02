using System.Collections.Generic;
using System.Linq;

namespace Shaverma.Models
{
    public class Order
    {
        public string Name { get; }
        public IReadOnlyCollection<IShaverma> Shavermas { get; }
        public int Price { get; }

        public Order(string name, List<IShaverma> shavermas)
        {
            Name = name;
            Shavermas = shavermas;
            Price = shavermas.Sum(x => x.Price);
        }
    }
}
