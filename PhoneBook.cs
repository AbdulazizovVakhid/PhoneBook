using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static телефонный_справочник_1.MetodPhone;

namespace телефонный_справочник_1
{
    public class PhoneBook
    {
        PhoneContext db = new PhoneContext();

        public void Add(Phone p)
        {
            db.Persons.Add(p);
        }

        public void Search(string name)
        {
            var res = db.Persons.Where(n => (n.Name.IndexOf(name) != -1));
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
            Phone p = db.Persons.First(per => per.Id == index);
            p.Number = ph;
            p.Name = name;
        }

        public int SearchIndex(string pn)
        {
            for (int i = 0; i < db.Persons.First(num => num.Id =>, pn).Count; ++i)
                if (db.Persons.First().Number == pn)
                    return i;
            return -1;
        }

        public void Print()
        {
            foreach (var p in db.Persons)
                Console.WriteLine(p);
        }
    }
}

