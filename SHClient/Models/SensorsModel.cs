namespace SHClient;

public struct SensorsModel
{
    public float Temperature { get; set; }
    public float Humidity { get; set; }
    public float HeatIndex { get; set; }
    public float Light { get; set; }

    public bool IR { get; set; }
    public float SDFree { get; set; }
}