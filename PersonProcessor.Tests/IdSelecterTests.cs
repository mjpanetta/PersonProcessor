using PersonProcessor.Logic;
using Xunit;

namespace PersonProcessor.Tests
{
    public class IdSelecterTests : PeopleTestsBaseClass
    {
        

        [Fact]
        public void IdSelecterReturnsPersonAssociatedToId()
        {
            const int idToSearch = 3;
            var selecter = new IdSelecter(idToSearch);
            var person1 = GeneratePerson(1);
            var person2 = GeneratePerson(2);
            var person3 = GeneratePerson(3);
            var person4 = GeneratePerson(4);
            var person5 = GeneratePerson(5);


            selecter.Process(person1);
            selecter.Process(person2);
            selecter.Process(person3);
            selecter.Process(person4);
            selecter.Process(person5);


            Assert.Equal(person3, ((PersonIdResult) selecter.GetResults()).Person);
        }

        [Fact]
        public void IdSelecterReturnsNullIfPersonNotInList()
        {
            const int idToSearch = 25;
            var selecter = new IdSelecter(idToSearch);
            var person1 = GeneratePerson(1);
            var person2 = GeneratePerson(2);
            var person3 = GeneratePerson(3);
            var person4 = GeneratePerson(4);
            var person5 = GeneratePerson(5);


            selecter.Process(person1);
            selecter.Process(person2);
            selecter.Process(person3);
            selecter.Process(person4);
            selecter.Process(person5);


            Assert.Null(selecter.GetResults());

        }

        [Fact]
        public void IdSelectorDoesntContinueProcessingAfterFindingResult()
        {
            var selecter = new IdSelecter(3);
            var mark = GeneratePerson(1, "Mark");
            var steve = GeneratePerson(2, "Steve");
            var john = GeneratePerson(3, "John");
            var paul = GeneratePerson(3, "Paul");
            var lucas = GeneratePerson(3, "Lucas");
            selecter.Process(mark);
            selecter.Process(steve);
            selecter.Process(john);
            selecter.Process(paul);
            selecter.Process(lucas);


            var result = (PersonIdResult) selecter.GetResults();


            Assert.Equal(john, result.Person);
        }
    }
}