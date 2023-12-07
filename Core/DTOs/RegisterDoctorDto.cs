using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class RegisterDoctorDto : RegisterDTO
    {

        [Required]
        public string Image { get; set; }

        [Required]
        public int SpecializationId { get; set; }


    }
}
