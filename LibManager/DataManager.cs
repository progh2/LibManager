using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace LibManager
{
    class DataManager
    {
        public static List<Book> Books = new List<Book>();
        public static List<User> Users = new List<User>();

        static DataManager()
        {
            Load();
        }

        private static void Load()
        {
            try
            {
                string bookOutput = File.ReadAllText(@"./Books.xml");
                XElement booksXElement = XElement.Parse(bookOutput);
                Books = (from item in booksXElement.Descendants("book")
                         select new Book()
                         {
                             Isbn = item.Element("isbn").Value,
                             Name = item.Element("isbn").Value,
                             Publisher = item.Element("isbn").Value,
                             Page = int.Parse(item.Element("isbn").Value),
                             BorrowedAt = DateTime.Parse(item.Element("borrowedAt").Value),
                             isBorrowed = item.Element("isBorrowed").Value != "0" ? true : false,
                             UserId = int.Parse(item.Element("userId").Value),
                             UserName = item.Element("userName").Value,
                         }).ToList<Book>();
                string userOutput = File.ReadAllText(@"./Users.xml");
                XElement usersXELement = XElement.Parse(userOutput);
                Users = (from item in usersXELement.Descendants("user")
                         select new User()
                         {
                             Id = int.Parse(item.Element("id").Value),
                             Name = item.Element("name").Value
                         }).ToList<User>();
            }
            catch (FileNotFoundException exception)
            {
                save();
            }
        }

        private static void save()
        {
            string booksOutput = "";
            booksOutput += "<books>\n";
            foreach(var item in Books)
            {
                booksOutput += "<book>\n";
                booksOutput += "\t<isbn>" + item.Isbn + "</isbn>\n";
                booksOutput += "\t<name>" + item.Name + "</name>\n";
                booksOutput += "\t<publisher>" + item.Publisher + "</publisher>\n";
                booksOutput += "\t<page>" + item.Page + "</page>\n";
                booksOutput += "\t<borrowedAt>" + item.BorrowedAt.ToLongDateString() + "</borrowedAt>\n";
                booksOutput += "\t<isBorrowed>" + (item.isBorrowed ? 1 : 0) + "</isBorrowed>\n";
                booksOutput += "\t<userId>" + item.UserId + "</userId>\n";
                booksOutput += "\t<userName>" + item.UserName + "</userName>\n";
                booksOutput += "</book>\n";
            }
            booksOutput += "</books>\n";

            string usersOutput = "";
            usersOutput += "<users>\n";
            foreach(var item in Users)
            {
                usersOutput += "<user>\n";
                usersOutput += "\t<id>" + item.Id + "</id>\n";
                usersOutput += "\t<name>" + item.Name + "</name>\n";
                usersOutput += "</user>\n";
            }
            usersOutput += "</users>\n";

            File.WriteAllText(@"./Books.xml", booksOutput);
            File.WriteAllText(@"./Users.xml", usersOutput);
        }
    }
}
