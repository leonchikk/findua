using FindUa.RstParser.Settings.Interfaces;
using FindUa.RstParser.Settings.Models;
using Microsoft.Extensions.Options;

namespace FindUa.RstParser.Settings.Services
{
    public class ParserSettingsService : IParserSettingsService
    {
        private readonly IOptionsMonitor<ParserSettings> _parserSettings;

        public ParserSettingsService(IOptionsMonitor<ParserSettings> parserSettings)
        {
            _parserSettings = parserSettings;
        }

        public int GetDaysCountForProcessing()
        {
            return _parserSettings.CurrentValue.ProcessingDepthInDays;
        }

        public int GetDelayBetweenStepsInMilliseconds()
        {
            return _parserSettings.CurrentValue.DelayBetweenStepsInMilliseconds;
        }

        public int GetItemsCountForStep()
        {
            return _parserSettings.CurrentValue.ItemsCountForStep;
        }
    }
}
