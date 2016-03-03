using AddinX.Bootstrap.Contract;
using Autofac;

namespace AddinX.Sample.WcfSample.Startup
{
    internal class RunnerInitial : IRunner
    {
        public void Execute(IRunnerMain bootstrap)
        {
            var bootstrapper = (Bootstrapper)bootstrap;
            
            // Ribbon
            bootstrapper?.Builder.RegisterInstance(new AddinRibbon());
        }
    }
}