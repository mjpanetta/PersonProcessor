using System;
using System.Collections.Generic;
using PersonProcessor.Dal;
using PersonProcessor.Logic;
using System.Diagnostics;

namespace PersonProcessor
{
    class Program
    {
        static void Main(string[] args)
        {

            var watch = Stopwatch.StartNew();

            IPersonRepository repo = new PersonFileRepository("../../../../example_data.json");
            List<IPersonProcessor> processors =new List<IPersonProcessor>();
            processors.Add(new CountPerAgeProcessor());
            processors.Add(new AgeSelecter(11));
            processors.Add(new IdSelecter(42));

            var people = repo.GetAll();

            foreach (var person in people)
            {
                processors.ForEach(p => p.Process(person));
            }

            processors.ForEach(p => Console.WriteLine(p.ResultsToString()));

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine($"time:{elapsedMs}");

            Console.ReadKey();

        }


    }
}
