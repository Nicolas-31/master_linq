// See https://aka.ms/new-console-template for more information
using System.Linq;

namespace LinqTutorial
{
    // extension method
    public static class StringExtensions
    {
        // here this indicates that the method is an extension method
        public static int GetCountofLines(this string input)
        {
            return input.Split("\n").Length;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var words = new[] { "a", "bb", "ccc", "dddd" };
            var wordsLongerThan2Lettters = words.Where(
                word => word.Length > 2
            );
            Console.WriteLine(string.Join(", ", wordsLongerThan2Lettters));

            var multilineString = @"Please give me a ride on your back,
                                  Said the Duck to the Kangaroo:
                                  I would sit quite still, and say nothing but 'Quack'
                                  The whole of the long day through; 
                                  And we'd go the Dee, and the Jelly Bo lee, 
                                  Over the land, and over the sea:
                                  Please take me a ride! oh, do !
                                  Said the duck to the Kangaroo";
            var countOfLines = multilineString.GetCountofLines();

            Console.WriteLine($"the total count of line is {countOfLines}");

            // method chaining
            var numbers = new List<int> { 5, 3, 7, 1, 2, 4 };
            var numbersWith10 = numbers.Append(10);
            Console.WriteLine($"numberswith10 : {string.Join(",", numbersWith10)}");
            var orderedOddNumbers = numbers
                .Where(number => number % 2 == 1)
                .OrderBy(number => number);
            Console.WriteLine("orderedOddNumbers: " + string.Join(",", orderedOddNumbers));
            Console.ReadKey();
        }
    }
}