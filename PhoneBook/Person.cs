using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook
{
    public class Person
    {

        private string _name, _surname, _number;

        public Person(string name, string surname, string number)
        {
            _name = name;
            _surname = surname;
            _number = number;
        }

        public string Name 
        { 
            get 
            {
                if (String.IsNullOrEmpty(_name))
                {
                    return null;
                }
                return _name;
            }

            set { _name = value; } 
        }

        public string Surname 
        { 
            get
            {
                if (String.IsNullOrEmpty(_surname))
                {
                    return null;
                }
                return _surname;
            }
            
            set { _surname = value; }
        }

        public string Number 
        { 
            get
            {
                if (String.IsNullOrEmpty(_number))
                {
                    return null;
                }
                return _number;
            }
            set { _number = value; }


        }
    }
}
