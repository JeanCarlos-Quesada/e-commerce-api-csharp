using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace e_commerce_api_csharp.Models
{
    public class User
    {
        public User()
        {
            this.rols = new List<short>();
        }

        public User(string identification, string fistName, string lastName, string phoneOne, string phoneTwo, string email, DateTime registerDate, bool isActive, bool isEmployee, byte[] password)
        {
            this.identification = identification;
            this.fistName = fistName;
            this.lastName = lastName;
            this.phoneOne = phoneOne;
            this.phoneTwo = phoneTwo;
            this.email = email;
            this.registerDate = registerDate;
            this.isActive = isActive;
            this.isEmployee = isEmployee;
            this.password = password;
            this.rols = new List<short>();
        }

        public string identification { get; set; }
        public string fistName { get; set; }
        public string lastName { get; set; }
        public string phoneOne { get; set; }
        public string phoneTwo { get; set; }
        public string email { get; set; }
        public DateTime registerDate { get; set; }
        public bool isActive { get; set; }
        public bool isEmployee { get; set; }
        public byte[] password { get; set; }
        public List<short> rols { get; set; }
    }
}
