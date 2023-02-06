using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public class StaticUserRepository : IUserRepository
    {
        private List<User> users = new List<User>()
        {
            new User()
            {
                Id = Guid.NewGuid(),
                FirstName = "Thomas",
                LastName = "Cat",
                Username = "tom",
                EmailAddress = "thomas@gmail.com",
                Password = "Password",
                Roles = new List<string>{ "reader" }
            },
            new User()
            {
                Id = Guid.NewGuid(),
                FirstName = "Jerry",
                LastName = "Mouse",
                Username = "jerry",
                EmailAddress = "jerry@gmail.com",
                Password = "Password",
                Roles = new List<string>{ "reader", "writer" }
            }
        };

        public async Task<User> AuthenticateAsync(string username, string password)
        {
            var user = users.Find(x => x.Username.Equals(username, StringComparison.InvariantCultureIgnoreCase) 
            && x.Password  == password);

            return user;
        }
    }
}
