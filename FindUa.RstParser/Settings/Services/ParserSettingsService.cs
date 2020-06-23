using FindUa.RstParser.Settings.Interfaces;
using FindUa.RstParser.Settings.Models;
using Microsoft.Extensions.Options;

namespace FindUa.RstParser.Settings.Services
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
