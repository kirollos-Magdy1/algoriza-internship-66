using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class RegisterPatientDto: RegisterDTO
    {
        
        public string Image { get; set; }
        

    }
}
