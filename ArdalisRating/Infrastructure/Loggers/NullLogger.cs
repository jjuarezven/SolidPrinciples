using ArdalisRating.Core.Interfaces;

namespace ArdalisRating.Infrastructure.Loggers
{
    public class NullLogger : ILogger
    {
        public void Log(string message)
        {
        }
    }
}
