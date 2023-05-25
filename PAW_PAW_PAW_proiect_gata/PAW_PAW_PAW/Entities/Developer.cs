using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAW_PAW_PAW.Classes
{
    [Serializable]
    public class Developer
    {
        private static int nextDeveloperId = 1;
        public int DeveloperId { get; set; }
        public string Name { get; set; }
        public List<Issue> AssignedIssues { get; set; }

        public Developer()
        {
            AssignedIssues = new List<Issue>();
        }

        public Developer(string name, List<Issue> assignedIssues)
        {
            DeveloperId = GenerateUniqueDeveloperId();
            Name = name;
            AssignedIssues = assignedIssues;
        }

        private static int GenerateUniqueDeveloperId()
        {
            int developerId = nextDeveloperId;
            nextDeveloperId++;
            return developerId;
        }
    }
}
