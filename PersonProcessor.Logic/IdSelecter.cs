using PersonProcessor.Dal;

namespace PersonProcessor.Logic
{
    public class IdSelecter : IPersonProcessor
    {
        private readonly int _idToSearch;
        private PersonIdResult _result;

        public IdSelecter(int idToSearch)
        {
            _idToSearch = idToSearch;
        }

        public IFormattedResult GetResults()
        {
            return _result;
        }

        public void Process(Person person)
        {
            //person already found, no need to continue search
            //may want to throw an exception here depending on how we want to handle this
            if (_result != null)
                return;

            if (person.Id == _idToSearch)
                _result = new PersonIdResult() { Person = person };
        }
    }
}