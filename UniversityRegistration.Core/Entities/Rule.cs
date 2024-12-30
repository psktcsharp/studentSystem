using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace UniversityRegistration.Core.Entities
{
    public class Rule
    {
        public Guid Id { get; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Rule(string name, string description)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
        }

        public void UpdateInfo(string name, string description)
        {
            Name = name;
            Description = description;
        }
   }

}
