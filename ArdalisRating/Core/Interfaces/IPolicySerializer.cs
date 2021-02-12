using ArdalisRating.Core.Models;

namespace ArdalisRating.Core.Interfaces
{
    public interface IPolicySerializer
    {
        Policy GetPolicyFromString(string policyString);
    }
}
