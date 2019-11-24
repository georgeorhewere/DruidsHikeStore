using System;
using System.Collections.Generic;
using System.Text;

namespace StoreDB.ViewModels
{
    public class AddUserViewModel
    {
        private string firstName;
        private string lastName;
        private string email;
        private string address;
        private string city;
        private string country;
        private string password;
        private string confirmPassword;
        private int role;

        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Address { get => address; set => address = value; }
        public string City { get => city; set => city = value; }
        public string Country { get => country; set => country = value; }
        public string Password { get => password; set => password = value; }
        public string ConfirmPassword { get => confirmPassword; set => confirmPassword = value; }
        public int Role { get => role; set => role = value; }
        public string Email { get => email; set => email = value; }
    }
}
