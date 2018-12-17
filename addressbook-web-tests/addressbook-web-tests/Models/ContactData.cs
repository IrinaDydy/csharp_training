using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using LinqToDB.Mapping;

namespace addressbook_web_tests
{
    [Table(Name = "addressbook")]
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string allEmails;
        private string allDetails;
        public bool Equals(ContactData other)
        {
            if (object.ReferenceEquals(other, null)) return false;
            if (object.ReferenceEquals(this, other)) return true;
            return Firstname == other.Firstname&&Lastname==other.Lastname;
        }

        public override int GetHashCode()
        {
            return (Firstname+" "+ Lastname).GetHashCode();
        }

        public override string ToString()
        {
            return Firstname + " " + Lastname;
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null)) return 1;
            return (Firstname+Lastname).CompareTo(other.Firstname + other.Lastname);
        }

        public ContactData(string firstname, string lastname)
        {
            this.Firstname = firstname;
            this.Lastname = lastname;

        }

        public ContactData()
        {


        }
        [Column(Name = "firstname")]
        public string Firstname { get; set; }
        [Column(Name = "lastname")]
        public string Lastname { get; set; }
        [Column(Name = "middlename")]
        public string Middlename { get; set; } = "";
        [Column(Name = "address")]
        public string Address { get; set; } = "";
        [Column(Name = "title")]
        public string Title { get; set; } = "";
        [Column(Name = "company")]
        public string Company { get; set; } = "";
        [Column(Name = "home")]
        public string Hometelephone { get; set; } = "";
        [Column(Name = "mobile")]
        public string Mobiletelephone { get; set; } = "";
       
        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else return (CleanUp(Hometelephone) + CleanUp(Mobiletelephone) + CleanUp(Worktelephone)+CleanUp(Phone2)).Trim();
                
            }
            set
            {
                allPhones = value;
                
            }
        }
        [Column(Name = "work")]
        public string Worktelephone { get; set; } = "";
        [Column(Name = "fax")]
        public string Fax { get; set; } = "";
        [Column(Name = "email")]
        public string Email { get; set; } = "";
        [Column(Name = "email2")]
        public string Email2 { get; set; } = "";
        [Column(Name = "email3")]
        public string Email3 { get; set; } = "";

        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                return (CleanUp(Email) + CleanUp(Email2) + CleanUp(Email3)).Trim();

            }
            set { allEmails = value; }
        }
        [Column(Name = "homepage")]
        public string Homepage { get; set; } = "";
        [Column(Name = "bday")]
        public string Bday { get; set; } = "1";
        [Column(Name = "bmonth")]
        public string Bmonth { get; set; } = "February";
        [Column(Name = "byear")]
        public string Byear { get; set; } = "1970";
        [Column(Name = "aday")]
        public string Aday { get; set; } = "1";
        [Column(Name = "amonth")]
        public string Amonth { get; set; } = "February";
        [Column(Name = "ayear")]
        public string Ayear { get; set; } = "1970";
        [Column(Name = "address2")]
        public string Address2 { get; set; } = "";
        [Column(Name = "phone2")]
        public string Phone2 { get; set; } = "";
        [Column(Name = "notes")]
        public string Notes { get; set; } = "";
        [Column(Name = "nickname")]
        public string Nickname { get; set; } = "";

        [Column(Name = "deprecated")]
        public string Deprecated { get; set; } = "";

        [Column(Name = "id"), PrimaryKey, Identity]
        public string Id { get; set; }


        public string AllDetails
        {
            get
            {
                if (allDetails != null)
                {
                    return allPhones;
                }
                else
                {
                    //return (CleanUp(Hometelephone) + CleanUp(Mobiletelephone) + CleanUp(Worktelephone) + CleanUp(Phone2)).Trim();
                    string allData = "";
                    if (Firstname != "") allData = allData + Firstname;
                    if (Middlename != "") allData = allData + $" {Middlename}";
                    if (Lastname != "") allData = allData + $" {Lastname}";
                    if (Nickname!= "") allData = allData + $"\r\n{Nickname}";
                    if (Title != "") allData = allData + $"\r\n{Title}";
                    if (Company != "") allData = allData + $"\r\n{Company}";
                    if (Address != "") allData = allData + $"\r\n{Address}";
                    if (Hometelephone != "") allData = allData + $"\r\nH: {Hometelephone}";
                    if (Mobiletelephone != "") allData = allData + $"\r\nM: {Mobiletelephone}";
                    if (Worktelephone != "") allData = allData + $"\r\nW: {Worktelephone}";
                    if (Fax != "") allData = allData + $"\r\nF: {Fax}";
                    if (Email != "") allData = allData + $"\r\n{Email}";
                    if (Email2 != "") allData = allData + $"\r\n{Email2}";
                    if (Email3 != "") allData = allData + $"\r\n{Email3}";
                    if (Homepage != "") allData = allData + $"\r\nHomepage:\r\n{Homepage}";
                    if (Bday != "" || Bmonth != "" || Byear != "")
                    {
                        allData = allData + "\r\nBirthday";
                        if (Bday != "-") allData = allData + $" {Bday}.";
                        if (Bmonth != "-") allData = allData + $" {Bmonth}";
                        if (Byear!= "") allData= allData+ $" {Byear} ({DateTime.Now.Year - Convert.ToInt32(Byear)})";
                    }

                    if (Aday != "" || Amonth != "" || Ayear != "")
                    {
                        allData = allData + "\r\nAnniversary";
                        if (Aday != "-") allData = allData + $" {Aday}.";
                        if (Amonth != "-") allData = allData + $" {Amonth}";
                        if (Ayear != "") allData = allData + $" {Ayear} ({DateTime.Now.Year - Convert.ToInt32(Ayear)})";
                    }
                    if (Address2 != "") allData = allData + $"\r\n{Address2}";
                    if (Phone2 != "") allData = allData + $"\r\nP: {Phone2}";
                    if (Notes != "") allData = allData + $"\r\n{Notes}";

                    return allData.Trim('\r').Trim('\n');
                }

            }
            set
            {
                allDetails = value;

            }
        }

        private string CleanUp(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return "";
            }
            else
            {
                return Regex.Replace(value, "[ -()]", "")+"\r\n";
                    //(value.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "") +"\r\n");
            }
        }

        public static List<ContactData> GetAll()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from c in db.Contacts select c).ToList().FindAll
                    (cont=>cont.Deprecated== "01.01.0001 0:00:00");
            }

        }
    }
}
