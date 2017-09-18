using Nancy;
using Nancy.Configuration;
using Nancy.Diagnostics;

namespace NancyService
{
    public class CustomerBoostrap : DefaultNancyBootstrapper
    {
        public override void Configure(INancyEnvironment environment)
        {
            environment.Tracing(enabled: false, displayErrorTraces: true);
            base.Configure(environment);
        } 
    }
}