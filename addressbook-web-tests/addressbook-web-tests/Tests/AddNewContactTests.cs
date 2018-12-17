using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using NUnit.Framework;
namespace addressbook_web_tests
{
    /// <summary>
    /// Summary description for AddNewContactTests
    /// </summary>
    [TestFixture]
    public class AddNewContactTests: ContactTestBase
    {

        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contacts = new List<ContactData>();

            for (var i = 0; i < 5; i++)
            {
                contacts.Add(new ContactData(GenerateRandomString(30), GenerateRandomString(30))
                {
                    Middlename = GenerateRandomString(100),
                    Address = GenerateRandomString(100),
                    Nickname = GenerateRandomString(100),
                    Email = GenerateRandomString(100),
                    Title = GenerateRandomString(100),
                    Company = GenerateRandomString(100),
                    Hometelephone = GenerateRandomString(100),
                    Mobiletelephone = GenerateRandomString(100)
                });
            }

            return contacts;
        }

        public static IEnumerable<ContactData> GetContactDataFromJson()
        {
            return JsonConvert.DeserializeObject<List<ContactData>>(File.ReadAllText("Data\\contacts.json"));
        }

        [Test, TestCaseSource("GetContactDataFromJson")]
        public void AddNewContactTest(ContactData contact)
        {

            var oldContacts = ContactData.GetAll();
            app.Contacts.Create(contact);
            Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactCount());
            var currentContacts = ContactData.GetAll();
            oldContacts.Add(contact);
            oldContacts.Sort();
            currentContacts.Sort();
            Assert.AreEqual(oldContacts, currentContacts);
        }


    }
}
