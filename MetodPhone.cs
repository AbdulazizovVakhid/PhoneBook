using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace телефонный_справочник_1
{
    public class MetodPhone
    {
        public class Phone
        {
            public string Number;
            public string Name;
            public int Id;

            public override string ToString()
            {
                return string.Format("Number: {0}, Name: {1}", Number, Name);
            }
        }
    }
}
