using System;
using System.Collections.Generic;
using System.Linq;

namespace Tel
{
    class Program
    {
        static void Main(string[] args)
        {
            PhoneBook pb = new PhoneBook();
            UserMode(pb);


        }

        static void UserMode(PhoneBook pb)
        {
            Console.Clear();
            Console.WriteLine("Создать: 0");
            Console.WriteLine("Найти: 1");
            Console.WriteLine("Редактировать: 2");
            Console.Write("\nПожалуйста выбирите действие: ");
            switch ((ActionPhone)int.Parse(Console.ReadLine()))
            {
                case ActionPhone.CREATE:
                    {
                        Phone p = new Phone();
                        Console.WriteLine("Создание нового елемента справочника...");
                        Console.Write("Введите номер абонента: ");
                        p.Number = Console.ReadLine();
                        Console.Write("Введите имя абонента: ");
                        p.Name = Console.ReadLine();
                        pb.Add(p);
                    }
                    break;
                case ActionPhone.EDIT:
                    {
                        Phone p = new Phone();
                        Console.WriteLine("Редактирование...");
                        Console.Write("Введите номер абонента для поиска: ");
                        int index = pb.SearchIndex(Console.ReadLine());
                        if (index == -1)
                        {
                            Console.WriteLine("Абонент отсутствует в справочнике");
                            break;
                        }
                        Console.Write("номер: ");
                        string n = Console.ReadLine();
                        Console.Write("имя: ");
                        string m = Console.ReadLine();
                        pb.Edit(index, n, m);

                    }
                    break;
                case ActionPhone.SEARCH:
                    {
                        Console.WriteLine("Поиск...");
                        Console.Write("Введите имя: ");
                        pb.Search(Console.ReadLine());
                    }
                    break;
            }

            Console.Write("\n\nЧто делаем дальше? Выходим (ДА - 0, НЕТ - 1): ");
            if (Console.ReadLine() == "0")
                
                return;

            UserMode(pb);
        }
    }

    class Phone
    {
        public string Number;
        public string Name;

        public override string ToString()
        {
            return string.Format("Number: {0}, Name: {1}", Number, Name);
        }
    }

    enum ActionPhone
    {
        CREATE = 0,
        SEARCH = 1,
        EDIT = 2,
    }

    class PhoneBook
    {
        private List<Phone> book = new List<Phone>();

        public void Add(Phone p)
        {
            book.Add(p);
        }

        public void Search(string name)
        {
            var res = book.Where(n => (n.Name.IndexOf(name) != -1));
            if (res.Count() == 0)
            {
                Console.WriteLine("Ни чего не найдено...");
                return;
            }
            foreach (var p in res)
                Console.WriteLine(p);
        }

        public void Edit(int index, string ph, string name)
        {
            Phone p = book[index];
            p.Number = ph;
            p.Name = name;
        }

        public int SearchIndex(string pn)
        {
            for (int i = 0; i < book.Count; ++i)
                if (book[i].Number == pn)
                    return i;
            return -1;
        }

        public void Print()
        {
            foreach (var p in book)
                Console.WriteLine(p);
        }
    }
}