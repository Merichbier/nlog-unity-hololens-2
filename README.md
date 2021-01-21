# nlog-unity-hololens-2

Sample project to test nlog integration in unity using nuget packages for HoloLens 2

## Nuget

To manage dependencies, we are using [NuGetForUnity](https://github.com/GlitchEnzo/NuGetForUnity).

## NLog

[NLog](https://www.nuget.org/packages/NLog) dependency is installed using NuGetForUnity

NLog is configurate at runtime. The entry point from unity to setup the configuration can be found in [NLogConfiguration](Assets/Scripts/NLogConfiguration.cs) file.
We are using a [custom target](https://github.com/NLog/NLog/wiki/How-to-write-a-custom-target) ([NLogUnityConsoleTarget](Assets/Scripts/NLogUnityConsoleTarget.cs)) to log to unity console in editor.

## Sentry

We with to integrate an Application Monitoring and Error Tracking Software. We have chosen [Sentry.io](https://sentry.io/about/).
Currently we are using the nuget package [Sentry.NLog](https://www.nuget.org/packages/Sentry.NLog).

Current state :

- Working in editor
- Failing on device

Exception thrown on device :

```
An error occurred when capturing the event System.NotSupportedException: System.Web.HttpContext::get_Current
  at System.Web.HttpContext.get_Current () [0x00000] in <00000000000000000000000000000000>:0
  at Sentry.Internal.Web.SystemWebRequestEventProcessor.Process (Sentry.SentryEvent event) [0x00000] in <00000000000000000000000000000000>:0
  at Sentry.SentryClient.DoSendEvent (Sentry.SentryEvent event, Sentry.Scope scope) [0x00000] in <00000000000000000000000000000000>:0
  at Sentry.SentryClient.CaptureEvent (Sentry.SentryEvent event, Sentry.Scope scope) [0x00000] in <00000000000000000000000000000000>:0
  at Sentry.Internal.Hub.CaptureEvent (Sentry.SentryEvent evt, Sentry.Scope scope) [0x00000] in <00000000000000000000000000000000>:0
  at Sentry.Extensibility.HubAdapter.CaptureEvent (Sentry.SentryEvent evt, Sentry.Scope scope) [0x00000] in <00000000000000000000000000000000>:0
  at Sentry.NLog.SentryTarget.Write (NLog.LogEventInfo logEvent) [0x00000] in <00000000000000000000000000000000>:0
  at NLog.Targets.Target.Write (NLog.Common.AsyncLogEventInfo logEvent) [0x00000] in <00000000000000000000000000000000>:0
  at NLog.Targets.Target.WriteAsyncThreadSafe (NLog.Common.AsyncLogEventInfo logEvent) [0x00000] in <00000000000000000000000000000000>:0
  at NLog.Targets.Target.WriteAsyncLogEvent (NLog.Common.AsyncLogEventInfo logEvent) [0x00000] in <00000000000000000000000000000000>:0
  at NLog.LoggerImpl.WriteToTargetWithFilterChain (NLog.Targets.Target target, NLog.Filters.FilterResult result, NLog.LogEventInfo logEvent, NLog.Common.AsyncContinuation onException) [0x00000] in <00000000000000000000000000000000>:0
  at NLog.LoggerImpl.Write (System.Type loggerType, NLog.Internal.TargetWithFilterChain targetsForLevel, NLog.LogEventInfo logEvent, NLog.LogFactory factory) [0x00000] in <00000000000000000000000000000000>:0
  at NLog.Logger.WriteToTargets (NLog.LogLevel level, System.IFormatProvider formatProvider, System.String message) [0x00000] in <00000000000000000000000000000000>:0
  at NLog.Logger.Error (System.String message) [0x00000] in <00000000000000000000000000000000>:0
  at BirchmeierGame.NLogTest.NlogTest.OnErrorClicked () [0x00000] in <00000000000000000000000000000000>:0
  at UnityEngine.RemoteSettings+UpdatedEventHandler.Invoke () [0x00000] in <00000000000000000000000000000000>:0
  at UnityEngine.Events.UnityEvent.Invoke () [0x00000] in <00000000000000000000000000000000>:0
  at Microsoft.MixedReality.Toolkit.UI.Interactable.SendOnClick (Microsoft.MixedReality.Toolkit.Input.IMixedRealityPointer pointer) [0x00000] in <00000000000000000000000000000000>:0
  at Microsoft.MixedReality.Toolkit.UI.Interactable.TriggerOnClick () [0x00000] in <00000000000000000000000000000000>:0
  at Microsoft.MixedReality.Toolkit.PhysicalPressEventRouter.OnHandPressTriggered () [0x00000] in <00000000000000000000000000000000>:0
  at UnityEngine.RemoteSettings+UpdatedEventHandler.Invoke () [0x00000] in <00000000000000000000000000000000>:0
  at UnityEngine.Events.UnityEvent.Invoke () [0x00000] in <00000000000000000000000000000000>:0
  at Microsoft.MixedReality.Toolkit.UI.PressableButton.UpdateTouch () [0x00000] in <00000000000000000000000000000000>:0
  at Microsoft.MixedReality.Toolkit.UI.PressableButton.Update () [0x00000] in <00000000000000000000000000000000>:0 .
```
