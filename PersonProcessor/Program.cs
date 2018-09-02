using System;
using System.Collections.Generic;
using PersonProcessor.Dal;
using PersonProcessor.Logic;
using System.Diagnostics;
using System.Linq;

namespace PersonProcessor
{
    class Program
    {
        static void Main(string[] args)
        {
            var watch = Stopwatch.StartNew();

            IPersonRepository repo = new PersonFileRepository("../../../../test_data.json");
            List<IPersonProcessor> processors =
                new List<IPersonProcessor>
                {
                    new IdSelecter(42),
                    new AgeSelecter(11),
                    new CountPerAgeProcessor()
                };

            var feeder = new PersonFeeder(processors);

            var people = repo.GetAll();
            
            feeder.FeedToProcessors(people);

            var results = feeder.GetResults().ToList();

            results.ForEach(r => Console.WriteLine(r.GetResultAsString() + "\n"));

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine($"time:{elapsedMs}");

            Console.ReadKey();

        }


    }
}
