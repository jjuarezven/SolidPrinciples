namespace ArdalisRating
{
    /// <summary>
    /// The RatingEngine reads the policy application details from a file and produces a numeric 
    /// rating value based on the details.
    /// </summary>
    public class RatingEngine
    {
        private readonly ILogger _logger;
        private readonly IPolicySource _policySource;
        private readonly IPolicySerializer _policySerializer;
        private readonly RaterFactory _raterFactory;

        //public IRatingContext Context { get; set; }
        public decimal Rating { get; set; }
        // these properties were encapsulated inside the context
        //public ConsoleLogger Logger { get; set; } = new ConsoleLogger();
        //public FilePolicySource PolicySource { get; set; } = new FilePolicySource();
        //public JsonPolicySerializer PolicySerializer { get; set; } = new JsonPolicySerializer();

        public RatingEngine(ILogger logger, IPolicySource policySource, IPolicySerializer policySerializer, RaterFactory raterFactory)
        {
            _logger = logger;
            _policySource = policySource;
            _policySerializer = policySerializer;
            _raterFactory = raterFactory;
            //Context = new DefaultRatingContext(_policySource, _policySerializer)
            //{
            //    Engine = this
            //};
        }

        public void Rate()
        {
            _logger.Log("Starting rate.");

            _logger.Log("Loading policy.");

            string policyString = _policySource.GetPolicyFromSource();

            var policy = _policySerializer.GetPolicyFromString(policyString);

            //var rater = Context.CreateRaterForPolicy(policy, Context);
            var rater = _raterFactory.Create(policy);

            Rating = rater.Rate(policy);

            _logger.Log("Rating completed.");
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
