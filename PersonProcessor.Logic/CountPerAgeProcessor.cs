using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PersonProcessor.Dal;

namespace PersonProcessor.Logic
{
    public class IdSelecter : IPersonProcessor
    {
        private readonly int _idToSearch;
        private Person _result;

        public IdSelecter(int idToSearch)
        {
            _idToSearch = idToSearch;
        }

        public void Process(Person people)
        {
            if (_result != null)
                return;

            if (people.Id == _idToSearch)
                _result = people;

        }

        public string ResultsToString()
        {
            return _result == null ? "" : $"Id:{_idToSearch} Name:{_result.First} {_result.Last}";
        }
    }

    public class AgeSelecter : IPersonProcessor
    {
        private readonly int _ageToSearch;
        private readonly List<Person> _results;

        public AgeSelecter(int ageToSearch)
        {
            _ageToSearch = ageToSearch;
            _results = new List<Person>();

        }

        public void Process(Person people)
        {
            if (people.Age == _ageToSearch)
                _results.Add(people);
        }

        public string ResultsToString()
        {
            return string.Join(',', _results.Select(r => r.First));
        }
    }

    public class CountPerAgeProcessor : IPersonProcessor
    {
        public Dictionary<int, PeopleAgeCounterResults> _results;

        public CountPerAgeProcessor()
        {
            _results = new Dictionary<int, PeopleAgeCounterResults>();
        }

        public void Process(Person people)
        {
            
                if (!_results.ContainsKey(people.Age))
                {
                    var ageResult = new PeopleAgeCounterResults() {Age = people.Age};
                    _results.Add(ageResult.Age, ageResult);
                }

                var counterForAge = _results[people.Age];
                switch (people.Gender)
                {
                    case 'M':
                        counterForAge.Males++;
                        break;
                    case 'F':
                        counterForAge.Females++;
                        break;
                }
            
        }

        public Dictionary<int, PeopleAgeCounterResults> GetResults()
        {
            return _results;
        }

        public string ResultsToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var result in GetResults().Values)
            {
                sb.AppendLine($"Age: {result.Age} Males: {result.Males} Females: {result.Females}");
            }

            return sb.ToString();
        }
    }

    public class PeopleAgeCounterResults
    {
        public int Age { get; set; }
        public int Males { get; set; }
        public int Females { get; set; }
    }
}