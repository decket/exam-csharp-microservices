namespace SecondService.EventProcessing
{
    public interface IEventProcessor
    {
        void ProcessEvent(string message);
    }
}