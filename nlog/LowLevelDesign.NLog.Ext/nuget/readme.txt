Those extensions allow you to log trace activity id in your NLog target as well as assembly version information. Just add the extension to your NLog configuration:

    <nlog xmlns="http://www.nlog-project.org/schemas/NLog.xsd" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
      <extensions>
        <add prefix="lld" assembly="LowLevelDesign.NLog.Ext" />
      </extensions>
      ...
    </nlog>

and then you can use it when defining a layout for your logging target, eg.:

      <targets>
        <target name="console" xsi:type="ColoredConsole" layout="${longdate}|${lld.asmver:assemblyname=NLog}|${lld.asmver}|${logger}|${uppercase:${level}}|${message}${onexception:|Exception occurred\:${exception:format=tostring}}" />
      </targets>

Detailed description on how to use this package can be found in the following posts:

- http://lowleveldesign.wordpress.com/2012/10/28/to-log-or-nlog/
- http://lowleveldesign.wordpress.com/2012/11/22/nlog-layoutrenderer-for-assembly-version
