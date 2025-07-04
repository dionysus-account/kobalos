namespace Kobalos.Domain.Models
{
    using System.Collections.Generic;
    using Kobalos.Domain.Contracts;

    internal class Position(int x, int y) : ValueObject
    {
        public int X { get; private set; } = x;

        public int Y { get; private set; } = y;

        public Position Up()
        {
            return new Position(this.X, this.Y + 1);
        }

        public Position Down()
        {
            return new Position(this.X, this.Y - 1);
        }

        public Position Left()
        {
            return new Position(this.X - 1, this.Y);
        }

        public Position Right()
        {
            return new Position(this.X + 1, this.Y);
        }

        public List<Position> GetPossibleMoves()
        {
            return [this.Up(), this.Down(), this.Left(), this.Right()];
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return this.X;
            yield return this.Y;
        }
    }
}
