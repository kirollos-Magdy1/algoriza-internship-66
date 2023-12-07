using Core.Domains;
using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IUserRepository
    {
        Task<IList<User>> FindAllAsync(Role role, int? pageSize, int? skip, int? take,
          Expression<Func<User, object>> orderBy = null, string orderByDirection = OrderBy.Ascending);

        Task<User> GetByIdAsync(string id, Role role);
    }
}
