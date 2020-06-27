using FindUa.ProxyGrabber.Settings.Interfaces;
using FindUa.ProxyGrabber.Settings.Models;
using Microsoft.Extensions.Options;
using System;

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

        public string GetProxyFilePath()
        {
            return _proxyGrabberSettings.ProxyFilePath;
        }
    }
}
