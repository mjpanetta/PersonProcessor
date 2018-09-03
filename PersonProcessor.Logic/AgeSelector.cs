using System.Collections.Generic;
using System.Linq;
using PersonProcessor.Dal;

namespace PersonProcessor.Logic
{
    public class AgeSelector : IPersonProcessor
    {
        private readonly int _ageToSearch;
        private readonly AgeSelectorResult _results;

        public AgeSelector(int ageToSearch)
        {
            _ageToSearch = ageToSearch;
            _results = new AgeSelectorResult();
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