using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monitor.Data;
using System.Data.SqlClient;

namespace Monitor.Business
{
    public class Customers
    {
        public static Guid Register(string name, string email, string password)
        {
            var customer = new Customer();
            customer.ID = Guid.NewGuid();
            customer.Name = name;
            customer.Email = email;
            customer.Password = password;
            customer.CreateDate = DateTime.Now;

            using (DataClasses1DataContext db = new DataClasses1DataContext())
            {
                db.Customers.InsertOnSubmit(customer);
                db.SubmitChanges();
            }

            return customer.ID;
        }

        public static Customer Login(string email, string password)
        {
            using (DataClasses1DataContext db = new DataClasses1DataContext())
            {
                return db.Customers.Where(x => x.Email == email && x.Password == password).FirstOrDefault();
            }
        }
    }
}
