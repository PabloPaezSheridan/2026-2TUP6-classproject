using Polly;
using Polly.Extensions.Http;

namespace Infrastructure.HttpResiliencePolicies;

public static class httpPollyPolices
{
        public static class PollyResiliencePolicies
    {
        public static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy(ApiClientConfigurationDTO config)
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
                .WaitAndRetryAsync(
                    config.RetryCount,
                    retryAttempt => TimeSpan.FromSeconds(config.RetryAttemptInSeconds)
                );
        }

        public static IAsyncPolicy<HttpResponseMessage> GetCircuitBreakerPolicy(ApiClientConfigurationDTO config)
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
                .CircuitBreakerAsync(config.HandledEventsAllowedBeforeBreaking, 
                TimeSpan.FromSeconds(config.DurationOfBreakInSeconds));
        }  
    } 
}