using Core.Domains;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IDoctorRepository: IUserRepository
    {

        Task<IdentityResult> UpdateAsync(User user);
        Task<User> DeleteAsync(string Id);

    }
}
