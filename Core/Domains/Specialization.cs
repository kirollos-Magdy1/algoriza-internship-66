using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domains
{
    public class Specialization
    {
        public int Id { get; set; }
        public string Name{ get; set; }

        public string DoctorId { get; set; }


        [ForeignKey("DoctorId")]
        public User Doctor { get; set; }

    }
}
