using Contracts;

namespace MefPluginsManager
{
    public class Logger
    {
        PluginsHandler _handler;

        public Logger()
        {
            _handler = new PluginsHandler();
            _handler.InializePlugins();
        }

        public void LogMessage(string message)
        {
            foreach (ILogger l in _handler.LoggerList)
            {
                l.Log(message);
            }
        }
    }
}
