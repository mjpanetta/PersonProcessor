using System;
using System.Collections.Generic;
using PersonProcessor.Dal;

namespace PersonProcessor.Logic
{
    public interface IPersonProcessor
    {
        void Process(Person person);

        IFormattedResult GetResults();

    }
}
