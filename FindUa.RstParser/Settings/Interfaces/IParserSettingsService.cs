namespace FindUa.RstParser.Settings.Interfaces
{
    public interface IParserSettingsService
    {
        int GetDelayBetweenStepsInMilliseconds();
        int GetItemsCountForStep();
        int GetDaysCountForProcessing();
    }
}
