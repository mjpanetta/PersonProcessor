using System.Collections.Generic;
using System.Text;

namespace PersonProcessor.Logic
{
    public class PeopleAgeCounterResultDictionary : IFormattedResult
    {
        public PeopleAgeCounterResultDictionary()
        {
            Dictionary = new Dictionary<int, PeopleAgeCounterResult>();
        }

        public PeopleAgeCounterResultDictionary(Dictionary<int, PeopleAgeCounterResult> dictionary)
        {
            Dictionary = dictionary;
        }

        public Dictionary<int, PeopleAgeCounterResult> Dictionary { get; private set; }

        public string GetResultAsString()
        {
            var sb = new StringBuilder();

            foreach (var result in Dictionary.Values)
            {
                sb.AppendLine($"Age: {result.Age} Males: {result.Males} Females: {result.Females}");
            }

            return sb.ToString();
        }
    }
}