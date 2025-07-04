namespace Kobalos.Domain.Models
{
    internal class Board
    {
        private int viewDistance = 10;

        private Position center = new(0, 0);

        private Dictionary<Position, string> tiles = [];

        private Dictionary<Position, Distance> movement = [];

        public int CenterX
        {
            get { return this.center.X; }
        }

        public int CenterY
        {
            get { return this.center.Y; }
        }

        public Dictionary<Position, string> GetCurrentTiles()
        {
            Dictionary<Position, string> result = [];

            for (int y = this.center.Y + this.viewDistance; y >= this.center.Y - this.viewDistance; y--)
            {
                for (int x = this.center.X - this.viewDistance; x <= this.center.X + this.viewDistance;  x++)
                {
                    Position p = new(x, y);

                    if (this.tiles.TryGetValue(p, out string? c))
                    {
                        result[p] = c;
                        continue;
                    }

                    if (this.movement.TryGetValue(p, out Distance? _))
                    {
                        result[p] = "..";
                        continue;
                    }

                    result[p] = "  ";
                }
            }

            return result;
        }

        public void Reset()
        {
            this.viewDistance = 10;
            this.center = new(0, 0);
            this.tiles = [];
            this.tiles[this.center] = @"🧙🏻‍♂️";
        }

        public void MarkMovement(int distance)
        {
            this.movement = [];
            List<Position> nextPositions = [this.center];

            for (int i = 0; i < distance; i++)
            {
                List<Position> next = [];
                foreach (Position position in nextPositions)
                {
                    next.AddRange([.. position.GetPossibleMoves()
                        .Where(m => this.movement.TryAdd(m, new() { PreviousPosition = position, DistanceTravelled = i + 1 }))]);
                }

                nextPositions = next;
            }
        }
    }
}
