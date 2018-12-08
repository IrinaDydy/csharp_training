using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using Newtonsoft.Json;
using addressbook_web_tests;

namespace addressbook_test_data_generator
{
    static class Program
    {
        static void Main(string[] args)
        {
            foreach (var arg in args)
            {
                Console.WriteLine(arg);
            }

            string type = args[0].ToString();
            int count = Convert.ToInt32(args[1]);
            StreamWriter sw = new StreamWriter(args[2]);
            string format = args[3];
            if (type == "group")
            {
                List<GroupData> groups = new List<GroupData>();
                for (int i = 0; i < count; i++)
                {
                    groups.Add(new GroupData(TestBase.GenerateRandomString(10))
                    {
                        Footer = TestBase.GenerateRandomString(10),
                        Header = TestBase.GenerateRandomString(10)

                    });
                }
                if (format == "csv")
                {
                    writeGroupsToCSV(groups, sw);
                }
                else if (format == "xml")
                {
                    writeGroupsToXML(groups, sw);
                }
                else if (format == "json")
                {
                    writeGroupsToJSON(groups, sw);
                }
                else
                {
                    Console.WriteLine("Unrecognized format: " + format);
                }
            }
            else
            {
                if (type == "contact")
                {
                    List<ContactData> contacts = new List<ContactData>();
                    for (int i = 0; i < count; i++)
                    {
                        contacts.Add(new ContactData(TestBase.GenerateRandomString(30), TestBase.GenerateRandomString(30))
                        {
                            Middlename = TestBase.GenerateRandomString(100),
                            Address = TestBase.GenerateRandomString(100),
                            Nickname = TestBase.GenerateRandomString(100),
                            Email = TestBase.GenerateRandomString(100),
                            Title = TestBase.GenerateRandomString(100),
                            Company = TestBase.GenerateRandomString(100),
                            Hometelephone = TestBase.GenerateRandomString(100),
                            Mobiletelephone = TestBase.GenerateRandomString(100)
                        });
                    }
                    if (format == "csv")
                    {
                        writeContactsToCSV(contacts, sw);
                    }
                    else if (format == "xml")
                    {
                        writeContactsToXML(contacts, sw);
                    }
                    else if (format == "json")
                    {
                        writeContactsToJSON(contacts, sw);
                    }
                    else
                    {
                        Console.WriteLine("Unrecognized format: " + format);
                    }
                }
            }
            sw.Close();
        }

        static void writeGroupsToCSV(List<GroupData> groups, StreamWriter sw)
        {
            foreach (var group in groups)
            {
           
                sw.WriteLine($"{group.Name},{group.Header},{group.Footer}");
            }
        }

        static void writeGroupsToXML(List<GroupData> groups, StreamWriter sw)
        {
            new XmlSerializer(typeof (List<GroupData>)).Serialize(sw, groups);
        }


        static void writeGroupsToJSON(List<GroupData> groups, StreamWriter sw)
        {
            
            sw.Write(JsonConvert.SerializeObject(groups,Formatting.Indented));
        }

        static void writeContactsToCSV(List<ContactData> contacts, StreamWriter sw)
        {
            foreach (var contact in contacts)
            {

                sw.WriteLine($"{contact.Firstname},{contact.Lastname},{contact.Middlename}," +
                             $"{contact.Address},{contact.Nickname},{contact.Email},{contact.Title}," +
                             $"{contact.Company},{contact.Hometelephone},{contact.Mobiletelephone}");

            }
        }

        static void writeContactsToXML(List<ContactData> contacts, StreamWriter sw)
        {
            new XmlSerializer(typeof(List<ContactData>)).Serialize(sw, contacts);
        }


        static void writeContactsToJSON(List<ContactData> contacts, StreamWriter sw)
        {

            sw.Write(JsonConvert.SerializeObject(contacts, Formatting.Indented));
        }

    }
}
