using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace ProjectLib.Object
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ProjectLibDbContext _dbContext;

        public AccountRepository(ProjectLibDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public User AddUser(User user){
           if (user !=null)
           {
               _dbContext.Users.Add(user);
               _dbContext.SaveChanges();
               return user;
           }
           return null;
        }
        public User GetUserByID(int id){
            return _dbContext.Users.SingleOrDefault(u=>u.UserID == id);
        }
    }
}