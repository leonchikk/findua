using FindUa.ProxyGrabber.Settings.Interfaces;
using FindUa.ProxyGrabber.Settings.Models;
using Microsoft.Extensions.Options;
using System.Collections.Generic;

namespace FindUa.ProxyGrabber.Settings.Services
{
    public class ProxyGrabberSettingsService : IProxyGrabberSettingsService
    {
        private readonly IOptionsMonitor<ProxyGrabberSettings> _proxyGrabberSettings;

        public ProxyGrabberSettingsService(IOptionsMonitor<ProxyGrabberSettings> parserSettings)
        {
            _proxyGrabberSettings = parserSettings;
        }

        public int GetAllowedTimeoutForProxy()
        {
            return _proxyGrabberSettings.CurrentValue.AllowedTimeout;
        }

        public int GetDelayBetweenGrabbing()
        {
            return _proxyGrabberSettings.CurrentValue.DelayBetweenGrabbingInMilliseconds;
        }

        public int GetFailedHealthCheckAttemptCount()
        {
            return _proxyGrabberSettings.CurrentValue.FailedHealthCheckAttemptCount;
        }

        public int GetHealthCheckFrequencyInMilliseconds()
        {
            return _proxyGrabberSettings.CurrentValue.HealthCheckFrequencyInMilliseconds;
        }

        public string GetProxyFilePath()
        {
            return _proxyGrabberSettings.CurrentValue.ProxyFilePath;
        }

        public IEnumerable<string> GetUrlsForCheck()
        {
            return _proxyGrabberSettings.CurrentValue.UrlsForCheck;
        }
    }
}
