using Flunt.Notifications;
using Flunt.Validations;
using InnerJungle.Domain.Enums;

namespace InnerJungle.Domain.Entities
{
    public class User : Entity
    {
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public RoleNames Role { get; private set; }
        public string Cpf { get; private set; }
        public IEnumerable<Research> Researches { get; private set; } 

        public User(string firstName, string lastName, string email, string password)
        {
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        public void SetEmployeeRole(RoleNames role)
        {
            switch (role)
            {
                case RoleNames.Manager:
                    this.Role = RoleNames.Manager;
                    break;
                default:
                    this.Role = RoleNames.Employee;
                    break;
            }
        }

        public void SetEmployeeCpf(string cpf)
        {
            this.Cpf = cpf;
        }

        public void SetUserName(string userName)
        {
            this.UserName = userName;
        }

        public void SetPassword(string password)
        {
            this.Password = password;
        }

        public void Validate(string userName, string password, RoleNames role, string cpf)
        {
            AddNotifications(new Contract<Notification>()
               .IsNotNullOrEmpty(userName, "invalid_userName", "Invalid userName")
               .IsGreaterThan(userName.Length, 2, "invalid_size_userName", "Invalid size userName")
               .IsNotNullOrEmpty(password, "invalid_password", "Invalid password")
               .IsGreaterThan(password.Length, 8, "invalid_size_password", "Invalid size password")
               .IsNotNull(role, "invalid_role", "Invalid role")
               .IsNotNullOrEmpty(cpf, "invalid_cpf", "Invalid cpf")
               .IsGreaterOrEqualsThan(cpf.Length, 11, "invalid_size_cpf", "Invalid size cpf"));
        }
    }
}
