using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAW_PAW_PAW.Classes
{
    public enum ResolutionType
    {
        Fixed,
        Pending,
        InProgress,
        NotApplicable
    }

    public class Resolution
    {
        private static int nextResolutionId = 1;

        public int ResolutionId { get; }
        public ResolutionType Description { get; }

        public Resolution(ResolutionType description)
        {
            ResolutionId = GenerateUniqueResolutionId();
            Description = description;
        }

        private static int GenerateUniqueResolutionId()
        {
            int resolutionId = nextResolutionId;
            nextResolutionId++;
            return resolutionId;
        }
    }



}
