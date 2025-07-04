namespace Kobalos
{
    using System.Text;
    using Kobalos.Application.UI;
    using Kobalos.Domain.Models;

    internal static class Program
    {
        public static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.CursorVisible = false;

            Console.ReadLine();
            Board b = new();
            b.Reset();
            ConsoleWriter.PrintBoard(b);
            Console.ReadLine();
            b.MarkMovement(5);
            ConsoleWriter.PrintBoard(b);
            Console.ReadLine();
        }
    }
}
