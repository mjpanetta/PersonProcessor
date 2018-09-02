using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace PersonProcessor.Dal
{
    public class PersonFileRepository :IPersonRepository
    {
        private readonly string _inputFilePath;

        public PersonFileRepository(string inputFilePath)
        {
            _inputFilePath = inputFilePath;
        }

        public IEnumerable<Person> GetAll()
        {
            var peopleAsStrings = System.IO.File.ReadLines(_inputFilePath);

            foreach (var personAsString in peopleAsStrings)
            {
                yield return JsonConvert.DeserializeObject<Person>(personAsString);

            }
            
        }
    }
}
