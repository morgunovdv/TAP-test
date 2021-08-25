using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TAP_test.Models
{
    [Keyless]
    public class Skill
    {
        public string Name { get; set; }
        public byte Level { get; set; } //добавить ограничение по уровню 1 - 10
    }
}
