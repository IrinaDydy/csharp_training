using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_web_tests
{
    public class ContactData
    {
        private string firstname;
        private string lastname;
        private string middlename = "";
        private string nickname = "";
        private string title = "";
        private string company = "";
        private string address = "";
        private string hometelephone = "";
        private string mobiletelephone = "";
        private string worktelephone = "";
        private string fax = "";
        private string email = "";
        private string email2 = "";
        private string email3 = "";
        private string homepage = "";
        private string bday = "1";
        private string bmonth = "February";
        private string byear = "1970";
        private string aday = "1";
        private string amonth = "February";
        private string ayear = "1970";
        private string address2 = "";
        private string phone2 = "";
        private string notes = "";



        public ContactData(string firstname, string lastname)
        {
            this.firstname = firstname;
            this.lastname = lastname;

        }
        public string Firstname
        {
            get { return firstname; }
            set { firstname = value; }
        }
        public string Lastname
        {
            get { return lastname; }
            set { lastname = value; }
        }

        public string Middlename
        {
            get { return middlename; }
            set { middlename = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Company
        {
            get { return company; }
            set { company = value; }
        }

        public string Hometelephone
        {
            get { return hometelephone; }
            set { hometelephone = value; }
        }

        public string Mobiletelephone
        {
            get { return mobiletelephone; }
            set { mobiletelephone = value; }
        }

        public string Worktelephone
        {
            get { return worktelephone; }
            set { worktelephone = value; }
        }

        public string Fax
        {
            get { return fax; }
            set { fax = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Email2
        {
            get { return email2; }
            set { email2 = value; }
        }

        public string Email3
        {
            get { return email3; }
            set { email3 = value; }
        }

        public string Homepage
        {
            get { return homepage; }
            set { homepage = value; }
        }

        public string Bday
        {
            get { return bday; }
            set { bday = value; }
        }

        public string Bmonth
        {
            get { return bmonth; }
            set { bmonth = value; }
        }

        public string Byear
        {
            get { return byear; }
            set { byear = value; }
        }

        public string Aday
        {
            get { return aday; }
            set { aday = value; }
        }

        public string Amonth
        {
            get { return amonth; }
            set { amonth = value; }
        }

        public string Ayear
        {
            get { return ayear; }
            set { ayear = value; }
        }

        public string Address2
        {
            get { return address2; }
            set { address2 = value; }
        }

        public string Phone2
        {
            get { return phone2; }
            set { phone2 = value; }
        }

        public string Notes
        {
            get { return notes; }
            set { notes = value; }
        }

        public string Nickname
        {
            get { return nickname; }
            set { nickname = value; }
        }

    }
}
