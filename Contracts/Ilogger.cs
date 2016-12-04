namespace Contracts
{
    /// <summary>
    /// This is the Log contract between the main application
    /// and it's plugins.
    /// </summary>
    public interface ILogger
    {
        string LogType { get; }

        void Log(string message);
    }
}
