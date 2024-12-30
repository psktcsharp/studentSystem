using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityRegistration.Core.Entities
{
    public class College
    {
        public Guid Id { get; }
        public string Name { get; private set; }
        public List<Rule> Rules { get; private set; } = new List<Rule>();


        public College(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
        public void UpdateInfo(string name)
        {
            Name = name;
        }

        public void AddRule(Rule rule)
        {
            Rules.Add(rule);
        }

        public void RemoveRule(Rule rule)
        {
            Rules.Remove(rule);
        }
    }
}
