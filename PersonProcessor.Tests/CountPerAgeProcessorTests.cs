using System.Collections.Generic;
using PersonProcessor.Dal;
using PersonProcessor.Logic;
using Xunit;

namespace PersonProcessor.Tests
{
    public class CountPerAgeProcessorTests : PeopleTestsBaseClass
    {
        [Fact]
        public void UnknownGendersAreIgnored()
        {
            int id = 1;
            List<Person> people = new List<Person>();
            for (int i = 0; i < 3; i++)
            {
                char gender = i % 2 == 0 ? 'M' : 'C';
                for (int age = 20; age <= 24; age += 2)
                {
                    people.Add(GeneratePerson(id, null, null, gender, age));
                    id++;
                }
            }
            people.Add(GeneratePerson(100, null, null, 'x', 99));
            var processor = new CountPerAgeProcessor();
            people.ForEach(p => processor.Process(p));

            var result = (PeopleAgeCounterResultDictionary)processor.GetResults();

            Assert.Contains(result.Dictionary, r => r.Key == 20);
            Assert.Contains(result.Dictionary, r => r.Key == 22);
            Assert.True(result.Dictionary[20].Females == 0);
            Assert.True(result.Dictionary[22].Females == 0);
            Assert.True(result.Dictionary[20].Males == 2);
            Assert.True(result.Dictionary[22].Males == 2);
            Assert.DoesNotContain(result.Dictionary, r => r.Key == 99);
            
        }
        [Fact]
        public void AgeAndGenderCountGroupsAndReturnsCorrectly()
        {
            int id = 1;
            List<Person> people = new List<Person>();
            for (int i = 0; i < 3; i++)
            {
                char gender = i % 2 == 0 ? 'M' : 'F';
                for (int age = 20; age <= 30; age += 2)
                {
                    people.Add(GeneratePerson(id, null, null, gender, age));
                    id++;
                }
            }
            var processor = new CountPerAgeProcessor();
            people.ForEach(p => processor.Process(p));


            var result = (PeopleAgeCounterResultDictionary)processor.GetResults();


            Assert.Contains(result.Dictionary, d => d.Key == 20);
            Assert.Contains(result.Dictionary, d => d.Key == 22);
            Assert.Contains(result.Dictionary, d => d.Key == 24);
            Assert.Contains(result.Dictionary, d => d.Key == 26);
            Assert.Contains(result.Dictionary, d => d.Key == 28);
            Assert.Contains(result.Dictionary, d => d.Key == 30);
            Assert.True(result.Dictionary[20].Females == 1);
            Assert.True(result.Dictionary[20].Males == 2);
            Assert.True(result.Dictionary[26].Females == 1);
            Assert.True(result.Dictionary[26].Males == 2);
            Assert.True(result.Dictionary[30].Females == 1);
            Assert.True(result.Dictionary[30].Males == 2);

        }
    }
}