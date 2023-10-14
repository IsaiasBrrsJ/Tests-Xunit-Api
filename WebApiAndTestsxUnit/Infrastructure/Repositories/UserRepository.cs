using Microsoft.AspNetCore.Mvc;
using WebApiAndTestsxUnit.Domain.Model.User;

namespace WebApiAndTestsxUnit.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository<User>
    {
        private readonly DataContext _contenxt;
        public UserRepository([FromServices] DataContext context)
        {

            _contenxt = context;

        }
        public bool Add(User User)
        {
            _contenxt.Add(User);

            _contenxt.SaveChanges();

            return true;
        }

        public bool Delete(int Id)
        {
            _contenxt.Remove(_contenxt.Users.Find(Id));

            _contenxt.SaveChanges();

            return true;
        }

        public User Get(int Id)
        {
            return _contenxt.Users.Find(Id);
        }

        public IEnumerable<User> GetAll()
        {
            return _contenxt.Users.ToList();
        }

        public bool Update(User User)
        {
            _contenxt.Entry(User).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            _contenxt.SaveChanges();

            return true;
        }
    }
}
