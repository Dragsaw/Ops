using Ga.Individuals;

namespace Ga.Paring
{
    public interface IPare
    {
        IIndividual First { get; set; }
        IIndividual Second { get; set; }
    }
}
