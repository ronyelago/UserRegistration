using UserRegistration.Domain.Entities;
using UserRegistration.Repository;

namespace UserRegistration.Service
{
    public class UserService
    {
        private readonly UserRepository userRepository;

        public UserService() => userRepository = new UserRepository();

        public User New(User user)
        {
            userRepository.Add(user);
            userRepository.SaveChanges();

            return user;
        }
    }
}
