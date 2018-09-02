using System.Collections.Generic;
using System.Linq;
using PersonProcessor.Dal;

namespace PersonProcessor.Logic
{
    public class AgeSelecter : IPersonProcessor
    {
        private readonly int _ageToSearch;
        private readonly AgeSelecterResult _results;

        public AgeSelecter(int ageToSearch)
        {
            _ageToSearch = ageToSearch;
            _results = new AgeSelecterResult();
        }

        public IFormattedResult GetResults()
        {
            return _results;
        }

        public void Process(Person person)
        {
            if (person.Age == _ageToSearch)
                _results.People.Add(person);
        }
    }
}