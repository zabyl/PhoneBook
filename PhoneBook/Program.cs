using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook
{
     public class Program
    {
        static void Main(string[] args)
        {
            IApplication app = new Application();
            app.Execute();
        }
    }
}
