using AddinX.Bootstrap.Contract;
using Autofac;
using Service.Contract;

namespace AddinX.Sample.WcfSample.Startup
{
    internal class RunnerWcfService : IRunner
    {
        public void Execute(IRunnerMain bootstrap)
        {
            var bootstrapper = (Bootstrapper)bootstrap;

            var serviceUri = AddinContext.ConfigManager.AppSettings["SayHelloServiceUri"];
            bootstrapper.Builder.RegisterWcfService<ISayHelloService>(serviceUri);
        }

    }
}