using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesktopContactsApp.Classes
{
    public class Contact
    {
        // STATE
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        // PUBLIC
        public override string ToString()
        {
            return $"{Name} - {Email} - {PhoneNumber}";
        }
    }
}
