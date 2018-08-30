using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PersonProcessor.Dal
{
    public interface IPersonRepository
    {

        IEnumerable<Person> GetAll();
    }
}
