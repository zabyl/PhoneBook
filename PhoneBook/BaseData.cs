using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook
{
    static class BaseData
    {
        private static List<Person> _people = new List<Person>
        {
            new Person("Marlon","Walters","5327418567"),
            new Person("Aldo","Mooney","3123492868"),
            new Person("Donovan","Stokes","2242432726"),
            new Person("Jose","Yang","2122867460"),
            new Person("Kieran","Lester","2324636729")

        };

        public static List<Person> People { get { return _people; } }
    }
}
