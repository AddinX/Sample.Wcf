using System;
using System.Threading;
using AddinX.Configuration.Implementation;
using AddinX.Sample.WcfSample.Startup;
using ExcelDna.Integration;

namespace AddinX.Sample.WcfSample
{
    public class Program : IExcelAddIn
    {
        public void AutoOpen()
        {
            AddinContext.ConfigManager = new ConfigurationManagerWrapper();

            // Token cancellation is useful to close all existing Tasks<> before leaving the application
            AddinContext.TokenCancellationSource = new CancellationTokenSource();

            // Start the bootstrapper now
            new Bootstrapper(AddinContext.TokenCancellationSource.Token).Start();
        }

        public void AutoClose()
        {
            throw new NotImplementedException();
        }
    }
}