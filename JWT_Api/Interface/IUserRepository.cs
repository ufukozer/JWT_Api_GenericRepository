using JWT_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWT_Api.Interface
{
    public interface IUserRepository : IRepository<User>
    {
    }
}
