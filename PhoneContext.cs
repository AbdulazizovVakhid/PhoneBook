using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Tel;
using static телефонный_справочник_1.MetodPhone;

namespace телефонный_справочник_1
{
    public class PhoneContext : DbContext
    {
        public PhoneContext()
        {

        }
        static PhoneContext ()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<PhoneContext>());
        }
        public DbSet <Phone> Persons { get; set; }
       
    }
}
