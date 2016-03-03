using System.Threading;
using AddinX.Configuration.Contract;
using AddinX.Sample.WcfSample.Controller;
using Autofac;

namespace AddinX.Sample.WcfSample
{
    public class AddinContext
    {
        public static IConfigurationManager ConfigManager { get; set; }

        private static MainController ctrls;

        public static IContainer Container { get; set; }

        public static CancellationTokenSource TokenCancellationSource { get; set; }

        public static MainController MainController => ctrls ?? (ctrls = Container.Resolve<MainController>());
    }
}
