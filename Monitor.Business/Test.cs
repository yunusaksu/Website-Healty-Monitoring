using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monitor.Data;
using System.Collections;

namespace Monitor.Business
{
    public class Test
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        public static void TestInsert(Guid customerId, string name, string url)
        {
            Monitor.Data.Test test = new Monitor.Data.Test();
            test.ID = Guid.NewGuid();
            test.Name = name;
            test.Url = url;
            test.CustomerID = customerId;
            test.CreateDate = DateTime.Now;

            using (DataClasses1DataContext db = new DataClasses1DataContext())
            {
                db.Tests.InsertOnSubmit(test);
                db.SubmitChanges();
            }
        }

        public static Dictionary<Guid, string> List()
        {
            using (DataClasses1DataContext db = new DataClasses1DataContext())
            {
                return db.Tests.Select(c => new { c.ID, c.Url }).ToDictionary(c => c.ID, c => c.Url);
            }
        }

        public static void SaveTestResult(Guid testId, int statusCode)
        {
            TestResult tr = new TestResult();
            tr.TestID = testId;
            tr.StatusCode = statusCode;
            tr.ID = Guid.NewGuid();
            tr.LastTestDate = DateTime.Now;

            DataClasses1DataContext db = new DataClasses1DataContext();

            var veri = (from ad in db.Tests where ad.ID == testId select ad).FirstOrDefault();
            tr.Name = veri.Name;
            tr.Url = veri.Url;


            using (DataClasses1DataContext dba = new DataClasses1DataContext())
            {
                dba.TestResults.InsertOnSubmit(tr);
                dba.SubmitChanges();
            }
        }

        public static void TestRemove(Guid id)
        {
            using (DataClasses1DataContext db = new DataClasses1DataContext())
            {
                var sonuc = db.Tests.Where(c => c.ID == id).FirstOrDefault();
                db.Tests.DeleteOnSubmit(sonuc);
                db.SubmitChanges();
            }
        }

        public static List<Data.TestResult> TestLogList(Guid id)
        {
            using (DataClasses1DataContext db = new DataClasses1DataContext())
            {
                //return db.TestResults.Where(c => c.Test.CustomerID == customerId).ToList();
                var result = db.TestResults.Where(c => c.TestID == id).OrderByDescending(c => c.LastTestDate).ToList();

                return result;
            }
        }

        /* public static TestResult TestList(Guid customerId)
         {
             using (DataClasses1DataContext db = new DataClasses1DataContext())
             {
                 //return db.TestResults.Where(c => c.Test.CustomerID == customerId).ToList();
                 return db.TestResults.Where(c => c.Test.CustomerID == customerId).OrderByDescending(c => c.LastTestDate).FirstOrDefault();
             }
         }
         */
        public static List<Monitor.Data.Test> TestList(Guid customerId)
        {
            using (DataClasses1DataContext db = new DataClasses1DataContext())
            {
                //return db.TestResults.Where(c => c.Test.CustomerID == customerId).ToList();
                return db.Tests.Where(c => c.CustomerID == customerId).ToList();
                // return db.Tests.Where(c => c.CustomerID == customerId).OrderByDescending(c => c.LastTestDate).ToList();
            }
        }
    }
}
