using System;
using System.Net;
using System.Threading.Tasks;

namespace FindUa.ProxyGrabber.Domain
{
    public class ExtendedWebClient : WebClient
    {
        public int Timeout { get; set; } = 10000;

        protected override WebRequest GetWebRequest(Uri uri)
        {
            var w = base.GetWebRequest(uri);
            w.Timeout = Timeout; //10 seconds timeout
            return w;
        }

        public new async Task<string> DownloadStringTaskAsync(Uri address)
        {
            var t = base.DownloadStringTaskAsync(address);
            if (await Task.WhenAny(t, Task.Delay(Timeout)) != t)
            {
                CancelAsync();
                throw new WebException("Connection timeout");
            }
            return await t;
        }
    }
}
