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
            var words = new List<string>() { "a", "bb", "ccc", "dddd" };
            // var wordsLongerThan2Lettters = words.Where(
            //     word => word.Length > 2
            // );
            // Console.WriteLine(string.Join(", ", wordsLongerThan2Lettters));
            
            var shortWords = words.Where(word => word.Length < 3).ToList();
            Console.WriteLine("First iteration");
            foreach (var word in shortWords)
            {
                // deferred execution
                Console.WriteLine(word);
            }
            words.Add("e");
            Console.WriteLine("Second iteration");
            foreach (var word in shortWords)
            {
                // deferred execution
                Console.WriteLine(word);
            }

          
            // var allAmericans = people.Where(person => person.Country == "USA");
            // var notAllAmericans = allAmericans.Take(100);

            var animals = new List<string>() { "Duck", "Lion", "Dolphin", "Tiger"};
            var animalsWithD = animals.Where(animal =>
            {
                Console.WriteLine("checking animals: " + animal);    
                return animal.StartsWith("D");
            });
            foreach (var animal  in animalsWithD)
            {
                Console.WriteLine(animal);
            }
            
            // here duck and dolphin will be printed twice at the same time
            // because the query is executed in the same time as the foreach loop iterates
            
            
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
            
            
            // method syntax vs query syntax
            var numbers2 = new List<int> { 4,2,7,10,12,5,4,2 };  
            var smallOrderedNumbersMethodSyntax = 
                numbers2
                    .Where(number => number <10)
                     .OrderBy(number => number)
                    .Distinct();
            Console.WriteLine(string.Join(",", smallOrderedNumbersMethodSyntax));

            var smallOrderedNumbersQuerySyntax =
                (from number in numbers2
                where number < 10
                orderby number
                select number).Distinct();

            Console.WriteLine(string.Join(",", smallOrderedNumbersQuerySyntax));
            Console.ReadKey();
        }
    }
}