using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook
{
    static class Menu
    {
        public static void ShowMenu()
        {
            Console.WriteLine(
                "\n\tPHONEBOOK\n\n+" +
                "Lütfen yapmak istediğiniz işlemi seçiniz: " +
                "\n****************************************" +
                "\n\t(1) Yeni numara kaydet" +
                "\n\t(2) Varolan Numarayı Sil" +
                "\n\t(3) Varolan Numarayı Güncelle" +
                "\n\t(4) Rehberi Listele" +
                "\n\t(5) Rehberde Arama Yap" +
                "\n\t(0) Çıkış yap\n"
                );
        }

        public static int SelectOperation()
        {
            Console.Write("\tSeçiminiz: ");
            string userInput = Console.ReadLine();

            if (String.IsNullOrEmpty(userInput))
            {
                return -1;
            }

            int choice = Convert.ToInt32(userInput);

            if (choice < 0 || choice > 5) 
            {
                return -1;
            }
            return choice;
        }
    }
}
