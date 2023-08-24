using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PhoneBook
{
    public class Application : IApplication
    {
        private List<Person> _accounts = new List<Person>();



        public void Execute()
        {
            _accounts.AddRange(BaseData.People);


            int option = 0;

            do
            {
                Menu.ShowMenu();
                option = Menu.SelectOperation();
                Console.WriteLine("****************************************");

                switch (option)
                {
                    case 0:
                        Console.WriteLine("Çıkış yapılıyor...\n");
                        break;
                    case 1:
                        SaveContact();
                        break;
                    case 2:
                        DeleteContact();
                        break;
                    case 3:
                        UpdateContact();
                        break;
                    case 4:
                        ListContact();
                        break;
                    case 5:
                        SearchContact();
                        break;
                    default:
                        Console.WriteLine("Yanlış bir giriş yaptınız!");
                        break;
                }
                this.ClearScreen();
            } while (option != 0);
        }


        public void ClearScreen()
        {
            Console.Write("Herhangi bir tuşa basın...");
            Console.ReadLine();
            Console.Clear();
        }

        public string TakeInput()
        {
            string text = Console.ReadLine();
            if (String.IsNullOrEmpty(text))
            {
                Console.WriteLine("Lütfen uygun değer giriniz!\n" +
                    "****************************************");
                return "null";
            }
            return text;
        }

        public bool MakeChoice()
        {
            while (true)
            {
                Console.Write("Devam etmek istiyor musunuz? (e/h)\n-> ");
                string choice = TakeInput();
                if (choice == "e" || choice == "E")
                {
                    return true;
                }
                else if (choice == "h" || choice == "H")
                {
                    return false;
                }
                Console.WriteLine("Lütfen bir seçim yapınuz!");
            }
        }

        public void SaveContact()
        {
            string name, surname, number;

            do
            {
                Console.Write("Lütfen isim giriniz             :");
                name = TakeInput();
                Console.WriteLine();

            } while (name.CompareTo("null") == 0);

            do
            {
                Console.Write("Lütfen soyisim giriniz          :");
                surname = TakeInput();
                Console.WriteLine();

            } while (surname.CompareTo("null") == 0);

            do
            {
                Console.Write("Lütfen telefon numarası giriniz :");
                number = TakeInput();
                Console.WriteLine();

            } while (number.CompareTo("null") == 0);

            _accounts.Add(new Person(name, surname, number));
            Console.WriteLine("Kayıt başarılı.");
        }

        public void DeleteContact()
        {
            while (true)
            {
                string userData;

                do
                {
                    Console.Write("Lütfen numarasını silmek istediğiniz kişinin adını ya da soyadını giriniz: ");
                    userData = TakeInput();

                } while (userData.CompareTo("null") == 0);

                foreach (var item in _accounts)
                {
                    if (item.Name.ToLower() == userData.ToLower() || item.Surname.ToLower() == userData.ToLower())
                    {
                        Console.WriteLine("Kayıt bulundu!");

                        if (!MakeChoice())
                            return;

                        _accounts.Remove(item);
                        Console.WriteLine("Kayıt başarıyla silindi.");
                        return;
                    }
                }
                Console.WriteLine("Aradığınız kriterlere uygun veri rehberde bulunamadı.");
                if (!MakeChoice())
                    return;

            }
        }

        public void UpdateContact()
        {
            while (true)
            {
                string userData;

                do
                {
                    Console.Write("Lütfen numarasını güncellemek istediğiniz kişinin adını ya da soyadını giriniz: ");
                    userData = TakeInput();

                } while (userData.CompareTo("null") == 0);

                foreach (var item in _accounts)
                {
                    if (item.Name.ToLower() == userData.ToLower() || item.Surname.ToLower() == userData.ToLower())
                    {
                        Console.WriteLine("Kayıt bulundu!");

                        if (!MakeChoice())
                            return;

                        Console.Write("Kişi kaydı için yeni isim giriniz: ");
                        item.Name = TakeInput();
                        Console.WriteLine();

                        Console.Write("Kişi kaydı için yeni soyisim giriniz: ");
                        item.Surname = TakeInput();
                        Console.WriteLine();

                        Console.Write("Kişi kaydı için yeni numara giriniz: ");
                        item.Number = TakeInput();
                        Console.WriteLine();

                        Console.WriteLine("Kayıt başarıyla güncellendi.");
                        return;
                    }
                }
                Console.WriteLine("Aradığınız krtiterlere uygun veri rehberde bulunamadı.");
                if (!MakeChoice())
                    return;

            }
        }

        public void ListContact()
        {
            Console.WriteLine("\t\tTelefon Rehberi\n" +
                "**********************************************");

            Console.WriteLine($"Rehberde kayıtlı toplam {_accounts.Count} kişi var.");

            if (_accounts == null || _accounts.Count == 0)
            {
                Console.WriteLine("Rehberde hiç kayıt yok!!");
                return;
            }

            foreach (var account in _accounts)
            {
                Console.WriteLine($"\tisim: {account.Name}" +
                    $"\n\tsoyisim: {account.Surname}" +
                    $"\n\ttelefon numarası: {account.Number}\n");
                Console.WriteLine("**********************************************");
            }

        }

        public void SearchContact()
        {
            while (true)
            {
                string choice;

                do
                {
                    Console.WriteLine("Arama yapmak istediğiniz tipi seçiniz: " +
                        "\n**********************************************");

                    Console.Write("\tİsim veya soyisime göre arama yapmak için: (1)" +
                        "\n\tTelefon numarasına göre arama yapmak için: (2)\n-> ");

                    choice = TakeInput();

                } while (choice.CompareTo("null") == 0);
                Console.WriteLine();

                if (choice != "1" || choice != "2")
                {
                    Console.WriteLine("Lütfen seçenekler arasından bir tercih yapınız!");
                    continue;
                }


                int num = 0;
                if (choice == "1")
                {
                    Console.Write("Rehberde aramak için bir isim veya soyisim girin: ");
                    string data = TakeInput();

                    foreach (var item in _accounts)
                    {
                        if (item.Name.ToLower() == data.ToLower() || item.Surname.ToLower() == data.ToLower())
                        {
                            Console.WriteLine("Arama Sonuçlarınız: " +
                                "\n**********************************************");

                            Console.WriteLine($"\tisim: {item.Name}" +
                            $"\n\tsoyisim: {item.Surname}" +
                            $"\n\ttelefon numarası: {item.Number}\n");
                            num = 1;
                        }
                    }
                }
                else if (choice == "2")
                {
                    Console.Write("Telefon numarası giriniz: ");
                    string data = TakeInput();

                    foreach (var item in _accounts)
                    {
                        if (item.Number == data)
                        {
                            Console.WriteLine("Arama Sonuçlarınız: " +
                                "\n**********************************************");

                            Console.WriteLine($"\tisim: {item.Name}" +
                            $"\n\tsoyisim: {item.Surname}" +
                            $"\n\ttelefon numarası: {item.Number}\n");
                            num = 1;
                        }
                    }
                }
                Console.WriteLine("**********************************************");
                if (num == 0)
                {
                    Console.WriteLine("Aradığınız krtiterlere uygun veri rehberde bulunamadı!");
                }
                if (!MakeChoice())
                    return;
            }
        }


        public List<Person> Accounts { get { return _accounts; } }
    }
}
