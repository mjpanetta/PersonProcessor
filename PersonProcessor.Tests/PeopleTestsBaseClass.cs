using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using PersonProcessor.Dal;
using Xunit;

namespace PersonProcessor.Tests
{
    public class PeopleTestsBaseClass
    {
        protected Person GeneratePerson(int id, string first = null, string last = null, char? gender = null,
            int? age = null)
        {
            var rnd = new Random();
            return new Person()
            {
                Age = age.GetValueOrDefault(rnd.Next(1, 100)),
                First = first ??
                        $"{(char)rnd.Next(97, 123)}{(char)rnd.Next(97, 123)}{(char)rnd.Next(97, 123)}{(char)rnd.Next(97, 123)}",
                Last = last ??
                       $"{(char)rnd.Next(97, 123)}{(char)rnd.Next(97, 123)}{(char)rnd.Next(97, 123)}{(char)rnd.Next(97, 123)}",
                Gender = gender.GetValueOrDefault(rnd.Next(0, 2) == 1 ? 'M' : 'F'),
                Id = id
            };
        }

        /// <summary>
        /// Method used to generate large amounts of data for testing purposes
        /// </summary>
        //[Fact]
        public void GenerateRandomTextFileForTesting()
        {
            int recordsToGenerate = 1000000;
            var peopleJson = new List<string>();
            for (int i = 1; i <= recordsToGenerate; i++)
            {
                var randomPerson = GeneratePerson(i);
                peopleJson.Add(JsonConvert.SerializeObject(randomPerson));
            }
            System.IO.File.WriteAllLines("test_data.json", peopleJson);
        }
    }
}