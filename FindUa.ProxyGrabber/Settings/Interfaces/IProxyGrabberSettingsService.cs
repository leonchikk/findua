using System.Collections.Generic;

namespace FindUa.ProxyGrabber.Settings.Interfaces
{
    public interface IProxyGrabberSettingsService
    {
        int GetDelayBetweenGrabbing();
        string GetProxyFilePath();
        IEnumerable<string> GetUrlsForCheck();
        int GetHealthCheckFrequencyInMilliseconds();
        int GetAllowedTimeoutForProxy();
        int GetFailedHealthCheckAttemptCount();
    }
}
