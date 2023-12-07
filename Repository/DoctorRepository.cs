using Core.Domains;
using Core.Enums;
using Core.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class DoctorRepository : UserRepository, IDoctorRepository
    {
        private readonly UserManager<User> usermanger;

        public DoctorRepository(UserManager<User> usermanger): base(usermanger)
        {
            this.usermanger = usermanger;
            
        }

        public async Task<IdentityResult> UpdateAsync(User doctor)
        {
            var existingDoctor = await usermanger.FindByIdAsync(doctor.Id.ToString());

            if (existingDoctor == null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "Doctor not found." });
            }

            existingDoctor.FirstName = doctor.FirstName;
            existingDoctor.LastName = doctor.LastName;
            existingDoctor.Phone = doctor.Phone;
            existingDoctor.DateOfBirth = doctor.DateOfBirth;
            existingDoctor.Email = doctor.Email;
            existingDoctor.Image = doctor.Image;

            var result = await usermanger.UpdateAsync(existingDoctor);

            return result;

        }

        public async Task<User> DeleteAsync(string Id)
        {
            var existingUser = await usermanger.FindByIdAsync(Id.ToString());

            if (existingUser == null)
            {
                return null;
            }

            var result = await usermanger.DeleteAsync(existingUser);

            if (result.Succeeded)
            {
                return existingUser;
            }
            else
            {
                return null;
            }
        }


    }
}
