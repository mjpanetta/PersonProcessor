using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PersonProcessor.Dal;

namespace PersonProcessor.Logic
{
    public class PersonFeeder
    {
        private readonly List<IPersonProcessor> _processors;

        public PersonFeeder(List<IPersonProcessor> processors)
        {
            _processors = processors;
        }

        public void FeedToProcessors(IEnumerable<Person> people)
        {
            foreach (var person in people)
            {
                _processors.ForEach(p => p.Process(person));
            }
        }

        public IEnumerable<IFormattedResult> GetResults()
        {
            return _processors.Select(p => p.GetResults());
        }
    }
}
