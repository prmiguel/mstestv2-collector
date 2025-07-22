namespace MSTestV2.Collector.Console;

public class TestCase
{
    public String Name { get; set; }
    public String Description { get; set; }
    public List<string?> Categories { get; set; }
    public Boolean IsIgnored { get; set; } 
    
    public int Priority { get; set; }
}