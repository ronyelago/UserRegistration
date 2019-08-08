using System;
using UserRegistration.Data.Entities;

namespace UserRegistration.Service
{
    public class UserService
    {
        public bool IsValid(User user)
        {
            if (ValidName(user.Name) && ValidBirthDate(user.BirthDate) && ValidGender(user.Gender))
                return true;

            return false;
        }

        private bool ValidName(string name)
        {
            if (name.Length < 3 || name.Length > 100 || string.IsNullOrEmpty(name))
                return false;

            return true;
        }

        private bool ValidBirthDate(DateTime birthDate)
        {
            if (birthDate == default)
                return false;

            return true;
        }

        private bool ValidGender(string gender)
        {
            if (string.IsNullOrEmpty(gender) || gender.Length > 1)
                return false;

            return true;
        }
    }
}
