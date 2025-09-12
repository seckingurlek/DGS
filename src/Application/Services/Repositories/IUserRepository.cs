using Core.Persistence.Repositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IUserRepository : IAsyncRepository<AppUser>, IRepository<AppUser>
{
}

