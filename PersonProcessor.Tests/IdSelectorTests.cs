using PersonProcessor.Logic;
using Xunit;

namespace PersonProcessor.Tests
{
    public class IdSelectorTests : PeopleTestsBaseClass
    {
        

        [Fact]
        public void IdSelectorReturnsPersonAssociatedToId()
        {
            const int idToSearch = 3;
            var selector = new IdSelector(idToSearch);
            var person1 = GeneratePerson(1);
            var person2 = GeneratePerson(2);
            var person3 = GeneratePerson(3);
            var person4 = GeneratePerson(4);
            var person5 = GeneratePerson(5);


            selector.Process(person1);
            selector.Process(person2);
            selector.Process(person3);
            selector.Process(person4);
            selector.Process(person5);


            Assert.Equal(person3, ((PersonIdResult) selector.GetResults()).Person);
        }

        [Fact]
        public void IdSelectorReturnsWithNoPersonIfPersonNotInList()
        {
            const int idToSearch = 25;
            var selector = new IdSelector(idToSearch);
            var person1 = GeneratePerson(1);
            var person2 = GeneratePerson(2);
            var person3 = GeneratePerson(3);
            var person4 = GeneratePerson(4);
            var person5 = GeneratePerson(5);


            selector.Process(person1);
            selector.Process(person2);
            selector.Process(person3);
            selector.Process(person4);
            selector.Process(person5);


            Assert.Null(((PersonIdResult)selector.GetResults()).Person);

        }

        [Fact]
        public void IdSelectorDoesntContinueProcessingAfterFindingResult()
        {
            var selector = new IdSelector(3);
            var mark = GeneratePerson(1, "Mark");
            var steve = GeneratePerson(2, "Steve");
            var john = GeneratePerson(3, "John");
            var paul = GeneratePerson(3, "Paul");
            var lucas = GeneratePerson(3, "Lucas");
            selector.Process(mark);
            selector.Process(steve);
            selector.Process(john);
            selector.Process(paul);
            selector.Process(lucas);


            var result = (PersonIdResult) selector.GetResults();


            Assert.Equal(john, result.Person);
        }
    }
}