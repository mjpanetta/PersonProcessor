using System.Reflection.Metadata.Ecma335;
using PersonProcessor.Dal;

namespace PersonProcessor.Logic
{
    public class PersonIdResult : IFormattedResult
    {
        public int Id { get; set; }
        public Person Person { get; set; }
        public string GetResultAsString()
        {
            return Person != null ? $"Id:{Person.Id} Name:{Person.First} {Person.Last}" : $"Person not found for Id:{Id}";
        }
    }
}