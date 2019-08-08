using System;

namespace UserRegistration.Data.Entities
{
    public class User
    {
        public User(string name, DateTime birthDate, string gender)
        {
            Name = name;
            BirthDate = birthDate;
            Gender = gender;
            Active = true;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public bool Active { get; set; }
    }
}
