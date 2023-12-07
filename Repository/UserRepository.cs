using Core;
using Core.Domains;
using Core.Enums;
using Core.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<User> usermanger;

        public UserRepository(UserManager<User> usermanger)
        {
            this.usermanger = usermanger;
        }

        public async Task<IList<User>> FindAllAsync(Role role, int? pageSize, int? skip, int? take, Expression<Func<User, object>> orderBy = null, string orderByDirection = "ASC")
        {
            IList<User> usersInRole = await usermanger.GetUsersInRoleAsync(role.ToString());

            if (orderBy != null)
            {
                usersInRole = orderByDirection == "ASC"
                    ? usersInRole.OrderBy(orderBy.Compile()).ToList()
                    : usersInRole.OrderByDescending(orderBy.Compile()).ToList();
            }

            if (skip.HasValue)
                usersInRole = usersInRole.Skip(skip.Value).ToList();

            if (take.HasValue)
                usersInRole = usersInRole.Take(take.Value).ToList();

            return usersInRole;
        }


        public async Task< User> GetByIdAsync(string id, Role role)
        {
            var usersInRole = await usermanger.GetUsersInRoleAsync(role.ToString());
            var user = usersInRole.Where(u => u.Id == id).FirstOrDefault();
            return user;
        }




        //public async Task<User> GetByIdAsync(string id, Role role)
        //{
        //    var usersInRole = await usermanger.GetUsersInRoleAsync(role.ToString());
        //    var user = usersInRole.Where(u => u.Id == id) ;
        //    return  
        //}
    }
}
