
using System.IO;
using NLog;
using NLog.Config;
using Sentry;
using UnityEngine;

namespace BirchmeierGame.NLogTest
{
    public static class NLogConfiguration
    {
        static NLogConfiguration()
        {
            Initialization();
        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Initialization()
        {

            // Setup NLog
            // enable internal logging to a file
            NLog.Common.InternalLogger.LogLevel = LogLevel.Trace;
            NLog.Common.InternalLogger.LogFile = Application.persistentDataPath + Path.DirectorySeparatorChar + "nlog-internal.log";

            ConfigurationItemFactory
            .Default
            .Targets
            .RegisterDefinition("UnityConsole", typeof(NLogUnityConsoleTarget));
            GlobalDiagnosticsContext.Set("platform", Application.platform.ToString());
            Debug.Log($"Platform is {GlobalDiagnosticsContext.Get("platform")}");
            GlobalDiagnosticsContext.Set("device", SystemInfo.deviceType);
            Debug.Log($"device is {GlobalDiagnosticsContext.Get("device")}");
            var config = new LoggingConfiguration()
                .AddSentry(o =>
                {
                    // Optionally specify a separate format for message
                    o.Layout = "${message}";
                    // Optionally specify a separate format for breadcrumbs
                    o.BreadcrumbLayout = "${longdate}|${level:uppercase=true}|${logger}|${message}";

                    // Debug and higher are stored as breadcrumbs (default is Info)
                    o.MinimumBreadcrumbLevel = LogLevel.Debug;
                    // Error and higher is sent as event (default is Error)
                    o.MinimumEventLevel = LogLevel.Error;

                    // Send the logger name as a tag
                    o.AddTag("logger", "${logger}");
                    o.AddTag("platform", GlobalDiagnosticsContext.Get("platform"));
                    o.AddTag("device", GlobalDiagnosticsContext.Get("device"));
                    o.Dsn = new Dsn("https://db8c7b6b1112404e84a1c43b6309ba8a@o508271.ingest.sentry.io/5600526");
                    o.MinimumBreadcrumbLevel = LogLevel.Debug;
                    o.MinimumEventLevel = LogLevel.Error;
                    // All Sentry Options are accessible here.
                });
            config.AddRule(LogLevel.Debug, LogLevel.Fatal, new NLog.Targets.FileTarget("logfile")
            {
                Name = "file",
                FileName = Application.persistentDataPath + Path.DirectorySeparatorChar + "${shortdate}-nlog-test.log",
                ArchiveNumbering = NLog.Targets.ArchiveNumberingMode.Date,
                ArchiveEvery = NLog.Targets.FileArchivePeriod.Day,
                ArchiveDateFormat = "yyyyMMdd",
                KeepFileOpen = true,
                ConcurrentWrites = false
            });
            config.AddRule(LogLevel.Debug, LogLevel.Fatal, new NLogUnityConsoleTarget());
            LogManager.Configuration = config;
            Debug.Log($"Loggin to {string.Join(", ", LogManager.Configuration.AllTargets)}");

        }
    }
}