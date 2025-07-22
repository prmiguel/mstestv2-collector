using System.Diagnostics;
using Splunk.Logging;

namespace MSTestV2.Collector.Console.Splunk;

public class TestTraceListener : HttpEventCollectorTraceListener
{
    private HttpEventCollectorSender sender;
    public HttpEventCollectorSender.HttpEventCollectorFormatter formatter;
    
    public TestTraceListener(Uri uri, string token, HttpEventCollectorEventInfo.Metadata metadata = null, HttpEventCollectorSender.SendMode sendMode = HttpEventCollectorSender.SendMode.Sequential, int batchInterval = 10000, int batchSizeBytes = 10240, int batchSizeCount = 10, HttpEventCollectorSender.HttpEventCollectorMiddleware middleware = null, HttpEventCollectorSender.HttpEventCollectorFormatter formatter = null) : base(uri, token, metadata, sendMode, batchInterval, batchSizeBytes, batchSizeCount, middleware, formatter)
    {
        this.formatter = formatter;
        this.sender = new HttpEventCollectorSender(uri, token, metadata, sendMode, batchInterval, batchSizeBytes, batchSizeCount, middleware, formatter);
    }

    public TestTraceListener(Uri uri, string token, int retriesOnError, HttpEventCollectorEventInfo.Metadata metadata = null, HttpEventCollectorSender.SendMode sendMode = HttpEventCollectorSender.SendMode.Sequential, int batchInterval = 10000, int batchSizeBytes = 10240, int batchSizeCount = 10) : base(uri, token, retriesOnError, metadata, sendMode, batchInterval, batchSizeBytes, batchSizeCount)
    {
    }
    
    public override void TraceData(
        TraceEventCache eventCache,
        string source,
        TraceEventType eventType,
        int id,
        params object[] data)
    {
        this.sender.Send(id.ToString(), eventType.ToString(), data: (object) data);
    }
    
    public override void TraceData(
        TraceEventCache? eventCache, 
        string source, 
        TraceEventType eventType, 
        int id, 
        object? data)
    {
        this.sender.Send(id.ToString(), eventType.ToString(), "testmessage123", data: data);
    }
}