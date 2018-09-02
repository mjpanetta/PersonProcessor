using PersonProcessor.Dal;

namespace PersonProcessor.Logic
{
    public class PersonIdResult : IFormattedResult
    {
        public Person Person { get; set; }
        public string GetResultAsString()
        {
            return $"Id:{Person.Id} Name:{Person.First} {Person.Last}";
        }
    }
}