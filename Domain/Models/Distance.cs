namespace Kobalos.Domain.Models
{
    internal class Distance
    {
        required public Position PreviousPosition { get; set; }

        public int DistanceTravelled { get; set; }
    }
}
