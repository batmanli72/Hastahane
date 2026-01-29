using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hastahane_Infrastructure.Data;

namespace Hastahane_Infrastructure.Services
{
     public class UserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public void Register(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public User Login(string email, string sifre)
        {
            return _context.Users
                .FirstOrDefault(x => x.Email == email && x.Sifre == sifre);
        }
    }
}
