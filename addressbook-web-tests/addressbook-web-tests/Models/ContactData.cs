using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace addressbook_web_tests
{
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

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Middlename { get; set; } = "";

        public string Address { get; set; } = "";

        public string Title { get; set; } = "";

        public string Company { get; set; } = "";

        public string Hometelephone { get; set; } = "";

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

        public string Worktelephone { get; set; } = "";

        public string Fax { get; set; } = "";

        public string Email { get; set; } = "";

        public string Email2 { get; set; } = "";

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

        public string Homepage { get; set; } = "";

        public string Bday { get; set; } = "1";

        public string Bmonth { get; set; } = "February";

        public string Byear { get; set; } = "1970";

        public string Aday { get; set; } = "1";

        public string Amonth { get; set; } = "February";

        public string Ayear { get; set; } = "1970";

        public string Address2 { get; set; } = "";

        public string Phone2 { get; set; } = "";

        public string Notes { get; set; } = "";

        public string Nickname { get; set; } = "";

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
    }
}
