using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tel;
using static телефонный_справочник_1.MetodPhone;

namespace телефонный_справочник_1
{
    public class WorkUser
    {
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
        enum ActionPhone
        {
            CREATE = 0,
            SEARCH = 1,
            EDIT = 2,
        }
    }
}
