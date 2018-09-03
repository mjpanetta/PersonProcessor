using System.Collections.Generic;
using System.Linq;
using PersonProcessor.Dal;

namespace PersonProcessor.Logic
{
    public class AgeSelectorResult : IFormattedResult
    {
        public AgeSelectorResult()
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