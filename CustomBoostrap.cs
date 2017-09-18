using Nancy;
using Nancy.Configuration;
using Nancy.Diagnostics;

namespace NancyService
{
    public class CustomBoostrap : DefaultNancyBootstrapper
    {
        public override void Configure(INancyEnvironment environment)
        {
            environment.Tracing(enabled: false, displayErrorTraces: true);
            base.Configure(environment);
        } 
    }
}