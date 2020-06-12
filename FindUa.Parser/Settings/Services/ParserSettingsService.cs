using FindUa.Parser.Settings.Interfaces;
using FindUa.Parser.Settings.Models;
using Microsoft.Extensions.Options;

namespace FindUa.Parser.Settings.Services
{
    public class ParserSettingsService : IParserSettingsService
    {
        private readonly ParserSettings _parserSettings;

        public ParserSettingsService(IOptionsMonitor<ParserSettings> parserSettings)
        {
            _parserSettings = parserSettings.CurrentValue;
        }

        public int GetDaysCountForProcessing()
        {
            return _parserSettings.ProcessingDepthInDays;
        }

        public int GetDelayBetweenStepsInMilliseconds()
        {
            return _parserSettings.DelayBetweenStepsInMilliseconds;
        }

        public int GetItemsCountForStep()
        {
            return _parserSettings.ItemsCountForStep;
        }
    }
}
