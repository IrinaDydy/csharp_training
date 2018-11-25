﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_web_tests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
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
        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Middlename { get; set; } = "";

        public string Address { get; set; } = "";

        public string Title { get; set; } = "";

        public string Company { get; set; } = "";

        public string Hometelephone { get; set; } = "";

        public string Mobiletelephone { get; set; } = "";

        public string Worktelephone { get; set; } = "";

        public string Fax { get; set; } = "";

        public string Email { get; set; } = "";

        public string Email2 { get; set; } = "";

        public string Email3 { get; set; } = "";

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

    }
}
