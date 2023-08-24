using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook
{
    public interface IApplication
    {
        void Execute();
        void ClearScreen();

        string TakeInput();

        bool MakeChoice();

        void SaveContact();

        void DeleteContact();

        void UpdateContact();

        void ListContact();

        void SearchContact();

    }
}
