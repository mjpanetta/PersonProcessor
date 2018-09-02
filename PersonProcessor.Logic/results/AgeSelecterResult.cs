using System.Collections.Generic;
using System.Linq;
using PersonProcessor.Dal;

namespace PersonProcessor.Logic
{
    public class AgeSelecterResult : IFormattedResult
    {
        public AgeSelecterResult()
        {
            People = new List<Person>();
        }

        public List<Person> People;

        public string GetResultAsString()
        {
            return string.Join(", ", People.Select(p => p.First));
        }
    }
}