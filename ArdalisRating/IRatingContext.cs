namespace ArdalisRating
{
    public interface IRatingContext : ILogger
    {
        RatingEngine Engine { get; set; }
        string LoadPolicyFromFile();
        string LoadPolicyFromURI(string uri);
        Policy GetPolicyFromJsonString(string policyJson);
        Policy GetPolicyFromXmlString(string policyXml);
        Rater CreateRaterForPolicy(Policy policy, IRatingContext context);
    }
}
