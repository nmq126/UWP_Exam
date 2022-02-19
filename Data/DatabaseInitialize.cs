using Exam.Entity;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Data
{
    class DatabaseInitialize
    {
        private static readonly SQLiteConnection cnn = new SQLiteConnection("uwpexam.db");
        public static bool CreateTables()
        {
            string sql = @"CREATE TABLE IF NOT EXISTS
                          Contact (Id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
                                    Name    VARCHAR(255),
                                    PhoneNumber    VARCHAR(255) UNIQUE
                                    );";
            using (var statement = cnn.Prepare(sql))
            {
                statement.Step();
            }
            return true;
        }
        public static bool InsertContact(Contact contact)
        {
            using (var stt = cnn.Prepare("INSERT INTO Contact(Name, PhoneNumber) VALUES (?, ?)"))
            {
                stt.Bind(1, contact.Name);
                stt.Bind(2, contact.PhoneNumber);
                stt.Step();
            }
            return true;
        }
        public static List<Contact> ShowListContact()
        {
            List<Contact> list = new List<Contact>();
            using (var stt = cnn.Prepare("select * from Contact"))
            {

                while (stt.Step() == SQLiteResult.ROW)
                {

                    Contact contact = new Contact()
                    {
                        Id = Convert.ToInt32(stt["Id"]),
                        Name = (string)stt["Name"],
                        PhoneNumber = (string)stt["PhoneNumber"]
                    };
                    
                    list.Add(contact);
                }
                return list;
            }
        }
    }
}
