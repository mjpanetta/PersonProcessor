using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PersonProcessor.Dal;

namespace PersonProcessor.Logic
{
    public class CountPerAgeProcessor : IPersonProcessor
    {
        private readonly PeopleAgeCounterResultDictionary _results;

        private static readonly char[] KnownGenders = {'M', 'F'};

        public CountPerAgeProcessor()
        {
            _results = new PeopleAgeCounterResultDictionary();
        }

        public void Process(Person person)
        {
            if (!KnownGenders.Contains(person.Gender)) //nothing to do
                return;
            
            if (!_results.Dictionary.ContainsKey(person.Age))
            {
                var ageResult = new PeopleAgeCounterResult() {Age = person.Age};
                _results.Dictionary.Add(ageResult.Age, ageResult);
            }

            var counterForAge = _results.Dictionary[person.Age];
            switch (person.Gender)
            {
                case 'M':
                    counterForAge.Males++;
                    break;
                case 'F':
                    counterForAge.Females++;
                    break;
            }
            
        }

        public IFormattedResult GetResults()
        {
            return _results;
        }
        
    }
}