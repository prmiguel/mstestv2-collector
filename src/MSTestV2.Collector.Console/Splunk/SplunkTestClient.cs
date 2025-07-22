using System.Diagnostics;
using Splunk.Logging;

namespace MSTestV2.Collector.Console.Splunk;

public class SplunkTestClient
{
    public static TraceSource Initialize()
    {
        TraceSource traceSource = new TraceSource("MyLogger");
        traceSource.Switch.Level = SourceLevels.All;
        traceSource.Listeners.Clear();
        traceSource.Listeners.Add(new 
            TestTraceListener
            (
                uri: new Uri("http://localhost:8088"),
                token: "abcd1234",
                metadata: new HttpEventCollectorEventInfo.Metadata(
                    source: "Test",
                    host: "MSTest",
                    sourceType: "test"
                ),
                batchSizeCount: -1,
                batchInterval: -1
            )
            
        );
        return traceSource;
    }
}