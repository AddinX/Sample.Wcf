using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Service.Contract;

namespace AddinX.Sample.WcfSample.Controller
{
    public class MainController:IDisposable
    {
        private ISayHelloService service;

        public MainController(ISayHelloService service)
        {
            this.service = service;
        }

        public async void SayHello(string name)
        {   
            var request = new SayHelloRequest {Name = name};

            await Task.Run(() =>
            {
                var response = service.SayHello(request);
                MessageBox.Show(response.HelloMessage);
            }
            ,AddinContext.TokenCancellationSource.Token);
        }

        public void Dispose()
        {
            service = null;
        }
    }
}