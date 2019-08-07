using System;

namespace UserRegistration.Api.ViewModels
{
    public class UserViewModel
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
    }
}
