using System.Threading;
using AddinX.Bootstrap.Autofac;
using ExcelDna.Integration;

namespace AddinX.Sample.WcfSample.Startup
{
    internal class Bootstrapper : AutofacRunnerMain
    {
        public Bootstrapper(CancellationToken token)
                    : base(token)
        {
        }

        public override void Start()
        {
            ExcelAsyncUtil.QueueAsMacro(
                    () => base.Start());
        }

        public override void ExecuteAll()
        {   
            base.ExecuteAll();
            AddinContext.Container = GetContainer();
        }
    }
}