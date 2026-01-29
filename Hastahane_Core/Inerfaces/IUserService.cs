using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hastahane_Core.Inerfaces
{
    public class IUserService
    {
        User Login(string email, string sifre);
        void Register(User user);
    }
}
