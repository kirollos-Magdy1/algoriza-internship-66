using Core.Domains;
using Core.IRepositories;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public class CouponRepository: BaseRepository<Coupon>, ICouponRepository
    {
        public CouponRepository(ApplicationDbContext context): base(context)
        {
        }
    }
}
