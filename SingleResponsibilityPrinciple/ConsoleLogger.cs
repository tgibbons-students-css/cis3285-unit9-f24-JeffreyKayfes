using System;

using SingleResponsibilityPrinciple.Contracts;

namespace SingleResponsibilityPrinciple
{
    public class ConsoleLogger : ILogger
    {
        public void LogWarning(string message, params object[] args)
        {
            //Console.WriteLine(string.Concat("WARN: ", message), args);
            LogMessage("WARN", message, args);
        }

        public void LogInfo(string message, params object[] args)
        {
            //Console.WriteLine(string.Concat("INFO: ", message), args);
            LogMessage("INFO", message, args);
        }

        private void LogMessage(string type, string message, params object[] args)
        {
            // Log to console
            Console.WriteLine($"{type}: {message}", args);

            // Log to XML file
            using (StreamWriter logfile = File.AppendText("log.xml"))
            {
                string formattedMessage = string.Format(message, args);
                logfile.WriteLine($"<log><type>{type}</type><message>{formattedMessage}</message></log>");
            }
        }
    }
}
