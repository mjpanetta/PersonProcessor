using System;
using System.Collections.Generic;
using PersonProcessor.Dal;
using PersonProcessor.Logic;
using System.Diagnostics;
using System.Linq;
using System.IO;

namespace PersonProcessor
{
    class Program
    {
        static int Main(string[] args)
        {
            if (!args.Any())
            {
                Console.WriteLine("Please enter the folder path to the data file");
                return 1;
            }

            var filePath = args[0];

            if (!File.Exists(filePath))
            {
                Console.WriteLine($"Can not find file at path {filePath}");
                return 1;
            }
            
            IPersonRepository repo = new PersonFileRepository(filePath);
            var processors =
                new List<IPersonProcessor>
                {
                    new IdSelector(42),
                    new AgeSelector(99),
                    new CountPerAgeProcessor()
                };

            var feeder = new PersonFeeder(processors);
            var people = repo.GetAll();
            
            feeder.FeedToProcessors(people);

            var results = feeder.GetResults().ToList();

            results.ForEach(r => Console.Write(r.GetResultAsString() + "\n\n"));

#if DEBUG
            Console.ReadKey();
#endif
            return 0;
        }


    }
}
