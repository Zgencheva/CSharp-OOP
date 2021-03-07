using System;

namespace AuthorProblem
{
    [AuthorAttribute("Ventsy")]
    public class StartUp
    {
        [AuthorAttribute("Gosho")]
        public static void Main(string[] args)
        {
            var tracker = new Tracker();
            tracker.PrintMethodsByAuthor();

        }
    }
}
