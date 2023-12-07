using Core.Domains;
using Core.Repositories;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class PatientRepository: UserRepository, IPatientRepository
    {
        private readonly UserManager<User> usermanger;

        public PatientRepository(UserManager<User> usermanger) : base(usermanger)
        {
            this.usermanger = usermanger;
        }
    }
}
