using Ga.Individuals;

namespace Ga.Paring
{
    /// <summary>Declares properties of a pare of individuals.</summary>
    public interface IPare
    {
        /// <summary>Gets or sets the first individual.</summary>
        IIndividual First { get; set; }
        /// <summary>Gets or sets the second individual.</summary>
        IIndividual Second { get; set; }
    }
}
