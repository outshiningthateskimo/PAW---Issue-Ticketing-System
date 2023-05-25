using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAW_PAW_PAW.Classes
{
    [Serializable]
    public class Issue
    {
        private static int nextIssueId = 1;

        public int IssueId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public Developer AssignedDeveloper { get; set; }
        public Resolution IssueResolution { get; set; }

        public Issue()
        {
            CreatedDate = DateTime.Now;
        }


        public Issue(string title, string description, DateTime createdDate, Developer assignedDeveloper, Resolution issueResolution)
        {
            IssueId = GenerateUniqueIssueId();
            Title = title;
            Description = description;
            CreatedDate = createdDate;
            AssignedDeveloper = assignedDeveloper;
            IssueResolution = issueResolution;
        }

        public static int GenerateUniqueIssueId()
        {
            int issueId = nextIssueId;
            nextIssueId++;
            return issueId;
        }

        public static int GenerateUniqueIssueId(List<Issue> existingIssues)
        {
            if (existingIssues.Count == 0)
            {
                // No existing issues, start with ID 1
                return 1;
            }

            int maxId = existingIssues[0].IssueId;

            foreach (Issue issue in existingIssues)
            {
                if (issue.IssueId > maxId)
                {
                    maxId = issue.IssueId;
                }
            }

            int newIssueId = maxId + 1;
            return newIssueId;
        }

    }
}
