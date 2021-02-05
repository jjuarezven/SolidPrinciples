namespace ArdalisRating
{
    /// <summary>
    /// The RatingEngine reads the policy application details from a file and produces a numeric 
    /// rating value based on the details.
    /// </summary>
    public class RatingEngine
    {
        public IRatingContext Context { get; set; } = new DefaultRatingContext();
        public decimal Rating { get; set; }
        // these properties were encapsulated inside the context
        //public ConsoleLogger Logger { get; set; } = new ConsoleLogger();
        //public FilePolicySource PolicySource { get; set; } = new FilePolicySource();
        //public JsonPolicySerializer PolicySerializer { get; set; } = new JsonPolicySerializer();

        public RatingEngine()
        {
            Context.Engine = this;
        }

        public void Rate()
        {
            Context.Log("Starting rate.");

            Context.Log("Loading policy.");

            string policyJson = Context.LoadPolicyFromFile();

            var policy = Context.GetPolicyFromJsonString(policyJson);

            var rater = Context.CreateRaterForPolicy(policy, Context);

            rater.Rate(policy);

            Context.Log("Rating completed.");
            #region old code before ISP
            //Logger.Log("Starting rate.");

            //Logger.Log("Loading policy.");

            //// load policy - open file policy.json
            //string policyJson = PolicySource.GetPolicyFromSource();

            //var policy = PolicySerializer.GetPolicyFromJsonString(policyJson);

            //var factory = new RaterFactory();
            //var rater = factory.Create(policy, this);
            //// first step: original behavior printed Unknown policy type when policy type was unknown
            ////rater?.Rate(policy);

            //// second step: this null check breaks LSP 
            ////if (rater == null)
            ////{
            ////    Logger.Log("Unknown policy type");
            ////}
            ////else
            ////{
            ////    rater.Rate(policy);
            ////}

            //// third step: all policies are processed the same way
            //rater.Rate(policy);

            //Logger.Log("Rating completed."); 
            #endregion
        }
    }
}
