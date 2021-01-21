using NLog;
using NLog.Config;
using NLog.Targets;
using UnityEngine;

namespace BirchmeierGame.NLogTest
{
    [Target("MyFirst")]
    public sealed class NLogUnityConsoleTarget : TargetWithLayout  //or inherit from Target
    {
        public NLogUnityConsoleTarget()
        {
            //set defaults
            this.Host = "localhost";
            this.Name = "Unity";
        }

        [RequiredParameter]
        public string Host { get; set; }

        protected override void Write(LogEventInfo logEvent)
        {
            string logMessage = $"{logEvent.LoggerName}:{logEvent.CallerLineNumber}|{logEvent.Message}";

            if (logEvent.Level == LogLevel.Debug || logEvent.Level == LogLevel.Info || logEvent.Level == LogLevel.Trace)
            {
                Debug.Log(logMessage);
            }
            else if (logEvent.Level == LogLevel.Warn)
            {
                Debug.LogWarning(logMessage);
            }
            else if (logEvent.Level == LogLevel.Error || logEvent.Level == LogLevel.Fatal)
            {
                Debug.LogError(logMessage);
            }
            else
            {
                Debug.Log($"Level not mapped ({logEvent.Level}) : {logMessage}");
            }
        }
    }
}