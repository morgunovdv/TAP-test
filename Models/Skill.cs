using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TAP_test.Models
{
    [NotMapped]
    [Keyless]
    public class Skill
    {
        public string Name { get; set; }
        public byte Level { get; set; } //написать ограничения по левелу 1-10
    }
}
