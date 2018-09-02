using System.Linq;
using PersonProcessor.Logic;
using Xunit;

namespace PersonProcessor.Tests
{
    public class AgeSelecterTests : PeopleTestsBaseClass
    {
        [Fact]
        public void AgeSelecterReturnsCorrectly()
        {
            var processor = new AgeSelecter(25);
            var mark = GeneratePerson(1, "Mark", null, null, 25);
            var steve = GeneratePerson(2, "Steve", null, null, 23);
            var bill = GeneratePerson(3, "Bill", null, null, 25);
            var dave = GeneratePerson(4, "Dave", null, null, 21);
            var tim = GeneratePerson(5, "Tim", null, null, 56);

            processor.Process(mark);
            processor.Process(steve);
            processor.Process(bill);
            processor.Process(dave);
            processor.Process(tim);
            var result = (AgeSelecterResult)processor.GetResults();

            Assert.True(result.People.TrueForAll(r => r.Age == 25));
            Assert.True(result.People.Count == 2);
            
        }

        [Fact]
        public void AgeSelecterReturnsEmptyWhenNoPeopleProvided()
        {
            var processor = new AgeSelecter(25);

            var result = (AgeSelecterResult)processor.GetResults();

            Assert.True(!result.People.Any());
        }
        [Fact]
        public void AgeSelecterReturnsEmptyListWhenAgeIsntPresent()
        {
            var processor = new AgeSelecter(0);
            var mark = GeneratePerson(1, "Mark", null, null, 25);
            var steve = GeneratePerson(2, "Steve", null, null, 23);
            var bill = GeneratePerson(3, "Bill", null, null, 25);
            var dave = GeneratePerson(4, "Dave", null, null, 21);
            var tim = GeneratePerson(5, "Tim", null, null, 56);

            processor.Process(mark);
            processor.Process(steve);
            processor.Process(bill);
            processor.Process(dave);
            processor.Process(tim);
            var result = (AgeSelecterResult)processor.GetResults();

            Assert.True(!result.People.Any());
        }
    }
}