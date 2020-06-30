using FindUa.ProxyGrabber.Settings.Interfaces;
using FindUa.ProxyGrabber.Settings.Models;
using Microsoft.Extensions.Options;
using System.Collections.Generic;

namespace FindUa.ProxyGrabber.Settings.Services
{
    public class ProxyGrabberSettingsService : IProxyGrabberSettingsService
    {
        private readonly ProxyGrabberSettings _proxyGrabberSettings;

        public ProxyGrabberSettingsService(IOptionsMonitor<ProxyGrabberSettings> parserSettings)
        {
            _proxyGrabberSettings = parserSettings.CurrentValue;
        }

        public int GetDelayBetweenGrabbing()
        {
            return _proxyGrabberSettings.DelayBetweenGrabbingInMilliseconds;
        }

        public int GetHealthCheckFrequencyInMilliseconds()
        {
            return _proxyGrabberSettings.HealthCheckFrequencyInMilliseconds;
        }

        public string GetProxyFilePath()
        {
            return _proxyGrabberSettings.ProxyFilePath;
        }

        public IEnumerable<string> GetUrlsForCheck()
        {
            return _proxyGrabberSettings.UrlsForCheck;
        }
    }
}
