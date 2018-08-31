using System;
using System.Collections.Generic;
using System.Text;

namespace PersonProcessor.Dal
{
    public class Person
    {
        public int Id { get; set; }
        public string First { get; set; }
        public string Last { get; set; }
        public int Age { get; set; }
        public char Gender { get; set; }
    }
}
