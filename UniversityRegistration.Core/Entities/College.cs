using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityRegistration.Core.Interfaces;

namespace UniversityRegistration.Core.Entities
{
    public class College
    {
        public Guid Id { get; }
        public string Name { get; private set; }
        public List<IRule> Rules { get; private set; } = new List<IRule>();

        public College(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
        public void UpdateInfo(string name)
        {
            Name = name;
        }

        public void AddRule(IRule rule)
        {
            Rules.Add(rule);
        }

        public void RemoveRule(IRule rule)
        {
            Rules.Remove(rule);
        }
    }
}