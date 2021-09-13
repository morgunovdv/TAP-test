using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TAP_test.Models;

namespace TAP_test
{
    public class SkillComparer : IEqualityComparer<Skill>
    {
        public bool Equals(Skill one, Skill two)
        {
            return StringComparer.InvariantCultureIgnoreCase.Equals(one.Name, two.Name);

        }

        public int GetHashCode(Skill item)
        {
            return StringComparer.InvariantCultureIgnoreCase.GetHashCode(item.Name);

        }
    }
}
