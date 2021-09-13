using System;
using System.ComponentModel.DataAnnotations;

namespace TAP_test.Models
{
    public class Skill
    { 
        public long Id { get; set; }

        public string Name { get; set; }
        [Range(1,10)]
        public byte Level { get; set; }

        public long PersonId { get; set; }
    }

    
}