using System.Threading.Tasks;

namespace Shaverma.Models
{
    public interface IChef
    {
        string Name { get; }
        Status Status { get; }
        Task Cook(IShaverma shaverma);
    }
}
