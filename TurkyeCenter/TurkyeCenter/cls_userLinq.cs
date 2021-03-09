using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Linq.SqlClient;

namespace TurkyeCenter
{
    class cls_userLinq
    {
        static dbDataContext db = new dbDataContext();
        static public bool ran = false;

        public static void GetAllCustomers(DataGridView gv) {
            var tb = from x in db.customers
                     orderby x.id descending select x;
            gv.DataSource = tb;
        }
        public static void GetAllCoats(DataGridView gv)
        {
            var tb = from x in db.coats
                     orderby x.id descending
                     select x;
            gv.DataSource = tb;
        }
        public static void GetAllDress(DataGridView gv)
        {
            var tb = from x in db.dresses
                     orderby x.id descending
                     select x;
            gv.DataSource = tb;
        }

        public static void InsertCustomers(int id,String name, int phone, String address) {
            customer customer1 = new customer();
            customer1.id = id;
            customer1.name = name;
            customer1.phone = phone;
            customer1.address = address;
            db.SPcustomers(customer1.id, customer1.name, customer1.phone, customer1.address, 1);
            db.SubmitChanges();
        }

        public static void InsertCoats(double tall, double shoulder, double hand, double chest, double abdomen,string details,string date,int customer_id)
        {
            coat coats1 = new coat();
            coats1.tall = tall;
            coats1.shoulder = shoulder;
            coats1.hand = hand;
            coats1.chest = chest;
            coats1.abdomen = abdomen;
            coats1.details = details;
            coats1.date = date;
            coats1.customer_id = customer_id;

            db.SPcoats(0, coats1.tall, coats1.shoulder, coats1.hand,coats1.chest,coats1.abdomen,coats1.details,coats1.date, coats1.customer_id, 1);
            db.SubmitChanges();
        }
        public static void InsertDress(double tall, double shoulder, double hand1, double hand2, double hand3, double neck , double chest, double gbzor, double dwor, string details, string date, int customer_id)
        {
            dress dress1 = new dress();
            dress1.tall = tall;
            dress1.shoulder = shoulder;
            dress1.hand1 = hand1;
            dress1.hand2 = hand2;
            dress1.hand3 = hand3;
            dress1.neck = neck;
            dress1.chest = chest;
            dress1.gbzor = gbzor;
            dress1.dwor = dwor;
            dress1.details = details;
            dress1.date = date;
            dress1.customer_id = customer_id;

            db.SPdress(0, dress1.tall, dress1.shoulder, dress1.hand1, dress1.hand2, dress1.hand3, dress1.neck, dress1.chest, dress1.gbzor, dress1.dwor, dress1.details, dress1.date, dress1.customer_id, 1);
            db.SubmitChanges();
        }
        public static void UpdateDress(int id, double tall, double shoulder, double hand1, double hand2, double hand3, double neck, double chest, double gbzor, double dwor, string details, string date, int customer_id)
        {
            dress dress1 = new dress();
            dress1.id = id;
            dress1.tall = tall;
            dress1.shoulder = shoulder;
            dress1.hand1 = hand1;
            dress1.hand2 = hand2;
            dress1.hand3 = hand3;
            dress1.neck = neck;
            dress1.chest = chest;
            dress1.gbzor = gbzor;
            dress1.dwor = dwor;
            dress1.details = details;
            dress1.date = date;
            dress1.customer_id = customer_id;

            db.SPdress(dress1.id = id, dress1.tall, dress1.shoulder, dress1.hand1, dress1.hand2, dress1.hand3, dress1.neck, dress1.chest, dress1.gbzor, dress1.dwor, dress1.details, dress1.date, dress1.customer_id, 2);
            db.SubmitChanges();
        }
        public static void UpdateCoats(int id, double tall, double shoulder, double hand, double chest, double abdomen, string details, string date, int customer_id)
        {
            coat coats1 = new coat();
            coats1.id = id;
            coats1.tall = tall;
            coats1.shoulder = shoulder;
            coats1.hand = hand;
            coats1.chest = chest;
            coats1.abdomen = abdomen;
            coats1.details = details;
            coats1.date = date;
            coats1.customer_id = customer_id;

            db.SPcoats(coats1.id, coats1.tall, coats1.shoulder, coats1.hand, coats1.chest, coats1.abdomen, coats1.details, coats1.date, coats1.customer_id, 2);
            db.SubmitChanges();
        }
        public static bool login(String username, String password)
        {
            var log = from x in db.users where x.username == username && x.password == password select x;
            if (log.Any())
            {
                ran = true;
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void DeleteCustomer (int id)
        {
            customer customer1 = new customer();
            customer1.id = id;
            customer1.name = "";
            customer1.phone = 0;
            customer1.address = "";
            db.SPcustomers(customer1.id, customer1.name, customer1.phone, customer1.address,3);
            db.SubmitChanges();

        }

        public static void DeleteCoats(int id)
        {
            coat coats1 = new coat();
            coats1.id = id;
            coats1.tall = 0;
            coats1.shoulder = 0;
            coats1.hand = 0;
            coats1.chest = 0;
            coats1.abdomen = 0;
            coats1.details = "";
            coats1.date = "";
            coats1.customer_id = 0;

            db.SPcoats(coats1.id, coats1.tall, coats1.shoulder, coats1.hand, coats1.chest, coats1.abdomen, coats1.details, coats1.date, coats1.customer_id, 3);
            db.SubmitChanges();
        }
        public static void DeleteDress(int id)
        {
            dress dress1 = new dress();
            dress1.id = id;
            dress1.tall = 0;
            dress1.shoulder = 0;
            dress1.hand1 = 0;
            dress1.hand2 = 0;
            dress1.hand3 = 0;
            dress1.neck = 0;
            dress1.chest = 0;
            dress1.gbzor = 0;
            dress1.dwor = 0;
            dress1.details = "";
            dress1.date = "";
            dress1.customer_id = 0;

            db.SPdress(dress1.id , dress1.tall, dress1.shoulder, dress1.hand1, dress1.hand2, dress1.hand3, dress1.neck, dress1.chest, dress1.gbzor, dress1.dwor, dress1.details, dress1.date, dress1.customer_id, 3);
            db.SubmitChanges();
        }
        public static void UpdateCustomers(int id,String name, int phone, String address)
        {
            customer customer1 = new customer();
            customer1.id = id;
            customer1.name = name;
            customer1.phone = phone;
            customer1.address = address;
            db.SPcustomers(customer1.id, customer1.name, customer1.phone, customer1.address, 2);
            db.SubmitChanges();
        }

        public static void SearchByCustomerName(DataGridView gv,String name)
        {
            var tb = from x in db.customers where
                     SqlMethods.Like(x.name,"%"+name+"%") orderby x.name descending select x;
            gv.DataSource = tb;
        }

        public static void SearchByCustomerID(DataGridView gv, int id)
        {
            var tb = from x in db.customers
                     where
            SqlMethods.Like(x.id.ToString(), "%" +id+ "%")
                     select x;
            gv.DataSource = tb;
        }

        public static void SearchCoatsByCustomerID(DataGridView gv, int id)
        {
            var tb = from x in db.coats
                     where
            SqlMethods.Like(x.customer_id.ToString(), "%" + id + "%")
                     select x;
            gv.DataSource = tb;
        }

        public static void SearchDressByCustomerID(DataGridView gv, int id)
        {
            var tb = from x in db.dresses
                     where
            SqlMethods.Like(x.customer_id.ToString(), "%" + id + "%")
                     select x;
            gv.DataSource = tb;
        }

        public static void SearchByBillID(DataGridView gv, String name)
        {
            var tb = from x in db.customers
                     join z in db.dresses on x.id equals z.customer_id
                     where SqlMethods.Like(x.name, "%" + name + "%")
                     orderby z.id descending
                     select new { x.name, z.id,z.customer_id, z.tall, z.shoulder, z.hand1, z.hand2, z.hand3, z.neck, z.chest, z.gbzor, z.dwor, z.details, z.date };
            gv.DataSource = tb;

        }
        public static void SearchByBillID22(DataGridView gv, String name)
        {
            var tb = from x in db.customers
                     join z in db.coats on x.id equals z.customer_id
                     where SqlMethods.Like(x.name, "%" + name + "%")
                     orderby z.id descending
                     select new { x.name, z.id, z.customer_id, z.tall, z.shoulder, z.hand, z.chest, z.abdomen, z.details, z.date };
            gv.DataSource = tb;

        }

    }
}
