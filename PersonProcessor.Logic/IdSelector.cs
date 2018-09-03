using PersonProcessor.Dal;

namespace PersonProcessor.Logic
{
    public class IdSelector : IPersonProcessor
    {
        private readonly PersonIdResult _result;

        public IdSelector(int idToSearch)
        {
            _result = new PersonIdResult() {Id = idToSearch};
        }

        public IFormattedResult GetResults()
        {
            return _result;
        }

        public void Process(Person person)
        {
            //person already found, no need to continue search
            //may want to throw an exception here depending on how we want to handle this
            if (_result.Person != null)
                return;

            if (person.Id == _result.Id)
                _result.Person = person ;
        }
    }
}