using System;
using System.Diagnostics;
using Microsoft.Extensions.Logging;

namespace Polly.Contrib.AzureFunctions.CircuitBreaker
{
    public class TimingLogger : IDisposable
    {
        private string activityName;
        private Stopwatch watch;
        private ILogger logger;

        public TimingLogger(string activityName, ILogger logger)
        {
            this.activityName = (String.IsNullOrWhiteSpace(activityName) ? null : activityName) ?? throw new ArgumentNullException(nameof(activityName));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            watch = Stopwatch.StartNew();
        }

        public void Dispose()
        {
            logger.LogInformation($"{activityName}. Duration (ms): {watch.ElapsedMilliseconds}");
        }
    }
}
