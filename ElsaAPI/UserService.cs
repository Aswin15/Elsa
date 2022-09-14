using ElsaAPI.Context;
using ElsaAPI.Entities;

namespace ElsaAPI
{
    public class UserService
    {
        private readonly ElsaAPIDbContext _elsaAPIDbContext;

        public UserService(ElsaAPIDbContext elsaAPIDbContext)
        {
            _elsaAPIDbContext = elsaAPIDbContext;
        }

        public void CreateUser(User user)
        {
            _elsaAPIDbContext.Users.Add(user);
            _elsaAPIDbContext.SaveChanges();
        }
    }
}
