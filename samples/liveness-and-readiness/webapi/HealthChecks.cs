using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace webapi
{
    class MyGenericCheck : IHealthCheck
    {
        private ConcurrentDictionary<string, bool> _statuses;
        private string _statusToCheck;

        public MyGenericCheck(ConcurrentDictionary<string, bool> statuses, string statusToCheck)
        {
            _statuses = statuses;
            _statusToCheck = statusToCheck;
        }

        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            if (!_statuses.TryGetValue(_statusToCheck, out var status))
            {
                return Task.FromResult(new HealthCheckResult(context.Registration.FailureStatus));
            }

            return Task.FromResult(new HealthCheckResult(status ? HealthStatus.Healthy : context.Registration.FailureStatus));
        }
    }
}