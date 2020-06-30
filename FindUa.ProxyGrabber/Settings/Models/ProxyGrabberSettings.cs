using System.Collections.Generic;

namespace FindUa.ProxyGrabber.Settings.Models
{
    public class ProxyGrabberSettings
    {
        public int DelayBetweenGrabbingInMilliseconds { get; set; }
        public string ProxyFilePath { get; set; }
        public IEnumerable<string> UrlsForCheck { get; set; }
        public int HealthCheckFrequencyInMilliseconds { get; set; }
    }
}
