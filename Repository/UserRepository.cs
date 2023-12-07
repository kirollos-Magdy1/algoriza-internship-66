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
        private readonly ApplicationDbContext context;


        public UserRepository(UserManager<User> usermanger, ApplicationDbContext context)
        {
            this.usermanger = usermanger;
            this.context = context;
        }

        public async Task<IEnumerable<User>> FindAllAsync(Expression<Func<User, bool>> criteria,Role role, int? pageSize, int? skip, int? take, Expression<Func<User, object>> orderBy = null, string orderByDirection = "ASC")
        {
            IList<User> usersInRole = await usermanger.GetUsersInRoleAsync(role.ToString());

            IQueryable<User> query = usersInRole.AsQueryable().Where(criteria);

            if (skip.HasValue)
                query = query.Skip(skip.Value);

            if (take.HasValue)
                query = query.Take(take.Value);

            if (orderBy != null)
            {
                if (orderByDirection == OrderBy.Ascending)
                    query = query.OrderBy(orderBy);
                else
                    query = query.OrderByDescending(orderBy);
            }

            return await query.ToListAsync();
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
