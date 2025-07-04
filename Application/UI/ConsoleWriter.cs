namespace Kobalos.Application.UI
{
    using Kobalos.Domain.Models;

    internal static class ConsoleWriter
    {
        public static void PrintBoard(Board board)
        {
            int middleBufferWidth = Console.BufferWidth / 2;
            int middleBufferHeight = Console.BufferHeight / 2;

            Dictionary<Position, string> tiles = board.GetCurrentTiles();

            foreach (KeyValuePair<Position, string> tile in tiles)
            {
                Console.SetCursorPosition(((tile.Key.X - board.CenterX) * 2) + middleBufferWidth, middleBufferHeight - tile.Key.Y - board.CenterY);
                Console.Write(tile.Value);
            }
        }
    }
}
