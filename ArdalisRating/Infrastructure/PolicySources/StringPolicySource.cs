﻿using ArdalisRating.Core.Interfaces;

namespace ArdalisRating.Infrastructure.PolicySources
{
    public class StringPolicySource : IPolicySource
    {
        public string PolicyString { get; set; } = "";

        public string GetPolicyFromSource()
        {
            return PolicyString;
        }
    }
}
